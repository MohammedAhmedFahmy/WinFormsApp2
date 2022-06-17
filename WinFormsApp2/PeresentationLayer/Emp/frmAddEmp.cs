using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
        String customSelectedValue ="";
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
            initForm();
            darkMode();


        }

        private void comboNationality_DrawItem(object sender, DrawItemEventArgs e)
        {
           
        }
        void initForm()
        {
            
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    x.Text = "";
                }
            }
            comboCompany.SelectedItem = "";
            comboNationality.SelectedItem = "";
            txtIdentityNumber.Text = "";
            txtPassportNumber.Text = "";
            txtWorkCardNumber.Text = "";
            picIdenty.Image = Properties.Resources.x_office_document_icon;
            picPassport.Image = Properties.Resources.x_office_document_icon;
            picWordCard.Image = Properties.Resources.x_office_document_icon;
            picEmpImage.Image = Properties.Resources._912214;

            txtEmpCode.Text = DataAccessLayer.getMax("Employees").ToString();
            DataTable dtCompaniesName = DataAccessLayer.orderDataTable("select * from Companies where type = 'Company' ");
            for (int i = 0; i < dtCompaniesName.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = dtCompaniesName.Rows[i][1].ToString();
                item.Value = dtCompaniesName.Rows[i][0].ToString();
                comboCompany.Items.Add(item);
            }

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

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            if (txtEmpName.Text.Trim() == "" || txtMobile.Text.Trim() == "" || txtEmail.Text.Trim() == "" || 
                comboNationality.Text.Trim() == "" || txtJob.Text.Trim() == "" || comboCompany.Text.Trim() == "" 
                || txtSalary.Text.Trim() == "" || txtIdentityNumber.Text.Trim() == "" || txtWorkCardNumber.Text.Trim() == "" 
                || txtPassportNumber.Text.Trim() == "") {
                this.Alert("برجاء إكمال البيانات", Form_Alert.enmType.Warning);

            }
            else
            {
                addEmp();
            }
        }
        void addEmp()
        {
            try
            {
                SqlConnection sqlconnection;
                sqlconnection = DataAccessLayer.sqlconnection;
                sqlconnection.Open();

                //Image Emp
                MemoryStream MS = new MemoryStream();
                picEmpImage.Image.Save(MS, ImageFormat.Png);
                byte[] byteImageEmp = MS.ToArray();

                //Image Identity
                MemoryStream MSIdentity = new MemoryStream();
                picIdenty.Image.Save(MSIdentity, ImageFormat.Png);
                byte[] byteImageIdentity = MSIdentity.ToArray();

                //Image WorkCard
                MemoryStream MSWorkCard = new MemoryStream();
                picWordCard.Image.Save(MSWorkCard, ImageFormat.Png);
                byte[] byteImageWorkCard = MSWorkCard.ToArray();

                //Image Passport
                MemoryStream MSPassport = new MemoryStream();
                picPassport.Image.Save(MSPassport, ImageFormat.Png);
                byte[] byteImagPassport = MSPassport.ToArray();

                //Add Query To Employees Table
                string sqlQuery1 = ("insert into Employees values(" + txtEmpCode.Text + ",N'" + txtEmpName.Text + "','" + txtIdentityNumber.Text + "' ,'" + txtWorkCardNumber.Text + "','" + txtPassportNumber.Text + "','" + txtMobile.Text + "','" + txtEmail.Text + "',N'" + comboNationality.Text + "'," + txtSalary.Text + ",N'" + txtJob.Text + "',@imgEmp," + customSelectedValue + ")");
                SqlCommand cmd;
                cmd = new SqlCommand(sqlQuery1, sqlconnection);
                cmd.Parameters.AddWithValue("@imgEmp", byteImageEmp);
                int n1 = cmd.ExecuteNonQuery();

                string sqlQueryImageIdentity = ("insert into Images values('imgImentityPicture','" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "' ,@imgIdentity," + txtEmpCode.Text + ")");
                SqlCommand cmdIdentity;
                cmdIdentity = new SqlCommand(sqlQueryImageIdentity, sqlconnection);
                cmdIdentity.Parameters.AddWithValue("@imgIdentity", byteImageIdentity);
                int n2 = cmdIdentity.ExecuteNonQuery();


                string sqlQueryImageWorkCard = ("insert into Images values('imgWorkCardPicture','" + dateTimePicker3.Value + "','" + dateTimePicker4.Value + "' ,@imgWorkCardImg," + txtEmpCode.Text + ")");
                SqlCommand cmdWordCard;
                cmdWordCard = new SqlCommand(sqlQueryImageWorkCard, sqlconnection);
                cmdWordCard.Parameters.AddWithValue("@imgWorkCardImg", byteImageWorkCard);
                int n3 = cmdWordCard.ExecuteNonQuery();

                string sqlQueryImagePassport = ("insert into Images values('imgWorkPassport','" + dateTimePicker5.Value + "','" + dateTimePicker6.Value + "' ,@passImg," + txtEmpCode.Text + ")");
                SqlCommand cmdPassport;
                cmdPassport = new SqlCommand(sqlQueryImagePassport, sqlconnection);
                cmdPassport.Parameters.AddWithValue("@passImg", byteImagPassport);
                int n4 = cmdPassport.ExecuteNonQuery();

                sqlconnection.Close();
                this.Alert("تمت إضافة الموظف بنجاح", Form_Alert.enmType.Success);
                initForm();

            }
            catch (Exception)
            {
                this.Alert("حدثت أخطاء أثناء الإضافة", Form_Alert.enmType.Error);
            }
        }
        private void comboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            customSelectedValue = (comboCompany.SelectedItem as ComboboxItem)!.Value!.ToString();
        }
    }
}   
