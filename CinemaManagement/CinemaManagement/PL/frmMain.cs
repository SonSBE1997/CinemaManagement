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
    public partial class frmMain : Form
    {
        private Account account;

        public Account Account
        {
            get
            {
                return account;
            }

            set
            {
                account = value;
            }
        }

        public frmMain(Account acc)
        {
            InitializeComponent();
            this.Account = acc;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (account.Type == 1)
                mniAdmin.Enabled = true;
        }

        private void mniExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mniAboutSoft_Click(object sender, EventArgs e)
        {
            StringBuilder about = new StringBuilder();
            about.AppendLine("     CINEMA MANAGEMENT v1.0     \n");
            about.AppendLine("   - Giáo viên hướng dẫn: ");
            about.AppendLine("               ThS Nguyễn Thu Hường");
            about.AppendLine("   - Sinh Viên thực hiện: ");
            about.AppendLine("              Vương Sỹ Sơn");
            about.AppendLine("              Đặng Tiến Mạnh");
            about.AppendLine("              Nguyễn Văn Thảo");
            about.AppendLine("    Liên hệ: ");
            about.AppendLine("          Email: ");
            about.AppendLine("          Số điện thoại: ");

            MessageBox.Show(about.ToString(), "About cinema management", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mniLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeAccount changeAccount = new frmChangeAccount(account);
            changeAccount.OnUpdatedAccount += ChangeAccount_OnUpdatedAccount;
            changeAccount.ShowDialog();
        }

        private void ChangeAccount_OnUpdatedAccount(object sender, AccountEvent e)
        {
            if (e.TypeUpdate == 1)
            {
                MessageBox.Show("Bạn cần đăng nhập lại!");
                this.Close();
            }
            else
            {
                account = AccountBLL.Instance.GetAccountByUsername(account.Username);
            }
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = "\r\tTHÔNG TIN NHÂN VIÊN\r\n\n\t- Tên đăng nhập: " + account.Username + "\r\n\t- Tên hiển thị: " + account.DisplayName + "\r\n\t- Chức vụ: ";
            if (account.Type == 0) str += "Nhân viên";
            else str += "Quản trị viên";
            MessageBox.Show(str, "About cinema management", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mniCompany_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmCompany"))
            {
                frmCompany company = new frmCompany();
                company.MdiParent = this;
                company.Show();
            }
            else
            {
                ActiveChilForm("frmCompany");
            }
        }


        #region Methods
        void ActiveChilForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    return;
                }
            }
        }
        bool CheckExistForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        private void mniCountry_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmCountry"))
            {
                frmCountry country = new frmCountry();
                country.MdiParent = this;
                country.Show();
            }
            else
            {
                ActiveChilForm("frmCountry");
            }
        }

        private void mniType_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmFilmType"))
            {
                frmFilmType filmType = new frmFilmType();
                filmType.MdiParent = this;
                filmType.Show();
            }
            else
            {
                ActiveChilForm("frmFilmType");
            }
        }

        private void mniHour_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmTimeStartFilm"))
            {
                frmTimeStartFilm filmStart = new frmTimeStartFilm();
                filmStart.MdiParent = this;
                filmStart.Show();
            }
            else
            {
                ActiveChilForm("frmTimeStartFilm");
            }
        }

        private void mniRoom_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmCinemaRoom"))
            {
                frmCinemaRoom cinemaRoom = new frmCinemaRoom();
                cinemaRoom.MdiParent = this;
                cinemaRoom.Show();
            }
            else
            {
                ActiveChilForm("frmCinemaRoom");
            }
        }

        private void mniCinema_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmCinema"))
            {
                frmCinema cinema = new frmCinema();
                cinema.MdiParent = this;
                cinema.Show();
            }
            else
            {
                ActiveChilForm("frmCinema");
            }
        }

        private void mniShowTime_Click(object sender, EventArgs e)
        {

        }

        private void mniShowingFilm_Click(object sender, EventArgs e)
        {

        }

        private void mniAllFilm_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmAllFilm"))
            {
                frmAllFilm listFilm = new frmAllFilm();
                listFilm.MdiParent = this;
                listFilm.Show();
            }
            else
            {
                ActiveChilForm("frmAllFilm");
            }
        }
    }
}
