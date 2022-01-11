using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxAdministration.model
{
    class Declaration
    {
        public int id { get; set; }
        public string number { get; set; }
        public DateTime create_date { get; set; }
        public double sum_all { get; set; }
        public double? sum_tax { get; set; }
        public double? sum_pension { get; set; }
        public int? exempt_id { get; set; }
        public double? exempt_sum { get; set; }
        public int? taxpayer_id { get; set; }
        public bool? accepted { get; set; }
    }
}
