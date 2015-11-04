using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
        private IGetAllGuitars _getAllGuitars;
        private GuitarController _ctrl;

        [SetUp]
        public void Setup()
        {
            _getGuitarsByCompany = MockRepository.GenerateMock<IGetGuitarsByCompany>();
            _getAllGuitars = MockRepository.GenerateMock<IGetAllGuitars>();
            _ctrl = new GuitarController(_getGuitarsByCompany, _getAllGuitars);
            _ctrl.Request = new HttpRequestMessage();
            //_ctrl.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, (object)new HttpConfiguration());
        }

        [Test]
        public void Get_returns_200_on_success()
        {
            _getAllGuitars.Stub(x => x.Select()).Return(new List<Guitar>());
            var result = _ctrl.Get();
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void Get_returns_500_on_exception()
        {
            _getAllGuitars.Stub(x => x.Select()).Throw(new Exception());
            var result = _ctrl.Get();
            Assert.AreEqual(HttpStatusCode.InternalServerError, result.StatusCode);
        }

        [Test]
        public void Get_with_search_text_returns_200_on_success()
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
