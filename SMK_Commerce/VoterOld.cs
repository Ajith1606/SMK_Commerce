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
using ZXing;

namespace SMK_Commerce
{
    public partial class VoterOld : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private Bitmap panel1Bitmap;
        private Bitmap panel2Bitmap;
        public VoterOld()
        {
            InitializeComponent();
            // Add PrintPage event handler
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);           
        }

        private void VoterOld_Load(object sender, EventArgs e)
        {
            lblDownloadDate.Text = "Date : " + DateTime.Now.ToString("dd/MM/yyyy");
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

        private void ClearPictureBoxImage(PictureBox pictureBox)
        {
            pictureBox.Image = null;
            pictureBox.Invalidate();
        }

        private void txtEpicNo_TextChanged_1(object sender, EventArgs e)
        {
            lblEpicNo.Text = txtEpicNo.Text.Trim();
        }
        //barcode
        private void txtTamilName_TextChanged_1(object sender, EventArgs e)
        {
            lblTamilName.Text = txtTamilName.Text.Trim();
        }

        private void txtName_TextChanged_1(object sender, EventArgs e)
        {
            lblName.Text = txtName.Text.Trim();
        }

        private void txtTamilFatherName_TextChanged_1(object sender, EventArgs e)
        {
            lblFatherName.Text = txtTamilFatherName.Text.Trim();
        }

        private void txtFatherName_TextChanged_1(object sender, EventArgs e)
        {
            lblHusbandName.Text = txtFatherName.Text.Trim();
        }

        private void dtpDateOfBirth_ValueChanged_1(object sender, EventArgs e)
        {
            lblDOB2.Text = dtpDateOfBirth.Text;
        }

        private void txtTamilAddress_TextChanged_1(object sender, EventArgs e)
        {
            lblTamilAddress.Text = "முகவரி : " + txtTamilAddress.Text;
        }

        private void txtAddress_TextChanged_1(object sender, EventArgs e)
        {
            lblAddress.Text = "Address : " + txtAddress.Text;
        }

        private void txtTamilVakalarpathivu_TextChanged_1(object sender, EventArgs e)
        {
            lblTamilElectrol.Text = txtTamilVakalarpathivu.Text.Trim();
        }

        private void txtElectoral_TextChanged_1(object sender, EventArgs e)
        {
            lblElectrol.Text = txtElectoral.Text.Trim();
        }

        private void btnSign_Click_1(object sender, EventArgs e)
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

        private void btnPhoto_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pitBoxImage1.Image = Image.FromFile(ofd.FileName);
                    pitBoxImage1.SizeMode = PictureBoxSizeMode.StretchImage;

                }
            }
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtEpicNo.Clear(); txtTamilAddress.Clear();
            txtTamilName.Clear(); txtAddress.Clear();
            txtName.Clear(); txtTamilVakalarpathivu.Clear();
            txtElectoral.Clear(); txtTamilFatherName.Clear();
            dtpDateOfBirth.Text = ""; txtFatherName.Clear();
            ClearPictureBoxImage(pitSign); lblGender.Text = "";
            ClearPictureBoxImage(pitBoxImage1); lblDOB2.Text = "";
            ClearPictureBoxImage(pitboxBarcode);
        }

        private void chkBackground_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkBackground.Checked)
            {
                lblEpicNo.Hide(); lblTamilName.Hide();
                lblName.Hide();
                lblFatherName.Hide();
                pitBoxImage1.Hide(); lblHusbandName.Hide();
                lblGender.Hide();
                pitSign.Hide(); lblDOB2.Hide();
                label26.Hide();
                label27.Hide(); label39.Hide();
                label29.Hide(); label38.Hide();
                label30.Hide(); label36.Hide();
                label37.Hide(); label35.Hide();
                label31.Hide(); label34.Hide();
                label32.Hide(); label33.Hide();
                label48.Hide(); lblTamilAddress.Hide();
                label49.Hide(); pitboxBarcode.Hide();
                lblTamilName.Hide(); lblAddress.Hide();
                lblTamilElectrol.Hide(); lblElectrol.Hide();
                lblDownloadDate.Hide();
            }
            else
            {
                lblEpicNo.Show(); lblTamilName.Show();
                lblName.Show();
                lblFatherName.Show();
                pitBoxImage1.Show(); lblHusbandName.Show();
                lblGender.Show();
                pitSign.Show(); lblDOB2.Show();
                label26.Show();
                label27.Show(); label39.Show();
                label29.Show(); label38.Show();
                label30.Show(); label36.Show();
                label37.Show(); label35.Show();
                label31.Show(); label34.Show();
                label32.Show(); label33.Show();
                label48.Show(); lblTamilAddress.Show();
                label49.Show(); pitboxBarcode.Show();
                lblTamilName.Show(); lblAddress.Show();
                lblTamilElectrol.Show(); lblElectrol.Show();
                lblDownloadDate.Show();
            }
        }

        private void cmbTitle_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblGender.Text = cmbGender.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get the text from the textbox
            string textToEncode = txtEpicNo.Text;

            // Create a barcode writer instance
            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128, // You can choose different formats
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = pitboxBarcode.Height,
                    Width = pitboxBarcode.Width,
                    PureBarcode = true
                }
            };

            // Generate barcode image
            Bitmap barcodeBitmap = writer.Write(textToEncode);

            // Show barcode image in PictureBox
            pitboxBarcode.Image = barcodeBitmap;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Demovoter demovoter = new Demovoter();
            demovoter.Show();
            this.Hide();
        }
    }
}
