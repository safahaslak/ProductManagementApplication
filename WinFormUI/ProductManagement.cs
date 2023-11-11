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
    public partial class ProductManagement : Form
    {
        public ProductManagement()
        {
            InitializeComponent();
        }

        ProductManager manager = new ProductManager();
        Repository<Category> repository = new Repository<Category>();
        private void ProductManagement_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        void DataLoad()
        {
            //dgvProducts.DataSource = manager.GetAll();
            dgvProducts.DataSource = manager.GetProducts();
            cmbCategory.DataSource = repository.GetAll();
            //dgvProducts.Columns.Remove("Image2");
            //dgvProducts.Columns.Remove("CategoryId");
            //dgvProducts.Columns.Remove("Category");
        }

        void CleanUp()
        {
            //txtName.Text = string.Empty;
            //txtDescription.Text = "";
            var objects = groupBox1.Controls.OfType<TextBox>();
            foreach ( var item in objects )
            {
                item.Clear();
            }
            cbIsActive.Checked = false;
            txtDescription.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Product Name Can't be Empty!"); 
                return;
            }
            var urun = new Product()
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Brand = txtBrand.Text,
                IsActive = cbIsActive.Checked,
                Price = Convert.ToDecimal(txtPrice.Text),
                Stock = Convert.ToInt32(txtStock.Text),
                CreateDate = DateTime.Now,
                CategoryId = Convert.ToInt32(cmbCategory.SelectedValue)
            };
            manager.Add(urun);
            try
            {
                int result = manager.Save();
                if (result > 0)
                {
                    CleanUp();
                    DataLoad();
                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    MessageBox.Show("Registiration is Successful!");
                }
            }
            catch (Exception Error)
            {

                MessageBox.Show("Error Occured!" + Error.Message);
            }
            
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value);
            var urun = manager.Find(id);
            txtBrand.Text = urun.Brand;
            txtDescription.Text = urun.Description;
            txtName.Text = urun.Name;
            txtPrice.Text = urun.Price.ToString();
            txtStock.Text = urun.Stock.ToString();
            cbIsActive.Checked = urun.IsActive;
            cmbCategory.SelectedValue = urun.CategoryId;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Product Name Can't be Empty!");
                return;
            }
            var id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value);
            var urun = new Product()
            {
                Id = id,
                Name = txtName.Text,
                Description = txtDescription.Text,
                Brand = txtBrand.Text,
                IsActive = cbIsActive.Checked,
                Price = Convert.ToDecimal(txtPrice.Text),
                Stock = Convert.ToInt32(txtStock.Text),
                CategoryId = Convert.ToInt32(cmbCategory.SelectedValue),
                CreateDate = Convert.ToDateTime(dgvProducts.CurrentRow.Cells[6].Value)
            };
            manager.Update(urun);
            try
            {
                int result = manager.Save();
                if (result > 0)
                {
                    CleanUp();
                    DataLoad();
                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    MessageBox.Show("Registiration is Successful!");
                }
            }
            catch (Exception Error)
            {

                MessageBox.Show("Error Occured!" + Error.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value);
            var kayit = manager.Find(id);
            manager.Delete(kayit);
            var result = manager.Save();
            if (result > 0)
            {
                CleanUp();
                DataLoad();
                MessageBox.Show("Deregistration is Successful!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgvProducts.DataSource = manager.GetAll(u => u.Name.Contains(textBox1.Text));
        }
    }
}
