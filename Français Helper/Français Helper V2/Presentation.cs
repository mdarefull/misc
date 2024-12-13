using Français_Helper.Windows;
using System;
using System.Windows.Forms;

namespace Français_Helper
{
    public partial class PresentationForm : Form
    {
        private readonly DataBase _myDbBase;
        private readonly Vocabulario _myVocabulario;
        private readonly Grammatique _myReglas;
        private readonly Interacciones _myInteractions;

        public PresentationForm()
        {
            InitializeComponent();

            _myDbBase = new DataBase();

            //
            // My Vocabulario.
            //
            _myVocabulario = new Vocabulario(_myDbBase);
            _myVocabulario.Location = new System.Drawing.Point(0, 0);
            _myVocabulario.Name = "vocabulario";
            _myVocabulario.Update();
            _myVocabulario.Visible = true;
            _myVocabulario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            Controls.Add(_myVocabulario);

            //
            // My Reglas.
            //
            _myReglas = new Grammatique(_myDbBase);
            _myReglas.Location = new System.Drawing.Point(0, -10);
            _myReglas.Name = "reglas";
            _myReglas.Update();
            _myReglas.Visible = false;
            _myReglas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            Controls.Add(_myReglas);
            
            //
            // My Interactions
            //
            _myInteractions = new Interacciones(_myDbBase);
            _myInteractions.Location = new System.Drawing.Point(0, -10);
            _myInteractions.Name = "interacciones";
            _myInteractions.Update();
            _myInteractions.Visible = false;
            _myInteractions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            Controls.Add(_myInteractions);
        }

        private void lVocabulario_Click(object sender, EventArgs e)
        {
            _myReglas.Visible = false;
            _myInteractions.Visible = false;
            _myVocabulario.Visible = true;
        }

        private void lReglas_Click(object sender, EventArgs e)
        {
            _myInteractions.Visible = false;
            _myVocabulario.Visible = false;
            _myReglas.Visible = true;
        }

        private void lInteracciones_Click(object sender, EventArgs e)
        {
            _myVocabulario.Visible = false;
            _myReglas.Visible = false;
            _myInteractions.Visible = true;
        }

        private void PresentationForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                lVocabulario_Click(sender, null);
            else if (e.KeyValue == (char)Keys.F2)
                lReglas_Click(sender, null);
            else if (e.KeyValue == (char)Keys.F3)
                lInteracciones_Click(sender, null);
        }
    }
}
