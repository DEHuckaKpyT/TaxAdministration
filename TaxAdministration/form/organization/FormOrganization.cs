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
    public partial class FormOrganization : Form
    {
        int id;
        bool canChange;
        public FormOrganization(int organizationId, bool canChange)
        {
            InitializeComponent();
            this.id = organizationId;
            this.canChange = canChange;
        }

        private void FormOrganization_Load(object sender, EventArgs e)
        {
            Organization organization = Repository.Get<Organization>($"select * from organization where id = {id}")[0];

            textBoxName.Text = organization.name;
            textBoxInn.Text = organization.inn;
            textBoxBuildingNumber.Text = organization.building_number.ToString();
            textBoxPhoneNumber.Text = organization.phone_number;
            textBoxFirstname.Text = organization.accountant_firstname;
            textBoxMiddlename.Text = organization.accountant_middlename;
            textBoxLastname.Text = organization.accountant_lastname;
            textBoxDescription.Text = organization.description;

            if (organization.street_id != null)
            {
                Street street = Repository.Get<Street>($"select * from street where id = {organization.street_id}")[0];

                foreach (Street st in Repository.Get<Street>("select * from street"))
                {
                    comboBoxStreet.Items.Add(st);
                    if (st.id == street.id) comboBoxStreet.SelectedItem = st;
                }
            }
            button1.Enabled = canChange;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "update organization set ";

            if (textBoxBuildingNumber.Text != "")
                query += $"building_number = {textBoxBuildingNumber.Text}, ";
            if (textBoxFirstname.Text != "")
                query += $"accountant_firstname = '{textBoxFirstname.Text}', ";
            if (textBoxMiddlename.Text != "")
                query += $"accountant_middlename = '{textBoxMiddlename.Text}', ";
            if (textBoxLastname.Text != "")
                query += $"accountant_lastname = '{textBoxLastname.Text}', ";
            if (textBoxDescription.Text != "")
                query += $"description = '{textBoxDescription.Text}', ";
            if (comboBoxStreet.Text != "")
                query += $"street_id = {((Street)comboBoxStreet.SelectedItem).id}, ";
            query += $"name = '{textBoxName.Text}', " +
                $"phone_number = '{textBoxPhoneNumber.Text}', " +
                $"inn = '{textBoxInn.Text}' " +
                $"where id = {id}";

            Repository.Post(query);
        }
    }
}
