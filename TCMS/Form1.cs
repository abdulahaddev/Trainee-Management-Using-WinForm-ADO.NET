using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTrainees_Click(object sender, EventArgs e)
        {
            FrmTrainees newForm = new FrmTrainees();
            newForm.Show();
            newForm.Focus();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
