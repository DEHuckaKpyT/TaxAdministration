using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxAdministration.model
{
    class V_Declarations
    {
        public int id { get; set; }
        public string number { get; set; }
        public DateTime create_date { get; set; }
        public double sum_all { get; set; }
        public double sum_tax { get; set; }
        public string inn { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
    }
}
