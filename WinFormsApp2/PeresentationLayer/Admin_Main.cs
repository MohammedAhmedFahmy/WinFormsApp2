using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.DAL;

namespace WinFormsApp2.PeresentationLayer
{
    public partial class Admin_Main : Form
    {
        public Admin_Main()
        {
            InitializeComponent();
        }

        private void Admin_Main_Load(object sender, EventArgs e)
        {
            darkMode();
        }
        void darkMode()
        {
            if (vars.darkMode == true)
            {
                this.BackColor = Color.FromArgb(17, 45, 78);

            }
            if (vars.darkMode == false)
            {
                this.BackColor = Color.FromArgb(249, 247, 247);

            }
        }
    }
}
