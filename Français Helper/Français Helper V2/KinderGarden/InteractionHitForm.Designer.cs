namespace Français_Helper.Windows
{
    partial class InteractionHitForm
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
            this.lbRespuestas = new System.Windows.Forms.ListBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lRespuestas = new System.Windows.Forms.Label();
            this.lPreguntas = new System.Windows.Forms.Label();
            this.lNombre = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.lbPreguntas = new System.Windows.Forms.ListBox();
            this.tbPreguntas = new System.Windows.Forms.TextBox();
            this.tbRespuestas = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbRespuestas
            // 
            this.lbRespuestas.ForeColor = System.Drawing.Color.Lime;
            this.lbRespuestas.FormattingEnabled = true;
            this.lbRespuestas.Location = new System.Drawing.Point(197, 79);
            this.lbRespuestas.Name = "lbRespuestas";
            this.lbRespuestas.Size = new System.Drawing.Size(158, 134);
            this.lbRespuestas.TabIndex = 9;
            this.lbRespuestas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbRespuestas_KeyPress);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 31);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(121, 20);
            this.tbName.TabIndex = 4;
            // 
            // lRespuestas
            // 
            this.lRespuestas.AutoSize = true;
            this.lRespuestas.Location = new System.Drawing.Point(194, 63);
            this.lRespuestas.Name = "lRespuestas";
            this.lRespuestas.Size = new System.Drawing.Size(66, 13);
            this.lRespuestas.TabIndex = 10;
            this.lRespuestas.Text = "Respuestas:";
            // 
            // lPreguntas
            // 
            this.lPreguntas.AutoSize = true;
            this.lPreguntas.Location = new System.Drawing.Point(9, 63);
            this.lPreguntas.Name = "lPreguntas";
            this.lPreguntas.Size = new System.Drawing.Size(58, 13);
            this.lPreguntas.TabIndex = 7;
            this.lPreguntas.Text = "Preguntas:";
            // 
            // lNombre
            // 
            this.lNombre.AutoSize = true;
            this.lNombre.Location = new System.Drawing.Point(8, 15);
            this.lNombre.Name = "lNombre";
            this.lNombre.Size = new System.Drawing.Size(47, 13);
            this.lNombre.TabIndex = 5;
            this.lNombre.Text = "Nombre:";
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(181, 264);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 11;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(67, 264);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 12;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // lbPreguntas
            // 
            this.lbPreguntas.ForeColor = System.Drawing.Color.Lime;
            this.lbPreguntas.FormattingEnabled = true;
            this.lbPreguntas.Location = new System.Drawing.Point(11, 79);
            this.lbPreguntas.Name = "lbPreguntas";
            this.lbPreguntas.Size = new System.Drawing.Size(158, 134);
            this.lbPreguntas.TabIndex = 13;
            this.lbPreguntas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbPreguntas_KeyPress);
            // 
            // tbPreguntas
            // 
            this.tbPreguntas.Location = new System.Drawing.Point(12, 219);
            this.tbPreguntas.Name = "tbPreguntas";
            this.tbPreguntas.Size = new System.Drawing.Size(157, 20);
            this.tbPreguntas.TabIndex = 14;
            this.tbPreguntas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPreguntas_KeyPress);
            // 
            // tbRespuestas
            // 
            this.tbRespuestas.Location = new System.Drawing.Point(197, 219);
            this.tbRespuestas.Name = "tbRespuestas";
            this.tbRespuestas.Size = new System.Drawing.Size(157, 20);
            this.tbRespuestas.TabIndex = 15;
            this.tbRespuestas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRespuestas_KeyPress);
            // 
            // InteractionHitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Magenta;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(367, 302);
            this.ControlBox = false;
            this.Controls.Add(this.tbRespuestas);
            this.Controls.Add(this.tbPreguntas);
            this.Controls.Add(this.lbPreguntas);
            this.Controls.Add(this.lbRespuestas);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lRespuestas);
            this.Controls.Add(this.lPreguntas);
            this.Controls.Add(this.lNombre);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.KeyPreview = true;
            this.Name = "InteractionHitForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "HitForm";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InteractionHitForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbRespuestas;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lRespuestas;
        private System.Windows.Forms.Label lPreguntas;
        private System.Windows.Forms.Label lNombre;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.ListBox lbPreguntas;
        private System.Windows.Forms.TextBox tbPreguntas;
        private System.Windows.Forms.TextBox tbRespuestas;
    }
}