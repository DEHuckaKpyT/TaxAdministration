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

        private void ToolStripMenuItemUserList_Click(object sender, EventArgs e) => new FormUserList().Show();

        private void ToolStripMenuItemDeclarationList_Click(object sender, EventArgs e) => new FormDeclarationList().Show();

        private void улицыToolStripMenuItem_Click(object sender, EventArgs e) => new FormStreets().Show();

        private void районыToolStripMenuItem_Click(object sender, EventArgs e) => new FormDistricts().Show();

        private void льготыToolStripMenuItem_Click(object sender, EventArgs e) => new FormExempts().Show();

        private void списокОрганизацийToolStripMenuItem_Click(object sender, EventArgs e) => new FormOrganizationList().Show();
    }
}
