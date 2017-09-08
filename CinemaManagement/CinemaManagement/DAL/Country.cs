using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.DAL
{
    public class Country
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public Country(DataRow row)
        {
            this.ID = row["manuocsx"].ToString();
            this.Name = row["tennuocsx"].ToString();
        }
    }
}
