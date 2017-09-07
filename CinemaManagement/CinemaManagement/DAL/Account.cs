using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.DAL
{
    public class Account
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public int Type { get; set; }

        public Account(DataRow row)
        {
            Username = row["username"].ToString();
            Password = row["password"].ToString();
            DisplayName = row["tenhienthi"].ToString();
            Type = (int)row["loaitaikhoan"];
        }
    }
}
