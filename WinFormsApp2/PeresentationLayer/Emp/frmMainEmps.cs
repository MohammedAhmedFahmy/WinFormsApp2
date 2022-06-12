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

namespace WinFormsApp2.PeresentationLayer.Emp
{
    public partial class frmMainEmps : Form
    {
        public frmMainEmps()
        {
            darkMode();
            InitializeComponent();
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

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            frmAddEmp frmAddEmp = new frmAddEmp();
            frmAddEmp.ShowDialog();
            darkMode();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            frmEmpsList frmEmpsList = new frmEmpsList();
            frmEmpsList.ShowDialog();
            darkMode();
        }
    }
}
