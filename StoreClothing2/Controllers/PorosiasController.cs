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
    public class PorosiasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Porosias
        public IQueryable<Porosia> GetPorosias()
        {
            return db.Porosias;
        }

        // GET: api/Porosias/5
        [ResponseType(typeof(Porosia))]
        public IHttpActionResult GetPorosia(int id)
        {
            Porosia porosia = db.Porosias.Find(id);
            if (porosia == null)
            {
                return NotFound();
            }

            return Ok(porosia);
        }

        // PUT: api/Porosias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPorosia(int id, Porosia porosia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != porosia.IDPorosia)
            {
                return BadRequest();
            }

            db.Entry(porosia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PorosiaExists(id))
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

        // POST: api/Porosias
        [ResponseType(typeof(Porosia))]
        public IHttpActionResult PostPorosia(Porosia porosia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Porosias.Add(porosia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = porosia.IDPorosia }, porosia);
        }

        // DELETE: api/Porosias/5
        [ResponseType(typeof(Porosia))]
        public IHttpActionResult DeletePorosia(int id)
        {
            Porosia porosia = db.Porosias.Find(id);
            if (porosia == null)
            {
                return NotFound();
            }

            db.Porosias.Remove(porosia);
            db.SaveChanges();

            return Ok(porosia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PorosiaExists(int id)
        {
            return db.Porosias.Count(e => e.IDPorosia == id) > 0;
        }
    }
}