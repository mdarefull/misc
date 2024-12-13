namespace Français_Helper.Windows
{
    partial class VocabularyQuiz
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
            this.bCancelar = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.lAux = new System.Windows.Forms.Label();
            this.tWordB = new System.Windows.Forms.TextBox();
            this.tWordA = new System.Windows.Forms.TextBox();
            this.lTraduce = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bCancelar
            // 
            this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancelar.Location = new System.Drawing.Point(162, 62);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(75, 23);
            this.bCancelar.TabIndex = 2;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bAceptar
            // 
            this.bAceptar.Location = new System.Drawing.Point(33, 62);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(75, 23);
            this.bAceptar.TabIndex = 1;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // lAux
            // 
            this.lAux.AutoSize = true;
            this.lAux.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAux.Location = new System.Drawing.Point(118, 31);
            this.lAux.Name = "lAux";
            this.lAux.Size = new System.Drawing.Size(38, 25);
            this.lAux.TabIndex = 3;
            this.lAux.Text = "=>";
            // 
            // tWordB
            // 
            this.tWordB.Location = new System.Drawing.Point(162, 36);
            this.tWordB.Name = "tWordB";
            this.tWordB.Size = new System.Drawing.Size(100, 20);
            this.tWordB.TabIndex = 0;
            // 
            // tWordA
            // 
            this.tWordA.Location = new System.Drawing.Point(8, 36);
            this.tWordA.Name = "tWordA";
            this.tWordA.ReadOnly = true;
            this.tWordA.Size = new System.Drawing.Size(100, 20);
            this.tWordA.TabIndex = 3;
            // 
            // lTraduce
            // 
            this.lTraduce.AutoSize = true;
            this.lTraduce.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTraduce.ForeColor = System.Drawing.Color.Cyan;
            this.lTraduce.Location = new System.Drawing.Point(26, 2);
            this.lTraduce.Name = "lTraduce";
            this.lTraduce.Size = new System.Drawing.Size(231, 25);
            this.lTraduce.TabIndex = 3;
            this.lTraduce.Text = "Traduce la palabra!!!";
            // 
            // VocabularyQuiz
            // 
            this.AcceptButton = this.bAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.CancelButton = this.bCancelar;
            this.ClientSize = new System.Drawing.Size(272, 95);
            this.ControlBox = false;
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.lAux);
            this.Controls.Add(this.tWordB);
            this.Controls.Add(this.tWordA);
            this.Controls.Add(this.lTraduce);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VocabularyQuiz";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VocabularyQuiz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Label lAux;
        private System.Windows.Forms.TextBox tWordB;
        private System.Windows.Forms.TextBox tWordA;
        private System.Windows.Forms.Label lTraduce;
    }
}