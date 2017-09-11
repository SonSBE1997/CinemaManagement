using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.BLL
{
    public class TimeStartBLL
    {
        private static TimeStartBLL instance;

        public static TimeStartBLL Instance
        {
            get
            {
                if (instance == null) instance = new TimeStartBLL();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private TimeStartBLL() { }

        public DataTable GetAllFilmTime()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT magiochieu as [Mã giờ chiếu], dongia as [Đơn giá] FROM dbo.GioChieu");
        }

        public bool CheckExistFilmTime(string id)
        {
            return DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.GioChieu WHERE magiochieu = '" + id + "'").Rows.Count > 0;
        }

        public bool DeleteFilmTime(string id)
        {
            return DataProvider.Instance.ExcuteNonQuery("EXEC dbo.USP_XoaGioChieu @magiochieu", new object[] { id }) > 0;
        }


        public bool UpdateFilmTime(string id, int cost)
        {
            return DataProvider.Instance.ExcuteNonQuery(string.Format("UPDATE dbo.GioChieu SET dongia = {0} WHERE magiochieu = '{1}'", cost, id)) > 0;
        }

        public bool AddFilmTime(string id, int cost)
        {
            return DataProvider.Instance.ExcuteNonQuery(string.Format("INSERT INTO dbo.GioChieu ( magiochieu, dongia )VALUES( '{0}', {1})", id, cost)) > 0;
        }


    }
}
