using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMK_Commerce
{
    public partial class Demovoter : Form
    {
         private PrintDocument printDocument = new PrintDocument();
         private Bitmap panel1Bitmap;
         private Bitmap panel2Bitmap;

        public Demovoter()
        {
            InitializeComponent();
            // Add PrintPage event handler
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);


            // lblv1
            // Load an image from resources
            //Image myImage = Properties.Resources.Voter_Front; // Replace with your actual image name

            //// Optionally, set the background image of a Panel
            //paneFronrt.BackgroundImage = myImage;
            //paneFronrt.BackgroundImageLayout = ImageLayout.Tile; // Adjust layout as needed

            lblv1.AutoSize = false;
            lblv1.Size = new Size(10, 100);  // Adjust to fit the rotated text
            lblv1.BackColor = Color.Bisque;  // Set background for better visibility
            lblv1.ForeColor = Color.Black;     // Set text color

            // Attach the ValueChanged event handler for DateTimePicker
            txtEpicNo.TextChanged += new EventHandler(txtEpicNo_TextChanged);

            // Force the label to repaint with rotated text
            lblv1.Paint += new PaintEventHandler(RotateLabelText);
        }

        private void Demovoter_Load(object sender, EventArgs e)
        {
            lblDownloadDate.Text = dtpDownloadDate.Text;
            dtpDownloadDate.Text = DateTime.Now.ToString();
        }

        private void txtEpicNo_TextChanged(object sender, EventArgs e)
        {
            lblEpicNo.Text = txtEpicNo.Text.Trim();           
            lblEpicNo3.Text = txtEpicNo.Text.Trim();

            // Set the selected date to the label
            lblv1.Text = txtEpicNo.Text.Trim();
            lblv1.Invalidate(); // Force the label to repaint
        }
        //lblv1
        private void RotateLabelText(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;

            // Create a graphics object
            Graphics g = e.Graphics;

            // Clear the existing background to avoid previous text showing
            g.Clear(lbl.BackColor);

            //if (lbl.Parent.BackgroundImage != null)
            //{
            //    // Get the portion of the panel's background image that should be drawn behind the label
            //    Rectangle srcRect = new Rectangle(lbl.Location, lbl.Size);
            //    g.DrawImage(lbl.Parent.BackgroundImage, new Rectangle(0, 0, lbl.Width, lbl.Height), srcRect, GraphicsUnit.Pixel);
            //}

            // Set the smoothing and rendering quality
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            // Move the origin to the bottom-left corner of the label (for 270-degree rotation)
            g.TranslateTransform(0, lbl.Height);

            // Rotate the text by 270 degrees (counter-clockwise)
            g.RotateTransform(270);

            // Set anti-aliasing for smoother text rendering
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            // Draw the rotated text
            g.DrawString(lbl.Text, lbl.Font, new SolidBrush(lbl.ForeColor), new PointF(0, 0));
        }

        private void txtTamilName_TextChanged(object sender, EventArgs e)
        {
            lblTamilName.Text = txtTamilName.Text.Trim();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lblName.Text = txtName.Text.Trim();
        }

        private void txtTamilFatherName_TextChanged(object sender, EventArgs e)
        {
            lblFatherName.Text = txtTamilFatherName.Text.Trim();
        }

        private void txtFatherName_TextChanged(object sender, EventArgs e)
        {
            lblHusbandName.Text = txtFatherName.Text.Trim();
        }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            lblDOB2.Text = dtpDateOfBirth.Text;
        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblGender.Text = cmbGender.SelectedItem.ToString();
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pitBoxImage1.Image = Image.FromFile(ofd.FileName);
                    pitBoxImage1.SizeMode = PictureBoxSizeMode.StretchImage;
                    
                    pitBoxImage2.Image = Image.FromFile(ofd.FileName);
                    pitBoxImage2.SizeMode = PictureBoxSizeMode.StretchImage;

                    //pitBoxImage3.Image = Image.FromFile(ofd.FileName);
                    pitBoxImage3.SizeMode = PictureBoxSizeMode.StretchImage;


                    Bitmap originalImage = new Bitmap(ofd.FileName);

                    // Convert the image to grayscale
                    Bitmap grayImage = ConvertToGrayscale(originalImage);

                    // Set the grayscale image in the PictureBox
                    pitBoxImage3.Image = grayImage;
                }
            }
        }
        //BlackandWhite
        private Bitmap ConvertToGrayscale(Bitmap original)
        {
            Bitmap grayImage = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color originalColor = original.GetPixel(x, y);
                    int grayValue = (int)(originalColor.R * 0.3 + originalColor.G * 0.59 + originalColor.B * 0.11);
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);                   
                    grayImage.SetPixel(x, y, grayColor);
                }
            }

            return grayImage;
        }

        //QRCode
        private void GenerateQRCode(string inputData)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(inputData, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            pitBoxQR1.Image = qrCodeImage;
            pitBoxQR1.Image = qrCodeImage;
            pitBoxQR2.Image = qrCodeImage;
            pitBoxQR2.Image = qrCodeImage;
        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            string qrcode = "Epic No : " + txtEpicNo.Text + " Name :" + txtName.Text;
            GenerateQRCode(qrcode);
        }

        private void txtTamilAddress_TextChanged(object sender, EventArgs e)
        {
            lblTamilAddress.Text = txtTamilAddress.Text;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            lblAddress.Text = txtAddress.Text;
        }

        private void txtTamilVakalarpathivu_TextChanged(object sender, EventArgs e)
        {
            lblTamilElectrol.Text = txtTamilVakalarpathivu.Text.Trim();
        }

        private void txtElectoral_TextChanged(object sender, EventArgs e)
        {
            lblElectrol.Text=txtElectoral.Text.Trim();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pitSign.Image = Image.FromFile(ofd.FileName);
                    pitSign.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void cmbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTitle.SelectedIndex == 1)
            {
                label5.Text = "கணவர் பெயர்";
                label4.Text = "Husband Name";
                label29.Text = "கணவர் பெயர்";
                label30.Text = "Husband Name";
            }
            else
            {
                label5.Text = "தந்தையின்  பெயர்";
                label4.Text = "Father's Name";
                label29.Text = "தந்தையின்  பெயர்";
                label30.Text = "Father's Name";
            }
        }

        private void chkBackground_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBackground.Checked)
            {
                lblEpicNo.Hide(); lblTamilName.Hide();
                lblName.Hide();
                lblEpicNo3.Hide(); lblFatherName.Hide();
                pitBoxImage1.Hide(); lblHusbandName.Hide();
                pitBoxImage3.Hide(); lblGender.Hide();
                pitSign.Hide(); lblDOB2.Hide();
                pitBoxQR2.Hide(); label42.Hide();
                label26.Hide(); label43.Hide();
                label27.Hide(); label39.Hide();
                label29.Hide(); label38.Hide();
                label30.Hide(); label36.Hide();
                label37.Hide(); label35.Hide();
                label31.Hide(); label34.Hide();
                label32.Hide(); label33.Hide();
                label48.Hide(); label50.Hide();
                label49.Hide(); label51.Hide();
                label44.Hide(); label46.Hide();
                label40.Hide(); label41.Hide();
                label47.Hide(); label45.Hide();
                lblTamilName.Hide(); lblAddress.Hide();
                lblTamilElectrol.Hide(); lblElectrol.Hide();
                lblDownloadDate.Hide();
            }
            else 
            {
                lblEpicNo.Show(); lblTamilName.Show();
                lblName.Show();
                lblEpicNo3.Show(); lblFatherName.Show();
                pitBoxImage1.Show(); lblHusbandName.Show();
                pitBoxImage3.Show(); lblGender.Show();
                pitSign.Show(); lblDOB2.Show();
                pitBoxQR2.Show(); label42.Show();
                label26.Show(); label43.Show();
                label27.Show(); label39.Show();
                label29.Show(); label38.Show();
                label30.Show(); label36.Show();
                label37.Show(); label35.Show();
                label31.Show(); label34.Show();
                label32.Show(); label33.Show();
                label48.Show(); label50.Show();
                label49.Show(); label51.Show();
                label44.Show(); label46.Show();
                label40.Show(); label41.Show();
                label47.Show(); label45.Show();
                lblTamilName.Show(); lblAddress.Show();
                lblTamilElectrol.Show(); lblElectrol.Show();
                lblDownloadDate.Show();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Capture panel1 as a bitmap
            panel1Bitmap = new Bitmap(paneFronrt.Width, paneFronrt.Height);
            paneFronrt.DrawToBitmap(panel1Bitmap, new Rectangle(0, 0, paneFronrt.Width, paneFronrt.Height));

            // Capture panel2 as a bitmap
            panel2Bitmap = new Bitmap(panelBack.Width, panelBack.Height);
            panelBack.DrawToBitmap(panel2Bitmap, new Rectangle(0, 0, panelBack.Width, panelBack.Height));

            // Show print dialog before printing
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Define positions for front and back panels
            int margin = 50;
            Rectangle panel1Rect = new Rectangle(margin, margin, panel1Bitmap.Width, panel1Bitmap.Height);
            Rectangle panel2Rect = new Rectangle(margin, panel1Rect.Bottom + margin, panel2Bitmap.Width, panel2Bitmap.Height);

            // Print panel1 (front of business card)
            e.Graphics.DrawImage(panel1Bitmap, panel1Rect);

            // Print panel2 (back of business card)
            e.Graphics.DrawImage(panel2Bitmap, panel2Rect);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtEpicNo.Clear(); txtTamilAddress.Clear();
            txtTamilName.Clear(); txtAddress.Clear();
            txtName.Clear(); txtTamilVakalarpathivu.Clear();
            txtElectoral.Clear(); txtTamilFatherName.Clear();
            dtpDateOfBirth.Text = ""; txtFatherName.Clear();
            ClearPictureBoxImage(pitBoxQR1);
            ClearPictureBoxImage(pitBoxQR2);
            ClearPictureBoxImage(pitSign);
            ClearPictureBoxImage(pitBoxImage1);
            ClearPictureBoxImage(pitBoxImage2);
            ClearPictureBoxImage(pitBoxImage3);
        }
        private void ClearPictureBoxImage(PictureBox pictureBox)
        {
            pictureBox.Image = null;
            pictureBox.Invalidate();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();          
        }

        private void paneFronrt_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOld_Click(object sender, EventArgs e)
        {
            VoterOld old = new VoterOld();
            old.Show();
            this.Hide();
        }

        private void lblv1_Click(object sender, EventArgs e)
        {

        }
    }
}
