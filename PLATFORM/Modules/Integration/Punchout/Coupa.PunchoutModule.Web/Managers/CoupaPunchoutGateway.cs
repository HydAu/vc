using request = Coupa.PunchoutModule.Web.Model.SetupRequest;
using response = Coupa.PunchoutModule.Web.Model.SetupResponse;
using order = Coupa.PunchoutModule.Web.Model.OrderMessage;
using System;
using System.Xml.Serialization;
using VirtoCommerce.Domain.Punchout.Model;
using System.Text;
using System.IO;
using VirtoCommerce.Domain.Cart.Services;
using VirtoCommerce.Domain.Cart.Model;
using Microsoft.Practices.ObjectBuilder2;
using System.Collections.Generic;

namespace Coupa.PunchoutModule.Web.Managers
{
    public class CoupaPunchoutGateway: PunchoutGateway
    {
        private readonly IShoppingCartService _cartService;

        public CoupaPunchoutGateway(string name, IShoppingCartService cartService) :
            base(name)
        {
            _cartService = cartService;
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
                var responseObject = GenerateResponse(requestObject);

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

            return response;
        }
        public override string PunchoutOrder(string cartId)
        {
            string response = null;

            var cart = _cartService.GetById(cartId);

            if (cart != null)
            {
                var orderMessageObject = GenerateOrderMessage(cart);

                if (orderMessageObject != null)
                {
                    using (MemoryStream stream = new MemoryStream())
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(order.cXML));
                        xml.Serialize(writer, orderMessageObject);

                        response = Encoding.UTF8.GetString(stream.ToArray());
                    }
                }
            }

            return response;
        }

        private response.cXML GenerateResponse(request.cXML request)
        {
            var responseObject = new response.cXML();

            responseObject.version = "1.1.007";
            responseObject.timestamp = DateTime.UtcNow;
            responseObject.payloadID = "200303450803006749@b2b.euro.com";
            responseObject.lang = "en-US";

            var requestResponse = new response.cXMLResponse();

            var status = new response.cXMLResponseStatus { text = "OK", code = 200 };
            requestResponse.Status = status;

            var setupResponse = new response.cXMLResponsePunchOutSetupResponse();
            var startPage = new response.cXMLResponsePunchOutSetupResponseStartPage { URL = "https://mygreatpunchoutsite.com/punchoutLogin.asp" };
            setupResponse.StartPage = startPage;

            requestResponse.PunchOutSetupResponse = setupResponse;

            responseObject.Response = requestResponse;

            return responseObject;
        }

        private order.cXML GenerateOrderMessage(ShoppingCart cart)
        {
            var orderMessage = new order.cXML();

            orderMessage.version = "1.2.0.14";
            orderMessage.lang = "en=US";
            orderMessage.timestamp = DateTime.UtcNow;
            orderMessage.payloadID = "200303450803006749@b2b.euro.com";

            #region Header

            var fromCredential = new order.cXMLHeaderFromCredential { domain = "NetworkId" };

            var headerFrom = new order.cXMLHeaderFrom { Credential = fromCredential };

            var senderCredential = new order.cXMLHeaderSenderCredential { domain = "NetworkId" };
            var headerSender = new order.cXMLHeaderSender { Credential = senderCredential };

            var toCredential = new order.cXMLHeaderTOCredential { domain = "NetworkId", Identity = "test@test.com" };
            var headerTo = new order.cXMLHeaderTO { Credential = toCredential };

            var header = new order.cXMLHeader { To = headerTo, From = headerFrom, Sender = headerSender };            
            orderMessage.Header = header;

            #endregion

            #region Message header

            var punchoutMoney = new order.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTotalMoney { currency = cart.Currency, Value = cart.Total };
            var punchoutTotal = new order.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTotal { Money = punchoutMoney };

            var shippingMoney = new order.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShippingMoney { currency = cart.Currency, Value = cart.ShippingTotal };
            var shippingDescription = new order.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShippingDescription { lang = "en-US", Value = "Unknown" };
            var shippingOrderMessageHeader = new order.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShipping { Money = shippingMoney, Description = shippingDescription };

            var taxMoney = new order.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTaxMoney { currency = cart.Currency, Value = cart.TaxTotal };
            var taxDescription = new order.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTaxDescription { lang = "en-US", Value = "Unknown" };
            var taxOrderMessageHeader = new order.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTax { Money = taxMoney, Description = taxDescription };


            var punchoutOrderMessageHeader = new order.cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeader {
                Total = punchoutTotal,
                operationAllowed = "edit",
                Shipping = shippingOrderMessageHeader,
                Tax = taxOrderMessageHeader
            };

            #endregion

            #region Message items

            var items = new List<order.cXMLMessagePunchOutOrderMessageItemIn>();

            cart.Items.ForEach(item =>
            {
                var itemId = new order.cXMLMessagePunchOutOrderMessageItemInItemID { SupplierPartID = item.Sku };

                var description = new order.cXMLMessagePunchOutOrderMessageItemInItemDetailDescription { lang = "en-US", Value = item.Name };

                var unitPriceMoney = new order.cXMLMessagePunchOutOrderMessageItemInItemDetailUnitPriceMoney { currency = cart.Currency, Value = item.PlacedPrice };
                var unitPrice = new order.cXMLMessagePunchOutOrderMessageItemInItemDetailUnitPrice { Money = unitPriceMoney };

                var itemDetail = new order.cXMLMessagePunchOutOrderMessageItemInItemDetail { UnitPrice = unitPrice, Description = description, LeadTime = 0 };

                var itemIn = new order.cXMLMessagePunchOutOrderMessageItemIn { ItemID = itemId, quantity = (byte) item.Quantity, ItemDetail = itemDetail };
                items.Add(itemIn);
            });

            

            #endregion

            var punchoutOrderMessage = new order.cXMLMessagePunchOutOrderMessage { PunchOutOrderMessageHeader = punchoutOrderMessageHeader, BuyerCookie = "f5d75ddbc9e75b6346b36ee5c28c5e8b", ItemIn = items.ToArray()  };

            var message = new order.cXMLMessage { PunchOutOrderMessage = punchoutOrderMessage };
            
            orderMessage.Message = message;

            return orderMessage;
        }        
    }
}