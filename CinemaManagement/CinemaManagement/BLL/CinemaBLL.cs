using CinemaManagement.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.BLL
{
    public class CinemaBLL
    {
        private static CinemaBLL instance;

        public static CinemaBLL Instance
        {
            get
            {
                if (instance == null) instance = new CinemaBLL();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private CinemaBLL() { }

        public DataTable GetAllCinema()
        {
            string query = "SELECT marap AS [Mã rạp], tenrap AS [Tên rạp] , diachi AS [Địa chỉ] , dienthoai AS [Số điện thoại], sophong AS [Số phòng],tongsoghe AS [Tổng số ghế] FROM dbo.Rap";
            return DataProvider.Instance.ExcuteQuery(query);
        }

        public List<Cinema> GetListCinema()
        {
            List<Cinema> list = new List<Cinema>();
            DataTable table = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Rap");
            foreach (DataRow item in table.Rows)
            {
                list.Add(new Cinema(item));
            }

            return list;
        }

        public bool CheckExistCinemaByID(string id)
        {
            return DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Rap WHERE marap = '" + id + "'").Rows.Count > 0;
        }

        public bool AddCinema(string id, string name, string address, string phoneNumber, int room)
        {
            string query = string.Format("INSERT INTO dbo.Rap( marap, tenrap, diachi, dienthoai, sophong) VALUES( '{0}', N'{1}', N'{2}', '{3}', {4})", id, name, address, phoneNumber, room);
            return DataProvider.Instance.ExcuteNonQuery(query) > 0;
        }


        public bool UpdateCinema(string id, string name, string address, string phoneNumber, int room)
        {
            string query = string.Format("UPDATE dbo.Rap SET tenrap=N'{0}',diachi=N'{1}',dienthoai='{2}',sophong={3} WHERE marap ='{4}'", name, address, phoneNumber, room, id);
            return DataProvider.Instance.ExcuteNonQuery(query) > 0;
        }

        public bool DeleteCinema(string id)
        {
            return DataProvider.Instance.ExcuteNonQuery("DELETE FROM dbo.Rap WHERE marap = '" + id + "'") > 0;
        }

        public Cinema GetCinemaByID(string id)
        {
            DataTable table = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Rap WHERE marap = '" + id + "'");
            foreach (DataRow item in table.Rows)
            {
                return new Cinema(item);
            }
            return null;
        }

        public Cinema GetCinemaByName(string name)
        {
            DataTable table = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Rap WHERE tenrap = N'" + name + "'");
            foreach (DataRow item in table.Rows)
            {
                return new Cinema(item);
            }
            return null;
        }
    }
}
