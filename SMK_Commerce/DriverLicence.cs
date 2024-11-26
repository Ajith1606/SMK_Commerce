using QRCoder;
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
    public partial class DriverLicence : Form
    {
        public DriverLicence()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pitboxImage.Image = Image.FromFile(ofd.FileName);
                    pitboxImage.SizeMode = PictureBoxSizeMode.StretchImage;          
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
                    pitboxSign.Image = Image.FromFile(ofd.FileName);
                    pitboxSign.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void btnRTOSign_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    pitboxRTOSign.Image = Image.FromFile(ofd.FileName);
                    pitboxRTOSign.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
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
            pitboxQRData.Image = qrCodeImage;
            pitboxQRData.SizeMode = PictureBoxSizeMode.StretchImage; 
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
