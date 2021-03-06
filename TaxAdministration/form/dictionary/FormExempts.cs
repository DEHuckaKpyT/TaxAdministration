using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxAdministration.form
{
    public partial class FormExempts : Form
    {
        bool canChange;
        DataSet dataSet;
        SqlDataAdapter dataAdapter;
        public FormExempts(bool canChange)
        {
            InitializeComponent();
            this.canChange = canChange;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            try
            {
                dataAdapter.Update(dataSet, "exempt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormExempts_Load(object sender, EventArgs e)
        {
            dataSet = new DataSet();
            dataAdapter = new SqlDataAdapter("SELECT * FROM exempt", Repository.connection);
            dataAdapter.Fill(dataSet, "exempt");
            dataGridView1.DataSource = dataSet.Tables["exempt"];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.ReadOnly = !canChange;
            button1.Enabled = canChange;
        }
    }
}
