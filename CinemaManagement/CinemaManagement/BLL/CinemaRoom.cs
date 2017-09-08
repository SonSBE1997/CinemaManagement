using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.BLL
{
    public class CinemaRoom
    {
        private static CinemaRoom instance;

        public static CinemaRoom Instance
        {
            get
            {
                if (instance == null) instance = new CinemaRoom();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private CinemaRoom() { }


    }
}
