using comp2007w2018finalB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace comp2007w2018finalB.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Breweries")]
    public class BreweriesController : ApiController
    {
        private CraftBrewingModel db;

        private BreweriesController(CraftBrewingModel db)
        {
            this.db = db;
        }

        // GET: api/Breweries
        [HttpGet]
        public IEnumerable<Brewery> Get()
        {
            return db.Breweries.OrderBy(a => a.Title).ToList();
        }

        public object Breweries { get; private set; }

        // Get/Breweries

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var Brewery = db.Breweries.SingleOrDefault(a => a.BreweriesId == id);

            if (Breweries == null)
            {
                return NotFound();
            }

            return Ok(Brewery);
        }
        // POST: api/Breweries
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Breweries/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
