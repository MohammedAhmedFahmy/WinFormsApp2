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

                DataTable dt = dataAccessLayer.order("select * from users where user_name = '" + txtUserName.Text + "' and user_password='" + txtPassword.Text + "'  ");
                if (dt.Rows.Count > 0)
                {
                    DAL.vars.loginName = txtUserName.Text;
                    Form1 f = new Form1();
                    this.Hide();
                    f.ShowDialog();

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
    }
}
