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
    public partial class GrammatiqueHitForm : Form
    {
        private readonly DataBase _myDataBase;
        private readonly Rule _rule;
        private readonly bool _isNew;

        public GrammatiqueHitForm(DataBase dataBase, Rule rule, bool isNew)
        {
            InitializeComponent();
            _myDataBase = dataBase;
            _rule = rule;
            _isNew = isNew;

            InitializeCbCategoria();
            InitializeFields();
            tbName.Focus();
        }
        private void InitializeCbCategoria()
        {
            cbCategories.Items.Clear();
            foreach (var item in _myDataBase.CategoryList)
                cbCategories.Items.Add(item);
            cbCategories.Update();
            if (cbCategories.Items.Count > 0)
                cbCategories.SelectedIndex = 0;
        }
        private void InitializeFields()
        {
            tbName.Text = _rule.Name;
            tbDescription.Text = _rule.Description;
            lbCategories.Items.AddRange(_rule.Categories.ToArray());
        }

        /// <summary>
        /// Adds the selected category to the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbCategories_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && cbCategories.SelectedIndex >= 0)
            {
                // Check no existe:
                if (!lbCategories.Items.Contains(cbCategories.SelectedItem))
                {
                    lbCategories.Items.Add(cbCategories.SelectedItem);
                    lbCategories.Update();
                }
            }
        }
        /// <summary>
        /// Save form hot-key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RuleHitForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)19)
                bSave_Click(this, null);
        }

        /// <summary>
        /// Remove an unwanted category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbCategories_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back && lbCategories.SelectedIndex >= 0)
                lbCategories.Items.RemoveAt(lbCategories.SelectedIndex);
        }

        /// <summary>
        /// Validate the fields, if correct, update or create the rule.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
            {
                string name = tbName.Text;
                string description = tbDescription.Text;
                List<Categoria> categories = lbCategories.Items.Cast<Categoria>().ToList();
                
                if (_isNew)
                    _myDataBase.InsertNewRule(name, description, categories);
                else
                    _myDataBase.UpdateExistingRule(_rule, name, description, categories);

                Close();
            }
        }
        /// <summary>
        /// Validate each field, to prevent possibles malfunctions and /)&/%.
        /// </summary>
        /// <returns>True if an error was found, false otherwise.</returns>
        private bool ValidateFields()
        {
            bool error = false;
            if (tbName.Text.Length == 0)
            {
                MessageBox.Show(@"Debe introducir un nombre", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = true;
            }
            if (_isNew && _myDataBase.Rules.FirstOrDefault(item => item.Name.Equals(tbName.Text)) != null)
            {
                MessageBox.Show(@"La nueva regla ya existe", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = true;
            }
            if (tbDescription.Text.Length == 0)
            {
                MessageBox.Show(@"Debe introducir una descripción", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = true;
            }
            if (lbCategories.Items.Count == 0)
            {
                MessageBox.Show(@"Debe introducir al menos una categoría", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = true;
            }
            return error;
        }
        /// <summary>
        /// Simply closes the form, returning control to the caller.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
