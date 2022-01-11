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
    public partial class FormAddTaxpayer : Form
    {
        public FormAddTaxpayer()
        {
            InitializeComponent();
        }

        private void FormAddTaxpayer_Load(object sender, EventArgs e)
        {
                foreach (Organization org in Repository.Get<Organization>("select * from organization"))
                    comboBoxOrganization.Items.Add(org);

                foreach (Street st in Repository.Get<Street>("select * from street"))
                    comboBoxStreet.Items.Add(st);

                foreach (District distr in Repository.Get<District>("select * from district"))
                    comboBoxDistrict.Items.Add(distr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into taxpayer (inn, lastname, firstname, middlename, document, document_serial, document_number, document_date, document_region, born, organization_id, street_id, building_number, district_id, tax_district, tax_number) values (";

            query += $"'{textBoxInn.Text}', ";

            query += $"'{textBoxLastname.Text}', ";

            query += $"'{textBoxFirstName.Text}', ";

            query += $"'{textBoxMiddleName.Text}', ";

            query += $"'{textBoxDocument.Text}', ";

            query += $"'{textBoxSerial.Text}', ";

            query += $"'{textBoxNumber.Text}', ";

            query += $"'{dateTimePickerDate.Value.ToString("yyyy-MM-dd")}', ";

            query += $"'{textBoxWhere.Text}', ";

            query += $"'{dateTimePickerBorn.Value.ToString("yyyy-MM-dd")}', ";

            if (comboBoxOrganization.Text != "")
                query += $"{((Organization)comboBoxOrganization.SelectedItem).id}, ";
            else
                query += $"null, ";

            if (comboBoxStreet.Text != "")
                query += $"{((Street)comboBoxStreet.SelectedItem).id}, ";
            else
                query += $"null, ";

            query += $"'{textBoxBuilding.Text}', ";

            if (comboBoxDistrict.Text != "")
                query += $"{((District)comboBoxDistrict.SelectedItem).id}, ";
            else
                query += $"null, ";


            query += $"'{textBoxTaxDistrict.Text}', ";

            query += $"'{textBoxTaxNumber.Text}') ";


           if (Repository.Post(query) == 1)
            {
                MessageBox.Show("Налогоплательщик добавлен");
                Close();
                Dispose();
            }
        }
    }
}
