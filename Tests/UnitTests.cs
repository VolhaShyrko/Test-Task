using System;
using System.Runtime.Remoting.Messaging;
using ArgumentsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        private CalculateManager manager;
        private Exception exception;

        [TestInitialize]
        public void TestInitialize()
        {
            var options = Settings.GetOptions();
            manager = new CalculateManager(options);
        }

        [TestMethod]
        public void CalculateSumTest()
        {
            var result = manager.Calculate("sum 1 2", out exception);
            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void CalculateMultTest()
        {
            var result = manager.Calculate("* 5 5 10", out exception);
            Assert.IsTrue(result == 250.0);
        }

        [TestMethod]
        public void CalculateMinTest()
        {
            var result = manager.Calculate("MIN 5 0 -10     4", out exception);
            Assert.IsTrue(result == -10);
        }

        [TestMethod]
        public void CalculateSqrtTest()
        {
            var result = manager.Calculate("^ 4", out exception);
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void InvalidOperationExceptionTest()
        {
            manager.Calculate("sum5 5 10", out exception);
            Assert.IsTrue(exception is InvalidOperationException);
        }

        [TestMethod]
        public void ArgumentOutOfRangeExceptionTest()
        {
            manager.Calculate("min  ", out exception);
            Assert.IsTrue(exception is ArgumentOutOfRangeException);
        }



    }
}
