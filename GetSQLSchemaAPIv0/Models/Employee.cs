using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class Employee
    {
        public Employee()
        {
            OrderPickerKeyNavigations = new HashSet<Order>();
            OrderSalespersonKeyNavigations = new HashSet<Order>();
            Sales = new HashSet<Sale>();
        }

        public int EmployeeKey { get; set; }
        public int WwiEmployeeId { get; set; }
        public string Employee1 { get; set; } = null!;
        public string PreferredName { get; set; } = null!;
        public bool IsSalesperson { get; set; }
        public byte[]? Photo { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int LineageKey { get; set; }

        public virtual ICollection<Order> OrderPickerKeyNavigations { get; set; }
        public virtual ICollection<Order> OrderSalespersonKeyNavigations { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
