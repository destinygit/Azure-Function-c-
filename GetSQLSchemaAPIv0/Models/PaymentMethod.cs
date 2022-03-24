using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int PaymentMethodKey { get; set; }
        public int WwiPaymentMethodId { get; set; }
        public string PaymentMethod1 { get; set; } = null!;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int LineageKey { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
