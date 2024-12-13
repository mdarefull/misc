namespace Français_Helper.Windows
{
    partial class GrammatiqueHitForm
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
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lbCategories = new System.Windows.Forms.ListBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lCategories = new System.Windows.Forms.Label();
            this.lDescription = new System.Windows.Forms.Label();
            this.lNombre = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.cbCategories = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(17, 94);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDescription.Size = new System.Drawing.Size(121, 150);
            this.tbDescription.TabIndex = 1;
            this.tbDescription.WordWrap = false;
            // 
            // lbCategories
            // 
            this.lbCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCategories.ForeColor = System.Drawing.Color.Lime;
            this.lbCategories.FormattingEnabled = true;
            this.lbCategories.Location = new System.Drawing.Point(186, 35);
            this.lbCategories.Name = "lbCategories";
            this.lbCategories.Size = new System.Drawing.Size(121, 95);
            this.lbCategories.Sorted = true;
            this.lbCategories.TabIndex = 2;
            this.lbCategories.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbCategories_KeyPress);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(17, 34);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(121, 20);
            this.tbName.TabIndex = 0;
            // 
            // lCategories
            // 
            this.lCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lCategories.AutoSize = true;
            this.lCategories.Location = new System.Drawing.Point(189, 19);
            this.lCategories.Name = "lCategories";
            this.lCategories.Size = new System.Drawing.Size(62, 13);
            this.lCategories.TabIndex = 2;
            this.lCategories.Text = "Categorías:";
            // 
            // lDescription
            // 
            this.lDescription.AutoSize = true;
            this.lDescription.Location = new System.Drawing.Point(14, 78);
            this.lDescription.Name = "lDescription";
            this.lDescription.Size = new System.Drawing.Size(66, 13);
            this.lDescription.TabIndex = 1;
            this.lDescription.Text = "Descripción:";
            // 
            // lNombre
            // 
            this.lNombre.AutoSize = true;
            this.lNombre.Location = new System.Drawing.Point(13, 18);
            this.lNombre.Name = "lNombre";
            this.lNombre.Size = new System.Drawing.Size(47, 13);
            this.lNombre.TabIndex = 0;
            this.lNombre.Text = "Nombre:";
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(186, 267);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSave
            // 
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSave.Location = new System.Drawing.Point(72, 267);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 3;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // cbCategories
            // 
            this.cbCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Location = new System.Drawing.Point(186, 136);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(121, 21);
            this.cbCategories.TabIndex = 2;
            this.cbCategories.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCategories_KeyPress);
            // 
            // GrammatiqueHitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Magenta;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(323, 302);
            this.ControlBox = false;
            this.Controls.Add(this.cbCategories);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lbCategories);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lCategories);
            this.Controls.Add(this.lDescription);
            this.Controls.Add(this.lNombre);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.KeyPreview = true;
            this.Name = "GrammatiqueHitForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HitForm";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RuleHitForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.ListBox lbCategories;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lCategories;
        private System.Windows.Forms.Label lDescription;
        private System.Windows.Forms.Label lNombre;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.ComboBox cbCategories;

    }
}