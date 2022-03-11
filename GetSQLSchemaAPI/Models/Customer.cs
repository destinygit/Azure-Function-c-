using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Movements = new HashSet<Movement>();
            Orders = new HashSet<Order>();
            SaleBillToCustomerKeyNavigations = new HashSet<Sale>();
            SaleCustomerKeyNavigations = new HashSet<Sale>();
            TransactionBillToCustomerKeyNavigations = new HashSet<Transaction>();
            TransactionCustomerKeyNavigations = new HashSet<Transaction>();
        }

        public int CustomerKey { get; set; }
        public int WwiCustomerId { get; set; }
        public string Customer1 { get; set; } = null!;
        public string BillToCustomer { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string BuyingGroup { get; set; } = null!;
        public string PrimaryContact { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int LineageKey { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Sale> SaleBillToCustomerKeyNavigations { get; set; }
        public virtual ICollection<Sale> SaleCustomerKeyNavigations { get; set; }
        public virtual ICollection<Transaction> TransactionBillToCustomerKeyNavigations { get; set; }
        public virtual ICollection<Transaction> TransactionCustomerKeyNavigations { get; set; }
    }
}
