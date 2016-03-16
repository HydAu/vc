using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;
using VirtoCommerce.Domain.Search.Model;
using VirtoCommerce.Domain.Search.Services;
using IDocument = VirtoCommerce.Domain.Search.Model.IDocument;

namespace VirtoCommerce.SearchModule.Data.Providers.ElasticsearchNest
{
    public class NestProvider : ISearchProvider
    {
        public NestProvider(ISearchQueryBuilder queryBuilder)
        {
            QueryBuilder = queryBuilder;
        }

        public ISearchQueryBuilder QueryBuilder { get; private set; }

        public void Close(string scope, string documentType)
        {
            throw new NotImplementedException();
        }

        public void Commit(string scope)
        {
            throw new NotImplementedException();
        }

        public void Index(string scope, string documentType, IDocument document)
        {
            throw new NotImplementedException();
        }

        public int Remove(string scope, string documentType, string key, string value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll(string scope, string documentType)
        {
            throw new NotImplementedException();
        }

        public ISearchResults Search(string scope, ISearchCriteria criteria)
        {
            var client = new ElasticClient();
            var query = QueryBuilder.BuildQuery(criteria);
            var response = client.Search<NestDocument>(s => s.Index(scope).Type(criteria.DocumentType).QueryRaw(query.ToString()));

            // Parse documents returned
            var docList = new List<IDocument>();
            foreach (var indexDoc in response.Documents)
            {
                var document = new ResultDocument();
                foreach (var field in indexDoc.Keys)
                    document.Add(new DocumentField(field, indexDoc[field]));
                docList.Add(document);
            }

            var documents = new ResultDocumentSet
            {
                TotalCount = (int)response.Total,
                Documents = docList.ToArray()
            };

            // Create search results object
            var results = new SearchResults(criteria, new[] { documents })
            {
                FacetGroups = CreateFacets(criteria, response)
            };

            return results;
        }


        private static FacetGroup[] CreateFacets(ISearchCriteria criteria, ISearchResponse<NestDocument> response)
        {
            return null;
        }
    }
}
