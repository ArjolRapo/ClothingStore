using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using StoreClothing2.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace StoreClothing2.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public AdminController()
        {
        }
        public AdminController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ??
                HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                UserManager = value;
            }
        }


        // GET: Admin
        [Authorize]
        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult Kerkesa()
        {
            return View(db.DrgPorosias.ToList());
        }
        public ActionResult Produkte()
        {
            return View(db.Produktes.ToList());
        }
        public ActionResult UserControl()
        {
            return View(db.Users.ToList());
        }

        public ActionResult NisePorosi()
        {
         
            return View();
        }
        [HttpPost]
        public ActionResult SendEmailView()
        {
            //call SendEmailView view to invoke webmail  
            return View();
        }

        public async Task<ActionResult> DetajetPerdorues(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            return View(user);
        }
        public ActionResult MosPorosin(int? id)
        {
            DrgPorosia porosia = db.DrgPorosias.Find(id);
            db.DrgPorosias.Remove(porosia);
            db.SaveChanges();
            return RedirectToAction("Kerkesa");
        }
        public ActionResult ModifioPorosine(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrgPorosia porosia = db.DrgPorosias.Find(id);
            if (porosia == null)
            {
                return HttpNotFound();
            }
            return View(porosia);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModifioPorosine([Bind(Include = "ID,Email,Emri,Mbiemri,Rruga,Qyteti,Shteti,KodiPostal,Telefon")] DrgPorosia porosi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(porosi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Kerkesa");
            }
            return View(porosi);
        }

    }
}