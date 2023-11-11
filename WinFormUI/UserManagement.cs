using ProductManagementApplication.BL;
using ProductManagementApplication.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinFormUI
{
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
        }
        Repository<User> repository = new Repository<User>();
        private void UserManagement_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        void Yukle()
        {
            dgvUsers.DataSource = repository.GetAll();
            CleanUp();
        }
        void CleanUp()
        {
            var objects = groupBox1.Controls.OfType<TextBox>();
            foreach (var item in objects)
            {
                item.Clear();
            }
            cbIsActive.Checked = false;
            cbIsAdmin.Checked = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name space can not be empty!");
                return;
            }
            var user = new User()
            {
                CreateDate = DateTime.Now,
                Email = txtEmail.Text,
                IsActive = cbIsActive.Checked,
                IsAdmin = cbIsAdmin.Checked,
                Name = txtName.Text,
                Surname = txtSurname.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Password = txtPassword.Text,
                Username = txtUsername.Text
            };
            repository.Add(user);
            try
            {
                var result = repository.Save();
                if (result > 0)
                {
                    Yukle();
                    MessageBox.Show("Registration is Successful!");
                }
            }
            catch (Exception Error)
            {

                MessageBox.Show("Error Occured!");
            }
            
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["Id"].Value);
            var user = repository.Find(id);
            txtEmail.Text = user.Email;
            txtName.Text = user.Name;
            txtPassword.Text = user.Password;
            txtUsername.Text = user.Username;
            txtPhoneNumber.Text = user.PhoneNumber;
            txtSurname.Text = user.Surname;
            cbIsActive.Checked = user.IsActive;
            cbIsAdmin.Checked = user.IsAdmin;
            tabControl1.SelectedTab = tabPage2;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name space can not be empty!");
                return;
            }
            var id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["Id"].Value);
            var user = new User()
            {
                Id = id,
                CreateDate = DateTime.Now,
                Email = txtEmail.Text,
                IsActive = cbIsActive.Checked,
                IsAdmin = cbIsAdmin.Checked,
                Name = txtName.Text,
                Surname = txtSurname.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Password = txtPassword.Text,
                Username = txtUsername.Text
            };
            repository.Update(user);
            try
            {
                var result = repository.Save();
                if (result > 0)
                {
                    Yukle();
                    tabControl1.SelectedTab = tabPage2;
                    MessageBox.Show("Update is Successful!");
                }
            }
            catch (Exception Error)
            {

                MessageBox.Show("Error Occured!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["Id"].Value);
            var user = repository.Find(id);
            repository.Delete(user);
            try
            {
                var result = repository.Save();
                if (result > 0)
                {
                    Yukle();
                    tabControl1.SelectedTab = tabPage2;
                    MessageBox.Show("Deregistration is Successful!");
                }
            }
            catch (Exception Error)
            {

                MessageBox.Show("Error Occured!");
            }
        }
    }
}
