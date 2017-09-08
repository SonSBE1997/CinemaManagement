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
    public partial class frmFilmType : Form
    {
        BindingSource source = new BindingSource();

        public frmFilmType()
        {
            InitializeComponent();
            dtgvFilmType.DataSource = source;
            LoadListFileType();
            LoadDataBinding();
        }

        private void LoadDataBinding()
        {
            txtTypeID.DataBindings.Add(new Binding("Text", dtgvFilmType.DataSource, "Mã thể loại", true, DataSourceUpdateMode.Never));
            txtTypeName.DataBindings.Add(new Binding("Text", dtgvFilmType.DataSource, "Tên thể loại", true, DataSourceUpdateMode.Never));
        }

        private void LoadListFileType()
        {
            source.DataSource = FilmTypeBLL.Instance.GetAllFilmType();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtTypeID.Text;
            string name = txtTypeName.Text;

            if (FilmTypeBLL.Instance.CheckExistFilmTypeByID(id))
            {
                MessageBox.Show("Mã thể loại phim đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (FilmTypeBLL.Instance.AddFilmType(id, name))
            {
                MessageBox.Show("Thêm thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListFileType();
            }
            else
            {
                MessageBox.Show("Thêmthể loại thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtTypeID.Text;
            string name = txtTypeName.Text;

            if (FilmTypeBLL.Instance.UpdateFilmType(id, name))
            {
                MessageBox.Show("Sửa thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListFileType();
            }
            else
            {
                MessageBox.Show("Sửa thể loại thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtTypeID.Text;
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa thể loại có ID là " + id + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (FilmTypeBLL.Instance.DeleteFilmType(id))
                {
                    MessageBox.Show("Xoá thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListFileType();
                }
                else
                {
                    MessageBox.Show("Xoá thể loại thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadListFileType();
        }
    }
}
