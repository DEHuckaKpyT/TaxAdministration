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
    public partial class FormDeclaration : Form
    {
        int declarationId;
        public FormDeclaration(int declarationId)
        {
            InitializeComponent();
            this.declarationId = declarationId;
        }

        private void FormDeclaration_Load(object sender, EventArgs e)
        {

        }
    }
}
