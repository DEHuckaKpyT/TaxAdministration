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
    public partial class FormAddOrganization : Form
    {
        public FormAddOrganization()
        {
            InitializeComponent();
        }

        private void FormAddOrganization_Load(object sender, EventArgs e)
        {
            foreach (Street st in Repository.Get<Street>("select * from street"))
                comboBoxStreet.Items.Add(st);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into organization (name, inn, phone_number, building_number, accountant_firstname, accountant_middlename, accountant_lastname, description, street_id) values (";

            query += $" '{textBoxName.Text}', " +
                $" '{textBoxInn.Text}', " +
                $" '{textBoxPhoneNumber.Text}', ";
                query += $" {textBoxBuildingNumber.Text}, ";
                query += $" '{textBoxFirstname.Text}', ";
                query += $" '{textBoxMiddlename.Text}', ";
                query += $" '{textBoxLastname.Text}', ";
                query += $" '{textBoxDescription.Text}', ";
            if (comboBoxStreet.SelectedItem != null)
                query += $" {((Street)comboBoxStreet.SelectedItem).id})";
            else
                query += $" null)";
            Repository.Post(query);
            Close();
            Dispose();
        }
    }
}
