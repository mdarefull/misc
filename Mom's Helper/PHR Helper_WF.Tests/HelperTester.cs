using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHR_Helper_WF.ViewModels;
using System.ServiceProcess;

namespace PHR_Helper_WF.Tests
{
    [TestClass]
    public class HelperTester
    {
        // This is an Integration Test, because it test if the method does Start a Service
        [TestMethod]
        public void StartService_SQLBrowser_ServiceStarted()
        {
            // arrange
            string serviceName = "SQLBrowser";

            // act
            Helpers.StartService(serviceName);

            // assert
            var service = new ServiceController(serviceName);
            Assert.AreEqual(ServiceControllerStatus.Running, service.Status);
        }


        // This is an Integration Test, because it test if the method does Stop a Service
        [TestMethod]
        public void StopService_SQLBrowser_ServiceStopped()
        {
            // arrange
            string serviceName = "SQLBrowser";

            // act
            Helpers.StopService(serviceName);

            // assert
            var service = new ServiceController(serviceName);
            Assert.AreEqual(ServiceControllerStatus.Stopped, service.Status);
        }
    }
}