using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxAdministration.model
{
    class V_Log
    {
        public int id { get; set; }
        public string login { get; set; }
        public DateTime datetime { get; set; }
        public string description { get; set; }

        public V_Log(int id, string login, DateTime datetime, string description)
        {
            this.id = id;
            this.login = login;
            this.datetime = datetime;
            this.description = description;
        }
    }
}
