using GetSQLSchemaAPI.Models;
using Microsoft.AspNetCore.WebUtilities;

namespace GetSQLSchemaAPI.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        public Uri GetPageUri(Pagination filter, string route)
        {
            var _enpointUri = new Uri(string.Concat(_baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "pageNumber", filter.pageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.pageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}
