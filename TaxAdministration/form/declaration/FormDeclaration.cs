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
    public partial class FormDeclaration : Form
    {
        int id;
        bool canChange;
        public FormDeclaration(int id, bool canChange)
        {
            InitializeComponent();
            this.id = id;
            this.canChange = canChange;
        }

        private void FormDeclaration_Load(object sender, EventArgs e)
        {
            Declaration declaration = Repository.Get<Declaration>($"select * from declaration where id = {id}")[0];
            button1.Visible = declaration.accepted == true ? false : true;

            textBox1.Text = declaration.number;
            textBoxCreateDate.Text = declaration.create_date.ToString("dd/MM/yyyy");
            textBoxSum.Text = declaration.sum_all.ToString();
            textBoxTax.Text = declaration.sum_tax.ToString();
            textBoxPension.Text = declaration.sum_pension.ToString();

            if (declaration.exempt_id != null)
            {
                Exempt exempt = Repository.Get<Exempt>($"select * from exempt where id = {declaration.exempt_id}")[0];

                foreach (Exempt ex in Repository.Get<Exempt>("select * from exempt"))
                {
                    comboBoxExempt.Items.Add(ex);
                    if (ex.id == exempt.id) comboBoxExempt.SelectedItem = ex;
                }
            }

            textBoxExemptSum.Text = declaration.number;


            Taxpayer taxpayer = Repository.Get<Taxpayer>($"select * from taxpayer where id = {declaration.taxpayer_id}")[0];

            textBoxInn.Text = taxpayer.inn;
            textBoxLastname.Text = taxpayer.lastname;
            textBoxFirstName.Text = taxpayer.firstname;
            textBoxMiddleName.Text = taxpayer.middlename;
            textBoxDocument.Text = taxpayer.document;
            textBoxSerial.Text = taxpayer.document_serial;
            textBoxNumber.Text = taxpayer.document_number;
            dateTimePickerDate.Value = taxpayer.document_date;
            textBoxWhere.Text = taxpayer.document_region;
            dateTimePickerBorn.Value = taxpayer.born;

            {
                Organization organization1 = Repository.Get<Organization>($"select * from organization where id = {taxpayer.organization_id}")[0];

                foreach (Organization org in Repository.Get<Organization>("select * from organization"))
                {
                    comboBoxOrganization.Items.Add(org);
                    if (org.id == organization1.id) comboBoxOrganization.SelectedItem = org;
                }
            }

            {
                Street street = Repository.Get<Street>($"select * from street where id = {taxpayer.street_id}")[0];

                foreach (Street st in Repository.Get<Street>("select * from street"))
                {
                    comboBoxStreet.Items.Add(st);
                    if (st.id == street.id) comboBoxStreet.SelectedItem = st;
                }
                textBoxBuilding.Text = taxpayer.building_number.ToString();
            }

            if (taxpayer.district_id != null)
            {
                District district = Repository.Get<District>($"select * from district where id = {taxpayer.district_id}")[0];

                foreach (District distr in Repository.Get<District>("select * from district"))
                {
                    comboBoxDistrict.Items.Add(distr);
                    if (distr.id == district.id) comboBoxDistrict.SelectedItem = distr;
                }
            }

            textBoxTaxDistrict.Text = taxpayer.tax_district;
            textBoxTaxNumber.Text = taxpayer.tax_number;


            Organization organization = Repository.Get<Organization>($"select * from organization where id = {taxpayer.organization_id}")[0];

            textBoxName.Text = organization.name;
            textBox11.Text = organization.inn;
            textBoxBuildingNumber.Text = organization.building_number.ToString();
            textBoxPhoneNumber.Text = organization.phone_number;
            textBox10.Text = organization.accountant_firstname;
            textBox9.Text = organization.accountant_middlename;
            textBox8.Text = organization.accountant_lastname;
            textBoxDescription.Text = organization.description;

            if (organization.street_id != null)
            {
                Street street = Repository.Get<Street>($"select * from street where id = {organization.street_id}")[0];

                foreach (Street st in Repository.Get<Street>("select * from street"))
                {
                    comboBox1.Items.Add(st);
                    if (st.id == street.id) comboBox1.SelectedItem = st;
                }
            }

            button1.Enabled = canChange;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Repository.Post($"update declaration set accepted = 1 where id = {id}");
            MessageBox.Show("Декларация принята.");
            Close();
            Dispose();
        }
    }
}
