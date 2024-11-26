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
    public partial class Adhar : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private Bitmap panel1Bitmap;
        private Bitmap panel2Bitmap;
        public Adhar()
        {
            InitializeComponent();

            // Add PrintPage event handler
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            // Set the selected date to the label
            lblv2.Text = "Details as on" + DateTime.Now.ToString("dd/MM/yyyy");
            lblv2.Invalidate(); // Force the label to repaint

            // Set the selected date to the label
            lblv3.Text = "Details as on" + DateTime.Now.ToString("dd/MM/yyyy");
            lblv3.Invalidate(); // Force the label to repaint


            //lblv1
            lblv1.AutoSize = false;
            lblv1.Size = new Size(10, 160);  // Adjust to fit the rotated text
            lblv1.BackColor = Color.Wheat;  // Set background for better visibility
            lblv1.ForeColor = Color.Black;     // Set text color

            // Attach the ValueChanged event handler for DateTimePicker
            dtpAdnoIssued.ValueChanged += new EventHandler(dtpAdnoIssued_ValueChanged);

            // Force the label to repaint with rotated text
            lblv1.Paint += new PaintEventHandler(RotateLabelTex);

            //lblv2
            lblv2.AutoSize = false;
            lblv2.Size = new Size(10, 160);  // Adjust to fit the rotated text
            lblv2.BackColor = Color.Wheat;  // Set background for better visibility
            lblv2.ForeColor = Color.Black;     // Set text color

            // Force the label to repaint with rotated text
            lblv2.Paint += new PaintEventHandler(RotateLabelText);

            //lblv3
            lblv3.AutoSize = false;
            lblv3.Size = new Size(10, 160);  // Adjust to fit the rotated text
            lblv3.BackColor = Color.White;  // Set background for better visibility
            lblv3.ForeColor = Color.Black;     // Set text color

            // Force the label to repaint with rotated text
            lblv3.Paint += new PaintEventHandler(RotateLabelTe);
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
            pitboxQRDataCard.Image = qrCodeImage;

            pitboxQRDataCardOld.Image = qrCodeImage;
            pitboxQRDataCard.Image = qrCodeImage;

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
                    pitboxImageCard1.Image = Image.FromFile(ofd.FileName);
                    pitboxImageCard1.SizeMode = PictureBoxSizeMode.StretchImage;

                    //pitBoxImageCard2.Image = Image.FromFile(ofd.FileName);
                    pitboxImageCard2.SizeMode = PictureBoxSizeMode.StretchImage;

                    pitboxImageCardOld.Image = Image.FromFile(ofd.FileName);
                    pitboxImageCardOld.SizeMode = PictureBoxSizeMode.StretchImage;

                    Bitmap originalImage = new Bitmap(ofd.FileName);

                    // Convert the image to grayscale
                    Bitmap grayImage = ConvertToGrayscale(originalImage);

                    // Set the grayscale image in the PictureBox
                    pitboxImageCard2.Image = grayImage;
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

        private void txtTamilName_TextChanged(object sender, EventArgs e)
        {
            lblTamilName.Text = txtTamilName.Text.Trim();
            lblTamilNameOld.Text = txtTamilName.Text.Trim();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lblName.Text = txtName.Text.Trim();
            lblNameOld.Text = txtName.Text.Trim();
        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblGender.Text = cmbGender.SelectedItem.ToString();
            lblGenderOld.Text = cmbGender.SelectedItem.ToString();
        }

        private void txtTamilAddress_TextChanged(object sender, EventArgs e)
        {
            lblTamilAddress.Text = txtTamilAddress.Text.Trim();
            lblTamilAddressOld.Text = txtTamilAddress.Text.Trim();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            lblAddress.Text = txtAddress.Text.Trim();
            lblAddressOld.Text = txtAddress.Text.Trim();
        }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            lblDOB.Text = "பிறந்த  நாள் / DOB : " + dtpDateOfBirth.Text.ToString();
            lblDobOld.Text = "பிறந்த  நாள் / DOB : " + dtpDateOfBirth.Text.ToString();
        }

        private void txtno1_TextChanged(object sender, EventArgs e)
        {
            lblno1.Text = txtno1.Text.Trim();
            lblno4.Text = txtno1.Text.Trim();
            lblno11.Text = txtno1.Text.Trim();

            lblNo1old.Text = txtno1.Text.Trim();
            lblNo4old.Text = txtno1.Text.Trim();
        }

        private void txtno2_TextChanged(object sender, EventArgs e)
        {
            lblno2.Text = txtno2.Text.Trim();
            lblno5.Text = txtno2.Text.Trim();
            lblno12.Text = txtno2.Text.Trim();

            lblNo2old.Text = txtno2.Text.Trim();
            lblNo5old.Text = txtno2.Text.Trim();
        }

        private void txtno3_TextChanged(object sender, EventArgs e)
        {
            lblno3.Text = txtno3.Text.Trim();
            lblno6.Text = txtno3.Text.Trim();
            lblno13.Text = txtno3.Text.Trim();

            lblNo3old.Text = txtno3.Text.Trim();
            lblNo6old.Text = txtno3.Text.Trim();
        }

        private void chkBackground_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBackground.Checked)
            {
                pitboxImageCard1.Hide(); lblTamilName.Hide(); 
                pitboxImageCard2.Hide(); lblName.Hide();
                pitboxQRDataCard.Hide(); lblDOB.Hide();
                lblGender.Hide(); lblno1.Hide(); 
                lblno2.Hide(); lblno3.Hide(); 
                lblno4.Hide(); lblno5.Hide();
                lblno6.Hide(); lblno11.Hide();
                lblno12.Hide(); lblno13.Hide(); 
                lblAddress.Hide(); lblTamilAddress.Hide();

                lblv1.Hide(); lblv2.Hide(); lblv3.Hide();                  
                lblNo1old.Hide(); lblNo2old.Hide();
                lblNo3old.Hide(); lblNo4old.Hide();
                lblNo5old.Hide(); lblNo6old.Hide();
                lblAddressOld.Hide(); lblTamilAddressOld.Hide();
                lblNameOld.Hide(); lblTamilNameOld.Hide();
                lblDobOld.Hide(); lblGenderOld.Hide();
                pitboxImageCardOld.Hide(); pitboxQRDataCardOld.Hide();
            }
            else
            {
                pitboxImageCard1.Show(); lblTamilName.Show();
                pitboxImageCard2.Show(); lblName.Show();
                pitboxQRDataCard.Show(); lblDOB.Show();
                lblGender.Show(); lblno1.Show();
                lblno2.Show(); lblno3.Show();
                lblno4.Show(); lblno5.Show();
                lblno6.Show(); lblno11.Show();
                lblno12.Show(); lblno13.Show();
                lblAddress.Show(); lblTamilAddress.Show();

                lblv1.Show(); lblv2.Show(); lblv3.Show();
                lblNo1old.Show(); lblNo2old.Show();
                lblNo3old.Show(); lblNo4old.Show();
                lblNo5old.Show(); lblNo6old.Show();
                lblAddressOld.Show(); lblTamilAddressOld.Show();
                lblNameOld.Show(); lblTamilNameOld.Show();
                lblDobOld.Show(); lblGenderOld.Show();
                pitboxImageCardOld.Show(); pitboxQRDataCardOld.Show();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(rdbNew.Checked || rdbOld.Checked)
            {
                if(rdbNew.Checked)
                {
                    // Capture panel1 as a bitmap
                    panel1Bitmap = new Bitmap(panelAdharFront.Width, panelAdharFront.Height);
                    panelAdharFront.DrawToBitmap(panel1Bitmap, new Rectangle(0, 0, panelAdharFront.Width, panelAdharFront.Height));

                    // Capture panel2 as a bitmap
                    panel2Bitmap = new Bitmap(panelAdharBack.Width, panelAdharBack.Height);
                    panelAdharBack.DrawToBitmap(panel2Bitmap, new Rectangle(0, 0, panelAdharBack.Width, panelAdharBack.Height));

                }

                if (rdbOld.Checked)
                {
                    // Capture panel1 as a bitmap
                    panel1Bitmap = new Bitmap(panelAdharFrontOld.Width, panelAdharFrontOld.Height);
                    panelAdharFrontOld.DrawToBitmap(panel1Bitmap, new Rectangle(0, 0, panelAdharFrontOld.Width, panelAdharFrontOld.Height));

                    // Capture panel2 as a bitmap
                    panel2Bitmap = new Bitmap(panelAdharBackOld.Width, panelAdharBackOld.Height);
                    panelAdharBackOld.DrawToBitmap(panel2Bitmap, new Rectangle(0, 0, panelAdharBackOld.Width, panelAdharBackOld.Height));

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
                MessageBox.Show("Please Select New or Old", "Printing Information");
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

        private void dtpAdnoIssued_ValueChanged(object sender, EventArgs e)
        {
            // Set the selected date to the label
            lblv1.Text = "Aadhaar no.issued:"+ dtpAdnoIssued.Value.ToString("dd/MM/yyyy");
            lblv1.Invalidate(); // Force the label to repaint
        }
        //lblv1
        private void RotateLabelTex(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;

            // Create a graphics object
            Graphics g = e.Graphics;

            // Clear the existing background to avoid previous text showing
            g.Clear(lbl.BackColor);

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

        private void dtpAdDetailson_ValueChanged(object sender, EventArgs e)
        {
            // Set the selected date to the label
            lblv2.Text = "Details as on" + dtpAdnoIssued.Value.ToString("dd/MM/yyyy");
            lblv2.Invalidate(); // Force the label to repaint

            // Set the selected date to the label
            lblv3.Text = "Details as on" + dtpAdnoIssued.Value.ToString("dd/MM/yyyy");
            lblv3.Invalidate(); // Force the label to repaint

        }
        //lblv2
        private void RotateLabelText(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;

            // Create a graphics object
            Graphics g = e.Graphics;

            // Clear the existing background to avoid previous text showing
            g.Clear(lbl.BackColor);

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

        //lblv3
        private void RotateLabelTe(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;

            // Create a graphics object
            Graphics g = e.Graphics;

            // Clear the existing background to avoid previous text showing
            g.Clear(lbl.BackColor);

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

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtTamilName.Clear(); dtpDateOfBirth.Text = ""; lblGender.Text = "";
            txtName.Clear(); txtTamilAddress.Clear(); lblDOB.Text = "";
            txtAddress.Clear(); txtno1.Clear(); txtno2.Clear(); txtno3.Clear();
            ClearPictureBoxImage(pitboxImage); ClearPictureBoxImage(pitboxQRdata1);
            lblv1.Text = ""; lblDobOld.Text = ""; lblGenderOld.Text = "";
        }

        private void ClearPictureBoxImage(PictureBox pictureBox)
        {
            pictureBox.Image = null;
            pictureBox.Invalidate();
        }

        private void rdbNew_CheckedChanged(object sender, EventArgs e)
        {
            panelAdharNew.Show();
            panelAdharOld.Hide();
        }

        private void rdbOld_CheckedChanged(object sender, EventArgs e)
        {
            panelAdharOld.Show();
            panelAdharNew.Hide();
        }
    }
}
