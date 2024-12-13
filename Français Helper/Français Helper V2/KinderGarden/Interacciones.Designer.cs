namespace Français_Helper.Windows
{
    partial class Interacciones
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lTitle = new System.Windows.Forms.Label();
            this.lbPreguntas = new System.Windows.Forms.ListBox();
            this.lRespuestas = new System.Windows.Forms.Label();
            this.lSearch = new System.Windows.Forms.Label();
            this.lPreguntas = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lsInteractions = new System.Windows.Forms.ListBox();
            this.lbRespuestas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.ForeColor = System.Drawing.Color.Blue;
            this.lTitle.Location = new System.Drawing.Point(107, 10);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(135, 24);
            this.lTitle.TabIndex = 13;
            this.lTitle.Text = "Interacciones";
            // 
            // lbPreguntas
            // 
            this.lbPreguntas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPreguntas.FormattingEnabled = true;
            this.lbPreguntas.HorizontalScrollbar = true;
            this.lbPreguntas.Location = new System.Drawing.Point(171, 50);
            this.lbPreguntas.Name = "lbPreguntas";
            this.lbPreguntas.Size = new System.Drawing.Size(162, 147);
            this.lbPreguntas.TabIndex = 2;
            // 
            // lRespuestas
            // 
            this.lRespuestas.AutoSize = true;
            this.lRespuestas.Location = new System.Drawing.Point(168, 200);
            this.lRespuestas.Name = "lRespuestas";
            this.lRespuestas.Size = new System.Drawing.Size(66, 13);
            this.lRespuestas.TabIndex = 3;
            this.lRespuestas.Text = "Respuestas:";
            // 
            // lSearch
            // 
            this.lSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lSearch.AutoSize = true;
            this.lSearch.Location = new System.Drawing.Point(172, 367);
            this.lSearch.Name = "lSearch";
            this.lSearch.Size = new System.Drawing.Size(111, 13);
            this.lSearch.TabIndex = 6;
            this.lSearch.Text = "Búsqueda Interactiva:";
            // 
            // lPreguntas
            // 
            this.lPreguntas.AutoSize = true;
            this.lPreguntas.Location = new System.Drawing.Point(168, 34);
            this.lPreguntas.Name = "lPreguntas";
            this.lPreguntas.Size = new System.Drawing.Size(58, 13);
            this.lPreguntas.TabIndex = 2;
            this.lPreguntas.Text = "Preguntas:";
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSearch.Location = new System.Drawing.Point(171, 383);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(155, 20);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // lsInteractions
            // 
            this.lsInteractions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lsInteractions.FormattingEnabled = true;
            this.lsInteractions.Location = new System.Drawing.Point(7, 37);
            this.lsInteractions.Name = "lsInteractions";
            this.lsInteractions.Size = new System.Drawing.Size(155, 368);
            this.lsInteractions.Sorted = true;
            this.lsInteractions.TabIndex = 1;
            this.lsInteractions.SelectedIndexChanged += new System.EventHandler(this.lsInteractions_SelectedIndexChanged);
            this.lsInteractions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lsInteractions_KeyPress);
            this.lsInteractions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsInteractions_MouseDoubleClick);
            // 
            // lbRespuestas
            // 
            this.lbRespuestas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRespuestas.FormattingEnabled = true;
            this.lbRespuestas.HorizontalScrollbar = true;
            this.lbRespuestas.Location = new System.Drawing.Point(171, 216);
            this.lbRespuestas.MultiColumn = true;
            this.lbRespuestas.Name = "lbRespuestas";
            this.lbRespuestas.Size = new System.Drawing.Size(162, 147);
            this.lbRespuestas.TabIndex = 3;
            // 
            // Interacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Magenta;
            this.Controls.Add(this.lbRespuestas);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.lbPreguntas);
            this.Controls.Add(this.lRespuestas);
            this.Controls.Add(this.lSearch);
            this.Controls.Add(this.lPreguntas);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lsInteractions);
            this.Name = "Interacciones";
            this.Size = new System.Drawing.Size(336, 410);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.ListBox lbPreguntas;
        private System.Windows.Forms.Label lRespuestas;
        private System.Windows.Forms.Label lSearch;
        private System.Windows.Forms.Label lPreguntas;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ListBox lsInteractions;
        private System.Windows.Forms.ListBox lbRespuestas;
    }
}
