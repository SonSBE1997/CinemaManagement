using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.BLL
{
    public class CinemaRoomBLL
    {
        private static CinemaRoomBLL instance;

        public static CinemaRoomBLL Instance
        {
            get
            {
                if (instance == null) instance = new CinemaRoomBLL();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private CinemaRoomBLL() { }

        public DataTable GetAllCinemaRoom()
        {
            string query = "SELECT r.tenrap AS [Rạp chiếu phim],pc.maphong AS [Mã phòng], pc.tenphong AS [Tên phòng],pc.soghe AS [Số ghế] FROM dbo.Rap AS r JOIN dbo.PhongChieu AS pc ON pc.marap = r.marap";
            return DataProvider.Instance.ExcuteQuery(query);
        }

        public bool CheckExistCinemaRoomByID(string id)
        {
            return DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.PhongChieu WHERE maphong = '" + id + "'").Rows.Count > 0;
        }

        public bool DeleteCinemaRoom(string id)
        {
            return DataProvider.Instance.ExcuteNonQuery("DELETE FROM dbo.PhongChieu WHERE maphong = '" + id + "'") > 0;
        }

        public bool AddCinemaRoom(string id, string name, int seats, string cinemaID)
        {
            string query = String.Format("INSERT INTO dbo.PhongChieu( marap, maphong, tenphong, soghe ) VALUES  ( '{0}', '{1}', N'{2}', {3})", cinemaID, id, name, seats);
            return DataProvider.Instance.ExcuteNonQuery(query) > 0;
        }

        public bool UpdateCinemaRoom(string id, string name, int seats, string cinemaID)
        {
            string query = String.Format("UPDATE dbo.PhongChieu SET marap = '{0}',tenphong='{1}',soghe ={2} WHERE maphong = '{3}'", cinemaID, name, seats, id);
            return DataProvider.Instance.ExcuteNonQuery(query) > 0;
        }
    }
}
