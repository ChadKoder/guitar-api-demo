
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using GuitarApi.controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace GuitarApi.Tests
{
    [TestFixture]
    public class GuitarControllerTests
    {
        [Test]
        public void Test_unit_tests_run()
        {
            var test = 1 + 1;
            Assert.AreEqual(2, test);
        }
    }
}
