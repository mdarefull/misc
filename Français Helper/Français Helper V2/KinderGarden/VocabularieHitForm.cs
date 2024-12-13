using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Français_Helper
{
    public partial class VocabularieHitForm : Form
    {
        private readonly DataBase _myDataBase;
        private readonly FrenchWord _frenchWord;
        private readonly bool _isNew;
        public VocabularieHitForm(DataBase myDataBase, FrenchWord frenchWord, bool isNew)
        {
            InitializeComponent();
            _myDataBase = myDataBase;
            _frenchWord = frenchWord;
            _isNew = isNew;

            InitializeCbCategoria();
            InitializeFields();
            tbSignificados.Focus();
        }
        private void InitializeCbCategoria()
        {
            cbCategoria.Items.Clear();
            foreach (var item in _myDataBase.CategoryList)
                cbCategoria.Items.Add(item);
            cbCategoria.Update();
        }
        private void InitializeFields()
        {
            tbWord.Text = _frenchWord.WordName;
            tbPronunciacion.Text = _frenchWord.Pronounce;
            cbCategoria.SelectedItem = _frenchWord.Categoria;
            cbSubcategoria.SelectedItem = _frenchWord.Subcategoria;
                
            lbSignificados.Items.Clear();
            foreach (var item in _frenchWord.SpanishesWords)
                lbSignificados.Items.Add(item.WordName);
            lbSignificados.Update();

            tbAIS.Text = _frenchWord.AsocSimple;
            tbAIC.Text = _frenchWord.AsocCompleta;

            lPrononciation.Visible = tbPronunciacion.Visible = _frenchWord.HitLevel >= 1;
            lAIS.Visible = tbAIS.Visible = _frenchWord.HitLevel >= 2;
            lAIC.Visible = tbAIC.Visible = _frenchWord.HitLevel >= 3;
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSubcategoria.Items.Clear();
            foreach (var item in ((Categoria)cbCategoria.SelectedItem).Subcategories)
                cbSubcategoria.Items.Add(item);
            cbSubcategoria.Update();
            if (cbSubcategoria.Items.Count > 0)
                cbSubcategoria.SelectedIndex = 0;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
            {
                string word = tbWord.Text;
                string prononciation = tbPronunciacion.Text;
                Categoria category = (Categoria)cbCategoria.SelectedItem;
                string subCategory = (string)cbSubcategoria.SelectedItem;
                string ais = tbAIS.Text;
                string aic = tbAIC.Text;
                IEnumerable<string> spanishList = lbSignificados.Items.Cast<string>().ToList();

                if (_isNew)
                    _myDataBase.InsertNewWord(word, prononciation, category, subCategory, ais, aic, spanishList);
                else
                    _myDataBase.UpdateExistingWord(_frenchWord, word, prononciation, category, subCategory, ais, aic, spanishList);

                DialogResult = System.Windows.Forms.DialogResult.Yes;
                Close();
            }
        }
        private bool ValidateFields()
        {
            bool error = false;
            if (_frenchWord.HitLevel >= 1 && tbPronunciacion.Text.Length == 0)
            {
                MessageBox.Show(@"Debe introducir una pronunciación", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = true;
            }
            if (_frenchWord.HitLevel >= 2 && tbAIS.Text.Length == 0)
            {
                MessageBox.Show(@"Debe introducir una AIS", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = true;
            }
            if (_frenchWord.HitLevel >= 3 && tbAIC.Text.Length == 0)
            {
                MessageBox.Show(@"Debe introducir una AIC", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = true;
            }
            if (tbWord.Text.Length == 0)
            {
                MessageBox.Show(@"Debe introducir una palabra", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = true;
            }
            if (_isNew && _myDataBase.FrenchWords.FirstOrDefault(item => item.WordName.Equals(tbWord.Text)) != null)
            {
                MessageBox.Show(@"La nueva palabra ya existe", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = true;
            }
            if (lbSignificados.Items.Count == 0)
            {
                MessageBox.Show(@"Debe introducir al menos un significado", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = true;
            }
            return error;
        }
        public ListBox LbSignificados
        {
            get
            {
                return lbSignificados;
            }
        }

        private void lbSignificados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Back && lbSignificados.SelectedIndex >= 0)
            {
                lbSignificados.Items.RemoveAt(lbSignificados.SelectedIndex);
                lbSignificados.Update();
            }
        }
        private void tbSignificados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter && tbSignificados.Text.Length > 0)
            {
                // Check no existe:
                if (!lbSignificados.Items.Contains(tbSignificados.Text))
                {
                    lbSignificados.Items.Add(tbSignificados.Text);
                    lbSignificados.Update();
                }
                tbSignificados.Text = "";
            }
            
        }
        /// <summary>
        /// Save form hot-key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VocabularieHitForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)19)
                bSave_Click(this, null);
        }
    }
}
