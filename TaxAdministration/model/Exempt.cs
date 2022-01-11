using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxAdministration.model
{
    class Exempt
    {
        public int id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return $"{name}";
        }
    }
}
