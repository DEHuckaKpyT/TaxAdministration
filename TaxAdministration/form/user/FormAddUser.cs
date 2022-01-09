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
    public partial class FormAddUser : Form
    {
        public FormAddUser()
        {
            InitializeComponent();
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            string roleName = comboBoxRole.Text;
            int role_id;

            List<Role> roles = Repository.Get<Role>($"select * from role where name = '{roleName}'");
            if (roles.Count == 1)
                role_id = roles.First().id;
            else
            {
                MessageBox.Show($"Pоли \"{roleName}\" не существует.");
                return;
            }

            if (Repository.Get<Role>($"select * from [user] where login = '{login}'").Count != 0)
            {
                MessageBox.Show($"Логин \"{login}\" уже существует.");
                return;
            }

            if (password == "")
            {
                MessageBox.Show($"Введите пароль.");
                return;
            }

            if (Repository.Post($"insert into [user] (login, password, role_id) values ('{login}', '{password}', {role_id})") == 1)
                MessageBox.Show("Пользователь успешно добавлен.");
            Close();
            Dispose();
        }

        private void buttonShowPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '\0';
        }

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            Role role = Repository.Get<Role>($"select * from role where name = '{comboBoxRole.SelectedItem}'").First();
            labelAudit.Text = role.access_log ? "Да" : "Нет";
            labelChange.Text = role.access_change_infirmation ? "Да" : "Нет";
            labelUsers.Text = role.access_users ? "Да" : "Нет";
        }

        private void buttonAddRole_Click(object sender, EventArgs e)
        {
            new FormAddRole().ShowDialog();
            comboBoxRole.Items.Clear();
            foreach (Role r in Repository.Get<Role>($"select * from role"))
                comboBoxRole.Items.Add(r.name);
        }

        private void FormAddUser_Load(object sender, EventArgs e)
        {
            foreach (Role r in Repository.Get<Role>($"select * from role"))
                comboBoxRole.Items.Add(r.name);
        }
    }
}
