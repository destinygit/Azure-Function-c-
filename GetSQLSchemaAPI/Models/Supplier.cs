using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Movements = new HashSet<Movement>();
            Purchases = new HashSet<Purchase>();
            Transactions = new HashSet<Transaction>();
        }

        public int SupplierKey { get; set; }
        public int WwiSupplierId { get; set; }
        public string Supplier1 { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string PrimaryContact { get; set; } = null!;
        public string? SupplierReference { get; set; }
        public int PaymentDays { get; set; }
        public string PostalCode { get; set; } = null!;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int LineageKey { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
