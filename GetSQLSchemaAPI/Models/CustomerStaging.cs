using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class CustomerStaging
    {
        public int CustomerStagingKey { get; set; }
        public int WwiCustomerId { get; set; }
        public string Customer { get; set; } = null!;
        public string BillToCustomer { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string BuyingGroup { get; set; } = null!;
        public string PrimaryContact { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
