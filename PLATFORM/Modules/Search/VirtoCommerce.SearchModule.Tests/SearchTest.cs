using VirtoCommerce.CatalogModule.Data.Repositories;
using VirtoCommerce.CatalogModule.Data.Services;
using VirtoCommerce.CoreModule.Data.Repositories;
using VirtoCommerce.Domain.Catalog.Services;
using VirtoCommerce.Domain.Commerce.Services;
using VirtoCommerce.Domain.Pricing.Services;
using VirtoCommerce.Domain.Search.Model;
using VirtoCommerce.Domain.Search.Services;
using VirtoCommerce.Platform.Core.ChangeLog;
using VirtoCommerce.Platform.Data.ChangeLog;
using VirtoCommerce.Platform.Data.Common;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;
using VirtoCommerce.Platform.Data.Repositories;
using VirtoCommerce.PricingModule.Data.Repositories;
using VirtoCommerce.PricingModule.Data.Services;
using VirtoCommerce.SearchModule.Data.Model;
using VirtoCommerce.SearchModule.Data.Providers.Azure;
using VirtoCommerce.SearchModule.Data.Providers.ElasticsearchNest;
using VirtoCommerce.SearchModule.Data.Providers.ElasticSearch;
using VirtoCommerce.SearchModule.Data.Providers.Lucene;
using VirtoCommerce.SearchModule.Data.Services;
using Xunit;

namespace VirtoCommerce.SearchModule.Tests
{
    public class SearchTest
    {
        [Theory]
        [InlineData("provider=Elasticsearch;server=localhost:9200;scope=default")]
        [InlineData("provider=Nest;server=localhost:9200;scope=default")]
        public void TestElasticsearchProvider(string searchConnectionString)
        {
            var connection = GetSearchConnection(searchConnectionString);
            var provider = GetSearchProvider(connection);

            var criteria = new CatalogIndexedSearchCriteria
            {
                RecordsToRetrieve = 2,
            };

            var results = provider.Search(connection.Scope, criteria);
            Assert.True(results.TotalCount > 0);
            Assert.Equal(2, results.DocCount);
        }

        private ISearchConnection GetSearchConnection(string connectionString)
        {
            return new SearchConnection(connectionString);
        }
        private ISearchProvider GetSearchProvider(ISearchConnection searchConnection)
        {
            var searchProviderManager = new SearchProviderManager(searchConnection);
            searchProviderManager.RegisterSearchProvider(SearchProviders.Nest.ToString(), connection => new NestProvider(new NestQueryBuilder(), connection));
            searchProviderManager.RegisterSearchProvider(SearchProviders.Elasticsearch.ToString(), connection => new ElasticSearchProvider(new ElasticSearchQueryBuilder(), connection));
            searchProviderManager.RegisterSearchProvider(SearchProviders.Lucene.ToString(), connection => new LuceneSearchProvider(new LuceneSearchQueryBuilder(), connection));
            searchProviderManager.RegisterSearchProvider(SearchProviders.AzureSearch.ToString(), connection => new AzureSearchProvider(new AzureSearchQueryBuilder(), connection));
            return searchProviderManager;
        }

        public void SearchCatalogBuilderTest()
        {
            var controller = GetSearchIndexController();
            controller.Process("default", CatalogIndexedSearchCriteria.DocType, true);
        }


        private SearchIndexController GetSearchIndexController()
        {


            return null;
        }


        private ICommerceService GetCommerceService()
        {
            return new CommerceServiceImpl(GetCommerceRepository);
        }

        private ICatalogSearchService GetSearchService()
        {
            return new CatalogSearchServiceImpl(GetCatalogRepository, GetItemService(), GetCatalogService(), GetCategoryService());
        }

        private IPricingService GetPricingService()
        {
            return new PricingServiceImpl(GetPricingRepository, null, null, null);
        }

        private IPropertyService GetPropertyService()
        {
            return new PropertyServiceImpl(GetCatalogRepository);
        }

        private ICategoryService GetCategoryService()
        {
            return new CategoryServiceImpl(GetCatalogRepository, GetCommerceService());
        }

        private ICatalogService GetCatalogService()
        {
            return new CatalogServiceImpl(GetCatalogRepository, GetCommerceService());
        }

        private IItemService GetItemService()
        {
            return new ItemServiceImpl(GetCatalogRepository, GetCommerceService());
        }

        private IChangeLogService GetChangeLogService()
        {
            return new ChangeLogService(GetPlatformRepository);
        }


        private IPlatformRepository GetPlatformRepository()
        {
            var result = new PlatformRepository("VirtoCommerce", new EntityPrimaryKeyGeneratorInterceptor(), new AuditableInterceptor(null));
            return result;
        }

        private IPricingRepository GetPricingRepository()
        {
            var result = new PricingRepositoryImpl("VirtoCommerce", new EntityPrimaryKeyGeneratorInterceptor(), new AuditableInterceptor(null));
            return result;
        }

        private ICatalogRepository GetCatalogRepository()
        {
            var result = new CatalogRepositoryImpl("VirtoCommerce", new EntityPrimaryKeyGeneratorInterceptor(), new AuditableInterceptor(null));
            return result;
        }

        private static IСommerceRepository GetCommerceRepository()
        {
            var result = new CommerceRepositoryImpl("VirtoCommerce", new EntityPrimaryKeyGeneratorInterceptor(), new AuditableInterceptor(null));
            return result;
        }
    }
}
