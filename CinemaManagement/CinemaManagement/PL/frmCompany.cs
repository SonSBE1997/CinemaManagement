using CinemaManagement.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaManagement.PL
{
    public partial class frmCompany : Form
    {
        BindingSource source = new BindingSource();
        public frmCompany()
        {
            InitializeComponent();
            dtgvCompany.DataSource = source;
            LoadListCompany();
            LoadBinding();
        }

        void LoadListCompany()
        {
            source.DataSource = CompanyBLL.Instance.GetAllCompany();
        }

        void LoadBinding()
        {
            txtCompanyID.DataBindings.Add(new Binding("Text", dtgvCompany.DataSource, "Mã hãng sản xuất", true, DataSourceUpdateMode.Never));
            txtCompanyName.DataBindings.Add(new Binding("Text", dtgvCompany.DataSource, "Tên hãng sản xuất", true, DataSourceUpdateMode.Never));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtCompanyID.Text;
            string name = txtCompanyName.Text;

            if (CheckExistCompanyID(id))
            {
                MessageBox.Show("Mã hãng sản xuất đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CompanyBLL.Instance.AddCompany(id, name))
            {
                MessageBox.Show("Thêm hãng sản xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListCompany();
            }
            else
            {
                MessageBox.Show("Thêm hãng sản xuất thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool CheckExistCompanyID(string id)
        {
            if (CompanyBLL.Instance.GetRowCompanyByID(id) != null) return true;
            return false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtCompanyID.Text;
            string name = txtCompanyName.Text;

            if (CompanyBLL.Instance.UpdateCompany(id, name))
            {
                MessageBox.Show("Sửa hãng sản xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListCompany();
            }
            else
            {
                MessageBox.Show("Sửa hãng sản xuất thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtCompanyID.Text;
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hãng sản xuất có ID là " + id + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (CompanyBLL.Instance.DeleteCompany(id))
                {
                    MessageBox.Show("Xoá hãng sản xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListCompany();
                }
                else
                {
                    MessageBox.Show("Xoá  hãng sản xuất thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadListCompany();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            dtgvCompany.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
