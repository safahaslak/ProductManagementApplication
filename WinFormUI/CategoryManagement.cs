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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Write a Category Name!");
                return;
            }
            var category = new Category()
            {
                CreateDate = DateTime.Now,
                Description = txtDescription.Text,
                IsActive = cbIsActive.Checked,
                Name = txtName.Text,
            };
            categoryManager.Add(category);
            var result = categoryManager.Save();
            if (result > 0)
            {
                dgvCategories.DataSource = categoryManager.GetCategories();
                txtName.Text = string.Empty;
                txtDescription.Text = string.Empty;
                MessageBox.Show("Successful Registration!"); 
            }
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgvCategories.CurrentRow.Cells[0].Value);
            var category = categoryManager.GetCategory(id);
            txtName.Text = category.Name;
            txtDescription.Text = category.Description;
            cbIsActive.Checked = category.IsActive;
            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Write a Category Name!");
                return;
            }
            var id = Convert.ToInt32(dgvCategories.CurrentRow.Cells[0].Value);
            var category = new Category()
            {
                Id = id,
                CreateDate = DateTime.Now,
                Description = txtDescription.Text,
                IsActive = cbIsActive.Checked,
                Name = txtName.Text,
            };
            categoryManager.Update(category);
            var result = categoryManager.Save();
            if (result > 0)
            {
                dgvCategories.DataSource = categoryManager.GetCategories();
                txtName.Text = string.Empty;
                txtDescription.Text = string.Empty;
                MessageBox.Show("Successful Update!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvCategories.CurrentRow.Cells[0].Value);
            var category = categoryManager.GetCategory(id);
            categoryManager.Delete(category);
            var result = categoryManager.Save();
            if (result > 0)
            {
                dgvCategories.DataSource = categoryManager.GetCategories();
                txtName.Text = string.Empty;
                txtDescription.Text = string.Empty;
                MessageBox.Show("Successful Deregistration!");
            }
        }
    }
}
