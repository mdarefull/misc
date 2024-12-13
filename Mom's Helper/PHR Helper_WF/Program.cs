using PHR_Helper_WF.ViewModels;
using PHR_Helper_WF.Views;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

[assembly: InternalsVisibleTo("PHR Helper_WF.Tests")]
namespace PHR_Helper_WF
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.UnhandledException += OnCurrentDomain_UnhandledException;
            Application.Run(new MainView());
        }

        private static void OnCurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string msg;
            if (e.ExceptionObject is Exception)
            {
                var ex = e.ExceptionObject as Exception;
                msg = String.Format("Error Detectado: {0}", ex.Message);
            }
            else
                msg = "Error Desconocido Detectado.";
            msg += "\nPulse aceptar para cerrar la aplicación.";
            MessageBox.Show(msg);

            Application.Exit();
        }
    }
}