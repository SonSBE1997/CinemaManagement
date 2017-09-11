using CinemaManagement.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.BLL
{
    public class FilmBLL
    {
        private static FilmBLL instance;

        public static FilmBLL Instance
        {
            get
            {
                if (instance == null) instance = new FilmBLL();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private FilmBLL() { }

        public List<Film> GetAllFilm()
        {
            List<Film> list = new List<Film>();
            DataTable table = DataProvider.Instance.ExcuteQuery("EXEC dbo.USP_GetAllFilm");
            foreach (DataRow item in table.Rows)
            {
                list.Add(new Film(item));
            }
            return list;
        }
    }
}
