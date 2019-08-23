using Library.DB;
using Library.Web.InfraStructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Library.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly DBContext db;
        public HomeController()
        {
            db = new DBContext();
        }

        // GET: Home
        public ActionResult Index()
        {
            var kitaplar = db.Kitaplar.ToList();
            return View(kitaplar);
        }

        [Authorize (Roles ="Admin")]
        public ActionResult Create()
        {
            ViewBag.YazarList = db.Yazarlar.ToList();
            ViewBag.TurList = db.Turler.ToList();
            ViewBag.RafList = db.Raflar.ToList();
            return View(new Kitaplar());
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public ActionResult Create(Kitaplar kitaplar)
        {
            kitaplar.olusturmaTarihi = DateTime.Now;
            kitaplar.isActive = true;
            db.Kitaplar.Add(kitaplar);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ViewBag.YazarList = db.Yazarlar.ToList();
            ViewBag.TurList = db.Turler.ToList();
            ViewBag.RafList = db.Raflar.ToList();
            var kitaplar = db.Kitaplar.Find(id);
            return View(kitaplar);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Kitaplar kitaplar)
        {
            db.Entry(kitaplar).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var kitaplar = db.Kitaplar.Find(id);
            return View(kitaplar);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Kitaplar kitaplar)
        {
            var dkitap = db.Kitaplar.FirstOrDefault(c => c.ID == kitaplar.ID);
            db.Kitaplar.Remove(dkitap); 
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult GetActiveUser()
        {
            var user = (LibraryPrinciple)this.HttpContext.User;
            return Content(user.userData.ad + " " + user.userData.soyad);
        }
    }
}