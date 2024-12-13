namespace EmailClientWindowsForm
{
    partial class MainPage
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
            this._setDefaultSettingsButton = new System.Windows.Forms.Button();
            this._validateSettingsButton = new System.Windows.Forms.Button();
            this._sendMessageButtonTextBox = new System.Windows.Forms.TextBox();
            this._sendMessageButton = new System.Windows.Forms.Button();
            this._receiveMessageButton = new System.Windows.Forms.Button();
            this._statusMessageLabel = new System.Windows.Forms.Label();
            this._statusMessageTextBox = new System.Windows.Forms.TextBox();
            this._receiveMessageRichTextBox = new System.Windows.Forms.RichTextBox();
            this._clearButton = new System.Windows.Forms.Button();
            this._viewSettingsButton = new System.Windows.Forms.Button();
            this._errorMessagesListBox = new System.Windows.Forms.ListBox();
            this._isIdleCheckBox = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 115);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 13);
            label1.TabIndex = 11;
            label1.Text = "Validation Messages";
            // 
            // _setDefaultSettingsButton
            // 
            this._setDefaultSettingsButton.Location = new System.Drawing.Point(12, 12);
            this._setDefaultSettingsButton.Name = "_setDefaultSettingsButton";
            this._setDefaultSettingsButton.Size = new System.Drawing.Size(113, 23);
            this._setDefaultSettingsButton.TabIndex = 0;
            this._setDefaultSettingsButton.Text = "Set Default Settings";
            this._setDefaultSettingsButton.UseVisualStyleBackColor = true;
            this._setDefaultSettingsButton.Click += new System.EventHandler(this.OnSetDefaultSettingsButton_Click);
            // 
            // _validateSettingsButton
            // 
            this._validateSettingsButton.Location = new System.Drawing.Point(9, 86);
            this._validateSettingsButton.Name = "_validateSettingsButton";
            this._validateSettingsButton.Size = new System.Drawing.Size(113, 23);
            this._validateSettingsButton.TabIndex = 1;
            this._validateSettingsButton.Text = "Validate Settings";
            this._validateSettingsButton.UseVisualStyleBackColor = true;
            this._validateSettingsButton.Click += new System.EventHandler(this.OnValidateSettingsButton_Click);
            // 
            // _sendMessageButtonTextBox
            // 
            this._sendMessageButtonTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._sendMessageButtonTextBox.Location = new System.Drawing.Point(143, 12);
            this._sendMessageButtonTextBox.Multiline = true;
            this._sendMessageButtonTextBox.Name = "_sendMessageButtonTextBox";
            this._sendMessageButtonTextBox.Size = new System.Drawing.Size(269, 41);
            this._sendMessageButtonTextBox.TabIndex = 2;
            // 
            // _sendMessageButton
            // 
            this._sendMessageButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._sendMessageButton.Location = new System.Drawing.Point(293, 59);
            this._sendMessageButton.Name = "_sendMessageButton";
            this._sendMessageButton.Size = new System.Drawing.Size(119, 23);
            this._sendMessageButton.TabIndex = 3;
            this._sendMessageButton.Text = "Send Message";
            this._sendMessageButton.UseVisualStyleBackColor = true;
            this._sendMessageButton.Click += new System.EventHandler(this.OnSendMessageButtonClick);
            // 
            // _receiveMessageButton
            // 
            this._receiveMessageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._receiveMessageButton.Location = new System.Drawing.Point(143, 285);
            this._receiveMessageButton.Name = "_receiveMessageButton";
            this._receiveMessageButton.Size = new System.Drawing.Size(107, 23);
            this._receiveMessageButton.TabIndex = 5;
            this._receiveMessageButton.Text = "Receive Messages";
            this._receiveMessageButton.UseVisualStyleBackColor = true;
            this._receiveMessageButton.Click += new System.EventHandler(this.OnReceiveMessageButtonClick);
            // 
            // _statusMessageLabel
            // 
            this._statusMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._statusMessageLabel.AutoSize = true;
            this._statusMessageLabel.Location = new System.Drawing.Point(21, 259);
            this._statusMessageLabel.Name = "_statusMessageLabel";
            this._statusMessageLabel.Size = new System.Drawing.Size(83, 13);
            this._statusMessageLabel.TabIndex = 6;
            this._statusMessageLabel.Text = "Status Message";
            // 
            // _statusMessageTextBox
            // 
            this._statusMessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._statusMessageTextBox.BackColor = System.Drawing.SystemColors.Control;
            this._statusMessageTextBox.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._statusMessageTextBox.Location = new System.Drawing.Point(12, 275);
            this._statusMessageTextBox.Multiline = true;
            this._statusMessageTextBox.Name = "_statusMessageTextBox";
            this._statusMessageTextBox.ReadOnly = true;
            this._statusMessageTextBox.Size = new System.Drawing.Size(110, 33);
            this._statusMessageTextBox.TabIndex = 7;
            this._statusMessageTextBox.Text = "Design Data";
            this._statusMessageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _receiveMessageRichTextBox
            // 
            this._receiveMessageRichTextBox.AcceptsTab = true;
            this._receiveMessageRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._receiveMessageRichTextBox.DetectUrls = false;
            this._receiveMessageRichTextBox.Location = new System.Drawing.Point(143, 88);
            this._receiveMessageRichTextBox.Name = "_receiveMessageRichTextBox";
            this._receiveMessageRichTextBox.ReadOnly = true;
            this._receiveMessageRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this._receiveMessageRichTextBox.Size = new System.Drawing.Size(269, 191);
            this._receiveMessageRichTextBox.TabIndex = 8;
            this._receiveMessageRichTextBox.Text = "";
            this._receiveMessageRichTextBox.WordWrap = false;
            // 
            // _clearButton
            // 
            this._clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._clearButton.Location = new System.Drawing.Point(337, 285);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(75, 23);
            this._clearButton.TabIndex = 9;
            this._clearButton.Text = "Clear";
            this._clearButton.UseVisualStyleBackColor = true;
            this._clearButton.Click += new System.EventHandler(this.OnClearButton_Click);
            // 
            // _viewSettingsButton
            // 
            this._viewSettingsButton.Location = new System.Drawing.Point(12, 41);
            this._viewSettingsButton.Name = "_viewSettingsButton";
            this._viewSettingsButton.Size = new System.Drawing.Size(113, 23);
            this._viewSettingsButton.TabIndex = 10;
            this._viewSettingsButton.Text = "View Settings";
            this._viewSettingsButton.UseVisualStyleBackColor = true;
            this._viewSettingsButton.Click += new System.EventHandler(this.OnViewSettingsButton_Click);
            // 
            // _errorMessagesListBox
            // 
            this._errorMessagesListBox.FormattingEnabled = true;
            this._errorMessagesListBox.HorizontalScrollbar = true;
            this._errorMessagesListBox.Items.AddRange(new object[] {
            "Design Data 1",
            "Design Data 2",
            "Design Data 3"});
            this._errorMessagesListBox.Location = new System.Drawing.Point(12, 129);
            this._errorMessagesListBox.Name = "_errorMessagesListBox";
            this._errorMessagesListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this._errorMessagesListBox.Size = new System.Drawing.Size(113, 121);
            this._errorMessagesListBox.TabIndex = 12;
            // 
            // _isIdleCheckBox
            // 
            this._isIdleCheckBox.AutoSize = true;
            this._isIdleCheckBox.Location = new System.Drawing.Point(143, 65);
            this._isIdleCheckBox.Name = "_isIdleCheckBox";
            this._isIdleCheckBox.Size = new System.Drawing.Size(54, 17);
            this._isIdleCheckBox.TabIndex = 13;
            this._isIdleCheckBox.Text = "Is Idle";
            this._isIdleCheckBox.UseVisualStyleBackColor = true;
            this._isIdleCheckBox.CheckedChanged += new System.EventHandler(this.OnIsIdleCheckBox_CheckedChanged);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 318);
            this.Controls.Add(this._isIdleCheckBox);
            this.Controls.Add(this._errorMessagesListBox);
            this.Controls.Add(label1);
            this.Controls.Add(this._viewSettingsButton);
            this.Controls.Add(this._clearButton);
            this.Controls.Add(this._receiveMessageRichTextBox);
            this.Controls.Add(this._statusMessageTextBox);
            this.Controls.Add(this._statusMessageLabel);
            this.Controls.Add(this._receiveMessageButton);
            this.Controls.Add(this._sendMessageButton);
            this.Controls.Add(this._sendMessageButtonTextBox);
            this.Controls.Add(this._validateSettingsButton);
            this.Controls.Add(this._setDefaultSettingsButton);
            this.MinimumSize = new System.Drawing.Size(398, 309);
            this.Name = "MainPage";
            this.Text = "Email Client Integration Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _setDefaultSettingsButton;
        private System.Windows.Forms.Button _validateSettingsButton;
        private System.Windows.Forms.TextBox _sendMessageButtonTextBox;
        private System.Windows.Forms.Button _sendMessageButton;
        private System.Windows.Forms.Button _receiveMessageButton;
        private System.Windows.Forms.Label _statusMessageLabel;
        private System.Windows.Forms.TextBox _statusMessageTextBox;
        private System.Windows.Forms.RichTextBox _receiveMessageRichTextBox;
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.Button _viewSettingsButton;
        private System.Windows.Forms.ListBox _errorMessagesListBox;
        private System.Windows.Forms.CheckBox _isIdleCheckBox;
    }
}

