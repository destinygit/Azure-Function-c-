using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class CityStaging
    {
        public int CityStagingKey { get; set; }
        public int WwiCityId { get; set; }
        public string City { get; set; } = null!;
        public string StateProvince { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Continent { get; set; } = null!;
        public string SalesTerritory { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string Subregion { get; set; } = null!;
        public long LatestRecordedPopulation { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
