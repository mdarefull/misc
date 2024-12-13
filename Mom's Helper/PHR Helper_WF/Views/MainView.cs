using PHR_Helper_WF.Models;
using PHR_Helper_WF.ViewModels;
using System;
using System.Windows.Forms;

namespace PHR_Helper_WF.Views
{
    public partial class MainView : Form
    {
        private readonly MainViewModel _viewModel = new MainViewModel();

        public MainView()
        {
            InitializeComponent();

            controlButton.Text = "Iniciar";
            controlButton.Enabled = false;

            startAppButton.Text = "Start App";
            startAppButton.Enabled = false;

            settingsLabel.Text = "More...";
            settingExtendedPanel.Visible = false;

            modesComboBox.Items.Clear();
            foreach (var item in _viewModel.ModesList)
                modesComboBox.Items.Add(item);
            modesComboBox.SelectedIndex = -1;
        }

        private void OnControlButton_Click(object sender, EventArgs e)
        {
            if (_viewModel.IsStarted)
            {
                _viewModel.StopPHR();

                controlButton.Text = "Iniciar";
                startAppButton.Enabled = false;
            }
            else
            {
                _viewModel.StartPHR();

                controlButton.Text = "Detener";
                startAppButton.Enabled = true;
            }
        }

        private void OnStartAppButton_Click(object sender, EventArgs e)
        {
            _viewModel.StartPHRApplication();

            startAppButton.Enabled = false;
        }

        private void OnSettingsLabel_Click(object sender, EventArgs e)
        {
            settingExtendedPanel.Visible ^= true;
            settingsLabel.Text = settingExtendedPanel.Visible ? "Less..." : "More...";
        }

        private void OnModesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            companiesComboBox.Items.Clear();

            _viewModel.SelectedMode = (Mode)modesComboBox.SelectedItem;
            if (modesComboBox.SelectedItem != null)
                foreach (var mode_company in _viewModel.CompaniesList)
                    companiesComboBox.Items.Add(mode_company);

            companiesComboBox.SelectedIndex = -1;
        }

        private void OnCompaniesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _viewModel.SelectedCompany = (Company)companiesComboBox.SelectedItem;
            if (companiesComboBox.SelectedItem != null)
                UpdateSettings();
            else
                ClearSettings();
        }
        private void UpdateSettings()
        {
            controlButton.Enabled = true;

            starterApplicationPathTextBox.Text = _viewModel.StartBatPath;
            stopperApplicationPathTextBox.Text = _viewModel.StopBatPath;
            propertiesPathTextBox.Text = _viewModel.JdbcPath;

            applicationUrlTextBox.Text = _viewModel.ApplicationUrl;

            propertyFileContentTextBox.Text = _viewModel.PropertyFileContent;
        }
        private void ClearSettings()
        {
            controlButton.Enabled = false;
            startAppButton.Enabled = false;

            starterApplicationPathTextBox.Clear();
            stopperApplicationPathTextBox.Clear();
            propertiesPathTextBox.Clear();
            applicationUrlTextBox.Clear();
            propertyFileContentTextBox.Clear();
        }
    }
}