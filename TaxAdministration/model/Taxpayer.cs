using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxAdministration.model
{
    class Taxpayer
    {
        public int id { get; set; }
        public string inn { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public DateTime born { get; set; }
        public string document { get; set; }
        public string document_serial { get; set; }
        public string document_number { get; set; }
        public DateTime document_date { get; set; }
        public string document_region { get; set; }
        public int organization_id { get; set; }
        public int street_id { get; set; }
        public int building_number { get; set; }
        public int? district_id { get; set; }
        public string tax_district { get; set; }
        public string tax_number { get; set; }
    }
}
