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
    public partial class FormAddRole : Form
    {
        public FormAddRole()
        {
            InitializeComponent();
        }

        private void buttonAddRole_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "") return;
            if (Repository.Get<Role>($"select * from role where name = '{textBoxName.Text}'").Count == 0)
            {
                Repository.Post($"insert into role (name, access_log, access_change_infirmation, access_users) " +
                    $"values ('{textBoxName.Text}'," +
                    $"{(checkBoxAudit.Checked ? 1 : 0)}," +
                    $"{(checkBoxChange.Checked ? 1 : 0)}," +
                    $"{(checkBoxUser.Checked ? 1 : 0)})");
                MessageBox.Show("Роль добавлена.");
                Close();
                Dispose();
            }
        }
    }
}
