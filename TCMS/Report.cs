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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void traineesReport1_InitReport(object sender, EventArgs e)
        {
            traineesReport1.Refresh();
        }
    }
}
