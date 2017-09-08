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
    public partial class frmCountry : Form
    {
        BindingSource source = new BindingSource();
        public frmCountry()
        {
            InitializeComponent();
            dtgvCountry.DataSource = source;
            LoadListCountry();
            LoadDataBinding();
        }

        private void LoadDataBinding()
        {
            txtCountryID.DataBindings.Add(new Binding("Text", dtgvCountry.DataSource, "Mã nước sản xuất", true, DataSourceUpdateMode.Never));
            txtCountryName.DataBindings.Add(new Binding("Text", dtgvCountry.DataSource, "Tên nước sản xuất", true, DataSourceUpdateMode.Never));
        }

        private void LoadListCountry()
        {
            source.DataSource = CountryBLL.Instance.GetAllCountry();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtCountryID.Text;
            string name = txtCountryName.Text;

            if (CountryBLL.Instance.CheckExistCountryByID(id))
            {
                MessageBox.Show("Mã nước sản xuất đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CountryBLL.Instance.AddCountry(id, name))
            {
                MessageBox.Show("Thêm nước sản xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListCountry();
            }
            else
            {
                MessageBox.Show("Thêm nước sản xuất thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            string id = txtCountryID.Text;
            string name = txtCountryName.Text;

            if (CountryBLL.Instance.UpdateCountry(id, name))
            {
                MessageBox.Show("Sửa nước sản xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListCountry();
            }
            else
            {
                MessageBox.Show("Sửa nước sản xuất thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtCountryID.Text;
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nước sản xuất có ID là " + id + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (CountryBLL.Instance.DeleteCountry(id))
                {
                    MessageBox.Show("Xoá nước sản xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListCountry();
                }
                else
                {
                    MessageBox.Show("Xoá  nước sản xuất thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadListCountry();
        }
    }
}
