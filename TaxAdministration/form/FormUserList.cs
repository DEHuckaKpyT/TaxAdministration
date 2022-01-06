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
            //note V_UsersWithRoles
            dataGridViewUsers.DataSource = Repository.Get<UsersWithRoles>($"select * from V_UsersWithRoles");
            dataGridViewUsers.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = "Открыть",
                UseColumnTextForButtonValue = true
            });
            dataGridViewUsers.Width = dataGridViewUsers.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 50;
            Width = dataGridViewUsers.Width + 35;
        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (e.RowIndex < 0)
                return;

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                UsersWithRoles user = (UsersWithRoles)grid.Rows[e.RowIndex].DataBoundItem;
                new FormUser(user.login).ShowDialog();
                dataGridViewUsers.DataSource = Repository.Get<UsersWithRoles>($"select * from V_UsersWithRoles");
            }
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            new FormAddUser().ShowDialog();
            dataGridViewUsers.DataSource = Repository.Get<UsersWithRoles>($"select * from V_UsersWithRoles");
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridViewUsers.SelectedRows)
            {
                UsersWithRoles user = ((UsersWithRoles)row.DataBoundItem);
                if (MessageBox.Show($"Действительно хотите удалить \"{user.login}\"?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    if (Repository.Post($"delete from [user] where login = '{user.login}'") == 1)
                    {
                        MessageBox.Show($"Пользователь {user.login} удалён.");
                        dataGridViewUsers.DataSource = Repository.Get<UsersWithRoles>($"select * from V_UsersWithRoles");
                    }
                    else
                        return;
            }
        }
    }
}
