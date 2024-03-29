﻿using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class Purchase
    {
        public long PurchaseKey { get; set; }
        public DateTime DateKey { get; set; }
        public int SupplierKey { get; set; }
        public int StockItemKey { get; set; }
        public int? WwiPurchaseOrderId { get; set; }
        public int OrderedOuters { get; set; }
        public int OrderedQuantity { get; set; }
        public int ReceivedOuters { get; set; }
        public string Package { get; set; } = null!;
        public bool IsOrderFinalized { get; set; }
        public int LineageKey { get; set; }

        public virtual Date DateKeyNavigation { get; set; } = null!;
        public virtual StockItem StockItemKeyNavigation { get; set; } = null!;
        public virtual Supplier SupplierKeyNavigation { get; set; } = null!;
    }
}
