using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxAdministration.model
{
    class Street
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sign { get; set; }
        public bool sequence { get; set; }

        public override string ToString()
        {
            return sequence ? $"{sign} {name}" : $"{name} {sign}";
        }
    }
}
