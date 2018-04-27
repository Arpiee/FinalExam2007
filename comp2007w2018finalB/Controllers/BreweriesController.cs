using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using comp2007w2018finalB.Models;

namespace comp2007w2018finalB.Controllers
{ 
    [Authorize]
    public class BreweriesController : Controller
    {
        // db connection moved to EFBreweryRepository
        // private CraftBrewingModel db = new CraftBrewingModel();
        private IMockBreweryRepository db;
        

        // default constructor for web app using db
        public BreweriesController()
        {
            this.db = new EFBreweryRepository();
        }

        public BreweriesController(IMockBreweryRepository mockRepo)
        {
            this.db = mockRepo;
        }

        // GET: Breweries
        public ActionResult Index()
        {
            return View(db.Brewery.ToList());
        }

        // GET: Breweries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Breweries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BreweryId,Name,City,Url,Logo")] Brewery brewery)
        {
            if (ModelState.IsValid)
            {
                db.Breweries.Add(brewery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brewery);
        }
    }
}
