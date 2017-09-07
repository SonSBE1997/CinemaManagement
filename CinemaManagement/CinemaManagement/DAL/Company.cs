using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.DAL
{
    public class Company
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public Company(DataRow row)
        {
            this.ID = row["mahangsx"].ToString();
            this.Name = row["tenhangsx"].ToString();
        }

        public Company(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
