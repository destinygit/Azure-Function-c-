using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class StockHolding
    {
        public long StockHoldingKey { get; set; }
        public int StockItemKey { get; set; }
        public int QuantityOnHand { get; set; }
        public string BinLocation { get; set; } = null!;
        public int LastStocktakeQuantity { get; set; }
        public decimal LastCostPrice { get; set; }
        public int ReorderLevel { get; set; }
        public int TargetStockLevel { get; set; }
        public int LineageKey { get; set; }

        public virtual StockItem StockItemKeyNavigation { get; set; } = null!;
    }
}
