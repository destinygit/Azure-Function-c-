using GetSQLSchemaAPI.Models;
using GetSQLSchemaAPI.Services;
using GetSQLSchemaAPI.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetSQLSchemaAPI.Helpers
{
   

    public static class PaginationHelperscs
    {
        public static PagedResponse<List<T>> CreatePagedReponse<T>(List<T> pagedData, Pagination filter, int totalRecords, IUriService uriService, string route)
        {
            var respose = new PagedResponse<List<T>>(pagedData, filter.pageNumber, filter.pageSize);
            var totalPages = ((double)totalRecords / (double)filter.pageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            respose.NextPage =
                filter.pageNumber >= 1 && filter.pageNumber < roundedTotalPages
                ? uriService.GetPageUri(new Pagination(filter.pageNumber + 1, filter.pageSize), route)
                : null;
            respose.PreviousPage =
                filter.pageNumber - 1 >= 1 && filter.pageNumber <= roundedTotalPages
                ? uriService.GetPageUri(new Pagination(filter.pageNumber - 1, filter.pageSize), route)
                : null;
            respose.FirstPage = uriService.GetPageUri(new Pagination(1, filter.pageSize), route);
            respose.LastPage = uriService.GetPageUri(new Pagination(roundedTotalPages, filter.pageSize), route);
            respose.TotalPages = roundedTotalPages;
            respose.TotalRecords = totalRecords;
            return respose;
        }
    }
}
