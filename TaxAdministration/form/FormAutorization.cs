using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaxAdministration.form;
using TaxAdministration.model;

namespace TaxAdministration
{
    public partial class FormAutorization : Form
    {
        public FormAutorization()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            List<User> users = Repository.Get<User>($"select * from [user] where login = '{comboBoxLogin.Text}'");
            if (users.Count == 1)
            {
                User user = users.First();
                if (user.password == textBoxPassword.Text)
                {
                    new FormMain(user.id).Show();
                    Hide();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void FormAutorization_Load(object sender, EventArgs e)
        {
            List<User> users = Repository.Get<User>($"select * from [user]");
            foreach (User user in users)
                comboBoxLogin.Items.Add(user.login);
        }

        private void comboBoxLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<User> users = Repository.Get<User>($"select * from [user] where login = '{comboBoxLogin.Text}'");
            if (users.Count == 1)
                textBoxHelpPassword.Text = users.First().password;
        }
    }
}
