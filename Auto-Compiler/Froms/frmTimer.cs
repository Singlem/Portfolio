using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Auto_Compiler
{
    public partial class frmTimer : Form
    {
        public frmTimer()
        {
            InitializeComponent();
        }

        private void frmTimer_Load(object sender, EventArgs e)
        {
            string[] _timer = ConfigSettings.ReadTimer().Split(',');
            edtHours.Text = _timer[0];
            edtMin.Text = _timer[1];
            edtSec.Text = _timer[2];
        }

        private void frmTimer_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimerHandler.GetInterval(Convert.ToInt16(edtHours.Text), Convert.ToInt16(edtMin.Text), Convert.ToInt16(edtSec.Text));
        }
    }
}
