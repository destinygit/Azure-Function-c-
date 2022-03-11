using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class SupplierStaging
    {
        public int SupplierStagingKey { get; set; }
        public int WwiSupplierId { get; set; }
        public string Supplier { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string PrimaryContact { get; set; } = null!;
        public string? SupplierReference { get; set; }
        public int PaymentDays { get; set; }
        public string PostalCode { get; set; } = null!;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
