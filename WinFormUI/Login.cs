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

namespace WinFormUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Repository<User> repository = new Repository<User>();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Username or Password can not be Empty!");
                return;
            }
            var account = repository.Get(u=>u.IsActive && u.IsAdmin && u.Username == txtUsername.Text && u.Password == txtPassword.Text);
            if (account != null) 
            {
                this.Hide();
                Main main = new Main();
                main.Show();
            }
            else
            {
                MessageBox.Show("User couldn't be found!");
            }
        }
    }
}
