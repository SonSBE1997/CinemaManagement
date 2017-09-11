using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.DAL
{
    public class CinemaRoom
    {
        public string CinemaID { get; set; }

        public string ID { get; set; }

        public string Name { get; set; }

        public int Seats { get; set; }

        public CinemaRoom(DataRow row)
        {
            this.CinemaID = row["marap"].ToString();
            this.ID = row["maphong"].ToString();
            this.Name = row["tenphong"].ToString();
            this.Seats = (int)row["soghe"];
        }
    }
}
