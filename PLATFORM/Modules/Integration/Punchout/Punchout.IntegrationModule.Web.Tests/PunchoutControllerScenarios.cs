using System.Data.Entity;
using VirtoCommerce.CartModule.Data.Migrations;
using VirtoCommerce.CartModule.Data.Repositories;
using VirtoCommerce.Domain.Cart.Model;
using VirtoCommerce.Platform.Data.Infrastructure;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;
using VirtoCommerce.Platform.Tests.Bases;
using Xunit;

namespace Punchout.IntegrationModule.Web.Tests
{
    public class PunchoutControllerScenarios: FunctionalTestBase
    {
        [Fact]
        public void Create_Punchout_Setup()
        {
            
        }

        private ShoppingCart GetShoppingCart()
        {
            var cart = new ShoppingCart();
            return cart;
        }

        //protected ICartRepository GetRepository()
        //{
        //    var repository = new CartRepositoryImpl(ConnectionString, new EntityPrimaryKeyGeneratorInterceptor(), new AuditableInterceptor(null));
        //    EnsureDatabaseInitialized(() => new CartRepositoryImpl(ConnectionString), () => Database.SetInitializer(new SetupDatabaseInitializer<CartRepositoryImpl, Configuration>()));
        //    return repository;
        //}

        //public override void Dispose()
        //{
        //    try
        //    {
        //        // Ensure LocalDb databases are deleted after use so that LocalDb doesn't throw if
        //        // the temp location in which they are stored is later cleaned.
        //        using (var context = new CartRepositoryImpl(ConnectionString))
        //        {
        //            context.Database.Delete();
        //        }
        //    }
        //    finally
        //    {
        //    }
        //}
    }
}
