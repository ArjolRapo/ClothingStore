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
    public class InventarisController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Inventaris
        public IQueryable<Inventari> GetInventaris()
        {
            return db.Inventaris;
        }

        // GET: api/Inventaris/5
        [ResponseType(typeof(Inventari))]
        public IHttpActionResult GetInventari(int id)
        {
            Inventari inventari = db.Inventaris.Find(id);
            if (inventari == null)
            {
                return NotFound();
            }

            return Ok(inventari);
        }

        // PUT: api/Inventaris/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventari(int id, Inventari inventari)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventari.IDinventari)
            {
                return BadRequest();
            }

            db.Entry(inventari).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventariExists(id))
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

        // POST: api/Inventaris
        [ResponseType(typeof(Inventari))]
        public IHttpActionResult PostInventari(Inventari inventari)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inventaris.Add(inventari);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = inventari.IDinventari }, inventari);
        }

        // DELETE: api/Inventaris/5
        [ResponseType(typeof(Inventari))]
        public IHttpActionResult DeleteInventari(int id)
        {
            Inventari inventari = db.Inventaris.Find(id);
            if (inventari == null)
            {
                return NotFound();
            }

            db.Inventaris.Remove(inventari);
            db.SaveChanges();

            return Ok(inventari);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventariExists(int id)
        {
            return db.Inventaris.Count(e => e.IDinventari == id) > 0;
        }
    }
}