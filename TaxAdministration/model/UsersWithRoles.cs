using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxAdministration.model
{
    class UsersWithRoles
    {
        public string login { get; set; }
        public string name { get; set; }
        public bool access_log { get; set;}
        public bool access_users { get; set; }
        public bool access_change_infirmation { get; set; }
    }
}
