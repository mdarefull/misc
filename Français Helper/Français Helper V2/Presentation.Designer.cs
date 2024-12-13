using Français_Helper.Windows;
namespace Français_Helper
{
    partial class PresentationForm
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
            this.lVocabulario = new System.Windows.Forms.Label();
            this.lInteracciones = new System.Windows.Forms.Label();
            this.lReglas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lVocabulario
            // 
            this.lVocabulario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lVocabulario.AutoSize = true;
            this.lVocabulario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lVocabulario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVocabulario.ForeColor = System.Drawing.Color.White;
            this.lVocabulario.Location = new System.Drawing.Point(12, 407);
            this.lVocabulario.Name = "lVocabulario";
            this.lVocabulario.Size = new System.Drawing.Size(74, 13);
            this.lVocabulario.TabIndex = 0;
            this.lVocabulario.Text = "Vocabulario";
            this.lVocabulario.Click += new System.EventHandler(this.lVocabulario_Click);
            // 
            // lInteracciones
            // 
            this.lInteracciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lInteracciones.AutoSize = true;
            this.lInteracciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lInteracciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lInteracciones.ForeColor = System.Drawing.Color.White;
            this.lInteracciones.Location = new System.Drawing.Point(242, 407);
            this.lInteracciones.Name = "lInteracciones";
            this.lInteracciones.Size = new System.Drawing.Size(84, 13);
            this.lInteracciones.TabIndex = 1;
            this.lInteracciones.Text = "Interacciones";
            this.lInteracciones.Click += new System.EventHandler(this.lInteracciones_Click);
            // 
            // lReglas
            // 
            this.lReglas.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lReglas.AutoSize = true;
            this.lReglas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lReglas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lReglas.ForeColor = System.Drawing.Color.White;
            this.lReglas.Location = new System.Drawing.Point(124, 407);
            this.lReglas.Name = "lReglas";
            this.lReglas.Size = new System.Drawing.Size(80, 13);
            this.lReglas.TabIndex = 2;
            this.lReglas.Text = "Grammatique";
            this.lReglas.Click += new System.EventHandler(this.lReglas_Click);
            // 
            // PresentationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.ClientSize = new System.Drawing.Size(338, 429);
            this.Controls.Add(this.lReglas);
            this.Controls.Add(this.lInteracciones);
            this.Controls.Add(this.lVocabulario);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(354, 300);
            this.Name = "PresentationForm";
            this.Text = "Française Helper";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PresentationForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lVocabulario;
        private System.Windows.Forms.Label lInteracciones;
        private System.Windows.Forms.Label lReglas;




    }
}

