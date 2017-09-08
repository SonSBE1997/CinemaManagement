using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.BLL
{
    public class CountryBLL
    {
        private static CountryBLL instance;

        public static CountryBLL Instance
        {
            get
            {
                if (instance == null) instance = new CountryBLL();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private CountryBLL() { }

        public DataTable GetAllCountry()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT manuocsx AS [Mã nước sản xuất],tennuocsx AS [Tên nước sản xuất] FROM dbo.NuocSanXuat");
        }


        public bool CheckExistCountryByID(string id)
        {
            return DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.NuocSanXuat WHERE manuocsx = '" + id + "'").Rows.Count > 0;
        }

        public bool DeleteCountry(string id)
        {
            return DataProvider.Instance.ExcuteNonQuery("DELETE FROM dbo.NuocSanXuat WHERE manuocsx = '" + id + "'") > 0;
        }


        public bool UpdateCountry(string id, string name)
        {
            return DataProvider.Instance.ExcuteNonQuery(string.Format("UPDATE dbo.NuocSanXuat SET tennuocsx = N'{0}' WHERE manuocsx = '{1}'", name, id)) > 0;
        }

        public bool AddCountry(string id, string name)
        {
            return DataProvider.Instance.ExcuteNonQuery(string.Format(" INSERT INTO dbo.NuocSanXuat ( manuocsx, tennuocsx )VALUES( '{0}', N'{1}')", id, name)) > 0;
        }
    }
}
