using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StoreClothing2.Models;

namespace StoreClothing2.Controllers
{
    public class ProduktesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Produktes
        public IQueryable<Produkte> GetProduktes()
        {
            return db.Produktes;
        }

        // GET: api/Produktes/5
        [ResponseType(typeof(Produkte))]
        public IHttpActionResult GetProdukte(int id)
        {
            Produkte produkte = db.Produktes.Find(id);
            if (produkte == null)
            {
                return NotFound();
            }

            return Ok(produkte);
        }

        // PUT: api/Produktes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProdukte(int id, Produkte produkte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produkte.IDProdukte)
            {
                return BadRequest();
            }

            db.Entry(produkte).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdukteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Produktes
        [ResponseType(typeof(Produkte))]
        public IHttpActionResult PostProdukte(Produkte produkte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Produktes.Add(produkte);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produkte.IDProdukte }, produkte);
        }

        // DELETE: api/Produktes/5
        [ResponseType(typeof(Produkte))]
        public IHttpActionResult DeleteProdukte(int id)
        {
            Produkte produkte = db.Produktes.Find(id);
            if (produkte == null)
            {
                return NotFound();
            }

            db.Produktes.Remove(produkte);
            db.SaveChanges();

            return Ok(produkte);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdukteExists(int id)
        {
            return db.Produktes.Count(e => e.IDProdukte == id) > 0;
        }
    }
}