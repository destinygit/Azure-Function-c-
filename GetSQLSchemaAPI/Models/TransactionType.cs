using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            Movements = new HashSet<Movement>();
            Transactions = new HashSet<Transaction>();
        }

        public int TransactionTypeKey { get; set; }
        public int WwiTransactionTypeId { get; set; }
        public string TransactionType1 { get; set; } = null!;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int LineageKey { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
