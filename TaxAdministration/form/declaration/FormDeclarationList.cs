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
    public partial class FormDeclarationList : Form
    {
        bool canChange;
        public FormDeclarationList(bool canChange)
        {
            InitializeComponent();
            this.canChange = canChange;
        }

        private void FormDeclarationList_Load(object sender, EventArgs e)
        {
            //note V_Declarations
            dataGridView1.DataSource = Repository.Get<V_Declarations>($"select * from V_Declarations");
            dataGridView1.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = "Открыть",
                UseColumnTextForButtonValue = true
            });
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (e.RowIndex < 0)
                return;

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                V_Declarations declaration = (V_Declarations)grid.Rows[e.RowIndex].DataBoundItem;
                new FormDeclaration(declaration.id, canChange).ShowDialog();
                dataGridView1.DataSource = Repository.Get<V_Declarations>($"select * from V_Declarations");
            }
        }
    }
}
