using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Français_Helper.Windows
{
    public partial class Interacciones : UserControl
    {
        private readonly DataBase _myDbBase;

        public Interacciones(DataBase dataBase)
        {
            InitializeComponent();
            _myDbBase = dataBase;
        }

        /// <summary>
        /// When typed a word and enter key pressed the application will attempt to find the interaction object,
        /// if fail, it suggest to create the new interaction.
        /// </summary>
        /// <param name="sender">(not used)</param>
        /// <param name="e">(not used)</param>
        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && tbSearch.Text.Length > 0)
            {
                if (lsInteractions.SelectedIndex >= 0 && lsInteractions.SelectedItem.ToString().Equals(tbSearch.Text))
                    lsInteractions_MouseDoubleClick(null, null);
                else
                {
                    DialogResult dgResult = MessageBox.Show(string.Format("La interacción '{0}' no existe. Desea crearla?", tbSearch.Text),
                        @"Interacción no registrada", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                    if (dgResult == DialogResult.Yes)
                    {
                        Interaction hitInteraction = new Interaction(tbSearch.Text);
                        if (new InteractionHitForm(_myDbBase, hitInteraction, true).ShowDialog(this) == DialogResult.Yes)
                            Update();
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
            if (lsInteractions.Items.Count > 0)
            {
                int index = 0;
                while (index + 1 < lsInteractions.Items.Count && String.Compare(lsInteractions.Items[index].ToString(), tbSearch.Text, true) < 0)
                    index++;
                lsInteractions.SelectedIndex = index;
            }
        }


        /// <summary>
        /// When double clicked over an interaction, the interaction is seeked and hitted for modification.
        /// </summary>
        /// <param name="sender">(not used)</param>
        /// <param name="e">(not used)</param>
        private void lsInteractions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsInteractions.SelectedIndex >= 0)
            {
                Interaction hitInteraction = (Interaction)lsInteractions.SelectedItem;
                new InteractionHitForm(_myDbBase, hitInteraction, false).ShowDialog(this);
            }
        }
        /// <summary>
        /// Allows the removing of unwanted interactions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsInteractions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back && lsInteractions.SelectedIndex >= 0)
            {
                Interaction toRemove = (Interaction)lsInteractions.SelectedItem;
                DialogResult dgResult = MessageBox.Show(string.Format("¿Desea eliminar la interacción {0}?", toRemove.Name),
                        @"Eliminar palabra", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                if (dgResult == DialogResult.Yes)
                {
                    _myDbBase.RemoveInteraction(toRemove);
                    Update();
                }
            }
        }
        /// <summary>
        /// Display the properties of the selected interaction in the siders boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsInteractions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsInteractions.SelectedIndex >= 0)
            {
                lbPreguntas.Items.Clear();
                lbPreguntas.Items.AddRange(((Interaction)lsInteractions.SelectedItem).Questions.ToArray());
                lbPreguntas.Update();

                lbRespuestas.Items.Clear();
                lbRespuestas.Items.AddRange(((Interaction)lsInteractions.SelectedItem).Answers.ToArray());
                lbRespuestas.Update();
            }
        }

        /// <summary>
        /// Performs the update of the entire control.
        /// </summary>
        public new void Update()
        {
            lsInteractions.Items.Clear();
            foreach (var item in _myDbBase.Interactions)
                lsInteractions.Items.Add(item);
            lsInteractions.Update();

            // El selector de elemento será el texto de la búsqueda.
            tbSearch_TextChanged(this, null);


            lbPreguntas.Items.Clear();
            lbRespuestas.Items.Clear();
        }
    }
}
