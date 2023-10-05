using ProductManagementApplication.BL;
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
    public partial class CategoryManagement : Form
    {
        public CategoryManagement()
        {
            InitializeComponent();
        }
        CategoryManager categoryManager = new CategoryManager();
        private void CategoryManagement_Load(object sender, EventArgs e)
        {
            dgvCategories.DataSource = categoryManager.GetCategories();
        }
    }
}
