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
    public partial class MdiParent : Form
    {
        public MdiParent()
        {
            InitializeComponent();
        }

        // Method to open child forms, ensuring only one instance is open
        private void OpenChildForm<T>() where T : Form, new()
        {
            // Check if the form is already open
            Form existingForm = this.MdiChildren.FirstOrDefault(f => f is T);

            if (existingForm == null)
            {
                // Form is not open, create and show a new one
                T childForm = new T
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill // Optional: this will make the form take full MDI parent space
                };
                childForm.Show();
            }
            else
            {
                // If form is already open, bring it to the front
                existingForm.BringToFront();
            }
        }

        private void voterCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<Demovoter>();
        }

        private void adharCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<Adhar>();
        }

        private void smartCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<Smart>();
        }

        private void panCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<Pan>();
        }
    }
}
