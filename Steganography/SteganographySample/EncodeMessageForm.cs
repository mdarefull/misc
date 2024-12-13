using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteganographySample
{
    public partial class EncodeMessageForm : Form
    {
        private int messageSize = 0;

        public EncodeMessageForm()
        {
            InitializeComponent();

            UpdateMessageSize();

            SetStatusState(StatusState.SelectImage);
        }

        private void UpdateMessageSize()
        {
            messageSize = sizeof(char) * textBox1.Text.Length;
            label3.Text = "Message size: " + messageSize  + " bytes";

            label2.Text = "Step 2 - Choose your image: (min size = " + (messageSize + 1024) + " bytes)";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateMessageSize();
            SetStatusState(StatusState.SelectImage);
        }

        private string fileName;
        private string fileSrc;
        private void button1_Click(object sender, EventArgs e)
        {
            var dr = openFileDialog1.ShowDialog(this);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                fileSrc = openFileDialog1.FileName;
                fileName = fileSrc.Substring(fileSrc.LastIndexOf('\\') + 1);

                using(var imageFile = File.Open(fileSrc, FileMode.Open))
                {
                    if (imageFile.Length >= messageSize + 1024)
                        SetStatusState(StatusState.ImageOk);
                    else
                        SetStatusState(StatusState.ImageWrong);
                    imageFile.Dispose();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessAndExportImage();
        }

        private void ProcessAndExportImage()
        {
            var message = textBox1.Text + '\0';
            var msgBytes = Encoding.UTF8.GetBytes(message);
            var msgBits = ConvertByteToBits(msgBytes);

            using (var image = new Bitmap(fileSrc))
            {
                var embededImage = EmbeedMessage(msgBits, image);
                ExportImage(embededImage);

                MessageBox.Show("Sucessfull Image exportation.");
            }
        }
        private bool[] ConvertByteToBits(byte[] msgBytes)
        {
            bool[] bits = new bool[msgBytes.Length * 8];
            int bitIndex = 0;

            foreach (var @byte in msgBytes)
            {
                byte bitFlag = 128;
                while (bitFlag != 0)
                {
                    bits[bitIndex] = (@byte & bitFlag) == bitFlag;
                    bitFlag >>= 1;
                    bitIndex++;
                }
            }

            return bits;
        }
        private Bitmap EmbeedMessage(bool[] msgBits, Bitmap image)
        {
            int xPixel = 0;
            int yPixel = 0;

            Bitmap newImage = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < msgBits.Length; i += 4)
            {
                Color currentPixel = image.GetPixel(xPixel, yPixel);

                byte alpha = SelectByte(currentPixel.A, msgBits[i]);
                byte red = SelectByte(currentPixel.R, msgBits[i + 1]);
                byte green = SelectByte(currentPixel.G, msgBits[i + 2]);
                byte blue = SelectByte(currentPixel.B, msgBits[i + 3]);
                Color newColor = Color.FromArgb(alpha, red, green, blue);

                newImage.SetPixel(xPixel, yPixel, newColor);

                xPixel++;
                if (xPixel == image.Width)
                {
                    xPixel = 0;
                    yPixel++;
                }
            }

            // Perform a simple copy of the image
            while (yPixel < image.Height)
            {
                Color currentPixel = image.GetPixel(xPixel, yPixel);
                newImage.SetPixel(xPixel, yPixel, currentPixel);

                xPixel++;
                if (xPixel == image.Width)
                {
                    xPixel = 0;
                    yPixel++;
                }
            }

            return newImage;
        }
        private byte SelectByte(byte currentColor, bool bit)
        {
            byte newColor = currentColor;
            newColor |= 1;

            if (!bit)
                newColor ^= 1;

            return newColor;
        }
        private void ExportImage(Bitmap image)
            {
                var dr = saveFileDialog1.ShowDialog(this);
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    image.Save(saveFileDialog1.FileName);
                }
            }

        private enum StatusState
        {
            SelectImage,
            ImageOk,
            ImageWrong,
        }
        private void SetStatusState(StatusState statusState)
        {
            bool ok;
            string statusMessage;
            switch (statusState)
            {
                case StatusState.SelectImage:
                    ok = false;
                    statusMessage = "Select an image";
                    break;
                case StatusState.ImageOk:
                    ok = true;
                    statusMessage = "Image OK";
                    break;
                case StatusState.ImageWrong:
                    ok = false;
                    statusMessage = "Incorrect Image";
                    break;
                default:
                    throw new Exception("Unespected StatusState");
            }

            if (ok)
            {
                label4.ForeColor = Color.Green;
                button2.Enabled = true;
            }
            else
            {
                label4.ForeColor = Color.Red;
                button2.Enabled = false;
            }

            label4.Text = statusMessage;
        }
    }
}