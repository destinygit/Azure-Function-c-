using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class PaymentMethodStaging
    {
        public int PaymentMethodStagingKey { get; set; }
        public int WwiPaymentMethodId { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
