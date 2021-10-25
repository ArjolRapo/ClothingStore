using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Microsoft.AspNet.Identity;
using StoreClothing2.Models;

namespace StoreClothing2.Controllers
{
    public class Produktes1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Produktes1
        public ActionResult Index()
        { 
            return View(db.Produktes.OrderBy(x=>x.Emri).ToList());
        }
       
        // GET: Produktes1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkte produkte = db.Produktes.Find(id);
            if (produkte == null)
            {
                return HttpNotFound();
            }
            return View(produkte);
        }

        // GET: Produktes1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produktes1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDProdukte,Emri,Imazh,Cmimi,Pershkrimi,Sasi")] Produkte produkte)
        {
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                db.Produktes.Add(produkte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produkte);
        }

        // GET: Produktes1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkte produkte = db.Produktes.Find(id);
            if (produkte == null)
            {
                return HttpNotFound();
            }
            return View(produkte);
        }

        // POST: Produktes1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDProdukte,Emri,Imazh,Cmimi,Pershkrimi,Sasi")] Produkte produkte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produkte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produkte);
        }

        // GET: Produktes1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkte produkte = db.Produktes.Find(id);
            if (produkte == null)
            {
                return HttpNotFound();
            }
            return View(produkte);
        }

        // POST: Produktes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produkte produkte = db.Produktes.Find(id);
            int? idtest = null;
            if (id!=null && id>=1)
            {
                idtest = id;
            }
            var shportaprodukt = db.Shportas.Where(x => x.Produkti.IDProdukte == idtest);
            db.Shportas.RemoveRange(shportaprodukt);
            db.Produktes.Remove(produkte);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult ShtoShport(int? id)
        {
            
            string UserId = Perdoruesi();
            if (id != null)
            {
                // Kontrollo nqs ky perdorues ka blere me pare kete produkt, nqs jo shto produkt
                Shporta kart = db.Shportas.FirstOrDefault(x => x.IdPerdorues == UserId && x.Produkti.IDProdukte == id);
                if (kart == null)
                {
                    Shporta kartRe = new Shporta()
                    {
                        Produkti=db.Produktes.Where(x=>x.IDProdukte==id).FirstOrDefault(),
                        IdPerdorues =UserId,
                        Sasia = 1
                    };
                   
                    db.Shportas.Add(kartRe);
                    db.SaveChanges();
                }
                // Perndryshe shto sasine per ate produkt
                else
                {
                    kart.Sasia += 1;

                }
                UlSasia(id, 1);
                db.SaveChanges();

            }
            List<Shporta> kartaPerdoruesi = db.Shportas.Include("Produkti").Where(k => k.IdPerdorues == UserId).ToList();
            
            return View(kartaPerdoruesi);
        }
        public string Perdoruesi()
        {
            if (Request.IsAuthenticated)
            {
                return User.Identity.GetUserId();
            }
            else
            {
                if (Session["user"] == null)
                {
                    Session["user"] = Guid.NewGuid().ToString();
                }
                return Session["user"].ToString();

            }
        }
        public ActionResult FshiProduktNgaKarta(int id)
        {
            string UserId = Perdoruesi();
            Shporta kartaP = db.Shportas.Where(k => k.IdPerdorues == UserId && k.Produkti.IDProdukte == id).FirstOrDefault();
            UpdateProductsIncrease(id, 1);
            db.Shportas.Remove(kartaP);
            db.SaveChanges();

            return RedirectToAction("ShtoShport");// View(db.Kartat.Where(k => k.IdPerdorues == UserId).ToList());
        }
        public ActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Checkout([Bind(Include = "ID,Email,Emri,Mbiemri,Rruga,Qyteti,Shteti,KodiPostal,Telefon")] DrgPorosia drg)
        {
            if(ModelState.IsValid)
            {
                db.DrgPorosias.Add(drg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(drg);
        }
        public ActionResult ZbritSasi(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                string UserId = Perdoruesi();
                Shporta kartaP = db.Shportas.Where(k => k.IdPerdorues == UserId && k.Produkti.IDProdukte == id).FirstOrDefault();
                if (kartaP.Sasia == 1)
                {
                    return FshiProduktNgaKarta((int)id);
                }
                else
                {
                    kartaP.Sasia -= 1;
                    //db.Entry(kartaP).State = EntityState.Modified;
                    db.SaveChanges();
                    UpdateProductsIncrease(id, 1);
                    return RedirectToAction("ShtoShport");
                }
            }
        }
        public void UlSasia(int? IDProdukt,int sasia)
        {
            var id = db.Produktes.Where(x => x.IDProdukte == IDProdukt).FirstOrDefault();
            id.Sasi = id.Sasi - sasia;
            db.SaveChanges();
        }
        public void UpdateProductsIncrease(int? idProduct, int sasia)
        {
            var product = db.Produktes.Where(p => p.IDProdukte== idProduct).FirstOrDefault();
            product.Sasi = product.Sasi + sasia;
            
            db.SaveChanges();
        }
        //public ActionResult PerfundoPorosine(int id, int SasiaShporte)
        //{
        //    var idProduct = db.Produktes.Where(x => x.IDProdukte == id).FirstOrDefault();
        //    idProduct.Inventari.SasiTotale = idProduct.Inventari.SasiTotale - SasiaShporte;
        //    if (idProduct.Inventari.SasiTotale == 0)
        //    {
        //        Produkte produkte = db.Produktes.Find(id);
        //        db.Produktes.Remove(produkte);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //}
    }
}
