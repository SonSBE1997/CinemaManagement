using CinemaManagement.BLL;
using CinemaManagement.DAL;
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
    public partial class frmCinemaRoom : Form
    {
        BindingSource source = new BindingSource();
        public frmCinemaRoom()
        {
            InitializeComponent();
            dtgvCinemaRoom.DataSource = source;
            LoadListCinemaRoom();
            LoadSourceComboBox();
            LoadDataBinding();
        }

        private void LoadSourceComboBox()
        {
            cbCinemaName.DataSource = CinemaBLL.Instance.GetListCinema();
            cbCinemaName.DisplayMember = "Name";
            SelectedCinema();
        }

        private void LoadDataBinding()
        {
            txtRoomID.DataBindings.Add("Text", dtgvCinemaRoom.DataSource, "Mã phòng", true, DataSourceUpdateMode.Never);
            txtRoomName.DataBindings.Add("Text", dtgvCinemaRoom.DataSource, "Tên phòng", true, DataSourceUpdateMode.Never);
            txtSeats.DataBindings.Add("Text", dtgvCinemaRoom.DataSource, "Số ghế", true, DataSourceUpdateMode.Never);

        }

        private void LoadListCinemaRoom()
        {
            source.DataSource = CinemaRoomBLL.Instance.GetAllCinemaRoom();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtRoomID.Text;
            DialogResult result = MessageBox.Show("Bạn có muốn xóa phòng chiếu có ID là " + id + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (CinemaRoomBLL.Instance.DeleteCinemaRoom(id))
                {
                    MessageBox.Show("Xóa phòng chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListCinemaRoom();
                }
                else MessageBox.Show("Xóa phòng chiếu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtRoomID.Text;
            string name = txtRoomName.Text;
            int seats = Int32.Parse(txtSeats.Text);
            string cinemaID = (cbCinemaName.SelectedItem as Cinema).ID;

            if (CinemaRoomBLL.Instance.UpdateCinemaRoom(id, name, seats, cinemaID))
            {
                MessageBox.Show("Sửa phòng chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListCinemaRoom();
            }
            else MessageBox.Show("Sửa phòng chiếu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtRoomID.Text;
            if (CinemaRoomBLL.Instance.CheckExistCinemaRoomByID(id))
            {
                MessageBox.Show("Mã phòng chiếu đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtRoomName.Text;
            int seats = Int32.Parse(txtSeats.Text);
            string cinemaID = (cbCinemaName.SelectedItem as Cinema).ID;

            if (CinemaRoomBLL.Instance.AddCinemaRoom(id, name, seats, cinemaID))
            {
                MessageBox.Show("Thêm phòng chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListCinemaRoom();
            }
            else MessageBox.Show("Thêm phòng chiếu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtSeats_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                MessageBox.Show("Bạn phải nhập số ghế là số");
                e.Handled = true;
            }
        }

        void SelectedCinema()
        {
            string cinemaName = dtgvCinemaRoom.SelectedRows[0].Cells["Rạp chiếu phim"].Value.ToString();
            foreach (var item in cbCinemaName.Items)
            {
                if ((item as Cinema).Name == cinemaName) cbCinemaName.SelectedItem = item;
            }
        }

        private void txtRoomID_TextChanged(object sender, EventArgs e)
        {
            SelectedCinema();
        }
    }
}
