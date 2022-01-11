using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxAdministration.model
{
    class Log
    {
        public int id { get; set; }
        public DateTime datetime { get; set; }
        public string description { get; set; }
        public int? user_id { get; set; }

        public override string ToString()
        {
            if (user_id == null)
                return $"{"Неизвестно",-20} {datetime.ToString("hh:mm dd/MM/yyyy"),-20} {description}";
            else
            {
                User user = Repository.Get<User>($"select * from [user] where id = {user_id}")[0];
                return $"{user.login,-20} {datetime.ToString("hh:mm dd/MM/yyyy"),-20} {description}";
            }
        }
    }
}
