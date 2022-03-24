using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class Date
    {
        public Date()
        {
            Movements = new HashSet<Movement>();
            OrderOrderDateKeyNavigations = new HashSet<Order>();
            OrderPickedDateKeyNavigations = new HashSet<Order>();
            Purchases = new HashSet<Purchase>();
            SaleDeliveryDateKeyNavigations = new HashSet<Sale>();
            SaleInvoiceDateKeyNavigations = new HashSet<Sale>();
            Transactions = new HashSet<Transaction>();
        }

        public DateTime Date1 { get; set; }
        public int DayNumber { get; set; }
        public string Day { get; set; } = null!;
        public string Month { get; set; } = null!;
        public string ShortMonth { get; set; } = null!;
        public int CalendarMonthNumber { get; set; }
        public string CalendarMonthLabel { get; set; } = null!;
        public int CalendarYear { get; set; }
        public string CalendarYearLabel { get; set; } = null!;
        public int FiscalMonthNumber { get; set; }
        public string FiscalMonthLabel { get; set; } = null!;
        public int FiscalYear { get; set; }
        public string FiscalYearLabel { get; set; } = null!;
        public int IsoWeekNumber { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }
        public virtual ICollection<Order> OrderOrderDateKeyNavigations { get; set; }
        public virtual ICollection<Order> OrderPickedDateKeyNavigations { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Sale> SaleDeliveryDateKeyNavigations { get; set; }
        public virtual ICollection<Sale> SaleInvoiceDateKeyNavigations { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
