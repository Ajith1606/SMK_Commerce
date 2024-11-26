using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMK_Commerce
{
    public partial class Pan : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private Bitmap panel1Bitmap;
        private Bitmap panel2Bitmap;

        public Pan()
        {
            InitializeComponent();
            // Add PrintPage event handler
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panelNSDL.Show();
            panelUTI.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panelUTI.Show();
            panelNSDL.Hide();            
        }

        private void txtPanNo_TextChanged(object sender, EventArgs e)
        {
            lblNSDLPanNo.Text = txtPanNo.Text.Trim();
            lblUTIPanNo.Text = txtPanNo.Text.Trim();            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lblNSDLName.Text = txtName.Text.Trim();
            lblUTIName.Text = txtName.Text.Trim();
        }

        private void txtFather_TextChanged(object sender, EventArgs e)
        {
            lblNSDLFatherName.Text = txtFather.Text.Trim();
            lblUTIFatherName.Text= txtFather.Text.Trim();
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            lblNSDLDOB.Text = dtpDOB.Text.Trim();
            lblUTIDOB.Text = dtpDOB.Text.Trim();
        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            string qrcode = "Family Head : ";
            GenerateQRCode(qrcode);
        }
        //QRCode
        private void GenerateQRCode(string inputData)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(inputData, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            pitboxQRdata1.Image = qrCodeImage;
            pitbobNSDLQR.Image = qrCodeImage;
            pitboxUTIQR.Image = qrCodeImage;
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pitboxImage.Image = Image.FromFile(ofd.FileName);
                    pitboxImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    //card
                    pitboxNSDLImage.Image = Image.FromFile(ofd.FileName);
                    pitboxNSDLImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    pitboxUTIImage.Image = Image.FromFile(ofd.FileName);
                    pitboxUTIImage.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
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

                    //Card
                    pitboxNSDLSign.Image = Image.FromFile(ofd.FileName);
                    pitboxNSDLSign.SizeMode = PictureBoxSizeMode.StretchImage;
                    pitboxUTISign.Image = Image.FromFile(ofd.FileName);
                    pitboxUTISign.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked || radioButton2.Checked)
            {
                if (radioButton1.Checked)
                {
                    // Capture panel1 as a bitmap
                    panel1Bitmap = new Bitmap(panelFrontNSDL.Width, panelFrontNSDL.Height);
                    panelFrontNSDL.DrawToBitmap(panel1Bitmap, new Rectangle(0, 0, panelFrontNSDL.Width, panelFrontNSDL.Height));

                    // Capture panel2 as a bitmap
                    panel2Bitmap = new Bitmap(panelBackNSDL.Width, panelBackNSDL.Height);
                    panelBackNSDL.DrawToBitmap(panel2Bitmap, new Rectangle(0, 0, panelBackNSDL.Width, panelBackNSDL.Height));

                }
                if (radioButton2.Checked)
                {
                    // Capture panel1 as a bitmap
                    panel1Bitmap = new Bitmap(panelFrontUTI.Width, panelFrontUTI.Height);
                    panelFrontUTI.DrawToBitmap(panel1Bitmap, new Rectangle(0, 0, panelFrontUTI.Width, panelFrontUTI.Height));

                    // Capture panel2 as a bitmap
                    panel2Bitmap = new Bitmap(panelBackUTI.Width, panelBackUTI.Height);
                    panelBackUTI.DrawToBitmap(panel2Bitmap, new Rectangle(0, 0, panelBackUTI.Width, panelBackUTI.Height));

                }
                // Show print dialog before printing
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            else
            {
                MessageBox.Show("Please Select NSDL or UTI", "Printing Information");
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

        private void chkBackground_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBackground.Checked) 
            {
                pitboxNSDLImage.Hide(); pitboxUTIImage.Hide();
                lblNSDLPanNo.Hide(); lblUTIPanNo.Hide();
                lblNSDLName.Hide(); lblUTIName.Hide();
                lblNSDLFatherName.Hide(); lblUTIFatherName.Hide();
                lblNSDLDOB.Hide(); lblUTIDOB.Hide();
                pitbobNSDLQR.Hide(); pitboxUTIQR.Hide();
                pitboxNSDLSign.Hide(); pitboxUTISign.Hide();
            }
            else
            {
                pitboxNSDLImage.Show(); pitboxUTIImage.Show();
                lblNSDLPanNo.Show(); lblUTIPanNo.Show();
                lblNSDLName.Show(); lblUTIName.Show();
                lblNSDLFatherName.Show(); lblUTIFatherName.Show();
                lblNSDLDOB.Show(); lblUTIDOB.Show();
                pitbobNSDLQR.Show(); pitboxUTIQR.Show();
                pitboxNSDLSign.Show(); pitboxUTISign.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtFather.Clear(); txtName.Clear(); txtPanNo.Clear();
            ClearPictureBoxImage(pitSign);
            ClearPictureBoxImage(pitboxUTISign);
            ClearPictureBoxImage(pitboxNSDLSign);
            ClearPictureBoxImage(pitboxQRdata1);
            ClearPictureBoxImage(pitboxUTIQR);
            ClearPictureBoxImage(pitbobNSDLQR);
            ClearPictureBoxImage(pitboxImage);
            ClearPictureBoxImage(pitboxNSDLImage);
            ClearPictureBoxImage(pitboxUTIImage);
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
    }
}
