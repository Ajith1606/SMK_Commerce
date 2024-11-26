using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMK_Commerce
{
    

    public partial class Form2 : Form
    {

        
        public Form2()
        {
            InitializeComponent();
            //l1
            dateTimePicker1.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);

            //l2
            label2.AutoSize = false;
            label2.Size = new Size(10, 100);  // Adjust to fit the rotated text
            label2.BackColor = Color.White;  // Set background for better visibility
            label2.ForeColor = Color.Black;     // Set text color

            // Attach the ValueChanged event handler for DateTimePicker
            dateTimePicker2.ValueChanged += new EventHandler(dateTimePicker2_ValueChanged);

            // Force the label to repaint with rotated text
            label2.Paint += new PaintEventHandler(RotateLabelTex);
        }
        //l1
        private void RotateLabelText(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;

            // Create a graphics object
            Graphics g = e.Graphics;

            // Translate the origin to the bottom-left corner of the label (for 270-degree rotation)
            g.TranslateTransform(0, lbl.Height);

            // Rotate the text by 270 degrees
            g.RotateTransform(270);

            // Draw the text at the rotated position
            g.DrawString(lbl.Text, lbl.Font, new SolidBrush(lbl.ForeColor), new PointF(0, 0));
        }
        //l1
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Set the selected date to the label
            label1.Text = "date : " + dateTimePicker1.Value.ToString("MM/dd/yyyy");
            label1.AutoSize = false;
            label1.Size = new Size(100, 200); // Adjust as needed

            // Attach the Paint event handler
            label1.Paint += new PaintEventHandler(RotateLabelText);
        }
        //l2
        private void RotateLabelTex(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;

            // Create a graphics object
            Graphics g = e.Graphics;

            // Clear the existing background to avoid previous text showing
            g.Clear(lbl.BackColor);

            // Move the origin to the bottom-left corner of the label (for 270-degree rotation)
            g.TranslateTransform(0, 170);

            // Rotate the text by 270 degrees (counter-clockwise)
            g.RotateTransform(-90);

            // Set anti-aliasing for smoother text rendering
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            // Draw the rotated text
            g.DrawString(lbl.Text, lbl.Font, new SolidBrush(lbl.ForeColor), new PointF(0, 0));
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            // Set the selected date to the label
            label2.Text = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            label2.Invalidate(); // Force the label to repaint
        }
    }
}
