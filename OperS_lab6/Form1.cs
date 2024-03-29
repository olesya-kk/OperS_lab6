using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperS_lab6
{
    public partial class MyForm : Form
    {
        private MyFunctions Function; 
        public MyForm()
        {
            InitializeComponent();
            Function = new MyFunctions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string b = MyFunctions.MyFunction();
            MessageBox.Show(b);
        }

        private void MyForm_Load(object sender, EventArgs e)
        {

        }
    }
}
