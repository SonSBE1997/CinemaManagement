using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaManagement.PL
{
    public partial class frmAllFilm : Form
    {
        public frmAllFilm()
        {
            InitializeComponent();
        }

        private void frmAllFilm_Load(object sender, EventArgs e)
        {
            cbCompany.SelectedIndex = -1;
            cbFilmType.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
