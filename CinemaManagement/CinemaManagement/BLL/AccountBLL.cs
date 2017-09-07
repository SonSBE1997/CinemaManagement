using CinemaManagement.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.BLL
{
    public class AccountBLL
    {
        private static AccountBLL instance;

        public static AccountBLL Instance
        {
            get
            {
                if (instance == null) instance = new AccountBLL();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private AccountBLL() { }


        public bool CheckLogin(string username, string password)
        {
            DataTable result = DataProvider.Instance.ExcuteQuery("EXEC dbo.USP_Login  @username , @password", new object[] { username, password });
            return result.Rows.Count > 0;
        }

        public List<Account> GetAllAcount()
        {
            List<Account> listAccount = new List<Account>();
            DataTable table = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.TaiKhoan");
            foreach (DataRow item in table.Rows)
            {
                listAccount.Add(new Account(item));
            }
            return listAccount;
        }

        public int RegisterAccount(string username, string password, string displayName)
        {
            password = Encryptor.MD5Hash(password);
            string query = string.Format("INSERT INTO dbo.TaiKhoan ( userName, password, tenhienthi ) VALUES  ( '{0}','{1}', N'{2}' )", username, password, displayName);
            return DataProvider.Instance.ExcuteNonQuery(query);
        }

        public Account GetAccountByUsername(string username)
        {
            string query = "SELECT * FROM dbo.TaiKhoan WHERE userName = '" + username + "'";
            DataTable result = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in result.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public bool UpdateAccount(string username, string displayName, string pass, string newPass)
        {
            string query;
            if (string.IsNullOrEmpty(newPass))
            {
                query = "UPDATE dbo.TaiKhoan SET tenhienthi = N'" + displayName + "' WHERE userName = '" + username + "'";
            }
            else query = "UPDATE dbo.TaiKhoan SET tenhienthi = N'" + displayName + "', password = '" + Encryptor.MD5Hash(newPass) + "' WHERE userName = '" + username + "'";
            return DataProvider.Instance.ExcuteNonQuery(query) > 0;
        }
    }
}
