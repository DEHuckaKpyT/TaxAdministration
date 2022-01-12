using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaxAdministration.form.declaration;
using TaxAdministration.form.taxpayer;
using TaxAdministration.model;

namespace TaxAdministration.form
{
    public partial class FormMain : Form
    {
        int userId;
        bool canChange = false;
        public FormMain(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            User user = Repository.Get<User>($"select * from [user] where id = {userId}")[0];
            Role role = Repository.Get<Role>($"select * from role where id = {user.role_id}")[0];

            toolStripDropDownButtonUsers.Enabled = role.access_users;
            toolStripButtonLog.Enabled = role.access_log;
            canChange = role.access_change_infirmation;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e) => Application.Restart();

        private void ToolStripMenuItemShow_Click(object sender, EventArgs e) => new FormProfile(userId).Show();

        private void ToolStripMenuItemUserList_Click(object sender, EventArgs e) => new FormUserList().Show();

        private void ToolStripMenuItemDeclarationList_Click(object sender, EventArgs e) => new FormNotAcceptedDeclarationList(canChange).Show();

        private void улицыToolStripMenuItem_Click(object sender, EventArgs e) => new FormStreets(canChange).Show();

        private void районыToolStripMenuItem_Click(object sender, EventArgs e) => new FormDistricts(canChange).Show();

        private void льготыToolStripMenuItem_Click(object sender, EventArgs e) => new FormExempts(canChange).Show();

        private void списокОрганизацийToolStripMenuItem_Click(object sender, EventArgs e) => new FormOrganizationList(canChange).Show();

        private void поискОрганизацийToolStripMenuItem_Click(object sender, EventArgs e) => new FormSearchOrganization(canChange).Show();

        private void списокНалогоплательщиковToolStripMenuItem_Click(object sender, EventArgs e) => new FormTaxpayerList(canChange).Show();

        private void поискНалогоплательщикаToolStripMenuItem_Click(object sender, EventArgs e) => new FormSearchTaxpayer(canChange).Show();

        private void всеДекларацииToolStripMenuItem_Click(object sender, EventArgs e) => new FormDeclarationList(canChange).Show();

        private void поискДекларацийToolStripMenuItem_Click(object sender, EventArgs e) => new FormSearchDeclaration(canChange).Show();

        private void toolStripButtonLog_Click(object sender, EventArgs e) => new FormLog().Show();
    }
}