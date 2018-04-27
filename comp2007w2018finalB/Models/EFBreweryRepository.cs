using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace comp2007w2018finalB.Models
{
    public class EFBreweryRepository : IMockBreweryRepository
    {
        // database connection
        private CraftBrewingModel db = new CraftBrewingModel();

        public IQueryable<Brewery> Brewery { get { return db.Breweries; } }

        public object Breweries => throw new NotImplementedException();

        public void Delete(Brewery Brewery)
        {
            db.Brewery.Remove(Brewery);
            db.SaveChanges();
        }

        public void Save(Brewery brewery)
        {
            if (Brewery.BreweryId != null)
                {
                db.Entry(Brewery).State = EntityState.Modified;
            }
            else
            {
                db.Brewery.Add(Brewery);
            }
            db.SaveChanges();
            return Brewery;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}