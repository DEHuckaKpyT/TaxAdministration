using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxAdministration
{
    class Organization
    {
        public int id { get; set; }
        public string name { get; set; }
        public string inn { get; set; }
        public int? street_id { get; set; }
        public int? building_number { get; set; }
        public string phone_number { get; set; }
        public string description { get; set; }
        public string accountant_firstname { get; set; }
        public string accountant_middlename { get; set; }
        public string accountant_lastname { get; set; }
    }
}
