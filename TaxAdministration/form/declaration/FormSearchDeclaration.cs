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
    public partial class FormSearchDeclaration : Form
    {
        bool canChange;
        public FormSearchDeclaration(bool canChange)
        {
            InitializeComponent();
            this.canChange = canChange;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                //note SearchDeclaration
                Declaration declaration = Repository.Exec<Declaration>("SearchDeclaration",
                    "@number", textBox1.Text,
                    "@fromDate", DBNull.Value,
                    "@tillDate", DBNull.Value)[0];

                new FormDeclaration(declaration.id, canChange).Show();

                Close();
                Dispose();
                return;
            }

            {
                //note SearchDeclaration
                List<Declaration> declarations = Repository.Exec<Declaration>("SearchDeclaration",
                    "@number", DBNull.Value,
                    "@fromDate", dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                    "@tillDate", dateTimePicker2.Value.ToString("yyyy-MM-dd"));

                if (declarations.Count > 0)
                {
                    new FormDeclarationListByDate(dateTimePicker1.Value, dateTimePicker2.Value, canChange).Show();

                    Close();
                    Dispose();
                    return;
                }
            }
        }
    }
}
