using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace PHR_Helper_WF.Tests
{
    [TestClass]
    public class FakesTests
    {
        [TestMethod]
        public void Fake_ExecuteProcess_WhatHappens()
        {
            var startBatUrl = "D:\\!New\\Ideas\\Wish List.txt";
            var newProcess = Process.Start(startBatUrl);
        }
    }
}
