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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegisterAccount register = new frmRegisterAccount();
            register.OnRegisted += Register_OnRegisted;
            register.ShowDialog();
        }

        private void Register_OnRegisted(object sender, EventArgs e)
        {
            SuggestUsername();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = Encryptor.MD5Hash(txtPassword.Text);
            if (AccountBLL.Instance.CheckLogin(username, password))
            {
                frmMain main = new frmMain(AccountBLL.Instance.GetAccountByUsername(username));
                this.Hide();
                main.ShowDialog();
                try
                {
                    this.Show();
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) e.Cancel = true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            SuggestUsername();
        }

        void SuggestUsername()
        {
            AutoCompleteStringCollection acscAccount = new AutoCompleteStringCollection();
            foreach (Account account in AccountBLL.Instance.GetAllAcount())
            {
                acscAccount.Add(account.Username);
            }
            txtUsername.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtUsername.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtUsername.AutoCompleteCustomSource = acscAccount;
        }
    }
}
