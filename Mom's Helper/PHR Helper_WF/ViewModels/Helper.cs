using PHR_Helper_WF.Models;
using PHR_Helper_WF.Models.DbModels;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

namespace PHR_Helper_WF.ViewModels
{
    static class Helpers
    {
        public static bool StartService(string serviceName)
        {
            var service = new ServiceController(serviceName);
            switch (service.Status)
            {
                case ServiceControllerStatus.StopPending:
                    service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                    goto case ServiceControllerStatus.Stopped;
                case ServiceControllerStatus.Stopped:
                    service.Start();
                    break;
            }

            service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
            return service.Status == ServiceControllerStatus.Running;
        }
        public static bool StopService(string serviceName)
        {
            var service = new ServiceController(serviceName);
            switch (service.Status)
            {
                case ServiceControllerStatus.StartPending:
                    service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                    goto case ServiceControllerStatus.Running;
                case ServiceControllerStatus.Running:
                    service.Stop();
                    break;
            }

            service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
            return service.Status == ServiceControllerStatus.Stopped;
        }

        public static void ContentWriter(TextWriter writer, DataBaseModel db, Mode mode)
        {
            writer.WriteLine("#CONFIGURACI?N DE LA CONEXI?N A LA BD DE PHR ");
            writer.WriteLine("jdbc.driverClassName=com.microsoft.sqlserver.jdbc.SQLServerDriver");
            writer.Write("jdbc.url=jdbc:sqlserver://{0}", db.DataBaseManager.Host);

            if (db.DataBaseManager.Version.InstanceName != null)
                writer.Write(";instanceName={0}", db.DataBaseManager.Version.InstanceName);
            writer.WriteLine(";databaseName={0}", db.Name);

            writer.WriteLine();
            writer.WriteLine("jdbc.username={0}", mode.UserName);
            writer.WriteLine("jdbc.password={0}", mode.Password);
            writer.Write(mode.OtherSettings);
        }

        public static void ApplicationExecuter(string applicationPath)
        {
            var processInfo = new ProcessStartInfo(applicationPath);
            processInfo.UseShellExecute = true;
            processInfo.WorkingDirectory = Directory.GetParent(applicationPath).FullName;

            Process.Start(processInfo);
        }

        // Stub method.
        public static bool TestConnectionString()
        {
            return true;
        }
    }
}