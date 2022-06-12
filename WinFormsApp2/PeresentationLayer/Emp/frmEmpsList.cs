using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.DAL;
using WinFormsApp2.Properties;
using WinFormsApp2.Utils;

namespace WinFormsApp2.PeresentationLayer.Emp
{
    public partial class frmEmpsList : Form
    {
        DataAccessLayer DataAccessLayer = new DataAccessLayer();
        String companySelectedValue = "";
        public frmEmpsList()
        {
            InitializeComponent();
            darkMode();
            initForm();
        }
        void darkMode()
        {
            if (vars.darkMode == true)
            {
                this.BackColor = Color.FromArgb(17, 45, 78);
                btnDarlMode.Image = Resources.lightMoon;
                bunifuDataGridView1.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
                bunifuDataGridView1.BackgroundColor = Color.FromArgb(50, 56, 62);
                foreach (Control x in this.Controls)
                {
                    if (x is Label)
                    {
                        x.ForeColor = Color.White;
                    }
                }

            }
            if (vars.darkMode == false)
            {
                this.BackColor = Color.FromArgb(249, 247, 247);
                btnDarlMode.Image = Resources.darkMoon;
                bunifuDataGridView1.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.DodgerBlue;
                bunifuDataGridView1.BackgroundColor = Color.White;
                foreach (Control x in this.Controls)
                {
                    if (x is Label)
                    {
                        x.ForeColor = Color.Black;
                    }
                }

            }
        }
        void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        void initForm()
        {
            DataTable dtCompaniesName = DataAccessLayer.orderDataTable("select * from Companies where type = 'Company' ");
            for (int i = 0; i < dtCompaniesName.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = dtCompaniesName.Rows[i][1].ToString();
                item.Value = dtCompaniesName.Rows[i][0].ToString();
                comboCompany.Items.Add(item);
            }
        }

        private void comboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            companySelectedValue = (comboCompany.SelectedItem as ComboboxItem)!.Value!.ToString();
            DataTable dtEmps = DataAccessLayer.orderDataTable("select * from Employees where emp_company = "+companySelectedValue+" ");
            bunifuDataGridView1.DataSource = dtEmps;

        }

        private void btnDarlMode_Click(object sender, EventArgs e)
        {
            vars.darkMode = !vars.darkMode;
            darkMode();
        }

        private void frmEmpsList_Load(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(bunifuDataGridView1.Rows.Count > 0)
            {

                Byte[] data = new Byte[0];
                data = (Byte[])(bunifuDataGridView1.CurrentRow.Cells[10].Value);
                MemoryStream mem = new MemoryStream(data);
                bunifuPictureBox1.Image = Image.FromStream(mem);

            }

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
