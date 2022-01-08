using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxAdministration.model
{
    class V_Taxpayers
    {
        public int id { get; set; }
        public string inn { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public DateTime born { get; set; }
        public string name { get; set; }
        public string org_inn { get; set; }
    }
}
