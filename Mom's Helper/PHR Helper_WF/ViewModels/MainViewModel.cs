using PHR_Helper_WF.DAL;
using PHR_Helper_WF.Models;
using PHR_Helper_WF.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PHR_Helper_WF.ViewModels
{
    public class MainViewModel
    {
        private const string SERVER_BROWSER_SERVICE_NAME = "SQLBrowser";
        private readonly HardCodedRepository _repository = new HardCodedRepository();

        public bool IsStarted { get; set; }
        public IEnumerable<Mode> ModesList { get { return _repository.Modes; } }
        public IEnumerable<Company> CompaniesList
        {
            get
            {
                var returnValue = Enumerable.Empty<Company>();

                if (SelectedMode != null)
                    returnValue = SelectedMode.Companies;

                return returnValue;
            }
        }

        public Mode SelectedMode {get; set;}
        public Company SelectedCompany { get; set; }

        public string StartBatPath { get { return SelectedMode.StartBatPath; } }
        public string StopBatPath { get { return SelectedMode.StopBatPath; } }
        public string JdbcPath { get { return SelectedMode.JdbcPath; } }
        public string ApplicationUrl { get { return "NOT IMPLEMENTED"; } }
        public string PropertyFileContent
        {
            get
            {
                using (var writer = new StringWriter())
                {
                    Helpers.ContentWriter(writer, SelectedCompany.DataBase, SelectedMode);
                    return writer.ToString();
                }
            }
        }

        public void StartPHR()
        {
            StartMSSQLServices();
            CreateConfigurationFile();
            TestMSSQLConnection();
            ExecuteStartBat();

            IsStarted = true;
        }

        private void StartMSSQLServices()
        {
            // Checks the Server Browser
            if (!Helpers.StartService(SERVER_BROWSER_SERVICE_NAME))
                throw new NotImplementedException(String.Format("No se pudo iniciar el servicio \"{0}\".", SERVER_BROWSER_SERVICE_NAME));

            // Checks the Specific SQL Server
            if (SelectedCompany != null)
            {
                var serviceName = SelectedCompany.DataBase.DataBaseManager.Version.ServiceName;
                if (!Helpers.StartService(serviceName))
                    throw new NotImplementedException(String.Format("No se pudo iniciar el servicio \"{0}\".", serviceName));
            }
        }
        private void CreateConfigurationFile()
        {
            var configurationFileURL = JdbcPath;

            // BACK UP Current Configuration File:
            if (File.Exists(configurationFileURL))
                File.Copy(configurationFileURL, configurationFileURL + ".BAK", true);

            // Create the configuration file's following Mode_Company settings:
            using (var file = new FileStream(configurationFileURL, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(file))
            {
                Helpers.ContentWriter(writer, SelectedCompany.DataBase, SelectedMode);
            }
        }
        
        private void TestMSSQLConnection()
        {
            if (!Helpers.TestConnectionString())
                throw new NotImplementedException("No es posible establecer una conexión con el servidor de bases de datos.");
        }
        private void ExecuteStartBat()
        {
            Helpers.ApplicationExecuter(StartBatPath);
        }

        public void StopPHR()
        {
            ExecuteStopBat();
            RestoreConfigurationFile();
            StopMSSQLServices();

            IsStarted = false;
        }
        private void ExecuteStopBat()
        {
            Helpers.ApplicationExecuter(StopBatPath);
        }
        private void RestoreConfigurationFile()
        {
            var configurationFileURL = JdbcPath;

            if (File.Exists(configurationFileURL + ".BAK"))
                File.Copy(configurationFileURL + ".BAK", configurationFileURL, true);
        }
        private void StopMSSQLServices()
        {
            // Stops the Specific SQL Server
            if (SelectedCompany != null)
            {
                var serviceName = SelectedCompany.DataBase.DataBaseManager.Version.ServiceName;
                if (!Helpers.StopService(serviceName))
                    MessageBox.Show(String.Format("No se pudo detener el servicio: \"{0}\".", serviceName));
            }

            // Stops the Server Browser
            if (!Helpers.StopService(SERVER_BROWSER_SERVICE_NAME))
                MessageBox.Show(String.Format("No se pudo detener el servicio: \"{0}\".", SERVER_BROWSER_SERVICE_NAME));
        }

        public void StartPHRApplication()
        {
            var appPath = SetUpApplicationFile();

            Helpers.ApplicationExecuter(appPath);
        }
        private string SetUpApplicationFile()
        {
            var appUri = Application.LocalUserAppDataPath + "PHR_App.url";
            if (!File.Exists(appUri))
            {
                using (var file = new FileStream(appUri, FileMode.Create, FileAccess.Write))
                using (var writer = new BinaryWriter(file))
                {
                    var resource = Resources.Aplicacion_PHR;
                    writer.Write(resource);
                }
            }

            return appUri;
        }

        
    }
}