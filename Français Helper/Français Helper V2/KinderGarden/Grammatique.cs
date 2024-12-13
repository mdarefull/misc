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
    public partial class Grammatique : UserControl
    {
        private readonly DataBase _myDbBase;

        public Grammatique(DataBase dataBase)
        {
            InitializeComponent();
            _myDbBase = dataBase;
        }

        // C'est le default constructor pour l'utilization au dessinateur.
        public Grammatique ()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When typed a word and enter key pressed the application will attempt to find the rule,
        /// if fail, it suggest to create the new rule.
        /// </summary>
        /// <param name="sender">(not used)</param>
        /// <param name="e">(not used)</param>
        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && tbSearch.Text.Length > 0)
            {
                if (lsRules.SelectedIndex >= 0 && lsRules.SelectedItem.ToString().Equals(tbSearch.Text))
                    lsRules_MouseDoubleClick(null, null);
                else
                {
                    DialogResult dgResult = MessageBox.Show(string.Format("La regla '{0}' no existe. Desea crearla?", tbSearch.Text),
                        @"Regla no registrada", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                    if (dgResult == DialogResult.Yes)
                    {
                        Rule hitRule = new Rule(tbSearch.Text, "");
                        new GrammatiqueHitForm(_myDbBase, hitRule, true).ShowDialog(this);
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
            if (lsRules.Items.Count > 0)
            {
                int index = 0;
                while (index + 1 < lsRules.Items.Count && String.Compare(lsRules.Items[index].ToString(), tbSearch.Text, true) < 0)
                    index++;
                lsRules.SelectedIndex = index;
            }
        }

        /// <summary>
        /// When double clicked over a rule, the rule is seeked and hitted for modification.
        /// </summary>
        /// <param name="sender">(not used)</param>
        /// <param name="e">(not used)</param>
        private void lsRules_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsRules.SelectedIndex >= 0)
            {
                Rule hitRule = (Rule)lsRules.SelectedItem;
                new GrammatiqueHitForm(_myDbBase, hitRule, false).ShowDialog(this);
                Update();
            }
        }
        /// <summary>
        /// Allows the removing of unwanted rules.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsRules_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back && lsRules.SelectedIndex >= 0)
            {
                Rule toRemoveRule = (Rule)lsRules.SelectedItem;
                DialogResult dgResult = MessageBox.Show(string.Format("¿Desea eliminar la regla {0}?", toRemoveRule.Name),
                        @"Eliminar palabra", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                if (dgResult == DialogResult.Yes)
                {
                    _myDbBase.RemoveRule(toRemoveRule);
                    Update();
                }
            }
        }
        /// <summary>
        /// Display the properties of the selected rule in the siders boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsRules.SelectedIndex >= 0)
            {
                tbDescription.Text = ((Rule)lsRules.SelectedItem).Description;
                lbCategorias.Items.Clear();
                lbCategorias.Items.AddRange(((Rule)lsRules.SelectedItem).Categories.ToArray());
                lbCategorias.Update();
            }
        }

        /// <summary>
        /// Performs the update of the entire control.
        /// </summary>
        public new void Update()
        {
            lsRules.Items.Clear();
            foreach (var item in _myDbBase.Rules)
                lsRules.Items.Add(item);
            lsRules.Update();

            tbDescription.Text = "";
            lbCategorias.Items.Clear();

            // El selector de elemento será el texto de la búsqueda.
            tbSearch_TextChanged(this, null);
        }
    }
}
