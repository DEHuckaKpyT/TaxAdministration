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

namespace TaxAdministration.form.taxpayer
{
    public partial class FormSearchTaxpayer : Form
    {
        public FormSearchTaxpayer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Taxpayer taxpayer = Repository.Exec<Taxpayer>("SearchTaxpayer",
                    "@id", textBox1.Text,
                    "@inn", DBNull.Value,
                    "@firstname", DBNull.Value,
                    "@middlename", DBNull.Value,
                    "@lastname", DBNull.Value)[0];

                new FormTaxpayer(taxpayer.id).Show();

                Close();
                Dispose();
                return;
            }
            if (textBox2.Text != "")
            {
                Taxpayer taxpayer = Repository.Exec<Taxpayer>("SearchTaxpayer",
                    "@id", DBNull.Value,
                    "@inn", textBox2.Text,
                    "@firstname", DBNull.Value,
                    "@middlename", DBNull.Value,
                    "@lastname", DBNull.Value)[0];

                new FormTaxpayer(taxpayer.id).Show();

                Close();
                Dispose();
                return;
            }
            if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                Taxpayer taxpayer = Repository.Exec<Taxpayer>("SearchTaxpayer",
                    "@id", DBNull.Value,
                    "@inn", DBNull.Value,
                    "@firstname", textBox3.Text,
                    "@middlename", textBox4.Text,
                    "@lastname", textBox5.Text)[0];

                new FormTaxpayer(taxpayer.id).Show();

                Close();
                Dispose();
                return;
            }
        }
    }
}
