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
    public partial class InteractionHitForm : Form
    {
        private readonly DataBase _myDataBase;
        private readonly Interaction _interaction;
        private readonly bool _isNew;

        public InteractionHitForm(DataBase myDataBase, Interaction interaction, bool isNew)
        {
            InitializeComponent();
            _myDataBase = myDataBase;
            _interaction = interaction;
            _isNew = isNew;

            InitializeFields();
            tbName.Focus();
        }
        private void InitializeFields()
        {
            tbName.Text = _interaction.Name;
            lbPreguntas.Items.AddRange(_interaction.Questions.ToArray());
            lbRespuestas.Items.AddRange(_interaction.Answers.ToArray());
        }

        /// <summary>
        /// Adds the selected question to the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPreguntas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && tbPreguntas.Text.Length > 0)
            {
                // Check no existe:
                if (!lbPreguntas.Items.Contains(tbPreguntas.Text))
                {
                    lbPreguntas.Items.Add(tbPreguntas.Text);
                    lbPreguntas.Update();
                }
                tbPreguntas.Text = "";
            }
        }
        /// <summary>
        /// Adds the selected answer to the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbRespuestas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && tbRespuestas.Text.Length > 0)
            {
                // Check no existe:
                if (!lbRespuestas.Items.Contains(tbRespuestas.Text))
                {
                    lbRespuestas.Items.Add(tbRespuestas.Text);
                    lbRespuestas.Update();
                }
                tbRespuestas.Text = "";
            }
        }
        /// <summary>
        /// Form save hot_key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InteractionHitForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)19)
                bSave_Click(this, null);
        }
        /// <summary>
        /// Remove an unwanted question.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbPreguntas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back && lbPreguntas.SelectedIndex >= 0)
                lbPreguntas.Items.RemoveAt(lbPreguntas.SelectedIndex);
        }
        /// <summary>
        /// Remove an unwanted answer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbRespuestas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back && lbRespuestas.SelectedIndex >= 0)
                lbRespuestas.Items.RemoveAt(lbRespuestas.SelectedIndex);
        }

        /// <summary>
        /// Validate the fields, if correct, update or create the interaction.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
            {
                string name = tbName.Text;
                List<string> questions = lbPreguntas.Items.Cast<string>().ToList();
                List<string> answers = lbRespuestas.Items.Cast<string>().ToList();

                if (_isNew)
                    _myDataBase.InsertNewInteraction(name, questions, answers);
                else
                    _myDataBase.UpdateExistingInteraction(_interaction, name, questions, answers);

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
            if (_isNew && _myDataBase.Interactions.FirstOrDefault(item => item.Name.Equals(tbName.Text)) != null)
            {
                MessageBox.Show(@"La nueva interacción ya existe", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = true;
            }
            if (lbPreguntas.Items.Count == 0)
            {
                MessageBox.Show(@"Debe introducir al menos una respuesta", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                error = true;
            }
            if (lbRespuestas.Items.Count == 0)
            {
                MessageBox.Show(@"Debe introducir al menos una respuesta", "Error", MessageBoxButtons.OK,
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
