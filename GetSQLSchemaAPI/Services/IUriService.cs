using GetSQLSchemaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetSQLSchemaAPI.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(Pagination filter, string route);
    }

    
}
