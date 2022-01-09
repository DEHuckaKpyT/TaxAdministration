using System;
using System.Windows.Forms;
using TaxAdministration.model;

namespace TaxAdministration.form
{
    public partial class FormTaxpayer : Form
    {
        int id;
        public FormTaxpayer(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void FormTaxpayer_Load(object sender, EventArgs e)
        {
            Taxpayer taxpayer = Repository.Get<Taxpayer>($"select * from taxpayer where id = {id}")[0];

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
                Organization organization = Repository.Get<Organization>($"select * from organization where id = {taxpayer.organization_id}")[0];

                foreach (Organization org in Repository.Get<Organization>("select * from organization"))
                {
                    comboBoxOrganization.Items.Add(org);
                    if (org.id == organization.id) comboBoxOrganization.SelectedItem = org;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
