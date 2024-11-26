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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SMK_Commerce
{
    public partial class Smart : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private Bitmap panel1Bitmap;
        private Bitmap panel2Bitmap;
        public Smart()
        {
            InitializeComponent();
            // Add PrintPage event handler
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        private void Smart_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {                  
                    pitboxImage1.Image = Image.FromFile(ofd.FileName);
                    pitboxImage1.SizeMode = PictureBoxSizeMode.StretchImage;
                    //card
                    pitboxImage1Card.Image = Image.FromFile(ofd.FileName);
                    pitboxImage1Card.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }                          
        }

        private void txtFamilyHead_TextChanged(object sender, EventArgs e)
        {
            lblFamilyHead.Text = txtFamilyHead.Text.Trim();
        }

        private void txtFatherHusband_TextChanged(object sender, EventArgs e)
        {
            lblFatherHusband.Text = txtFatherHusband.Text.Trim();
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            lblDtp.Text = dtpDOB.Text.Trim();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            lblAddress.Text = txtAddress.Text.Trim();
        }

        private void txtCardType_TextChanged(object sender, EventArgs e)
        {
            
            lblCardType.Text = txtCardType.Text.Trim();
           
        }

        private void txtCardNo_TextChanged(object sender, EventArgs e)
        {
            lblCardNo.Text = txtCardNo.Text.Trim();
        }

        private void txtshopNo_TextChanged(object sender, EventArgs e)
        {
            lblShopNo.Text = txtshopNo.Text.Trim();
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            lblYear.Text = txtYear.Text.Trim();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            txtAddMember.Focus();

            int count;
            string inputText = txtAddMember.Text;

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                
                ListViewItem item = new ListViewItem(inputText);
                lvAddMember.Items.Add(item);
                
                //for total family count
                count = lvAddMember.Items.Count;
                lblCount.Text = Convert.ToString(count + 1);

                //show the family member
                string listViewContent = "";
                foreach (ListViewItem item1 in lvAddMember.Items)
                {
                    listViewContent += "- " + item1.Text + Environment.NewLine;
                }
                lblAddMemberView.Text = listViewContent;
                txtAddMember.Clear();

            }
            else
            {
                MessageBox.Show("Please enter a Family Member.", "Input Required");
            }
        }

        private void chkBackground_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBackground.Checked)
            {
                pitboxImage1Card.Hide();
                lblCardNo.Hide();
                lblCardType.Hide();
                guna2Panel1.Hide();
                guna2Panel2.Hide();
                label6.Hide();
                label11.Hide();
                label13.Hide();
                label14.Hide();
                label15.Hide();
                label16.Hide();
                label17.Hide();
                lblFamilyHead.Hide();
                lblFatherHusband.Hide();
                lblAddMemberView.Hide();
                lblDtp.Hide();               
                lblAddress.Hide();
                lblCount.Hide();             
                lblShopNo.Hide();
                lblYear.Hide();
                pitboxQRdata2.Hide();
            }
            else
            {
                pitboxImage1Card.Show();
                lblCardNo.Show();
                lblCardType.Show();
                guna2Panel1.Show();
                guna2Panel2.Show();
                label6.Show();
                label11.Show();
                label13.Show();
                label14.Show();
                label15.Show();
                label16.Show();
                label17.Show();
                lblFamilyHead.Show();
                lblFatherHusband.Show();
                lblAddMemberView.Show();
                lblDtp.Show();
                lblAddress.Show();
                lblCount.Show();
                lblShopNo.Show();
                lblYear.Show();
                pitboxQRdata2.Show();
            }
        }
        //QRCode
       private void GenerateQRCode(string inputData)
        {          
            QRCodeGenerator qrGenerator = new QRCodeGenerator();           
             QRCodeData qrCodeData = qrGenerator.CreateQrCode(inputData, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            pitboxQRdata1.Image = qrCodeImage;
            pitboxQRdata2.Image = qrCodeImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string qrcode = "Family Head : " + txtFamilyHead.Text + " Father/Husband :" + txtFatherHusband.Text
                + " Date Of Birth : " + dtpDOB.Text + " Address :" + txtAddress.Text
                + " Card No : " + txtCardNo.Text + " card Type :" + txtCardType.Text
                + " Shop No : " + txtshopNo.Text + " Year :" + txtYear.Text
                + " Family Members : " + lblAddMemberView.Text + " Family Member count : " + lblCount.Text;
            GenerateQRCode(qrcode);
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Capture panel1 as a bitmap
            panel1Bitmap = new Bitmap(panelFront.Width, panelFront.Height);
            panelFront.DrawToBitmap(panel1Bitmap, new Rectangle(0, 0, panelFront.Width, panelFront.Height));

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


        private void button3_Click(object sender, EventArgs e)
        {
            txtFamilyHead.Clear();
            txtFatherHusband.Clear();         
            txtAddress.Clear();
            txtCardNo.Clear();
            txtCardType.Clear();
            txtshopNo.Clear();
            txtYear.Clear();
            ClearPictureBoxImage(pitboxImage1);
            ClearPictureBoxImage(pitboxQRdata1);
            ClearPictureBoxImage(pitboxImage1Card);
            ClearPictureBoxImage(pitboxQRdata2);
            lvAddMember.Clear();
            lblDtp.Text = "";
            lblAddMemberView.Text = "";
            lblCount.Text = "";
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
