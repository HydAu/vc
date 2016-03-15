using Common.Logging;
using Coupa.PunchoutModule.Web.Managers;
using Coupa.PunchoutModule.Web.Services;
using Microsoft.Practices.Unity;
using System;
using VirtoCommerce.Domain.Cart.Services;
using VirtoCommerce.Domain.Catalog.Services;
using VirtoCommerce.Domain.Customer.Services;
using VirtoCommerce.Domain.Order.Services;
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
            var cartService = _container.Resolve<IShoppingCartService>();
            var orderService = _container.Resolve<ICustomerOrderService>();
            var storeService = _container.Resolve<IStoreService>();
            var catalogService = _container.Resolve<ICatalogSearchService>();
            var customerSearchService = _container.Resolve<ICustomerSearchService>();
            var logger = _container.Resolve<ILog>();

            Func<CoupaPunchoutGateway> coupaPunchoutGatewayFactory = () => new CoupaPunchoutGateway("Coupa", cartService, orderService, storeService, catalogService, customerSearchService, logger)
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