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
    public partial class FormUserList : Form
    {
        public FormUserList()
        {
            InitializeComponent();
        }

        private void FormUserList_Load(object sender, EventArgs e)
        {
            dataGridViewUsers.DataSource = Repository.Get<UsersWithRoles>($"select * from V_UsersWithRoles");
            dataGridViewUsers.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = "Открвыть",
            });
        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (e.RowIndex < 0)
                return;

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                UsersWithRoles user = (UsersWithRoles)grid.Rows[e.RowIndex].DataBoundItem;
                new FormUser(user.login).Show();
            }
        }
    }
}
