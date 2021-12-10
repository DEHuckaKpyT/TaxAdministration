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
    public partial class FormMain : Form
    {
        int userId;
        public FormMain(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) => Application.Restart();

        private void ToolStripMenuItemShow_Click(object sender, EventArgs e) => new FormProfile(userId).Show();
    }
}
