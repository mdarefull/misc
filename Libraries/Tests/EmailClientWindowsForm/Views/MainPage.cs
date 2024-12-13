using MyEmailManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace EmailClientWindowsForm
{
    public partial class MainPage : Form
    {
        private readonly EmailManagerFactory _emailManagerFactory;
        private IEmailManager _emailManager;

        public MainPage()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException += OnCurrentDomain_UnhandledException;

            // TODO [CHECK] I have to Instantiate EMU in order set EMF into a consistent state.
            _emailManagerFactory = EmailManagerUtilities.Instance;
            _emailManager = _emailManagerFactory.NewEmailManager();
            _errorMessagesListBox.Items.Clear();

            SettingsValidated(false);
            ClearStatusMessages();
        }

        #region Event's Handlers
        private void OnCurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("------------------[UNHANDLED EXCEPTION DETECTED]------------------");
            Console.WriteLine((e.ExceptionObject as Exception).ToString());
            Console.WriteLine("-------------------[END OF UNHANDLED EXCEPTION]-------------------");
        }

        private void OnSetDefaultSettingsButton_Click(object sender, EventArgs e)
        {
            ClearStatusMessages();
            SettingsValidated(false);

            var settings = _emailManagerFactory.NewEmailSettings("127.0.0.1", "mdarefull@gmail.com", "!QAZxsw2");
            _emailManager.Settings = settings;

            SetStatusMessage("Settings Setted");
        }
        private void OnViewSettingsButton_Click(object sender, EventArgs e)
        {
            ClearStatusMessages();
            SettingsValidated(false);

            var settingsPage = new SettingsPage(_emailManager.Settings);
            var dResult = settingsPage.ShowDialog(this);
            if (dResult == DialogResult.OK)
            {
                var settings = settingsPage.Settings;
                _emailManager.Settings = settings;

                SetStatusMessage("Custom Settings Setted");
            }
            else
                SetStatusMessage("Custom Settings Cancelled");
        }
        private void OnValidateSettingsButton_Click(object sender, EventArgs e)
        {
            ClearStatusMessages();

            if (_emailManager.ValidateSettings())
            {
                SettingsValidated(true);

                SetStatusMessage("Validation Success");
            }
            else
            {
                SettingsValidated(false);
                SetStatusMessage("Validation Error", true);
            }
            _errorMessagesListBox.DataSource = _emailManager.ErrorsMessages;
        }
        private void OnSendMessageButtonClick(object sender, EventArgs e)
        {
            ClearStatusMessages();

            string messageBody = _sendMessageButtonTextBox.Text;
            _sendMessageButtonTextBox.Clear();

            _emailManager.SendEmail(messageBody);

            SetStatusMessage("Message Sent");
        }
        private void OnReceiveMessageButtonClick(object sender, EventArgs e)
        {
            ClearStatusMessages();
            ProcessReceivedMessages(_emailManager.ReceiveEmail());

            SetStatusMessage("Messages Received");
        }
        private void OnClearButton_Click(object sender, EventArgs e)
        {
            _receiveMessageRichTextBox.Clear();
        }
        private async void OnIsIdleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var startIdle = _isIdleCheckBox.Checked;
            if (startIdle)
                await Task.Factory.StartNew(() =>
                    {
                        _emailManager.StartIdle(ProcessReceivedMessages, false);
                        _errorMessagesListBox.DataSource = _emailManager.ErrorsMessages;
                    });
            else
                _emailManager.StopIdle();
        }
        #endregion

        #region Helpers
        private void ProcessReceivedMessages(IEnumerable<Email> mesages)
        {
            var msgList = mesages.ToList();
            Invoke((MethodInvoker)delegate
            {
                foreach (var email in msgList)
                {
                    var msgText = String.Format("From: {0}\nDate: {1}\nSubject: {2}\nBody: {3}", email.From, email.SentDate.ToString(), email.Subject, email.Body);
                    msgText += "---------------------------------\n";
                    _receiveMessageRichTextBox.AppendText(msgText);
                }
            });

            Thread.Sleep(1 * 1000);
        }
        private void SettingsValidated(bool valid)
        {
            _sendMessageButton.Enabled = valid;
            _sendMessageButtonTextBox.Enabled = valid;
            _receiveMessageButton.Enabled = valid;
            _receiveMessageRichTextBox.Enabled = valid;
            _clearButton.Enabled = valid;
            _isIdleCheckBox.Enabled = valid;
        }
        private void ClearStatusMessages()
        {
            _statusMessageTextBox.Clear();
        }
        private void SetStatusMessage(string message, bool error = false)
        {
            _statusMessageTextBox.Text = message;
            if (error)
                _statusMessageTextBox.ForeColor = Color.Red;
            else
                _statusMessageTextBox.ForeColor = Color.Green;
        }
        #endregion
    }
}
