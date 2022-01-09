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
    public partial class FormOrganizationList : Form
    {
        public FormOrganizationList()
        {
            InitializeComponent();
        }

        private void FormOrganizationList_Load(object sender, EventArgs e)
        {
            //note V_Organizations
            dataGridView1.DataSource = Repository.Get<V_Organizations>($"select * from V_Organizations");
            dataGridView1.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = "Открыть",
                UseColumnTextForButtonValue = true
            });
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[3].Width = 150;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (e.RowIndex < 0)
                return;

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                V_Organizations organization = (V_Organizations)grid.Rows[e.RowIndex].DataBoundItem;
                new FormOrganization(organization.id).ShowDialog();
                dataGridView1.DataSource = Repository.Get<V_Organizations>($"select * from V_Organizations");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormAddOrganization().ShowDialog();
            dataGridView1.DataSource = Repository.Get<V_Organizations>($"select * from V_Organizations");
        }
    }
}
