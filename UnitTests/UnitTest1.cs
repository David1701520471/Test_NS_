using NUnit.Framework;
using System;
using TestMVC.Controllers;
using TestMVC.DbAccess.Interface;
using TestMVC.ExternalAPI.Interface;
using TestMVC.ExternalAPI.Response;
using TestMVC.Models.Search;
using TestMVC.Models.SearchData;
using TestMVC.DbAccess.Exeptions;

namespace UnitTests
{
    [TestFixture]
    public class Tests
    {
        private IAPI api;
        private IDbAcces dbAccess;
        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public void SearchFlightsFilledFields()
        {
            SearchData data = new SearchData
            {
                Origin = "BOG",
                Destination = "PEI",
                Datepicker = "2020-01-4"
            };

            SearchFlightController controller = new SearchFlightController(api, dbAccess);
            Assert.That(controller.Search(data), !Is.EqualTo(null), "Successful Search ");
        }

        [Test]
        public void SearchFlightsWithMissedFields()
        {
        SearchData data = new SearchData
            {
                Origin = "BOG",
                Destination = "PEI",
                Datepicker = ""
            };
            
            SearchFlightController controller = new SearchFlightController(api, dbAccess);
            Assert.ThrowsAsync<SearchMissedFieldException>(() => 
            controller.Search(data));
        }
    }
}