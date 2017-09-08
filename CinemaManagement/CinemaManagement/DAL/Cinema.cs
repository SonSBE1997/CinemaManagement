using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.DAL
{
    public class Cinema
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int CountRoom { get; set; }

        public int CoutChair { get; set; }

        public Cinema(DataRow row)
        {
            this.ID = row["marap"].ToString();
            this.Name = row["tenrap"].ToString();
            this.Address = row["diachi"].ToString();
            this.PhoneNumber = row["dienthoai"].ToString();
            this.CountRoom = (int)row["sophong"];
            this.CoutChair = (int)row["tongsoghe"];
        }
    }
}
