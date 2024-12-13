namespace Français_Helper.Windows
{
    partial class Vocabulario
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
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lsWords = new System.Windows.Forms.ListBox();
            this.lFiltrar = new System.Windows.Forms.Label();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.lFiltrar2 = new System.Windows.Forms.Label();
            this.cbSubcategoria = new System.Windows.Forms.ComboBox();
            this.lSearch = new System.Windows.Forms.Label();
            this.lTitle = new System.Windows.Forms.Label();
            this.lSpToFrQuiz = new System.Windows.Forms.Label();
            this.lFrToSpQuiz = new System.Windows.Forms.Label();
            this.lSearchSp = new System.Windows.Forms.Label();
            this.tbSearchSp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSearch.Location = new System.Drawing.Point(5, 378);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(155, 20);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // lsWords
            // 
            this.lsWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lsWords.Location = new System.Drawing.Point(3, 26);
            this.lsWords.Name = "lsWords";
            this.lsWords.Size = new System.Drawing.Size(169, 329);
            this.lsWords.TabIndex = 1;
            this.lsWords.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lsWords_KeyPress);
            this.lsWords.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsWords_MouseDoubleClick);
            // 
            // lFiltrar
            // 
            this.lFiltrar.AutoSize = true;
            this.lFiltrar.Location = new System.Drawing.Point(176, 26);
            this.lFiltrar.Name = "lFiltrar";
            this.lFiltrar.Size = new System.Drawing.Size(102, 13);
            this.lFiltrar.TabIndex = 2;
            this.lFiltrar.Text = "Filtrar por categoría:";
            // 
            // cbCategoria
            // 
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(179, 42);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(154, 21);
            this.cbCategoria.TabIndex = 2;
            this.cbCategoria.SelectedIndexChanged += new System.EventHandler(this.cbCategoria_SelectedIndexChanged);
            // 
            // lFiltrar2
            // 
            this.lFiltrar2.AutoSize = true;
            this.lFiltrar2.Location = new System.Drawing.Point(176, 66);
            this.lFiltrar2.Name = "lFiltrar2";
            this.lFiltrar2.Size = new System.Drawing.Size(119, 13);
            this.lFiltrar2.TabIndex = 3;
            this.lFiltrar2.Text = "Filtrar por subcategoría:";
            // 
            // cbSubcategoria
            // 
            this.cbSubcategoria.FormattingEnabled = true;
            this.cbSubcategoria.Location = new System.Drawing.Point(179, 82);
            this.cbSubcategoria.Name = "cbSubcategoria";
            this.cbSubcategoria.Size = new System.Drawing.Size(154, 21);
            this.cbSubcategoria.TabIndex = 3;
            this.cbSubcategoria.SelectedIndexChanged += new System.EventHandler(this.cbSubcategoria_SelectedIndexChanged);
            // 
            // lSearch
            // 
            this.lSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lSearch.AutoSize = true;
            this.lSearch.Location = new System.Drawing.Point(3, 362);
            this.lSearch.Name = "lSearch";
            this.lSearch.Size = new System.Drawing.Size(111, 13);
            this.lSearch.TabIndex = 0;
            this.lSearch.Text = "Búsqueda Interactiva:";
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.ForeColor = System.Drawing.Color.Lime;
            this.lTitle.Location = new System.Drawing.Point(103, 0);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(122, 24);
            this.lTitle.TabIndex = 4;
            this.lTitle.Text = "Vocabulario";
            // 
            // lSpToFrQuiz
            // 
            this.lSpToFrQuiz.AutoSize = true;
            this.lSpToFrQuiz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lSpToFrQuiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSpToFrQuiz.ForeColor = System.Drawing.Color.Snow;
            this.lSpToFrQuiz.Location = new System.Drawing.Point(176, 145);
            this.lSpToFrQuiz.Name = "lSpToFrQuiz";
            this.lSpToFrQuiz.Size = new System.Drawing.Size(134, 16);
            this.lSpToFrQuiz.TabIndex = 5;
            this.lSpToFrQuiz.Text = "Spanish => French Q!";
            this.lSpToFrQuiz.Click += new System.EventHandler(this.lSpToFrQuiz_Click);
            // 
            // lFrToSpQuiz
            // 
            this.lFrToSpQuiz.AutoSize = true;
            this.lFrToSpQuiz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lFrToSpQuiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFrToSpQuiz.ForeColor = System.Drawing.Color.Snow;
            this.lFrToSpQuiz.Location = new System.Drawing.Point(176, 120);
            this.lFrToSpQuiz.Name = "lFrToSpQuiz";
            this.lFrToSpQuiz.Size = new System.Drawing.Size(134, 16);
            this.lFrToSpQuiz.TabIndex = 6;
            this.lFrToSpQuiz.Text = "French => Spanish Q!";
            this.lFrToSpQuiz.Click += new System.EventHandler(this.lFrToSpQuiz_Click);
            // 
            // lSearchSp
            // 
            this.lSearchSp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lSearchSp.AutoSize = true;
            this.lSearchSp.Location = new System.Drawing.Point(175, 362);
            this.lSearchSp.Name = "lSearchSp";
            this.lSearchSp.Size = new System.Drawing.Size(138, 13);
            this.lSearchSp.TabIndex = 7;
            this.lSearchSp.Text = "Buscar Palabra en Español:";
            // 
            // tbSearchSp
            // 
            this.tbSearchSp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSearchSp.Location = new System.Drawing.Point(178, 378);
            this.tbSearchSp.Name = "tbSearchSp";
            this.tbSearchSp.Size = new System.Drawing.Size(155, 20);
            this.tbSearchSp.TabIndex = 8;
            this.tbSearchSp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearchSp_KeyPress);
            // 
            // Vocabulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Magenta;
            this.Controls.Add(this.lSearchSp);
            this.Controls.Add(this.tbSearchSp);
            this.Controls.Add(this.lFrToSpQuiz);
            this.Controls.Add(this.lSpToFrQuiz);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.lSearch);
            this.Controls.Add(this.cbSubcategoria);
            this.Controls.Add(this.lFiltrar2);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.lFiltrar);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lsWords);
            this.Name = "Vocabulario";
            this.Size = new System.Drawing.Size(336, 410);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ListBox lsWords;
        private System.Windows.Forms.Label lFiltrar;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Label lFiltrar2;
        private System.Windows.Forms.ComboBox cbSubcategoria;
        private System.Windows.Forms.Label lSearch;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lSpToFrQuiz;
        private System.Windows.Forms.Label lFrToSpQuiz;
        private System.Windows.Forms.Label lSearchSp;
        private System.Windows.Forms.TextBox tbSearchSp;

    }
}
