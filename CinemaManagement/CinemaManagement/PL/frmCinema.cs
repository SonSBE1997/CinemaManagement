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
    public partial class frmCinema : Form
    {

        BindingSource source = new BindingSource();

        public frmCinema()
        {
            InitializeComponent();
            dtgvCinema.DataSource = source;
            LoadListCinema();
            LoadDataBinding();
        }

        private void LoadDataBinding()
        {
            txtCinemaID.DataBindings.Add(new Binding("Text", dtgvCinema.DataSource, "Mã rạp", true, DataSourceUpdateMode.Never));
            txtCinemaName.DataBindings.Add(new Binding("Text", dtgvCinema.DataSource, "Tên rạp", true, DataSourceUpdateMode.Never));
            txtCinemaAddress.DataBindings.Add(new Binding("Text", dtgvCinema.DataSource, "Địa chỉ", true, DataSourceUpdateMode.Never));
            txtCinemaPhoneNumber.DataBindings.Add(new Binding("Text", dtgvCinema.DataSource, "Số điện thoại", true, DataSourceUpdateMode.Never));
            txtCountCinemaRoom.DataBindings.Add(new Binding("Text", dtgvCinema.DataSource, "Số phòng", true, DataSourceUpdateMode.Never));
            txtCountChair.DataBindings.Add(new Binding("Text", dtgvCinema.DataSource, "Tổng số ghế", true, DataSourceUpdateMode.Never));
        }

        private void LoadListCinema()
        {
            source.DataSource = CinemaBLL.Instance.GetAllCinema();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtCinemaID.Text;
            if (CinemaBLL.Instance.CheckExistCinemaByID(id))
            {
                MessageBox.Show("Mã rạp đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtCinemaName.Text;
            string address = txtCinemaAddress.Text;
            string phoneNumber = txtCinemaPhoneNumber.Text;
            int room = Int32.Parse(txtCountCinemaRoom.Text);
            if (CinemaBLL.Instance.AddCinema(id, name, address, phoneNumber, room))
            {
                MessageBox.Show("Thêm rạp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListCinema();
            }
            else MessageBox.Show("Thêm rạp thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = txtCinemaID.Text;
            string name = txtCinemaName.Text;
            string address = txtCinemaAddress.Text;
            string phoneNumber = txtCinemaPhoneNumber.Text;
            int room = Int32.Parse(txtCountCinemaRoom.Text);
            if (CinemaBLL.Instance.UpdateCinema(id, name, address, phoneNumber, room))
            {
                MessageBox.Show("Sửa thông tin rạp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListCinema();
            }
            else MessageBox.Show("Sửa thông tin rạp thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtCinemaID.Text;
            DialogResult result = MessageBox.Show("Bạn có muốn xóa rạp có ID là " + id + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (CinemaBLL.Instance.DeleteCinema(id))
                {
                    MessageBox.Show("Xóa rạp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListCinema();
                }
                else MessageBox.Show("Xóa rạp thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
