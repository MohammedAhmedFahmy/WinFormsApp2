using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Alert("تم العمل بنجاح", Form_Alert.enmType.Success);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Alert("لم يتم الأمر بنجاح", Form_Alert.enmType.Error);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Alert("الأمر يبدو غير جيد", Form_Alert.enmType.Warning);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Alert("من الجيد عودتك", Form_Alert.enmType.Info);

        }
    }
}
