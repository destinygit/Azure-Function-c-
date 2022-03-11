using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class StockItem
    {
        public StockItem()
        {
            Movements = new HashSet<Movement>();
            Orders = new HashSet<Order>();
            Purchases = new HashSet<Purchase>();
            Sales = new HashSet<Sale>();
            StockHoldings = new HashSet<StockHolding>();
        }

        public int StockItemKey { get; set; }
        public int WwiStockItemId { get; set; }
        public string StockItem1 { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string SellingPackage { get; set; } = null!;
        public string BuyingPackage { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Size { get; set; } = null!;
        public int LeadTimeDays { get; set; }
        public int QuantityPerOuter { get; set; }
        public bool IsChillerStock { get; set; }
        public string? Barcode { get; set; }
        public decimal TaxRate { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? RecommendedRetailPrice { get; set; }
        public decimal TypicalWeightPerUnit { get; set; }
        public byte[]? Photo { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int LineageKey { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<StockHolding> StockHoldings { get; set; }
    }
}
