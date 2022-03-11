using System;
using System.Collections.Generic;

namespace GetSQLSchemaAPI.Models
{
    public partial class EtlCutoff
    {
        public string TableName { get; set; } = null!;
        public DateTime CutoffTime { get; set; }
    }
}
