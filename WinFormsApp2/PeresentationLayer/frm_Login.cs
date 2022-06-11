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
using WinFormsApp2.Properties;
using WinFormsApp2.Utils;

namespace WinFormsApp2.PeresentationLayer
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            darkMode();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            login();
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        DataAccessLayer dataAccessLayer = new DataAccessLayer();
        void login()
        {
            if (txtUserName.Text.Trim() != "" && txtPassword.Text != "")
            {

                DataTable dt = dataAccessLayer.orderDataTable("select * from Users where user_name = '" + txtUserName.Text + "' and user_password='" + txtPassword.Text + "'  ");
                if (dt.Rows.Count > 0)
                {

                    DAL.vars.loginName = txtUserName.Text;
                    DAL.vars.loginSort = dt.Rows[0][3].ToString();
                    if(DAL.vars.loginSort == "admin")
                    {
                        Admin_Main admin_Main = new Admin_Main();
                        admin_Main.Show();
                    }
                    else
                    {
                        Form1 f = new Form1();
                        f.ShowDialog();

                    }
                    this.Hide();

                }
                else
                {
                    this.Alert("البيانات غير صحيحة", Form_Alert.enmType.Error);
                }

            }
            else
            {
                this.Alert("أكمل البيانات من فضلك", Form_Alert.enmType.Warning);

            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) { 
                login();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            vars.darkMode = !vars.darkMode;
            darkMode();
        }
        public void darkMode()
        {
            if (vars.darkMode == true)
            {
                txtUserName.BackColor = Color.FromArgb(63, 114, 175);
                txtPassword.BackColor = Color.FromArgb(63, 114, 175);
                pictureBox1.Image = Resources.lightMoon;
                this.BackColor = Color.FromArgb(17, 45, 78);
                label1.ForeColor = Color.FromArgb(249, 247, 247);
                label2.ForeColor = Color.FromArgb(249, 247, 247);
                txtUserName.ForeColor = Color.White;
                txtPassword.ForeColor = Color.White;




            }
            if (vars.darkMode == false)
            {
                
                pictureBox1.Image = Resources.darkMoon;
                this.BackColor = Color.FromArgb(249, 247, 247);
                label1.ForeColor = Color.FromArgb(17, 45, 78);
                label2.ForeColor = Color.FromArgb(17, 45, 78);

                txtUserName.BackColor = Color.FromArgb(219, 226, 239);
                txtPassword.BackColor = Color.FromArgb(219, 226, 239);
                txtUserName.ForeColor = Color.Black;
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }
    }
}
