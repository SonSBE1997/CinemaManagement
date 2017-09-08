using CinemaManagement.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.BLL
{
    public class CompanyBLL
    {
        private static CompanyBLL instance;

        public static CompanyBLL Instance
        {
            get
            {
                if (instance == null) instance = new CompanyBLL();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private CompanyBLL() { }

        public DataTable GetAllCompany()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT mahangsx as [Mã hãng sản xuất], tenhangsx as [Tên hãng sản xuất] FROM dbo.HangSX");
        }

        public bool CheckExistCompanyByID(string id)
        {
            return DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.HangSX WHERE mahangsx = '" + id + "'").Rows.Count > 0;
        }

        public bool DeleteCompany(string id)
        {
            return DataProvider.Instance.ExcuteNonQuery("DELETE FROM dbo.HangSX WHERE mahangsx = '" + id + "'") > 0;
        }


        public bool UpdateCompany(string id, string name)
        {
            return DataProvider.Instance.ExcuteNonQuery(string.Format("UPDATE dbo.HangSX SET tenhangsx = N'{0}' WHERE mahangsx = '{1}'", name, id)) > 0;
        }

        public bool AddCompany(string id, string name)
        {
            return DataProvider.Instance.ExcuteNonQuery(string.Format(" INSERT INTO dbo.HangSX ( mahangsx, tenhangsx )VALUES( '{0}', N'{1}')", id, name)) > 0;
        }

    }
}

