using Common.Logging;
using Coupa.PunchoutModule.Web.Controllers;
using Coupa.PunchoutModule.Web.Managers;
using Coupa.PunchoutModule.Web.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using VirtoCommerce.CartModule.Data.Migrations;
using VirtoCommerce.CartModule.Data.Repositories;
using cartModel = VirtoCommerce.Domain.Cart.Model;
using VirtoCommerce.Domain.Cart.Services;
using VirtoCommerce.Domain.Catalog.Services;
using VirtoCommerce.Domain.Customer.Services;
using VirtoCommerce.Domain.Order.Services;
using VirtoCommerce.Domain.Store.Services;
using VirtoCommerce.Platform.Core.Settings;
using VirtoCommerce.Platform.Data.Infrastructure;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;
using VirtoCommerce.Platform.Tests.Bases;
using Xunit;
using System.Net.Http;
using System.Web.Http;
using orderMessage = Coupa.PunchoutModule.Web.Model.OrderMessage;
using orderResponse = Coupa.PunchoutModule.Web.Model.OrderResponse;
using purchaseOrder = Coupa.PunchoutModule.Web.Model.PurchaseOrder;
using request = Coupa.PunchoutModule.Web.Model.SetupRequest;
using response = Coupa.PunchoutModule.Web.Model.SetupResponse;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using customerModel = VirtoCommerce.Domain.Customer.Model;
using VirtoCommerce.Platform.Core.DynamicProperties;
using Moq;

namespace Punchout.IntegrationModule.Web.Tests
{
    public class PunchoutControllerScenarios: FunctionalTestBase
    {       
        [Fact]
        public async void Create_Punchout_Setup()
        {
            var coupaPunchoutController = GetPunchoutController();

            coupaPunchoutController.Request = new HttpRequestMessage();
            coupaPunchoutController.Configuration = new HttpConfiguration();
            var serializedSetupRequest = Serialize(GenerateSetupRequest());
            coupaPunchoutController.Request.Content = new StringContent(serializedSetupRequest);
            var response = await coupaPunchoutController.PunchoutSetup();
        }
        
        private CoupaPunchoutController GetPunchoutController()
        {
            var punchoutService = new PunchoutServiceImpl();
            punchoutService.RegisterPunchoutGateway(GetCoupaPunchoutGateway());

            return new CoupaPunchoutController(punchoutService);
        }

        private Func<CoupaPunchoutGateway> GetCoupaPunchoutGateway()
        {
            var settings = new Mock<ISettingsManager>();
            settings.Setup(s => s.GetModuleSettings("Coupa")).Returns(new List<SettingEntry>().ToArray());
            var cartService = new Mock<IShoppingCartService>();
            var orderService = new Mock<ICustomerOrderService>();
            var storeService = new Mock<IStoreService>();
            var catalogService = new Mock<ICatalogSearchService>();

            var customerSearchService = new Moq.Mock<ICustomerSearchService>();
            var contacts = new List<customerModel.Contact>();
            var contact = new customerModel.Contact();
            contact.DynamicProperties = new[] { new DynamicObjectProperty { Name = "SharedSecret", Values = new[] { new DynamicPropertyObjectValue { Value = "test" } } } };
            contact.FirstName = "John";
            contact.LastName = "Doe";
            contact.FullName = "John Doe";
            contacts.Add(contact);
            var result = new customerModel.SearchResult { Contacts = contacts, TotalCount = 1 };
            customerSearchService.Setup(c => c.Search(Moq.It.IsAny<customerModel.SearchCriteria>())).Returns(result);

            var logger = new Mock<ILog>();

            Func<CoupaPunchoutGateway> coupaPunchoutGatewayFactory = () => new CoupaPunchoutGateway("Coupa", cartService.Object, orderService.Object, storeService.Object, catalogService.Object, customerSearchService.Object, logger.Object)
            {
                Description = "Coupa punchout gateway integration",
                LogoUrl = "https://www.coupa.com/success/templates/coupa_succes_tpl/images/coupa.png",
                Settings = settings.Object.GetModuleSettings("Coupa"),
                IsActive = false
            };

            return coupaPunchoutGatewayFactory;
        }

        private cartModel.ShoppingCart GetShoppingCart()
        {
            var cart = new cartModel.ShoppingCart();
            return cart;
        }

        protected ICartRepository GetRepository()
        {
            var repository = new CartRepositoryImpl(ConnectionString, new EntityPrimaryKeyGeneratorInterceptor(), new AuditableInterceptor(null));
            EnsureDatabaseInitialized(() => new CartRepositoryImpl(ConnectionString), () => Database.SetInitializer(new SetupDatabaseInitializer<CartRepositoryImpl, Configuration>()));
            return repository;
        }

        public override void Dispose()
        {
            try
            {
                // Ensure LocalDb databases are deleted after use so that LocalDb doesn't throw if
                // the temp location in which they are stored is later cleaned.
                using (var context = new CartRepositoryImpl(ConnectionString))
                {
                    context.Database.Delete();
                }
            }
            finally
            {
            }
        }

        public request.cXML GenerateSetupRequest()
        {
            var request = new request.cXML();

            request.lang = "en-US";
            request.payloadID = "123456789";
            request.timestamp = DateTime.UtcNow;

            request.Request = new request.cXMLRequest();
            request.Request.PunchOutSetupRequest = new request.cXMLRequestPunchOutSetupRequest();
            request.Request.PunchOutSetupRequest.BuyerCookie = "c64af92dc27e68172e030d3dfd1bc944";
            request.Request.PunchOutSetupRequest.Contact = new request.cXMLRequestPunchOutSetupRequestContact();
            request.Request.PunchOutSetupRequest.Contact.Email = "test@test.com";
            request.Request.PunchOutSetupRequest.Contact.Name = new request.cXMLRequestPunchOutSetupRequestContactName { lang = "en-US", Value = "John Doe" };
            request.Request.PunchOutSetupRequest.Contact.role = "endUser";
            request.Request.PunchOutSetupRequest.operation = "create";
            request.Request.PunchOutSetupRequest.BrowserFormPost = new request.cXMLRequestPunchOutSetupRequestBrowserFormPost { URL = "https://qa.coupahost.com/punchout/checkout/4" };

            var extrinsicList = new List<request.cXMLRequestPunchOutSetupRequestExtrinsic>();

            var firstName = new request.cXMLRequestPunchOutSetupRequestExtrinsic { name = "FirstName", Value = "John" };
            var lastName = new request.cXMLRequestPunchOutSetupRequestExtrinsic { name = "LastName", Value = "Doe" };
            var uniqueName = new request.cXMLRequestPunchOutSetupRequestExtrinsic { name = "UniqueName", Value = "johnDoe" };
            var email = new request.cXMLRequestPunchOutSetupRequestExtrinsic { name = "UserEmail", Value = "test@test.com" };
            var user = new request.cXMLRequestPunchOutSetupRequestExtrinsic { name = "User", Value = "john" };
            var bussinessUnit = new request.cXMLRequestPunchOutSetupRequestExtrinsic { name = "BussinessUnit", Value = "COUPA" };

            extrinsicList.AddRange(new[] { firstName, lastName, uniqueName, email, user, bussinessUnit });

            request.Request.PunchOutSetupRequest.Extrinsic = extrinsicList.ToArray();

            request.Header = new request.cXMLHeader();
            request.Header.From = new request.cXMLHeaderFrom();
            request.Header.From.Credential = new request.cXMLHeaderFromCredential { domain = "DUNS", Identity = "coupa-t" };

            request.Header.To = new request.cXMLHeaderTO();
            request.Header.To.Credential = new request.cXMLHeaderTOCredential { domain = "DUNS", Identity = "coupa-t" };

            request.Header.Sender = new request.cXMLHeaderSender();
            request.Header.Sender.Credential = new request.cXMLHeaderSenderCredential { domain = "DUNS", Identity = "coupa-t", SharedSecret = "test" };
            request.Header.Sender.UserAgent = "Coupa Procurement 1.0";

            return request;
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

    }
}
