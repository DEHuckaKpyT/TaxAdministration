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
    public partial class FormTaxpayerList : Form
    {
        bool canChange;
        public FormTaxpayerList(bool canChange)
        {
            InitializeComponent();
            this.canChange = canChange;
        }

        private void FormTaxpayerList_Load(object sender, EventArgs e)
        {
            //note V_Taxpayers
            dataGridView1.DataSource = Repository.Get<V_Taxpayers>($"select * from V_Taxpayers");
            dataGridView1.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = "Открыть",
                UseColumnTextForButtonValue = true
            });
            dataGridView1.Columns[0].Visible = false;
            button1.Enabled = canChange;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (e.RowIndex < 0)
                return;

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                V_Taxpayers taxpayer = (V_Taxpayers)grid.Rows[e.RowIndex].DataBoundItem;
                new FormTaxpayer(taxpayer.id, canChange).ShowDialog();
                dataGridView1.DataSource = Repository.Get<V_Taxpayers>($"select * from V_Taxpayers");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormAddTaxpayer().ShowDialog();
            dataGridView1.DataSource = Repository.Get<V_Taxpayers>($"select * from V_Taxpayers");
        }
    }
}
