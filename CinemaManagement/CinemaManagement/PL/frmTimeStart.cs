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
    public partial class frmTimeStartFilm : Form
    {
        BindingSource source = new BindingSource();
        public frmTimeStartFilm()
        {
            InitializeComponent();
            dtgvTimeStart.DataSource = source;
            LoadListTimeStart();
            LoadDataBinding();
        }

        private void LoadDataBinding()
        {
            txtTimeID.DataBindings.Add(new Binding("Text", dtgvTimeStart.DataSource, "Mã giờ chiếu", true, DataSourceUpdateMode.Never));
            txtCost.DataBindings.Add(new Binding("Text", dtgvTimeStart.DataSource, "Đơn giá", true, DataSourceUpdateMode.Never));
        }

        private void LoadListTimeStart()
        {
            source.DataSource = TimeStartBLL.Instance.GetAllFilmTime();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtTimeID.Text;
            int cost = Int32.Parse(txtCost.Text);

            if (TimeStartBLL.Instance.CheckExistFilmTime(id))
            {
                MessageBox.Show("Giờ chiếu phim đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TimeStartBLL.Instance.AddFilmTime(id, cost))
            {
                MessageBox.Show("Thêm giờ chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListTimeStart();
            }
            else
            {
                MessageBox.Show("Thêm giờ chiếu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtTimeID.Text;
            int cost = Int32.Parse(txtCost.Text);

            if (TimeStartBLL.Instance.UpdateFilmTime(id, cost))
            {
                MessageBox.Show("Sửa giờ chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListTimeStart();
            }
            else
            {
                MessageBox.Show("Sửa giờ chiếu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtTimeID.Text;
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa giờ chiếu có ID là " + id + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (TimeStartBLL.Instance.DeleteFilmTime(id))
                {
                    MessageBox.Show("Xoá giờ chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListTimeStart();
                }
                else
                {
                    MessageBox.Show("Xoá giờ chiếu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {

        }
    }
}
