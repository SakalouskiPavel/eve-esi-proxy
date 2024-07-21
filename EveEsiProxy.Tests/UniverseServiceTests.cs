using EveEsiProxy.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveEsiProxy.Tests
{
    [TestFixture]
    public class UniverseServiceTests
    {
        private UniverseService _service;

        [SetUp]
        public void SetUp()
        {
            this._service = new UniverseService();
        }

        [Test]
        public void TestGetTypes()
        {
            var pageNumber = 1;

            var types = this._service.GetUniverseTypes(pageNumber);

            Assert.That(types != null);
            Assert.That(types.Count != 0);
        }

        [Test]
        public void TestGetTypes2()
        {
            var pageNumber = 100;

            var types = this._service.GetUniverseTypes(pageNumber);

            Assert.That(types != null);
            Assert.That(types.Count == 0);
        }

        [Test]
        public void TestGetType()
        {
            var typeId = 10;

            var type = this._service.GetUniverseTypeById(typeId);

            Assert.That(type != null);
        }
    }
}
