using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.DAL
{
    public class Film
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string CountryName { get; set; }

        public string CompanyName { get; set; }

        public string Director { get; set; }

        public string FileType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string MainActress { get; set; }

        public string MainActor { get; set; }

        public string MainContent { get; set; }

        public long TotalCost { get; set; }

        public long TotalRevenue { get; set; }

        public Film(DataRow row)
        {
            this.ID = row["maphim"].ToString();
            this.Name = row["tenphim"].ToString();
            this.CountryName = row["tennuocsx"].ToString();
            this.CompanyName = row["tenhangsx"].ToString();
            this.Director = row["daodien"].ToString();
            this.FileType = row["tentheloai"].ToString();
            this.StartDate = (DateTime)row["ngaykhoichieu"];
            this.EndDate = (DateTime)row["ngayketthuc"];
            this.MainActress = row["nudienvienchinh"].ToString();
            this.MainActor = row["namdienvienchinh"].ToString();
            this.MainContent = row["noidungchinh"].ToString();
            this.TotalCost = (long)row["tongchiphi"];
            this.TotalRevenue = (long)row["tongthu"];
        }
    }
}
