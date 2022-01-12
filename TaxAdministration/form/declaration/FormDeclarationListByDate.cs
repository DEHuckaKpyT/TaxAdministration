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

namespace TaxAdministration.form.declaration
{
    public partial class FormDeclarationListByDate : Form
    {
        bool canChange;
        DateTime fromDate;
        DateTime tillDate;
        public FormDeclarationListByDate(DateTime fromDate, DateTime tillDate, bool canChange)
        {
            InitializeComponent();
            this.fromDate = fromDate;
            this.tillDate = tillDate;
            this.canChange = canChange;
        }

        private void FormDeclarationListByDate_Load(object sender, EventArgs e)
        {
            //note SearchDeclaration
            dataGridView1.DataSource = Repository.Exec<Declaration>("SearchDeclaration",
                    "@number", DBNull.Value,
                    "@fromDate", fromDate.ToString("yyyy-MM-dd"),
                    "@tillDate", tillDate.ToString("yyyy-MM-dd"));
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
                Declaration declaration = (Declaration)grid.Rows[e.RowIndex].DataBoundItem;
                new FormDeclaration(declaration.id, canChange).ShowDialog();
                dataGridView1.DataSource = Repository.Exec<Declaration>("SearchDeclaration",
                    "@number", DBNull.Value,
                    "@fromDate", fromDate.ToString("yyyy-MM-dd"),
                    "@tillDate", tillDate.ToString("yyyy-MM-dd"));
            }
        }
    }
}
