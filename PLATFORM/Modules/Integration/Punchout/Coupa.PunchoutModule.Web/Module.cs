using Coupa.PunchoutModule.Web.Managers;
using Microsoft.Practices.Unity;
using System;
using VirtoCommerce.Domain.Cart.Services;
using VirtoCommerce.Domain.Catalog.Services;
using VirtoCommerce.Domain.Customer.Services;
using VirtoCommerce.Domain.Order.Services;
using VirtoCommerce.Domain.Punchout.Model;
using VirtoCommerce.Domain.Punchout.Services;
using VirtoCommerce.Domain.Quote.Services;
using VirtoCommerce.Domain.Store.Services;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Core.Settings;

namespace Coupa.PunchoutModule.Web
{
    public class Module : ModuleBase
    {
        private readonly IUnityContainer _container;

        public Module(IUnityContainer container)
        {
            _container = container;
        }
        public override void Initialize()
        {
            #region Punchout service
            var punchoutService = new PunchoutServiceImpl();
            _container.RegisterInstance<IPunchoutService>(punchoutService);
            #endregion
        }

        public override void PostInitialize()
        {
            var settings = _container.Resolve<ISettingsManager>().GetModuleSettings("Coupa");
            var quoteService = _container.Resolve<IQuoteRequestService>();
            var orderService = _container.Resolve<ICustomerOrderService>();
            var storeService = _container.Resolve<IStoreService>();
            var catalogService = _container.Resolve<ICatalogSearchService>();
            var customerSearchService = _container.Resolve<ICustomerSearchService>();

            Func<CoupaPunchoutGateway> coupaPunchoutGatewayFactory = () => new CoupaPunchoutGateway("Coupa", quoteService, orderService, storeService, catalogService, customerSearchService)
            {
                Description = "Coupa punchout gateway integration",
                LogoUrl = "https://www.coupa.com/success/templates/coupa_succes_tpl/images/coupa.png",
                Settings = settings,
                IsActive = false
            };

            _container.Resolve<IPunchoutService>().RegisterPunchoutGateway(coupaPunchoutGatewayFactory);
        }
    }
}