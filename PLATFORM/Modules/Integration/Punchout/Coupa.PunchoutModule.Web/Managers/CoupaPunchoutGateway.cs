using System;
using System.Xml.Serialization;
using VirtoCommerce.Domain.Punchout.Model;
using System.Text;
using System.IO;
using Microsoft.Practices.ObjectBuilder2;
using System.Collections.Generic;
using Coupa.PunchoutModule.Web.Converters;
using VirtoCommerce.Domain.Order.Services;
using request = Coupa.PunchoutModule.Web.Model.SetupRequest;
using response = Coupa.PunchoutModule.Web.Model.SetupResponse;
using orderMessage = Coupa.PunchoutModule.Web.Model.OrderMessage;
using orderResponse = Coupa.PunchoutModule.Web.Model.OrderResponse;
using purchaseOrder = Coupa.PunchoutModule.Web.Model.PurchaseOrder;
using VirtoCommerce.Domain.Store.Services;
using System.Linq;
using VirtoCommerce.Domain.Catalog.Services;
using VirtoCommerce.Domain.Quote.Services;
using VirtoCommerce.Domain.Customer.Services;
using VirtoCommerce.Domain.Quote.Model;
using VirtoCommerce.Domain.Customer.Model;

namespace Coupa.PunchoutModule.Web.Managers
{
    public class CoupaPunchoutGateway: PunchoutGateway
    {
        private const string okResponseText = "OK";
        private const string sharedSecretPropertyName = "SharedSecret";

        private readonly IQuoteRequestService _quoteService;
        private readonly ICustomerOrderService _orderService;
        private readonly IStoreService _storeService;
        private readonly ICatalogSearchService _catalogSearchService;
        private readonly ICustomerSearchService _customerSearchService;

        public CoupaPunchoutGateway(string name, 
            IQuoteRequestService quoteService, 
            ICustomerOrderService orderService, 
            IStoreService storeService, 
            ICatalogSearchService catalogService, 
            ICustomerSearchService customerSearchService) :
            base(name)
        {
            _quoteService = quoteService;
            _orderService = orderService;
            _storeService = storeService;
            _catalogSearchService = catalogService;
            _customerSearchService = customerSearchService;
        }


        public override string PunchoutSetup(string request)
        {
            if (string.IsNullOrEmpty(request))
                throw new ArgumentNullException("request");

            string response = null;
            request.cXML requestObject;


            var deserializer = new XmlSerializer(typeof(request.cXML));
            var inBuffer = Encoding.UTF8.GetBytes(request);
            using (var stream = new MemoryStream(inBuffer))
            {
                requestObject = (request.cXML) deserializer.Deserialize(stream);
            }

            if (requestObject != null)
            {
                var contact = CheckSharedSecret(requestObject);

                if (contact != null)
                {
                    var responseObject = GenerateStartPageResponse(requestObject, contact);

                    if (responseObject != null)
                    {
                        using (MemoryStream stream = new MemoryStream())
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            XmlSerializer xml = new XmlSerializer(typeof(response.cXML));
                            xml.Serialize(writer, responseObject);

                            response = Encoding.UTF8.GetString(stream.ToArray());
                        }
                    }
                }
                else
                {
                    var responseObject = GenerateResponse(400, "Request rejected", "Could not find customer with the provided shared secret key");
                }
            }

            return response;
        }

        public override string PunchoutOrderMessage(string quoteId)
        {
            string response = null;

            var quote = _quoteService.GetByIds(quoteId).FirstOrDefault();

            if (quote != null)
            {
                var orderMessageObject = GenerateOrderMessage(quote);

                if (orderMessageObject != null)
                {
                    using (MemoryStream stream = new MemoryStream())
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(orderMessage.cXML));
                        xml.Serialize(writer, orderMessageObject);

                        response = Encoding.UTF8.GetString(stream.ToArray());
                    }
                }
            }

            return response;
        }

        public override string CreateOrder(string customerOrderRequest)
        {
            string response = null;

            purchaseOrder.cXML requestObject;

            var deserializer = new XmlSerializer(typeof(purchaseOrder.cXML));
            var inBuffer = Encoding.UTF8.GetBytes(customerOrderRequest);
            using (var stream = new MemoryStream(inBuffer))
            {
                requestObject = (purchaseOrder.cXML)deserializer.Deserialize(stream);
            }

            if (requestObject != null)
            {
                //TODO get store by provided data in request (quote id?)
                var store = _storeService.SearchStores(new VirtoCommerce.Domain.Store.Model.SearchCriteria()).Stores.FirstOrDefault();
                if (store != null)
                {
                    var catalogId = _catalogSearchService.Search(new VirtoCommerce.Domain.Catalog.Model.SearchCriteria { ResponseGroup = VirtoCommerce.Domain.Catalog.Model.SearchResponseGroup.WithCatalogs }).Catalogs.FirstOrDefault(x => store.Catalog.Equals(x.Id))?.Id;

                    var order = requestObject.ToCoreModel(store.Id, catalogId);

                    var resultOrder = _orderService.Create(order);

                    if (resultOrder != null)
                    {
                        var responseObject = GenerateResponse(200, okResponseText);

                        if (responseObject != null)
                        {
                            using (MemoryStream stream = new MemoryStream())
                            using (StreamWriter writer = new StreamWriter(stream))
                            {
                                XmlSerializer xml = new XmlSerializer(typeof(orderResponse.cXML));
                                xml.Serialize(writer, responseObject);

                                response = Encoding.UTF8.GetString(stream.ToArray());
                            }
                        }
                    }
                    else
                    {
                        var responseObject = GenerateResponse(400, "Order Rejected", "Could not create order from the provided order data");

                        if (responseObject != null)
                        {
                            using (MemoryStream stream = new MemoryStream())
                            using (StreamWriter writer = new StreamWriter(stream))
                            {
                                XmlSerializer xml = new XmlSerializer(typeof(orderMessage.cXML));
                                xml.Serialize(writer, responseObject);

                                response = Encoding.UTF8.GetString(stream.ToArray());
                            }
                        }
                    }
                }
            }

            return response;
        }

        private orderResponse.cXML GenerateResponse(uint code, string text, string errorMessage = null)
        {
            var orderResponse = new orderResponse.cXML();

            orderResponse.lang = "en-US";
            orderResponse.payloadID = "200303450803006749@b2b.euro.com";
            orderResponse.timestamp = DateTime.UtcNow;

            var requestResponse = new orderResponse.cXMLResponse();

            var status = new orderResponse.cXMLResponseStatus { text = text, code = code };
            if (!string.IsNullOrEmpty(errorMessage))
                status.Value = errorMessage;
            requestResponse.Status = status;
            orderResponse.Response = requestResponse;

            return orderResponse;
        }

        private response.cXML GenerateStartPageResponse(request.cXML request, Contact customer)
        {
            var responseObject = new response.cXML();

            responseObject.version = "1.1.007";
            responseObject.timestamp = DateTime.UtcNow;
            responseObject.payloadID = "200303450803006749@b2b.euro.com";
            responseObject.lang = "en-US";

            var requestResponse = new response.cXMLResponse();

            var status = new response.cXMLResponseStatus { text = okResponseText, code = 200 };
            requestResponse.Status = status;

            var setupResponse = new response.cXMLResponsePunchOutSetupResponse();
            var startPage = new response.cXMLResponsePunchOutSetupResponseStartPage { URL = GetPunchoutUrl() };
            setupResponse.StartPage = startPage;

            requestResponse.PunchOutSetupResponse = setupResponse;

            responseObject.Response = requestResponse;

            return responseObject;
        }

        private orderMessage.cXML GenerateOrderMessage(QuoteRequest quote)
        {
            var orderMessage = new orderMessage.cXML();

            orderMessage.version = "1.2.0.14";
            orderMessage.lang = "en=US";
            orderMessage.timestamp = DateTime.UtcNow;
            orderMessage.payloadID = "200303450803006749@b2b.euro.com";

            #region Header

            var fromCredential = new orderMessage.cXMLHeaderFromCredential { domain = "NetworkId" };

            var headerFrom = new orderMessage.cXMLHeaderFrom { Credential = fromCredential };

            var senderCredential = new orderMessage.cXMLHeaderSenderCredential { domain = "NetworkId" };
            var headerSender = new orderMessage.cXMLHeaderSender { Credential = senderCredential };

            var toCredential = new orderMessage.cXMLHeaderTOCredential { domain = "NetworkId", Identity = "test@test.com" };
            var headerTo = new orderMessage.cXMLHeaderTO { Credential = toCredential };

            var header = new orderMessage.cXMLHeader { To = headerTo, From = headerFrom, Sender = headerSender };            
            orderMessage.Header = header;

            #endregion

            #region Message header

            var punchoutMoney = new orderMessage.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTotalMoney { currency = quote.Currency, Value = quote.Totals.GrandTotalInclTax };
            var punchoutTotal = new orderMessage.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTotal { Money = punchoutMoney };

            var shippingMoney = new orderMessage.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShippingMoney { currency = quote.Currency, Value = quote.Totals.ShippingTotal };
            var shippingDescription = new orderMessage.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShippingDescription { lang = "en-US", Value = "Unknown" };
            var shippingOrderMessageHeader = new orderMessage.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShipping { Money = shippingMoney, Description = shippingDescription };

            var taxMoney = new orderMessage.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTaxMoney { currency = quote.Currency, Value = quote.Totals.TaxTotal };
            var taxDescription = new orderMessage.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTaxDescription { lang = "en-US", Value = "Unknown" };
            var taxOrderMessageHeader = new orderMessage.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTax { Money = taxMoney, Description = taxDescription };


            var punchoutOrderMessageHeader = new orderMessage.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeader {
                Total = punchoutTotal,
                operationAllowed = "edit",
                Shipping = shippingOrderMessageHeader,
                Tax = taxOrderMessageHeader
            };

            #endregion

            #region Message items

            var items = new List<orderMessage.cXMLMessagePunchOutOrderMessageItemIn>();

            quote.Items.ForEach(item =>
            {
                var itemId = new orderMessage.cXMLMessagePunchOutOrderMessageItemInItemID { SupplierPartID = item.Sku };

                var description = new orderMessage.cXMLMessagePunchOutOrderMessageItemInItemDetailDescription { lang = "en-US", Value = item.Name };

                var unitPriceMoney = new orderMessage.cXMLMessagePunchOutOrderMessageItemInItemDetailUnitPriceMoney { currency = quote.Currency, Value = item.SelectedTierPrice.Price };
                var unitPrice = new orderMessage.cXMLMessagePunchOutOrderMessageItemInItemDetailUnitPrice { Money = unitPriceMoney };

                var itemDetail = new orderMessage.cXMLMessagePunchOutOrderMessageItemInItemDetail { UnitPrice = unitPrice, Description = description, LeadTime = 0 };

                var itemIn = new orderMessage.cXMLMessagePunchOutOrderMessageItemIn { ItemID = itemId, quantity = (byte) item.SelectedTierPrice.Quantity, ItemDetail = itemDetail };
                items.Add(itemIn);
            });

            

            #endregion

            var punchoutOrderMessage = new orderMessage.cXMLMessagePunchOutOrderMessage { PunchOutOrderMessageHeader = punchoutOrderMessageHeader, BuyerCookie = GenerateBuyerCookie(), ItemIn = items.ToArray()  };

            var message = new orderMessage.cXMLMessage { PunchOutOrderMessage = punchoutOrderMessage };
            
            orderMessage.Message = message;

            return orderMessage;
        }

        private string GenerateBuyerCookie()
        {
            string cookie = null;

            //TODO generate cookie
            cookie = "f5d75ddbc9e75b6346b36ee5c28c5e8b";
            return cookie;
        }

        private string GetPunchoutUrl()
        {
            string retVal = null;

            //TODO get punchout url
            retVal = "http://demo.virtocommerce.com";

            return retVal;
        }

        private Contact CheckSharedSecret(request.cXML request)
        {
            var searchResult = _customerSearchService.Search(new SearchCriteria { Keyword = request.Header.From.Credential.Identity });

            if (searchResult != null && searchResult.Contacts != null && searchResult.Contacts.Any())
            {
                //search for the contact with the matching shared secret
                var contact = searchResult.Contacts.FirstOrDefault(c => {
                    var property = c.DynamicProperties.FirstOrDefault(x => x.Name.Equals(sharedSecretPropertyName));
                    if (property != null && property.Values.Any(pv => pv.Value.Equals(request.Header.Sender.Credential.SharedSecret)))
                    {
                        return true;
                    }
                    return false;
                });

                return contact;
            }

            //contact with the identity not found
            return null;
        }
    }
}