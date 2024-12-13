namespace Français_Helper.Windows
{
    partial class Grammatique
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
            this.lSearch = new System.Windows.Forms.Label();
            this.lCategories = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lsRules = new System.Windows.Forms.ListBox();
            this.lDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lbCategorias = new System.Windows.Forms.ListBox();
            this.lTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lSearch
            // 
            this.lSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lSearch.AutoSize = true;
            this.lSearch.Location = new System.Drawing.Point(170, 367);
            this.lSearch.Name = "lSearch";
            this.lSearch.Size = new System.Drawing.Size(111, 13);
            this.lSearch.TabIndex = 0;
            this.lSearch.Text = "Búsqueda Interactiva:";
            // 
            // lCategories
            // 
            this.lCategories.AutoSize = true;
            this.lCategories.Location = new System.Drawing.Point(167, 37);
            this.lCategories.Name = "lCategories";
            this.lCategories.Size = new System.Drawing.Size(62, 13);
            this.lCategories.TabIndex = 2;
            this.lCategories.Text = "Categorías:";
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSearch.Location = new System.Drawing.Point(173, 383);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(155, 20);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // lsRules
            // 
            this.lsRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lsRules.FormattingEnabled = true;
            this.lsRules.Location = new System.Drawing.Point(6, 37);
            this.lsRules.Name = "lsRules";
            this.lsRules.Size = new System.Drawing.Size(155, 368);
            this.lsRules.Sorted = true;
            this.lsRules.TabIndex = 1;
            this.lsRules.SelectedIndexChanged += new System.EventHandler(this.lsRules_SelectedIndexChanged);
            this.lsRules.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lsRules_KeyPress);
            this.lsRules.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsRules_MouseDoubleClick);
            // 
            // lDescription
            // 
            this.lDescription.AutoSize = true;
            this.lDescription.Location = new System.Drawing.Point(171, 151);
            this.lDescription.Name = "lDescription";
            this.lDescription.Size = new System.Drawing.Size(66, 13);
            this.lDescription.TabIndex = 3;
            this.lDescription.Text = "Descripción:";
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(174, 167);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDescription.Size = new System.Drawing.Size(154, 197);
            this.tbDescription.TabIndex = 3;
            this.tbDescription.WordWrap = false;
            // 
            // lbCategorias
            // 
            this.lbCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCategorias.FormattingEnabled = true;
            this.lbCategorias.HorizontalScrollbar = true;
            this.lbCategorias.Location = new System.Drawing.Point(173, 53);
            this.lbCategorias.Name = "lbCategorias";
            this.lbCategorias.Size = new System.Drawing.Size(158, 95);
            this.lbCategorias.Sorted = true;
            this.lbCategorias.TabIndex = 4;
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.ForeColor = System.Drawing.Color.Red;
            this.lTitle.Location = new System.Drawing.Point(107, 10);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(134, 24);
            this.lTitle.TabIndex = 5;
            this.lTitle.Text = "Grammatique";
            // 
            // Grammatique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.lbCategorias);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lDescription);
            this.Controls.Add(this.lSearch);
            this.Controls.Add(this.lCategories);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lsRules);
            this.Name = "Grammatique";
            this.Size = new System.Drawing.Size(336, 410);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lSearch;
        private System.Windows.Forms.Label lCategories;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ListBox lsRules;
        private System.Windows.Forms.Label lDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.ListBox lbCategorias;
        private System.Windows.Forms.Label lTitle;
    }
}
