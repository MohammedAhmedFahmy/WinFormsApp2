using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.DAL;
using WinFormsApp2.PeresentationLayer;
using WinFormsApp2.Properties;
using WinFormsApp2.Utils;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            darkMode();
            lblUserName.Text = vars.loginName;
            this.Alert("تم تسجيل الدخول بنجاح", Form_Alert.enmType.Success);
            timer1.Start();
            String nowDate = DateTime.Now.ToString("dd MMM yyyy");
            String loginTime = DateTime.Now.ToString("hh:mm:ss tt");
            lblDate.Text = nowDate;
            lblLoginTime.Text = loginTime;

        }

        void darkMode()
        {
            if (vars.darkMode == true)
            {
                this.BackColor = Color.FromArgb(17, 45, 78);
                pictureBox1.Image = Resources.lightMoon;

            }
            if (vars.darkMode == false)
            {
                this.BackColor = Color.FromArgb(249, 247, 247);
                pictureBox1.Image = Resources.darkMoon;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Alert("نحن سعداء بعودتك", Form_Alert.enmType.Love);
            timer1.Stop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            vars.darkMode = !vars.darkMode;
            darkMode();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_Login frm_ = new frm_Login();
            frm_.Show();
        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
