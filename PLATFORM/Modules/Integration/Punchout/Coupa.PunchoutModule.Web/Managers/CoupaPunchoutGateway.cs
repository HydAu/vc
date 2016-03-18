using Common.Logging;
using Coupa.PunchoutModule.Web.Converters;
using Coupa.PunchoutModule.Web.Model;
using Microsoft.Practices.ObjectBuilder2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using VirtoCommerce.Domain.Cart.Model;
using VirtoCommerce.Domain.Cart.Services;
using VirtoCommerce.Domain.Catalog.Services;
using customerModel = VirtoCommerce.Domain.Customer.Model;
using VirtoCommerce.Domain.Customer.Services;
using VirtoCommerce.Domain.Order.Services;
using storeModel = VirtoCommerce.Domain.Store.Model;
using VirtoCommerce.Domain.Store.Services;
using orderMessage = Coupa.PunchoutModule.Web.Model.OrderMessage;
using orderResponse = Coupa.PunchoutModule.Web.Model.OrderResponse;
using purchaseOrder = Coupa.PunchoutModule.Web.Model.PurchaseOrder;
using request = Coupa.PunchoutModule.Web.Model.SetupRequest;
using response = Coupa.PunchoutModule.Web.Model.SetupResponse;

namespace Coupa.PunchoutModule.Web.Managers
{
    public class CoupaPunchoutGateway: PunchoutGateway
    {
        private const string okResponseText = "OK";
        private const string sharedSecretPropertyName = "SharedSecret";

        private readonly IShoppingCartService _cartService;
        private readonly ICustomerOrderService _orderService;
        private readonly IStoreService _storeService;
        private readonly ICatalogSearchService _catalogSearchService;
        private readonly ICustomerSearchService _customerSearchService;
        private readonly ILog _logger;

        public CoupaPunchoutGateway(string name,
            IShoppingCartService cartService, 
            ICustomerOrderService orderService, 
            IStoreService storeService, 
            ICatalogSearchService catalogService, 
            ICustomerSearchService customerSearchService,
            ILog logger) :
            base(name)
        {
            _cartService = cartService;
            _orderService = orderService;
            _storeService = storeService;
            _catalogSearchService = catalogService;
            _customerSearchService = customerSearchService;
            _logger = logger;
        }


        public override string PunchoutSetup(string request)
        {
            if (string.IsNullOrEmpty(request))
            {
                var argumentNullException = new ArgumentNullException("request");
                _logger.Error("Coupa", argumentNullException);
                throw argumentNullException;
            }

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
                _logger.InfoFormat("Timestamp: {0}, From: {1}, payloadId: {2}", requestObject.timestamp, requestObject.Header.From.Credential.Identity, requestObject.payloadID);

                var contact = GetCustomer(requestObject);

                if (contact != null)
                {
                    var responseObject = GenerateStartPageResponse(requestObject, contact);

                    _logger.InfoFormat("Timestamp: {0}, Url: {1}, payloadId: {2}", responseObject.timestamp, responseObject.Response.PunchOutSetupResponse.StartPage.URL, responseObject.payloadID);

                    if (responseObject != null)
                    {
                        response = Serialize(responseObject);
                    }
                }
                else
                {
                    _logger.Error("Coupa: could not deserialized request");
                    var responseObject = GenerateResponse(400, "Request rejected", requestObject.payloadID, requestObject.lang, "Could not find customer with the provided shared secret key");

                    if (responseObject != null)
                    {
                        response = Serialize(responseObject);
                    }
                }
            }
            else
            {
                _logger.ErrorFormat("Coupa: could not deserialize request: {0}", request);
            }

            return response;
        }

        public override string PunchoutOrderMessage(string cartId)
        {
            string response = null;

            var cart = _cartService.GetById(cartId);

            if (cart != null)
            {
                var orderMessageObject = GenerateOrderMessage(cart);

                _logger.InfoFormat("Timestamp: {0}, Cart number: {1}, payloadId: {2}", orderMessageObject.timestamp, cart.Id, orderMessageObject.payloadID);

                if (orderMessageObject != null)
                {
                    response = Serialize(orderMessageObject);
                }
            }
            else
            {
                _logger.ErrorFormat("Cart not found: {0}", cartId);
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
                //TODO get store by provided data in request (cart id?)
                var store = _storeService.SearchStores(new VirtoCommerce.Domain.Store.Model.SearchCriteria()).Stores.FirstOrDefault();
                if (store != null)
                {
                    var catalogId = _catalogSearchService.Search(new VirtoCommerce.Domain.Catalog.Model.SearchCriteria { ResponseGroup = VirtoCommerce.Domain.Catalog.Model.SearchResponseGroup.WithCatalogs }).Catalogs.FirstOrDefault(x => store.Catalog.Equals(x.Id))?.Id;

                    var order = requestObject.ToCoreModel(store.Id, catalogId);

                    var resultOrder = _orderService.Create(order);

                    if (resultOrder != null)
                    {
                        var responseObject = GenerateResponse(200, okResponseText, requestObject.payloadID, requestObject.lang);

                        if (responseObject != null)
                        {
                            response = Serialize(responseObject);
                        }
                    }
                    else
                    {
                        var responseObject = GenerateResponse(400, "Order Rejected", requestObject.payloadID, requestObject.lang, "Could not create order from the provided order data");

                        if (responseObject != null)
                        {
                            response = Serialize(responseObject);
                        }
                    }
                }
            }
            else
            {
                _logger.ErrorFormat("Coupa: could not deserialize request: {0}", customerOrderRequest);
            }

            return response;
        }

        private string Serialize(object toSerialize)
        {
            using (MemoryStream stream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(stream))
            {
                XmlSerializer xml = new XmlSerializer(toSerialize.GetType());
                xml.Serialize(writer, toSerialize);

                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        /// <summary>
        /// Generate response to the request
        /// </summary>
        /// <param name="code">Response code</param>
        /// <param name="text">Response text. Example: "OK"</param>
        /// <param name="payloadId">Payload id</param>
        /// <param name="locale">Language code. Example: "en-US"</param>
        /// <param name="errorMessage">Error description text for error response</param>
        /// <returns></returns>
        private orderResponse.cXML GenerateResponse(uint code, string text, string payloadId, string locale, string errorMessage = null)
        {
            var orderResponse = new orderResponse.cXML();

            orderResponse.lang = locale;
            orderResponse.payloadID = payloadId;
            orderResponse.timestamp = DateTime.UtcNow;

            var requestResponse = new orderResponse.cXMLResponse();

            var status = new orderResponse.cXMLResponseStatus { text = text, code = code };
            if (!string.IsNullOrEmpty(errorMessage))
                status.Value = errorMessage;
            requestResponse.Status = status;
            orderResponse.Response = requestResponse;

            return orderResponse;
        }

        /// <summary>
        /// generates response with start page URL
        /// </summary>
        /// <param name="request"></param>
        /// <param name="contact"></param>
        /// <returns></returns>
        private response.cXML GenerateStartPageResponse(request.cXML request, customerModel.Contact contact)
        {
            var punchoutStore = GetPunchoutStore(contact);

            var responseObject = new response.cXML();

            //version static?
            responseObject.version = "1.1.007";
            responseObject.timestamp = DateTime.UtcNow;
            
            responseObject.payloadID = request.payloadID;

            //TODO set language dynamically
            responseObject.lang = punchoutStore.DefaultLanguage;

            var requestResponse = new response.cXMLResponse();

            var status = new response.cXMLResponseStatus { text = okResponseText, code = 200 };
            requestResponse.Status = status;

            var setupResponse = new response.cXMLResponsePunchOutSetupResponse();
            var startPage = new response.cXMLResponsePunchOutSetupResponseStartPage { URL = punchoutStore.Url };
            setupResponse.StartPage = startPage;

            requestResponse.PunchOutSetupResponse = setupResponse;
            responseObject.Response = requestResponse;

            return responseObject;
        }

        private orderMessage.cXML GenerateOrderMessage(ShoppingCart cart)
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

            var punchoutMoney = new orderMessage.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTotalMoney { currency = cart.Currency, Value = cart.Total };
            var punchoutTotal = new orderMessage.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTotal { Money = punchoutMoney };

            var shippingMoney = new orderMessage.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShippingMoney { currency = cart.Currency, Value = cart.ShippingTotal };
            var shippingDescription = new orderMessage.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShippingDescription { lang = "en-US", Value = "Unknown" };
            var shippingOrderMessageHeader = new orderMessage.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShipping { Money = shippingMoney, Description = shippingDescription };

            var taxMoney = new orderMessage.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTaxMoney { currency = cart.Currency, Value = cart.TaxTotal };
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

            cart.Items.ForEach(item =>
            {
                var itemId = new orderMessage.cXMLMessagePunchOutOrderMessageItemInItemID { SupplierPartID = item.Sku };

                var description = new orderMessage.cXMLMessagePunchOutOrderMessageItemInItemDetailDescription { lang = "en-US", Value = item.Name };

                var unitPriceMoney = new orderMessage.cXMLMessagePunchOutOrderMessageItemInItemDetailUnitPriceMoney { currency = cart.Currency, Value = item.PlacedPrice };
                var unitPrice = new orderMessage.cXMLMessagePunchOutOrderMessageItemInItemDetailUnitPrice { Money = unitPriceMoney };

                var itemDetail = new orderMessage.cXMLMessagePunchOutOrderMessageItemInItemDetail { UnitPrice = unitPrice, Description = description, LeadTime = 0 };

                var itemIn = new orderMessage.cXMLMessagePunchOutOrderMessageItemIn { ItemID = itemId, quantity = (byte)item.Quantity, ItemDetail = itemDetail };
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

        private storeModel.Store GetPunchoutStore(customerModel.Contact contact)
        {
            storeModel.Store retVal = null;

            //var storeIds = _storeService.GetUserAllowedStoreIds(new VirtoCommerce.Platform.Core.Security.ApplicationUserExtended { MemberId = contact.Id });

            retVal = _storeService.SearchStores(new storeModel.SearchCriteria()).Stores.Where(s => s.StoreState == storeModel.StoreState.Open).FirstOrDefault();
            
            return retVal;
        }

        private customerModel.Contact GetCustomer(request.cXML request)
        {
            var searchResult = _customerSearchService.Search(new customerModel.SearchCriteria { Keyword = request.Header.From.Credential.Identity });

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