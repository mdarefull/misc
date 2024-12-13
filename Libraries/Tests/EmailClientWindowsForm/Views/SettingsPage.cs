using EmailClientWindowsForm.Models;
using MyEmailManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailClientWindowsForm
{
    public partial class SettingsPage : Form
    {
        private BindingSource _settingsBindingSource;
        public EmailSettings Settings { get; set; }

        public SettingsPage(EmailSettings defaultSettings)
        {
            InitializeComponent();
            Settings = defaultSettings;
            _settingsBindingSource = new BindingSource();
            _settingsBindingSource.Add(Settings);

            SetUI();
            SetBindings();
            SetCustomSettings();
        }

        private void SetUI()
        {
            _receivedOptionsCheckedListBox.Items.Clear();
            foreach (var item in Enum.GetNames(typeof(AfterReceiveOptions)))
                if (!String.Equals(AfterReceiveOptions.DoNothing.ToString(), item))
                    _receivedOptionsCheckedListBox.Items.Add(item);
        }

        private void SetBindings()
        {
            _smtpHostTextBox.DataBindings.Add(new Binding("Text", _settingsBindingSource, "SmtpHost"));
            _smtpPortTextBox.DataBindings.Add(new Binding("Text", _settingsBindingSource, "SmtpPort"));
            _imapHostTextBox.DataBindings.Add(new Binding("Text", _settingsBindingSource, "ImapHost"));
            _imapPortTextBox.DataBindings.Add(new Binding("Text", _settingsBindingSource, "ImapPort"));
            _useSslCheckBox.DataBindings.Add(new Binding("Checked", _settingsBindingSource, "UseSsl"));
            _userLoginTextBox.DataBindings.Add(new Binding("Text", _settingsBindingSource, "UserLogin"));
            _userPasswordTextBox.DataBindings.Add(new Binding("Text", _settingsBindingSource, "UserPassword"));
            _userEmailTextBox.DataBindings.Add(new Binding("Text", _settingsBindingSource, "UserEmail"));
            _recipientEmailTextBox.DataBindings.Add(new Binding("Text", _settingsBindingSource, "RecipientEmail"));
            _messageSubjectTextBox.DataBindings.Add(new Binding("Text", _settingsBindingSource, "MessageSubject"));
            _filterSubjectTextBox.DataBindings.Add(new Binding("Text", _settingsBindingSource, "FilterSubject"));
            _filterSenderTextBox.DataBindings.Add(new Binding("Text", _settingsBindingSource, "FilterSender"));
            _filterUnreadCheckBox.DataBindings.Add(new Binding("Checked", _settingsBindingSource, "FilterUnread"));
            _idleTimeoutTextBox.DataBindings.Add(new Binding("Text", _settingsBindingSource, "IdleTimeout"));
            DataBindings.Add(new Binding("AfterReceiveOptionsMirror", _settingsBindingSource, "AfterReceiveOptions"));
        }
        private void OnReceivedOptionsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var receivedOptionsEnum = (AfterReceiveOptions)Enum.Parse(
                            typeof(AfterReceiveOptions), _receivedOptionsCheckedListBox.Items[e.Index].ToString());

            var isSetted = (_afterReceiveOptionsMirror & receivedOptionsEnum) == receivedOptionsEnum;
            if (e.NewValue == CheckState.Checked && !isSetted)
            {
                _afterReceiveOptionsMirror |= receivedOptionsEnum;
                Settings.AfterReceiveOptions = _afterReceiveOptionsMirror;
            }
            else if (e.NewValue == CheckState.Unchecked && isSetted)
            {
                _afterReceiveOptionsMirror ^= receivedOptionsEnum;
                Settings.AfterReceiveOptions = _afterReceiveOptionsMirror;
            }
        }
        private AfterReceiveOptions _afterReceiveOptionsMirror;
        public AfterReceiveOptions AfterReceiveOptionsMirror
        {
            get { return _afterReceiveOptionsMirror; }
            set
            {
                if (_afterReceiveOptionsMirror != value)
                {
                    _afterReceiveOptionsMirror = value;

                    // Updating View:
                    var items = _receivedOptionsCheckedListBox.Items;
                    for (int i = 0; i < items.Count; i++)
                    {
                        var optionsEnum = (AfterReceiveOptions)Enum.Parse(typeof(AfterReceiveOptions), items[i].ToString());
                        var isSetted = (_afterReceiveOptionsMirror & optionsEnum) == optionsEnum;
                        _receivedOptionsCheckedListBox.SetItemCheckState(i, isSetted ? CheckState.Checked : CheckState.Unchecked);
                    }
                }
            }
        }

        private void SetCustomSettings()
        {
            _sampleSettingsListBox.Items.Clear();

            _sampleSettingsListBox.Items.Add(CreateSimpleSettings());
            _sampleSettingsListBox.Items.Add(CreateServiceClon());
        }
        private CustomSettings CreateSimpleSettings()
        {
            var newCustomSettings = new CustomSettings("SimpleSettings");
            newCustomSettings.SmtpHost = "127.0.0.1";
            newCustomSettings.UserEmail = "mdarefull@gmail.com";
            newCustomSettings.UserPassword = "!QAZxsw2";
            newCustomSettings.AfterReceiveOptions = AfterReceiveOptions.MarkAsRead;
            newCustomSettings.FilterUnread = true;

            return newCustomSettings;
        }
        private CustomSettings CreateServiceClon()
        {
            var newCustomSettings = new CustomSettings("ServiceClon");
            newCustomSettings.SmtpHost = "127.0.0.1";
            newCustomSettings.UserEmail = "email2fbtest@gmail.com";
            newCustomSettings.UserPassword = "Klose.28.11";
            newCustomSettings.AfterReceiveOptions = AfterReceiveOptions.MarkAsRead;
            newCustomSettings.FilterUnread = true;
            newCustomSettings.FilterSubject = "FbTest_";
            newCustomSettings.MessageSubject = "FbTest_";

            return newCustomSettings;
        }
        private void OnSampleSettingsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSettings = (CustomSettings)_sampleSettingsListBox.SelectedItem;
            Settings = selectedSettings.Clone() as EmailSettings;

            _settingsBindingSource.Clear();
            _settingsBindingSource.Add(Settings);
        }

        private void OnAcceptButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        private void OnCancelButton_Click(object sender, EventArgs e)
        {
            Settings = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}