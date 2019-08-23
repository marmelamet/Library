using Library.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    [Authorize]
    public class KullanicilarController : Controller
    {
        private readonly DBContext db;
        public KullanicilarController()
        {
            db = new DBContext();
        }

        // GET: Kullanicilar
        public ActionResult Index()
        {
            var kullanicilar = db.Kullanicilar.ToList();
            return View(kullanicilar);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.RolList = db.Roller.ToList();
            ViewBag.SehirList = db.iller.ToList();
            return View(new Kullanicilar());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Kullanicilar kullanicilar)
        {
            kullanicilar.olusturmaTarihi = DateTime.Now;
            kullanicilar.isActive = true;
            db.Kullanicilar.Add(kullanicilar);
            db.SaveChanges();
            return RedirectToAction("Index", "Kullanicilar");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.RolList = db.Roller.ToList();
            ViewBag.SehirList = db.iller.ToList();
            var kullanicilar = db.Kullanicilar.Find(id);
            return View(kullanicilar);
        }

        [HttpPost]
        public ActionResult Edit(Kullanicilar kullanicilar)
        {
            db.Entry(kullanicilar).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Kullanicilar");
        }

        public ActionResult Delete(int id)
        {
            var kullanicilar = db.Kullanicilar.Find(id);
            return View(kullanicilar);
        }

        [HttpPost]
        public ActionResult Delete(Kullanicilar kullanicilar)
        {
            var dkullanici = db.Kullanicilar.FirstOrDefault(c => c.ID == kullanicilar.ID);
            db.Kullanicilar.Remove(dkullanici);
            db.SaveChanges();
            return RedirectToAction("Index", "Kullanicilar");
        }
    }
}