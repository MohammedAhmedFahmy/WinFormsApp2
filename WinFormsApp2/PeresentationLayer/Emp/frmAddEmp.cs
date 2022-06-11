using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.DAL;
using WinFormsApp2.Properties;
using WinFormsApp2.Utils;

namespace WinFormsApp2.PeresentationLayer.Emp
{

    public partial class frmAddEmp : Form
    {
        public frmAddEmp()
        {
            InitializeComponent();
        }
        DAL.DataAccessLayer DataAccessLayer = new DAL.DataAccessLayer();
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picEmpImage.Image = new Bitmap(open.FileName);

            }
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void btnInsertIdentity_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picIdenty.Image = new Bitmap(open.FileName);
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&(e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void bunifuCustomTextbox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void btnInsertWorkCard_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picWordCard.Image = new Bitmap(open.FileName);
            }
        }

        private void btnInsertPassport_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picPassport.Image = new Bitmap(open.FileName);
            }
        }

        private void frmAddEmp_Load(object sender, EventArgs e)
        {
            txtEmpCode.Text = DataAccessLayer.getMax("Employees").ToString();
            DataTable dtCompaniesName = DataAccessLayer.orderDataTable("select * from Companies where type = 'Company' ");
            for(int i = 0; i < dtCompaniesName.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = dtCompaniesName.Rows[i][1].ToString();
                item.Value = dtCompaniesName.Rows[i][0].ToString();
                comboCompany.Items.Add(item);
            }
            darkMode();
           
        }

        private void comboNationality_DrawItem(object sender, DrawItemEventArgs e)
        {
           
        }
        
        void darkMode()
        {

            if (vars.darkMode == true)
            {
                btnDarlMode.Image = Resources.lightMoon;
                this.BackColor = Color.FromArgb(17, 45, 78);
                foreach (Control x in this.Controls)
                {
                    if (x is Label)
                    {
                        x.ForeColor = Color.White;
                    }
                }
                foreach (Control x in groupBox1.Controls)
                {
                    if (x is Label)
                    {
                        x.ForeColor = Color.White;
                    }
                }
                foreach (Control x in groupBox2.Controls)
                {
                    if (x is Label)
                    {
                        x.ForeColor = Color.White;
                    }
                }
                foreach (Control x in groupBox3.Controls)
                {
                    if (x is Label)
                    {
                        x.ForeColor = Color.White;
                    }
                }
                groupBox1.ForeColor = Color.White;
                groupBox2.ForeColor = Color.White;
                groupBox3.ForeColor = Color.White;


            }
            if (vars.darkMode == false)
            {
                btnDarlMode.Image = Resources.darkMoon;
                this.BackColor = Color.FromArgb(249, 247, 247);
                foreach (Control x in this.Controls)
                {
                    if (x is Label)
                    {
                        x.ForeColor = Color.Black;
                    }
                }
                foreach (Control x in groupBox1.Controls)
                {
                    if (x is Label)
                    {
                        x.ForeColor = Color.Black;
                    }
                }
                foreach (Control x in groupBox2.Controls)
                {
                    if (x is Label)
                    {
                        x.ForeColor = Color.Black;
                    }
                }
                foreach (Control x in groupBox3.Controls)
                {
                    if (x is Label)
                    {
                        x.ForeColor = Color.Black;
                    }
                }
                groupBox1.ForeColor = Color.Black;
                groupBox2.ForeColor = Color.Black;
                groupBox3.ForeColor = Color.Black;

            }

            
        }

        private void btnDarlMode_Click(object sender, EventArgs e)
        {
            vars.darkMode = !vars.darkMode;
            darkMode();
        }

        private void txtEmail_Validated(object sender, EventArgs e)
        {
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");
            if (txtEmail.Text != "")
            {
                if (!validateEmailRegex.IsMatch(txtEmail.Text))
                {
                    this.Alert("البريد الالكتروني غير صحيح", Form_Alert.enmType.Error);
                    txtEmail.Focus();
                }

            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
