using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Français_Helper.Windows
{
    public partial class VocabularyQuiz : Form
    {
        private readonly Word _quizedWord;
        private readonly List<Word> _toCheckWords;

        public VocabularyQuiz(Word quizedWord, List<Word> toCheckWords)
        {
            InitializeComponent();
            _quizedWord = quizedWord;
            _toCheckWords = toCheckWords;
            tWordA.Text = _quizedWord.WordName;
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            string typedWord = tWordB.Text;
            bool correct = false;
            foreach (var item in _toCheckWords)
            {
                if (item.WordName.Equals(typedWord))
                {
                    correct = true;
                    break;
                }
            }
            if (correct)
                DialogResult = DialogResult.Yes;
            else
                DialogResult = DialogResult.No;
            Close();
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
