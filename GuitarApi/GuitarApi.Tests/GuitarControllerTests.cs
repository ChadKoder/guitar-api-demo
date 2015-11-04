using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using GuitarApi.controllers;
using GuitarApi.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace GuitarApi.Tests
{
    [TestFixture]
    public class GuitarControllerTests
    {
        private IGetGuitarsByCompany _getGuitarsByCompany;
        private GuitarController _ctrl;

        [SetUp]
        public void Setup()
        {
            _getGuitarsByCompany = MockRepository.GenerateMock<IGetGuitarsByCompany>();
            _ctrl = new GuitarController(_getGuitarsByCompany);
            _ctrl.Request = new HttpRequestMessage();
            //_ctrl.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, (object)new HttpConfiguration());
        }

        [Test]
        public void Get_with_search_text_returns_200OK_on_success()
        {
            _getGuitarsByCompany.Stub(x => x.Select(Arg<string>.Is.Anything)).Return(new List<Guitar>());
            var result = _ctrl.Get("text");
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void Get_with_search_returns_500_on_exception()
        {
            _getGuitarsByCompany.Stub(x => x.Select(Arg<string>.Is.Anything)).Throw(new Exception());
            var result = _ctrl.Get("text");
            Assert.AreEqual(HttpStatusCode.InternalServerError, result.StatusCode);
        }
    }
}
