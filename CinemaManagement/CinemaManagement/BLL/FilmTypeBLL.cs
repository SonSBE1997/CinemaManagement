using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.BLL
{
    public class FilmTypeBLL
    {
        private static FilmTypeBLL instance;

        public static FilmTypeBLL Instance
        {
            get
            {
                if (instance == null) instance = new FilmTypeBLL();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private FilmTypeBLL() { }

        public DataTable GetAllFilmType()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT matheloai AS [Mã thể loại], tentheloai AS [Tên thể loại] FROM dbo.TheLoai");
        }


        public bool CheckExistFilmTypeByID(string id)
        {
            return DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.TheLoai WHERE matheloai = '" + id + "'").Rows.Count > 0;
        }

        public bool DeleteFilmType(string id)
        {
            return DataProvider.Instance.ExcuteNonQuery("DELETE FROM dbo.TheLoai WHERE matheloai = '" + id + "'") > 0;
        }


        public bool UpdateFilmType(string id, string name)
        {
            return DataProvider.Instance.ExcuteNonQuery(string.Format("UPDATE dbo.TheLoai SET tentheloai = N'{0}' WHERE matheloai = '{1}'", name, id)) > 0;
        }

        public bool AddFilmType(string id, string name)
        {
            return DataProvider.Instance.ExcuteNonQuery(string.Format(" INSERT INTO dbo.TheLoai ( matheloai, tentheloai )VALUES( '{0}', N'{1}')", id, name)) > 0;
        }
    }
}
