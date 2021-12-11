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
    public partial class FormProfile : Form
    {
        int userId;
        User user;
        public FormProfile(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void FormProfile_Load(object sender, EventArgs e)
        {
            user = Repository.Get<User>($"select * from [user] where id = {userId}").First();
            Role role = Repository.Get<Role>($"select * from role where id = {user.role_id}").First();
            labelLogin.Text = user.login;
            labelRole.Text = role.name;
            if (role.access_log) labelAuditAccess.Text = "Да";
            if (role.access_users) labelUsersAccess.Text = "Да";
            if (role.access_change_infirmation) labelChangesAccess.Text = "Да";
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            if (textBoxOldPassword.Text == user.password)
            {
                if (textBoxNewPassword.Text == "" || textBoxNewPassword2.Text == "")
                {
                    MessageBox.Show("Введите новый пароль.");
                    return;
                }
                if (textBoxNewPassword.Text == textBoxNewPassword2.Text)
                {
                    Repository.Post($"update [user] set password = '{textBoxNewPassword.Text}' where id = {user.id}");
                    user.password = textBoxNewPassword.Text;

                    MessageBox.Show("Пароль успешно изменён.");

                    textBoxOldPassword.Text = "";
                    textBoxNewPassword.Text = "";
                    textBoxNewPassword2.Text = "";
                }
                else
                    MessageBox.Show("Новые пароли не совпадают.");
            }
            else
                MessageBox.Show("Пароль введён неверно.");
        }
    }
}
