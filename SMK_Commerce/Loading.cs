using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMK_Commerce
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            guna2ProgressBar1.Increment(2);
            if(guna2ProgressBar1.Value == 100)
            {
                timer1.Stop();
                Home home = new Home();
                this.Hide();
                home.Show();
                
            }
        }
    }
}
