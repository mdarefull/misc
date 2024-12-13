using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Français_Helper.Windows
{
    public partial class Vocabulario : UserControl
    {
        private readonly DataBase _myDbBase;
        private readonly Random _rnd;

        public Vocabulario(DataBase dataBase)
        {
            InitializeComponent();
            _myDbBase = dataBase;
            _rnd = new Random(DateTime.Now.Millisecond);

            LoadCategories();
        }
        /// <summary>
        /// Load the categories list.
        /// </summary>
        private void LoadCategories()
        {
            cbCategoria.Items.Clear();
            cbCategoria.Items.Add("Todas las categorías.");
            foreach (var item in _myDbBase.CategoryList)
                cbCategoria.Items.Add(item);
            cbCategoria.Update();
            cbCategoria.SelectedIndex = 0;
        }

        /// <summary>
        /// When typed a word and enter key pressed the application will attempt to find the word,
        /// if fail, it suggest to create the new word.
        /// </summary>
        /// <param name="sender">(not used)</param>
        /// <param name="e">(not used)</param>
        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && tbSearch.Text.Length > 0)
            {
                FrenchWord frWord = _myDbBase.FrenchWords.FirstOrDefault(x => x.WordName.Equals(tbSearch.Text));

                if (frWord != null)
                    lsWords_MouseDoubleClick(frWord, null);
                else
                {
                    DialogResult dgResult = MessageBox.Show(string.Format("La palabra '{0}' no existe. Desea crearla?", tbSearch.Text),
                        @"Palabra no registrada", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                    if (dgResult == DialogResult.Yes)
                    {
                        int index = cbCategoria.SelectedIndex;
                        if (cbCategoria.SelectedIndex == 0)
                            index = 1;
                        FrenchWord hitFrenchWord = new FrenchWord(tbSearch.Text, "", (Categoria)cbCategoria.Items[index], cbSubcategoria.SelectedItem.ToString(),
                            "", "", DateTime.Today, -1, 0);

                        if (new VocabularieHitForm(_myDbBase, hitFrenchWord, true).ShowDialog(this) == DialogResult.Yes)
                            lsWords.Items.Add(_myDbBase.FrenchWords[_myDbBase.FrenchWords.Count - 1]);
                    }
                }
                tbSearch.Text = "";
            }
        }
        /// <summary>
        /// Enabled interactive search.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (lsWords.Items.Count > 0)
                lsWords.SelectedIndex = MyAlgorithmsStore.SearchLessWord(tbSearch.Text.ToLower(), lsWords.Items);
        }
        private void lsWords_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FrenchWord hittedFrenchWord = null;
            if (sender is FrenchWord)
                hittedFrenchWord = sender as FrenchWord;
            else if (lsWords.SelectedIndex >= 0)
                hittedFrenchWord = lsWords.SelectedItem as FrenchWord;

            if (hittedFrenchWord != null)
            {
                DateTime prevDT = hittedFrenchWord.LastHitDate;
                _myDbBase.HitFrenchWord(hittedFrenchWord);
                if (new VocabularieHitForm(_myDbBase, hittedFrenchWord, false).ShowDialog(this) == DialogResult.Cancel)
                    _myDbBase.UnHitFrenchWord(hittedFrenchWord, prevDT);
            }
        }
        /// <summary>
        /// Allows the removing of unwanted words.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsWords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lsWords.SelectedIndex >= 0 && e.KeyChar == (char)Keys.Back)
            {
                FrenchWord selectedWord = (FrenchWord)lsWords.SelectedItem;
                DialogResult dgResult = MessageBox.Show(string.Format("¿Desea eliminar la palabra {0}?", selectedWord.WordName),
                        @"Eliminar Palabra", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                if (dgResult == DialogResult.Yes)
                {
                    _myDbBase.RemoveFrenchWord(selectedWord);
                    lsWords.Items.RemoveAt(lsWords.SelectedIndex);
                }
            }
        }

        /// <summary>
        /// Updates subcategory list when changed, and filter the lsWords.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSubcategoria.Items.Clear();
            cbSubcategoria.Items.Add("Todas las subcategorías");
            if (cbCategoria.SelectedIndex != 0)
                foreach (var item in ((Categoria)cbCategoria.SelectedItem).Subcategories)
                    cbSubcategoria.Items.Add(item);
            cbSubcategoria.Update();
            cbSubcategoria.SelectedIndex = 0;

            // Acá no actualizo la lista de filtrado pues la línea anterior causa el cambio de index de subcategoría
            // y por consiguiente la actualización nula.
        }
        /// <summary>
        /// Invoca la actualización de la lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSubcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            Update();
        }
        /// <summary>
        /// Performs the update of the entire control. List the words specified accordingly to the filter.
        /// </summary>
        public new void Update()
        {
            lsWords.Items.Clear();
            string categoryFilter = cbCategoria.SelectedIndex == 0 ? null : cbCategoria.SelectedItem.ToString();
            string subcategoryFilter = cbSubcategoria.SelectedIndex == 0 ? null : cbSubcategoria.SelectedItem.ToString();

            List<FrenchWord> filtreds = new List<FrenchWord>();
            foreach (var item in _myDbBase.FrenchWords)
                if (categoryFilter == null || item.Categoria.ToString().Equals(categoryFilter))
                    if (subcategoryFilter == null || item.Subcategoria.Equals(subcategoryFilter))
                        filtreds.Add(item);

            foreach (var item in filtreds)
                lsWords.Items.Add(item);

            lsWords.Invalidate();

            // El selector de elemento será el texto de la búsqueda.
            tbSearch_TextChanged(this, null);
        }


        private void lSpToFrQuiz_Click(object sender, EventArgs e)
        {
            if (_myDbBase.SpanishWords.Count == 0)
                return;

            // Chequeo que la palabra no sea una definición y que tenga algún significado en francés que no sea compuesta.
            SpanishWord randomSpWord = null;
            FrenchWord nonCompouestaFrWord;
            do
            {
                int randomIndex = _rnd.Next(0, _myDbBase.SpanishWords.Count);
                randomSpWord = _myDbBase.SpanishWords[randomIndex];
                nonCompouestaFrWord = randomSpWord.FrenchWords.FirstOrDefault(x => !x.Categoria.CategoriaName.Equals("Compuestas"));
            } while (randomSpWord.WordName[0] == '*' || nonCompouestaFrWord == null);
            
            
            DialogResult dResult = new VocabularyQuiz(randomSpWord, randomSpWord.FrenchWords.Cast<Word>().ToList()).ShowDialog();
            if (dResult == DialogResult.No)
            {
                lsWords.SelectedItem = randomSpWord.FrenchWords[0];
                lsWords_MouseDoubleClick(null, null);
            }
        }
        private void lFrToSpQuiz_Click(object sender, EventArgs e)
        {
            if (_myDbBase.FrenchWords.Count == 0)
                return;

            // Chequeo que la palabra no sea compuesta y que posea al menos un significado que no sea una definición.
            FrenchWord randomFrWord = null;
            SpanishWord nonDefinitionSpWord = null;

            do
            {
                int randomIndex = _rnd.Next(0, _myDbBase.FrenchWords.Count);
                randomFrWord = _myDbBase.FrenchWords[randomIndex];
                nonDefinitionSpWord = randomFrWord.SpanishesWords.FirstOrDefault(x => x.WordName[0] != '*');
            } while (randomFrWord.Categoria.CategoriaName.Equals("Compuetas") || nonDefinitionSpWord == null);
            
            
            DialogResult dResult = new VocabularyQuiz(randomFrWord, randomFrWord.SpanishesWords.Cast<Word>().ToList()).ShowDialog();
            if (dResult == DialogResult.No)
            {
                lsWords.SelectedItem = randomFrWord;
                lsWords_MouseDoubleClick(null, null);
            }
        }

        private void tbSearchSp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && tbSearchSp.Text.Length > 0)
            {
                SpanishWord spWord = _myDbBase.SpanishWords.FirstOrDefault(x => x.WordName.Equals(tbSearchSp.Text));
                if (spWord != null)
                    foreach (var item in spWord.FrenchWords)
                        lsWords_MouseDoubleClick(item, null);
                else
                {
                    DialogResult dgResult = MessageBox.Show(string.Format("La palabra '{0}' no existe. Desea crearla?", tbSearch.Text),
                        @"Palabra no registrada", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                    if (dgResult == DialogResult.Yes)
                    {
                        int index = cbCategoria.SelectedIndex;
                        if (cbCategoria.SelectedIndex == 0)
                            index = 1;
                        FrenchWord hitFrenchWord = new FrenchWord("", "", (Categoria)cbCategoria.Items[index], cbSubcategoria.SelectedItem.ToString(),
                            "", "", DateTime.Today, -1, 0);

                        VocabularieHitForm newVocabularieHitForm = new VocabularieHitForm(_myDbBase, hitFrenchWord, true);
                        newVocabularieHitForm.LbSignificados.Items.Add(tbSearchSp.Text);
                        if (newVocabularieHitForm.ShowDialog(this) == DialogResult.Yes)
                            lsWords.Items.Add(hitFrenchWord);
                    }
                }
                tbSearchSp.Text = "";
            }
        }
    }
}
