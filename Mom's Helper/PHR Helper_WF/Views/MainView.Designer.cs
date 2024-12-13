namespace PHR_Helper_WF.Views
{
    partial class MainView
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label6;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.controlButton = new System.Windows.Forms.Button();
            this.startAppButton = new System.Windows.Forms.Button();
            this.modesComboBox = new System.Windows.Forms.ComboBox();
            this.companiesComboBox = new System.Windows.Forms.ComboBox();
            this.settingsLabel = new System.Windows.Forms.Label();
            this.settingExtendedPanel = new System.Windows.Forms.Panel();
            this.applicationUrlTextBox = new System.Windows.Forms.TextBox();
            this.propertiesPathTextBox = new System.Windows.Forms.TextBox();
            this.stopperApplicationPathTextBox = new System.Windows.Forms.TextBox();
            this.starterApplicationPathTextBox = new System.Windows.Forms.TextBox();
            this.propertyFileContentTextBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.settingExtendedPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(91, 13);
            label1.TabIndex = 2;
            label1.Text = "Modo de Trabajo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(152, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(59, 13);
            label2.TabIndex = 4;
            label2.Text = "Compañía:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(20, 132);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(115, 13);
            label7.TabIndex = 21;
            label7.Text = "Property File\'s Content:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(13, 69);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(82, 13);
            label5.TabIndex = 19;
            label5.Text = "Properties Path:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(29, 43);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(66, 13);
            label4.TabIndex = 18;
            label4.Text = "Stoper Path:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(29, 15);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(66, 13);
            label3.TabIndex = 17;
            label3.Text = "Starter Path:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(8, 95);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(87, 13);
            label6.TabIndex = 20;
            label6.Text = "Application URL:";
            // 
            // controlButton
            // 
            this.controlButton.Location = new System.Drawing.Point(131, 65);
            this.controlButton.Name = "controlButton";
            this.controlButton.Size = new System.Drawing.Size(75, 23);
            this.controlButton.TabIndex = 0;
            this.controlButton.Text = "Design Text";
            this.controlButton.UseVisualStyleBackColor = true;
            this.controlButton.Click += new System.EventHandler(this.OnControlButton_Click);
            // 
            // startAppButton
            // 
            this.startAppButton.Location = new System.Drawing.Point(212, 65);
            this.startAppButton.Name = "startAppButton";
            this.startAppButton.Size = new System.Drawing.Size(75, 23);
            this.startAppButton.TabIndex = 1;
            this.startAppButton.Text = "Design Text";
            this.startAppButton.UseVisualStyleBackColor = true;
            this.startAppButton.Click += new System.EventHandler(this.OnStartAppButton_Click);
            // 
            // modesComboBox
            // 
            this.modesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modesComboBox.FormattingEnabled = true;
            this.modesComboBox.Location = new System.Drawing.Point(7, 25);
            this.modesComboBox.Name = "modesComboBox";
            this.modesComboBox.Size = new System.Drawing.Size(142, 21);
            this.modesComboBox.TabIndex = 3;
            this.modesComboBox.SelectedIndexChanged += new System.EventHandler(this.OnModesComboBox_SelectedIndexChanged);
            // 
            // companiesComboBox
            // 
            this.companiesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.companiesComboBox.FormattingEnabled = true;
            this.companiesComboBox.Location = new System.Drawing.Point(155, 25);
            this.companiesComboBox.Name = "companiesComboBox";
            this.companiesComboBox.Size = new System.Drawing.Size(132, 21);
            this.companiesComboBox.TabIndex = 5;
            this.companiesComboBox.SelectedIndexChanged += new System.EventHandler(this.OnCompaniesComboBox_SelectedIndexChanged);
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.settingsLabel.Location = new System.Drawing.Point(4, 70);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(73, 13);
            this.settingsLabel.TabIndex = 6;
            this.settingsLabel.Text = "Design Text...";
            this.settingsLabel.Click += new System.EventHandler(this.OnSettingsLabel_Click);
            // 
            // settingExtendedPanel
            // 
            this.settingExtendedPanel.Controls.Add(this.applicationUrlTextBox);
            this.settingExtendedPanel.Controls.Add(this.propertiesPathTextBox);
            this.settingExtendedPanel.Controls.Add(this.stopperApplicationPathTextBox);
            this.settingExtendedPanel.Controls.Add(this.starterApplicationPathTextBox);
            this.settingExtendedPanel.Controls.Add(this.propertyFileContentTextBox);
            this.settingExtendedPanel.Controls.Add(label7);
            this.settingExtendedPanel.Controls.Add(label6);
            this.settingExtendedPanel.Controls.Add(label5);
            this.settingExtendedPanel.Controls.Add(label4);
            this.settingExtendedPanel.Controls.Add(label3);
            this.settingExtendedPanel.Location = new System.Drawing.Point(1, 94);
            this.settingExtendedPanel.Name = "settingExtendedPanel";
            this.settingExtendedPanel.Size = new System.Drawing.Size(561, 392);
            this.settingExtendedPanel.TabIndex = 7;
            // 
            // applicationUrlTextBox
            // 
            this.applicationUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applicationUrlTextBox.Location = new System.Drawing.Point(101, 92);
            this.applicationUrlTextBox.Name = "applicationUrlTextBox";
            this.applicationUrlTextBox.ReadOnly = true;
            this.applicationUrlTextBox.Size = new System.Drawing.Size(457, 20);
            this.applicationUrlTextBox.TabIndex = 26;
            // 
            // propertiesPathTextBox
            // 
            this.propertiesPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertiesPathTextBox.Location = new System.Drawing.Point(101, 64);
            this.propertiesPathTextBox.Name = "propertiesPathTextBox";
            this.propertiesPathTextBox.ReadOnly = true;
            this.propertiesPathTextBox.Size = new System.Drawing.Size(457, 20);
            this.propertiesPathTextBox.TabIndex = 25;
            // 
            // stopperApplicationPathTextBox
            // 
            this.stopperApplicationPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stopperApplicationPathTextBox.Location = new System.Drawing.Point(101, 38);
            this.stopperApplicationPathTextBox.Name = "stopperApplicationPathTextBox";
            this.stopperApplicationPathTextBox.ReadOnly = true;
            this.stopperApplicationPathTextBox.Size = new System.Drawing.Size(457, 20);
            this.stopperApplicationPathTextBox.TabIndex = 24;
            // 
            // starterApplicationPathTextBox
            // 
            this.starterApplicationPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.starterApplicationPathTextBox.Location = new System.Drawing.Point(101, 12);
            this.starterApplicationPathTextBox.Name = "starterApplicationPathTextBox";
            this.starterApplicationPathTextBox.ReadOnly = true;
            this.starterApplicationPathTextBox.Size = new System.Drawing.Size(457, 20);
            this.starterApplicationPathTextBox.TabIndex = 23;
            // 
            // propertyFileContentTextBox
            // 
            this.propertyFileContentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyFileContentTextBox.Location = new System.Drawing.Point(6, 148);
            this.propertyFileContentTextBox.Multiline = true;
            this.propertyFileContentTextBox.Name = "propertyFileContentTextBox";
            this.propertyFileContentTextBox.ReadOnly = true;
            this.propertyFileContentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.propertyFileContentTextBox.Size = new System.Drawing.Size(552, 241);
            this.propertyFileContentTextBox.TabIndex = 22;
            this.propertyFileContentTextBox.WordWrap = false;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(565, 485);
            this.Controls.Add(this.settingExtendedPanel);
            this.Controls.Add(this.settingsLabel);
            this.Controls.Add(this.companiesComboBox);
            this.Controls.Add(label2);
            this.Controls.Add(this.modesComboBox);
            this.Controls.Add(label1);
            this.Controls.Add(this.startAppButton);
            this.Controls.Add(this.controlButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainView";
            this.Text = "Ayudante PHR";
            this.settingExtendedPanel.ResumeLayout(false);
            this.settingExtendedPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button controlButton;
        public System.Windows.Forms.Button startAppButton;
        public System.Windows.Forms.ComboBox modesComboBox;
        public System.Windows.Forms.ComboBox companiesComboBox;
        public System.Windows.Forms.Label settingsLabel;
        public System.Windows.Forms.TextBox propertyFileContentTextBox;
        public System.Windows.Forms.TextBox starterApplicationPathTextBox;
        public System.Windows.Forms.TextBox propertiesPathTextBox;
        public System.Windows.Forms.TextBox stopperApplicationPathTextBox;
        public System.Windows.Forms.Panel settingExtendedPanel;
        public System.Windows.Forms.TextBox applicationUrlTextBox;
    }
}

