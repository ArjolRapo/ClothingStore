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
    public class ShportasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Shportas
        public IQueryable<Shporta> GetShportas()
        {
            return db.Shportas;
        }

        // GET: api/Shportas/5
        [ResponseType(typeof(Shporta))]
        public IHttpActionResult GetShporta(int id)
        {
            Shporta shporta = db.Shportas.Find(id);
            if (shporta == null)
            {
                return NotFound();
            }

            return Ok(shporta);
        }

        // PUT: api/Shportas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShporta(int id, Shporta shporta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shporta.IDShoprta)
            {
                return BadRequest();
            }

            db.Entry(shporta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShportaExists(id))
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

        // POST: api/Shportas
        [ResponseType(typeof(Shporta))]
        public IHttpActionResult PostShporta(Shporta shporta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Shportas.Add(shporta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shporta.IDShoprta }, shporta);
        }

        // DELETE: api/Shportas/5
        [ResponseType(typeof(Shporta))]
        public IHttpActionResult DeleteShporta(int id)
        {
            Shporta shporta = db.Shportas.Find(id);
            if (shporta == null)
            {
                return NotFound();
            }

            db.Shportas.Remove(shporta);
            db.SaveChanges();

            return Ok(shporta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShportaExists(int id)
        {
            return db.Shportas.Count(e => e.IDShoprta == id) > 0;
        }
    }
}