using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class City
    {
        public City()
        {
            Orders = new HashSet<Order>();
            Sales = new HashSet<Sale>();
        }

        public int CityKey { get; set; }
        public int WwiCityId { get; set; }
        public string City1 { get; set; } = null!;
        public string StateProvince { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Continent { get; set; } = null!;
        public string SalesTerritory { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string Subregion { get; set; } = null!;
        public long LatestRecordedPopulation { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int LineageKey { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
