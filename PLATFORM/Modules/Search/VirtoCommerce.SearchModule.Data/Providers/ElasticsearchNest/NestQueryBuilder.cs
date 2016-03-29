using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Search.Model;
using VirtoCommerce.Domain.Search.Services;

namespace VirtoCommerce.SearchModule.Data.Providers.ElasticsearchNest
{
    public class NestQueryBuilder : ISearchQueryBuilder
    {
        public object BuildQuery(ISearchCriteria criteria)
        {
            var query = new Nest.QueryDescriptor<NestDocument>();
            return query;
        }
    }
}
