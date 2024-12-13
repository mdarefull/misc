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
    public partial class DecodeMessageForm : Form
    {
        public DecodeMessageForm()
        {
            InitializeComponent();

            button2.Enabled = false;
        }


        private string fileSrc;
        private void button1_Click(object sender, EventArgs e)
        {
            var dr = openFileDialog1.ShowDialog(this);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                fileSrc = openFileDialog1.FileName;
                button2.Enabled = true;
            }
            else
                button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessAndExtractMessage();
        }

        private void ProcessAndExtractMessage()
        {
            using (var image = ImportImage())
            {
                var msgBits = ExtractMessage(image);
                var msgBytes = ConvertBitsToByte(msgBits);
                var message = Encoding.UTF8.GetString(msgBytes);
                message.Remove(message.IndexOf('\0'));
                textBox1.Text = message;

                MessageBox.Show("Successfull message extraction.");
            }
        }
        private Bitmap ImportImage()
        {
            return new Bitmap(fileSrc);
        }
        private bool[] ExtractMessage(Bitmap image)
        {
            int xPixel = 0;
            int yPixel = 0;

            bool[] msgBits = new bool[image.Height * image.Width * 8];
            int bitIndex = 0;
            while (yPixel < image.Height)
            {
                var currentPixel = image.GetPixel(xPixel, yPixel);
                msgBits[bitIndex++] = DetectBit(currentPixel.A);
                msgBits[bitIndex++] = DetectBit(currentPixel.R);
                msgBits[bitIndex++] = DetectBit(currentPixel.G);
                msgBits[bitIndex++] = DetectBit(currentPixel.B);
                
                xPixel++;
                if (xPixel == image.Width)
                {
                    xPixel = 0;
                    yPixel++;
                }
            }

            return msgBits;
        }
            private bool DetectBit(byte embededColor)
            {
                var bit = (embededColor & 1) == 1;

                return bit;
            }
        private byte[] ConvertBitsToByte(bool[] msgBits)
        {
            byte[] bytes = new byte[msgBits.Length / 8];
            for (int byteIndex = 0, i = 0; i < msgBits.Length; byteIndex++)
            {
                byte nextByte = 0;
                for (int j = 0; j < 8; j++, i++)
                {
                    nextByte *= 2;

                    if (msgBits[i]) nextByte++;
                }
                bytes[byteIndex] = nextByte;
            }

            return bytes;
        }
    }
}
