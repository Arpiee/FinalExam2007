using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using comp2007w2018finalB.Controllers;
using Moq;
using comp2007w2018finalB.Models;
using System.Linq;
using System.Collections;
using System.Web.Mvc;

namespace comp2007w2018finalB.Tests.Controllers
{
    [TestClass]
    public class BreweriesControllerTest
    {
        BreweriesController controller;
        Mock<IMockBreweryRepository> mock;
        List<Brewery> breweries;

        public ICollection Breweries { get; private set; }

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IMockBreweryRepository>();

            breweries = new List<Brewery>
            {
                new Brewery { BreweryId = 1, Name = "One", City = "Barrie", Url = "http://one.ca", Logo = "one.gif" },
                new Brewery { BreweryId = 2, Name = "Two", City = "Barrie", Url = "http://two.ca", Logo = "two.gif" },
                new Brewery { BreweryId = 2, Name = "Three", City = "Barrie", Url = "http://three.ca", Logo = "three.gif" }
            };

            mock.Setup(m => m.Brewery).Returns(breweries.AsQueryable());

            controller = new BreweriesController(mock.Object);
        }
        [TestMethod]

        public void IndexViewLoads()
        {
            // act
            var actual = controller.Index();

            // assert

            Assert.IsNotNull(actual);
        }
        [TestMethod]

        public void IndexLoadsBreweries()
        {
            // act - cast ActionResult to ViewResult, then Model to list of Brewery
            var actual = (List<Brewery>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(Breweries, actual);

        }
        [TestMethod]
       
        public void CreateViewLoads()
        {
            // act
            var actual = (ViewResult)controller.Create();

            // assert
            Assert.AreEqual("Create", actual.ViewName);
        }
        [TestMethod]
        public void CreateValid()
        {
            // arrange
            Brewery a = new Brewery
            {
                Name = "New Brewery"
            };

            // act
            var actual = (RedirectToRouteResult)controller.Create(a);

            // assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }
        [TestMethod]
        public void CreateInvalid()
        {
            // arrange 
            Brewery a = new Brewery
            {
                Name = "New Brewery"
            };

            controller.ModelState.AddModelError("key", "create error");

            // act
            var actual = (ViewResult)controller.Create(a);

            // assert
            Assert.AreEqual("create", actual.ViewName);
        }
    }
}
