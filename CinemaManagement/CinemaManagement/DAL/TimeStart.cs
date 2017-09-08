using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.DAL
{
    public class TimeStart
    {
        public string ID { get; set; }

        public int Cost { get; set; }

        public TimeStart(DataRow row)
        {
            this.ID = row["magiochieu"].ToString();
            this.Cost = (int)row["dongia"];
        }
    }
}
