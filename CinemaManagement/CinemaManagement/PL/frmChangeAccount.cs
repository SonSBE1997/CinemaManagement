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
    public partial class frmChangeAccount : Form
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

        private event EventHandler<AccountEvent> _onUpdatedAccount;
        public event EventHandler<AccountEvent> OnUpdatedAccount
        {
            add { _onUpdatedAccount += value; }
            remove { _onUpdatedAccount -= value; }
        }

        public frmChangeAccount(Account acc)
        {
            InitializeComponent();
            this.Account = acc;
            LoadInfoAccount();
        }

        void LoadInfoAccount()
        {
            txtUsername.Text = account.Username;
            txtDisplayName.Text = account.DisplayName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }

        private void UpdateAccount()
        {
            string username = txtUsername.Text;
            string displayName = txtDisplayName.Text;
            string password = Encryptor.MD5Hash(txtPassword.Text);
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text;

            if (!checkPass(password, newPass, confirmPass)) return;

            if (AccountBLL.Instance.UpdateAccount(username, displayName, password, newPass))
            {
                MessageBox.Show("Cập nhật thành công!");
                if (_onUpdatedAccount != null)
                {
                    if (newPass.Equals(""))
                        _onUpdatedAccount(this, new AccountEvent(AccountBLL.Instance.GetAccountByUsername(username), 0));
                    else _onUpdatedAccount(this, new AccountEvent(AccountBLL.Instance.GetAccountByUsername(username), 1));
                }
                this.Close();
            }
        }

        private bool checkPass(string password, string newPass, string confirmPass)
        {
            if (!password.Equals(account.Password))
            {
                MessageBox.Show("Mật khẩu không đúng!");
                return false;
            }

            if (!newPass.Equals(confirmPass))
            {
                MessageBox.Show("Mật khẩu mới không khớp");
                return false;
            }

            if (txtPassword.Text.Equals(newPass))
            {
                MessageBox.Show("Bạn không thể đặt mật khẩu mới trùng với mật khẩu hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }


    public class AccountEvent : EventArgs
    {
        private Account acc;
        private int typeUpdate;

        public Account Acc
        {
            get
            {
                return acc;
            }

            set
            {
                acc = value;
            }
        }

        public int TypeUpdate
        {
            get
            {
                return typeUpdate;
            }

            set
            {
                typeUpdate = value;
            }
        }

        public AccountEvent(Account account)
        {
            this.Acc = account;
        }

        public AccountEvent(Account account, int type)
        {
            this.Acc = account;
            this.TypeUpdate = type;
        }
    }
}
