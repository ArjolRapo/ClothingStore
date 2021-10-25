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
    public class DrgPorosiasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/DrgPorosias
        public IQueryable<DrgPorosia> GetDrgPorosias()
        {
            return db.DrgPorosias;
        }

        // GET: api/DrgPorosias/5
        [ResponseType(typeof(DrgPorosia))]
        public IHttpActionResult GetDrgPorosia(int id)
        {
            DrgPorosia drgPorosia = db.DrgPorosias.Find(id);
            if (drgPorosia == null)
            {
                return NotFound();
            }

            return Ok(drgPorosia);
        }

        // PUT: api/DrgPorosias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrgPorosia(int id, DrgPorosia drgPorosia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drgPorosia.ID)
            {
                return BadRequest();
            }

            db.Entry(drgPorosia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrgPorosiaExists(id))
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

        // POST: api/DrgPorosias
        [ResponseType(typeof(DrgPorosia))]
        public IHttpActionResult PostDrgPorosia(DrgPorosia drgPorosia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DrgPorosias.Add(drgPorosia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = drgPorosia.ID }, drgPorosia);
        }

        // DELETE: api/DrgPorosias/5
        [ResponseType(typeof(DrgPorosia))]
        public IHttpActionResult DeleteDrgPorosia(int id)
        {
            DrgPorosia drgPorosia = db.DrgPorosias.Find(id);
            if (drgPorosia == null)
            {
                return NotFound();
            }

            db.DrgPorosias.Remove(drgPorosia);
            db.SaveChanges();

            return Ok(drgPorosia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrgPorosiaExists(int id)
        {
            return db.DrgPorosias.Count(e => e.ID == id) > 0;
        }
    }
}