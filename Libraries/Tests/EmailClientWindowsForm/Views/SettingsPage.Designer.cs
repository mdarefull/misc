namespace EmailClientWindowsForm
{
    partial class SettingsPage
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label5;
            this.label14 = new System.Windows.Forms.Label();
            this._smtpHostTextBox = new System.Windows.Forms.TextBox();
            this._smtpPortTextBox = new System.Windows.Forms.TextBox();
            this._imapHostTextBox = new System.Windows.Forms.TextBox();
            this._imapPortTextBox = new System.Windows.Forms.TextBox();
            this._useSslCheckBox = new System.Windows.Forms.CheckBox();
            this._userLoginTextBox = new System.Windows.Forms.TextBox();
            this._userPasswordTextBox = new System.Windows.Forms.TextBox();
            this._userEmailTextBox = new System.Windows.Forms.TextBox();
            this._recipientEmailTextBox = new System.Windows.Forms.TextBox();
            this._messageSubjectTextBox = new System.Windows.Forms.TextBox();
            this._filterSubjectTextBox = new System.Windows.Forms.TextBox();
            this._filterSenderTextBox = new System.Windows.Forms.TextBox();
            this._filterUnreadCheckBox = new System.Windows.Forms.CheckBox();
            this._receivedOptionsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this._idleTimeoutTextBox = new System.Windows.Forms.TextBox();
            this._acceptButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._sampleSettingsListBox = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(65, 13);
            label1.TabIndex = 0;
            label1.Text = "SMTP Host:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(11, 48);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(62, 13);
            label2.TabIndex = 1;
            label2.Text = "STMP Port:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 87);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(61, 13);
            label3.TabIndex = 2;
            label3.Text = "IMAP Host:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 126);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(58, 13);
            label4.TabIndex = 3;
            label4.Text = "IMAP Port:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(161, 87);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(61, 13);
            label6.TabIndex = 5;
            label6.Text = "User Login:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(161, 48);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(81, 13);
            label7.TabIndex = 6;
            label7.Text = "User Password:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(163, 9);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(60, 13);
            label8.TabIndex = 7;
            label8.Text = "User Email:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(296, 9);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(83, 13);
            label9.TabIndex = 8;
            label9.Text = "Recipient Email:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(296, 48);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(89, 13);
            label10.TabIndex = 9;
            label10.Text = "Message Subject";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(296, 87);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(68, 13);
            label11.TabIndex = 10;
            label11.Text = "Filter Subject";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(298, 126);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(66, 13);
            label12.TabIndex = 11;
            label12.Text = "Filter Sender";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(163, 207);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(68, 13);
            label15.TabIndex = 14;
            label15.Text = "Idle Timeout:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(161, 269);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(86, 13);
            label5.TabIndex = 33;
            label5.Text = "Sample Settings:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(162, 145);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Received Options:";
            // 
            // _smtpHostTextBox
            // 
            this._smtpHostTextBox.Location = new System.Drawing.Point(15, 25);
            this._smtpHostTextBox.Name = "_smtpHostTextBox";
            this._smtpHostTextBox.Size = new System.Drawing.Size(122, 20);
            this._smtpHostTextBox.TabIndex = 15;
            // 
            // _smtpPortTextBox
            // 
            this._smtpPortTextBox.Location = new System.Drawing.Point(14, 64);
            this._smtpPortTextBox.Name = "_smtpPortTextBox";
            this._smtpPortTextBox.Size = new System.Drawing.Size(122, 20);
            this._smtpPortTextBox.TabIndex = 16;
            // 
            // _imapHostTextBox
            // 
            this._imapHostTextBox.Location = new System.Drawing.Point(15, 103);
            this._imapHostTextBox.Name = "_imapHostTextBox";
            this._imapHostTextBox.Size = new System.Drawing.Size(121, 20);
            this._imapHostTextBox.TabIndex = 17;
            // 
            // _imapPortTextBox
            // 
            this._imapPortTextBox.Location = new System.Drawing.Point(16, 142);
            this._imapPortTextBox.Name = "_imapPortTextBox";
            this._imapPortTextBox.Size = new System.Drawing.Size(121, 20);
            this._imapPortTextBox.TabIndex = 18;
            // 
            // _useSslCheckBox
            // 
            this._useSslCheckBox.AutoSize = true;
            this._useSslCheckBox.Location = new System.Drawing.Point(16, 168);
            this._useSslCheckBox.Name = "_useSslCheckBox";
            this._useSslCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._useSslCheckBox.Size = new System.Drawing.Size(68, 17);
            this._useSslCheckBox.TabIndex = 19;
            this._useSslCheckBox.Text = "Use SSL";
            this._useSslCheckBox.UseVisualStyleBackColor = true;
            // 
            // _userLoginTextBox
            // 
            this._userLoginTextBox.Location = new System.Drawing.Point(164, 103);
            this._userLoginTextBox.Name = "_userLoginTextBox";
            this._userLoginTextBox.Size = new System.Drawing.Size(122, 20);
            this._userLoginTextBox.TabIndex = 20;
            // 
            // _userPasswordTextBox
            // 
            this._userPasswordTextBox.Location = new System.Drawing.Point(164, 64);
            this._userPasswordTextBox.Name = "_userPasswordTextBox";
            this._userPasswordTextBox.Size = new System.Drawing.Size(122, 20);
            this._userPasswordTextBox.TabIndex = 21;
            // 
            // _userEmailTextBox
            // 
            this._userEmailTextBox.Location = new System.Drawing.Point(165, 25);
            this._userEmailTextBox.Name = "_userEmailTextBox";
            this._userEmailTextBox.Size = new System.Drawing.Size(122, 20);
            this._userEmailTextBox.TabIndex = 22;
            // 
            // _recipientEmailTextBox
            // 
            this._recipientEmailTextBox.Location = new System.Drawing.Point(299, 25);
            this._recipientEmailTextBox.Name = "_recipientEmailTextBox";
            this._recipientEmailTextBox.Size = new System.Drawing.Size(122, 20);
            this._recipientEmailTextBox.TabIndex = 23;
            // 
            // _messageSubjectTextBox
            // 
            this._messageSubjectTextBox.Location = new System.Drawing.Point(299, 64);
            this._messageSubjectTextBox.Name = "_messageSubjectTextBox";
            this._messageSubjectTextBox.Size = new System.Drawing.Size(122, 20);
            this._messageSubjectTextBox.TabIndex = 24;
            // 
            // _filterSubjectTextBox
            // 
            this._filterSubjectTextBox.Location = new System.Drawing.Point(299, 103);
            this._filterSubjectTextBox.Name = "_filterSubjectTextBox";
            this._filterSubjectTextBox.Size = new System.Drawing.Size(122, 20);
            this._filterSubjectTextBox.TabIndex = 25;
            // 
            // _filterSenderTextBox
            // 
            this._filterSenderTextBox.Location = new System.Drawing.Point(299, 142);
            this._filterSenderTextBox.Name = "_filterSenderTextBox";
            this._filterSenderTextBox.Size = new System.Drawing.Size(122, 20);
            this._filterSenderTextBox.TabIndex = 26;
            // 
            // _filterUnreadCheckBox
            // 
            this._filterUnreadCheckBox.AutoSize = true;
            this._filterUnreadCheckBox.Location = new System.Drawing.Point(299, 168);
            this._filterUnreadCheckBox.Name = "_filterUnreadCheckBox";
            this._filterUnreadCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._filterUnreadCheckBox.Size = new System.Drawing.Size(86, 17);
            this._filterUnreadCheckBox.TabIndex = 27;
            this._filterUnreadCheckBox.Text = "Filter Unread";
            this._filterUnreadCheckBox.UseVisualStyleBackColor = true;
            // 
            // _receivedOptionsCheckedListBox
            // 
            this._receivedOptionsCheckedListBox.BackColor = System.Drawing.SystemColors.Control;
            this._receivedOptionsCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._receivedOptionsCheckedListBox.CheckOnClick = true;
            this._receivedOptionsCheckedListBox.FormattingEnabled = true;
            this._receivedOptionsCheckedListBox.Items.AddRange(new object[] {
            "DesignItem1",
            "DesignItem2"});
            this._receivedOptionsCheckedListBox.Location = new System.Drawing.Point(166, 161);
            this._receivedOptionsCheckedListBox.Name = "_receivedOptionsCheckedListBox";
            this._receivedOptionsCheckedListBox.Size = new System.Drawing.Size(91, 30);
            this._receivedOptionsCheckedListBox.TabIndex = 28;
            this._receivedOptionsCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnReceivedOptionsCheckedListBox_ItemCheck);
            // 
            // _idleTimeoutTextBox
            // 
            this._idleTimeoutTextBox.Location = new System.Drawing.Point(164, 223);
            this._idleTimeoutTextBox.Name = "_idleTimeoutTextBox";
            this._idleTimeoutTextBox.Size = new System.Drawing.Size(122, 20);
            this._idleTimeoutTextBox.TabIndex = 29;
            // 
            // _acceptButton
            // 
            this._acceptButton.Location = new System.Drawing.Point(31, 357);
            this._acceptButton.Name = "_acceptButton";
            this._acceptButton.Size = new System.Drawing.Size(75, 23);
            this._acceptButton.TabIndex = 30;
            this._acceptButton.Text = "Accept";
            this._acceptButton.UseVisualStyleBackColor = true;
            this._acceptButton.Click += new System.EventHandler(this.OnAcceptButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(305, 357);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 31;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.OnCancelButton_Click);
            // 
            // _sampleSettingsListBox
            // 
            this._sampleSettingsListBox.FormattingEnabled = true;
            this._sampleSettingsListBox.Items.AddRange(new string[] {
            "Design Item 1",
            "Design Item 2",
            "Design Item 3"});
            this._sampleSettingsListBox.Location = new System.Drawing.Point(164, 285);
            this._sampleSettingsListBox.Name = "_sampleSettingsListBox";
            this._sampleSettingsListBox.Size = new System.Drawing.Size(120, 95);
            this._sampleSettingsListBox.TabIndex = 32;
            this._sampleSettingsListBox.SelectedIndexChanged += new System.EventHandler(this.OnSampleSettingsListBox_SelectedIndexChanged);
            // 
            // SettingsPage
            // 
            this.AcceptButton = this._acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(439, 392);
            this.ControlBox = false;
            this.Controls.Add(label5);
            this.Controls.Add(this._sampleSettingsListBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._acceptButton);
            this.Controls.Add(this._idleTimeoutTextBox);
            this.Controls.Add(this._receivedOptionsCheckedListBox);
            this.Controls.Add(this._filterUnreadCheckBox);
            this.Controls.Add(this._filterSenderTextBox);
            this.Controls.Add(this._filterSubjectTextBox);
            this.Controls.Add(this._messageSubjectTextBox);
            this.Controls.Add(this._recipientEmailTextBox);
            this.Controls.Add(this._userEmailTextBox);
            this.Controls.Add(this._userPasswordTextBox);
            this.Controls.Add(this._userLoginTextBox);
            this.Controls.Add(this._useSslCheckBox);
            this.Controls.Add(this._imapPortTextBox);
            this.Controls.Add(this._imapHostTextBox);
            this.Controls.Add(this._smtpPortTextBox);
            this.Controls.Add(this._smtpHostTextBox);
            this.Controls.Add(label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(label12);
            this.Controls.Add(label11);
            this.Controls.Add(label10);
            this.Controls.Add(label9);
            this.Controls.Add(label8);
            this.Controls.Add(label7);
            this.Controls.Add(label6);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(455, 431);
            this.MinimumSize = new System.Drawing.Size(455, 431);
            this.Name = "SettingsPage";
            this.ShowIcon = false;
            this.Text = "SettingsPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox _smtpHostTextBox;
        private System.Windows.Forms.TextBox _smtpPortTextBox;
        private System.Windows.Forms.TextBox _imapHostTextBox;
        private System.Windows.Forms.TextBox _imapPortTextBox;
        private System.Windows.Forms.CheckBox _useSslCheckBox;
        private System.Windows.Forms.TextBox _userLoginTextBox;
        private System.Windows.Forms.TextBox _userPasswordTextBox;
        private System.Windows.Forms.TextBox _userEmailTextBox;
        private System.Windows.Forms.TextBox _recipientEmailTextBox;
        private System.Windows.Forms.TextBox _messageSubjectTextBox;
        private System.Windows.Forms.TextBox _filterSubjectTextBox;
        private System.Windows.Forms.TextBox _filterSenderTextBox;
        private System.Windows.Forms.CheckBox _filterUnreadCheckBox;
        private System.Windows.Forms.CheckedListBox _receivedOptionsCheckedListBox;
        private System.Windows.Forms.TextBox _idleTimeoutTextBox;
        private System.Windows.Forms.Button _acceptButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.ListBox _sampleSettingsListBox;
    }
}