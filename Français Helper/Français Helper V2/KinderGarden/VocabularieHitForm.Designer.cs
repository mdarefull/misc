namespace Français_Helper
{
    partial class VocabularieHitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.lPalabra = new System.Windows.Forms.Label();
            this.lPrononciation = new System.Windows.Forms.Label();
            this.lCategoria = new System.Windows.Forms.Label();
            this.lSubcategoria = new System.Windows.Forms.Label();
            this.lAIS = new System.Windows.Forms.Label();
            this.lAIC = new System.Windows.Forms.Label();
            this.lSignificados = new System.Windows.Forms.Label();
            this.tbWord = new System.Windows.Forms.TextBox();
            this.tbPronunciacion = new System.Windows.Forms.TextBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.cbSubcategoria = new System.Windows.Forms.ComboBox();
            this.lbSignificados = new System.Windows.Forms.ListBox();
            this.tbSignificados = new System.Windows.Forms.TextBox();
            this.tbAIS = new System.Windows.Forms.TextBox();
            this.tbAIC = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bSave.Location = new System.Drawing.Point(67, 363);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 7;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(181, 363);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 8;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // lPalabra
            // 
            this.lPalabra.AutoSize = true;
            this.lPalabra.Location = new System.Drawing.Point(12, 14);
            this.lPalabra.Name = "lPalabra";
            this.lPalabra.Size = new System.Drawing.Size(46, 13);
            this.lPalabra.TabIndex = 3;
            this.lPalabra.Text = "Palabra:";
            // 
            // lPrononciation
            // 
            this.lPrononciation.AutoSize = true;
            this.lPrononciation.Location = new System.Drawing.Point(14, 62);
            this.lPrononciation.Name = "lPrononciation";
            this.lPrononciation.Size = new System.Drawing.Size(75, 13);
            this.lPrononciation.TabIndex = 4;
            this.lPrononciation.Text = "Pronunciación";
            // 
            // lCategoria
            // 
            this.lCategoria.AutoSize = true;
            this.lCategoria.Location = new System.Drawing.Point(14, 112);
            this.lCategoria.Name = "lCategoria";
            this.lCategoria.Size = new System.Drawing.Size(54, 13);
            this.lCategoria.TabIndex = 1;
            this.lCategoria.Text = "Categoría";
            // 
            // lSubcategoria
            // 
            this.lSubcategoria.AutoSize = true;
            this.lSubcategoria.Location = new System.Drawing.Point(14, 166);
            this.lSubcategoria.Name = "lSubcategoria";
            this.lSubcategoria.Size = new System.Drawing.Size(75, 13);
            this.lSubcategoria.TabIndex = 2;
            this.lSubcategoria.Text = "Subcategoría:";
            // 
            // lAIS
            // 
            this.lAIS.AutoSize = true;
            this.lAIS.Location = new System.Drawing.Point(12, 214);
            this.lAIS.Name = "lAIS";
            this.lAIS.Size = new System.Drawing.Size(27, 13);
            this.lAIS.TabIndex = 5;
            this.lAIS.Text = "AIS:";
            // 
            // lAIC
            // 
            this.lAIC.AutoSize = true;
            this.lAIC.Location = new System.Drawing.Point(183, 214);
            this.lAIC.Name = "lAIC";
            this.lAIC.Size = new System.Drawing.Size(27, 13);
            this.lAIC.TabIndex = 6;
            this.lAIC.Text = "AIC:";
            // 
            // lSignificados
            // 
            this.lSignificados.AutoSize = true;
            this.lSignificados.Location = new System.Drawing.Point(189, 14);
            this.lSignificados.Name = "lSignificados";
            this.lSignificados.Size = new System.Drawing.Size(67, 13);
            this.lSignificados.TabIndex = 0;
            this.lSignificados.Text = "Significados:";
            // 
            // tbWord
            // 
            this.tbWord.Location = new System.Drawing.Point(16, 30);
            this.tbWord.Name = "tbWord";
            this.tbWord.Size = new System.Drawing.Size(121, 20);
            this.tbWord.TabIndex = 3;
            // 
            // tbPronunciacion
            // 
            this.tbPronunciacion.ForeColor = System.Drawing.Color.Red;
            this.tbPronunciacion.Location = new System.Drawing.Point(17, 79);
            this.tbPronunciacion.Name = "tbPronunciacion";
            this.tbPronunciacion.Size = new System.Drawing.Size(121, 20);
            this.tbPronunciacion.TabIndex = 4;
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(17, 129);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(121, 21);
            this.cbCategoria.TabIndex = 1;
            this.cbCategoria.SelectedIndexChanged += new System.EventHandler(this.cbCategoria_SelectedIndexChanged);
            // 
            // cbSubcategoria
            // 
            this.cbSubcategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubcategoria.FormattingEnabled = true;
            this.cbSubcategoria.Location = new System.Drawing.Point(17, 183);
            this.cbSubcategoria.Name = "cbSubcategoria";
            this.cbSubcategoria.Size = new System.Drawing.Size(121, 21);
            this.cbSubcategoria.TabIndex = 2;
            // 
            // lbSignificados
            // 
            this.lbSignificados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSignificados.ForeColor = System.Drawing.Color.Lime;
            this.lbSignificados.FormattingEnabled = true;
            this.lbSignificados.Location = new System.Drawing.Point(186, 30);
            this.lbSignificados.Name = "lbSignificados";
            this.lbSignificados.Size = new System.Drawing.Size(168, 95);
            this.lbSignificados.Sorted = true;
            this.lbSignificados.TabIndex = 0;
            this.lbSignificados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbSignificados_KeyPress);
            // 
            // tbSignificados
            // 
            this.tbSignificados.Location = new System.Drawing.Point(186, 130);
            this.tbSignificados.Name = "tbSignificados";
            this.tbSignificados.Size = new System.Drawing.Size(168, 20);
            this.tbSignificados.TabIndex = 0;
            this.tbSignificados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSignificados_KeyPress);
            // 
            // tbAIS
            // 
            this.tbAIS.Location = new System.Drawing.Point(16, 231);
            this.tbAIS.Multiline = true;
            this.tbAIS.Name = "tbAIS";
            this.tbAIS.Size = new System.Drawing.Size(126, 109);
            this.tbAIS.TabIndex = 5;
            // 
            // tbAIC
            // 
            this.tbAIC.Location = new System.Drawing.Point(181, 231);
            this.tbAIC.Multiline = true;
            this.tbAIC.Name = "tbAIC";
            this.tbAIC.Size = new System.Drawing.Size(173, 109);
            this.tbAIC.TabIndex = 6;
            // 
            // VocabularieHitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Magenta;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(367, 397);
            this.ControlBox = false;
            this.Controls.Add(this.tbAIC);
            this.Controls.Add(this.tbAIS);
            this.Controls.Add(this.tbSignificados);
            this.Controls.Add(this.lbSignificados);
            this.Controls.Add(this.cbSubcategoria);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.tbPronunciacion);
            this.Controls.Add(this.tbWord);
            this.Controls.Add(this.lSignificados);
            this.Controls.Add(this.lAIC);
            this.Controls.Add(this.lAIS);
            this.Controls.Add(this.lSubcategoria);
            this.Controls.Add(this.lCategoria);
            this.Controls.Add(this.lPrononciation);
            this.Controls.Add(this.lPalabra);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(383, 436);
            this.Name = "VocabularieHitForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HitForm";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VocabularieHitForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label lPalabra;
        private System.Windows.Forms.Label lPrononciation;
        private System.Windows.Forms.Label lCategoria;
        private System.Windows.Forms.Label lSubcategoria;
        private System.Windows.Forms.Label lAIS;
        private System.Windows.Forms.Label lAIC;
        private System.Windows.Forms.Label lSignificados;
        private System.Windows.Forms.TextBox tbWord;
        private System.Windows.Forms.TextBox tbPronunciacion;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.ComboBox cbSubcategoria;
        private System.Windows.Forms.ListBox lbSignificados;
        private System.Windows.Forms.TextBox tbSignificados;
        private System.Windows.Forms.TextBox tbAIS;
        private System.Windows.Forms.TextBox tbAIC;
    }
}