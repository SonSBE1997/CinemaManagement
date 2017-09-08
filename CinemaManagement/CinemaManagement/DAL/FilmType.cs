using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.DAL
{
    public class FilmType
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public FilmType(DataRow row)
        {
            this.ID = row["matheloai"].ToString();
            this.Name = row["tentheloai"].ToString();
        }
    }
}
