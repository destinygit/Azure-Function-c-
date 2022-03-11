using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class TransactionTypeStaging
    {
        public int TransactionTypeStagingKey { get; set; }
        public int WwiTransactionTypeId { get; set; }
        public string TransactionType { get; set; } = null!;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
