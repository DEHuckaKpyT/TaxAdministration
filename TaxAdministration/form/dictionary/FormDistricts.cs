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
    public partial class FormDistricts : Form
    {
        DataSet dataSet;
        SqlDataAdapter dataAdapter;
        public FormDistricts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            try
            {
                dataAdapter.Update(dataSet, "district");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormDistricts_Load(object sender, EventArgs e)
        {
            dataSet = new DataSet();
            dataAdapter = new SqlDataAdapter("SELECT * FROM district", Repository.connection);
            dataAdapter.Fill(dataSet, "district");
            dataGridView1.DataSource = dataSet.Tables["district"];
            dataGridView1.Columns[0].Visible = false;
            //dataGridView1.ReadOnly = !change;
            //button1.Enabled = change;
        }
    }
}
