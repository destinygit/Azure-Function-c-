using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class EmployeeStaging
    {
        public int EmployeeStagingKey { get; set; }
        public int WwiEmployeeId { get; set; }
        public string Employee { get; set; } = null!;
        public string PreferredName { get; set; } = null!;
        public bool IsSalesperson { get; set; }
        public byte[]? Photo { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
