using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxAdministration.form
{
    public partial class FormSearchOrganization : Form
    {
        bool canChange;
        public FormSearchOrganization(bool canChange)
        {
            InitializeComponent();
            this.canChange = canChange;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                //note SearchOrganization
                Organization organization = Repository.Exec<Organization>("SearchOrganization",
                    "@id", textBox1.Text,
                    "@name", DBNull.Value,
                    "@inn", DBNull.Value)[0];

                new FormOrganization(organization.id, canChange).Show();

                Close();
                Dispose();
                return;
            }
            if (textBox2.Text != "")
            {
                //note SearchOrganization
                Organization organization = Repository.Exec<Organization>("SearchOrganization",
                    "@id", DBNull.Value,
                    "@name", textBox2.Text,
                    "@inn", DBNull.Value)[0];

                new FormOrganization(organization.id, canChange).Show();

                Close();
                Dispose();
                return;
            }
            if (textBox3.Text != "")
            {
                //note SearchOrganization
                Organization organization = Repository.Exec<Organization>("SearchOrganization",
                    "@id", DBNull.Value,
                    "@name", DBNull.Value,
                    "@inn", textBox3.Text)[0];

                new FormOrganization(organization.id, canChange).Show();

                Close();
                Dispose();
                return;
            }
        }
    }
}
