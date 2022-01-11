using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaxAdministration.model;

namespace TaxAdministration.form
{
    public partial class FormLog : Form
    {
        public FormLog()
        {
            InitializeComponent();
        }

        private void FormLog_Load(object sender, EventArgs e)
        {
            List<Log> logs = Repository.Get<Log>($"select * from log");

            List<V_Log> v_logs = new List<V_Log>();
            foreach(Log log in logs)
            {
                User user = Repository.Get<User>($"select * from [user] where id = {log.user_id}")[0];
                v_logs.Add(new V_Log(log.id, user.login, log.datetime, log.description));
            }

            dataGridView1.DataSource = v_logs;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Width = 500;
        }
    }
}
