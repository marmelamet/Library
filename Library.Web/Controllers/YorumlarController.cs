using Library.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    [Authorize]
    public class YorumlarController : Controller
    {
        private readonly DBContext db;
        public YorumlarController()
        {
            db = new DBContext();
        }
        // GET: Yorumlar
        public ActionResult Index()
        {
            var yorumlar = db.Yorumlar.ToList();
            return View(yorumlar);
        }

        public ActionResult Create()
        {
            ViewBag.KitapList = db.Kitaplar.ToList();
            ViewBag.KullaniciList = db.Kullanicilar.ToList();
            return View(new Yorumlar());
        }
        [HttpPost]
        public ActionResult Create(Yorumlar yorumlar)
        {
            yorumlar.olusturmaTarihi = DateTime.Now;
            db.Yorumlar.Add(yorumlar);
            db.SaveChanges();
            return RedirectToAction("Index", "Yorumlar");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.KitapList = db.Kitaplar.ToList();
            ViewBag.KullaniciList = db.Kullanicilar.ToList();
            var yorumlar = db.Yorumlar.Find(id);
            return View(yorumlar);
        }

        [HttpPost]
        public ActionResult Edit(Yorumlar yorumlar)
        {
            db.Entry(yorumlar).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Yorumlar");
        }
        public ActionResult Delete(int id)
        {
            var yorumlar = db.Yorumlar.Find(id);
            return View(yorumlar);
        }

        [HttpPost]
        public ActionResult Delete(Yorumlar model)
        {
            var dyorumlar = db.Yorumlar.FirstOrDefault(c => c.ID == model.ID);
            db.Yorumlar.Remove(dyorumlar);
            db.SaveChanges();
            return RedirectToAction("Index", "Yorumlar");
        }

        public ActionResult Details(int id)
        {
            var yorum = db.Yorumlar.Where(x => x.ID == id).FirstOrDefault();
            var kitapAd = db.Kitaplar.Where(x => x.ID == yorum.kitapID).FirstOrDefault();
            ViewBag.KitapAd = kitapAd.ad;
            var yorumlar = db.Yorumlar.ToList();
            return View(yorumlar);
        }
    }
}