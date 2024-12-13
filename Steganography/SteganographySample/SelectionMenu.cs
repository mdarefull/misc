using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteganographySample
{
    public partial class SelectionMenu : Form
    {
        public SelectionMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new EncodeMessageForm().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new DecodeMessageForm().ShowDialog();
        }
    }
}
