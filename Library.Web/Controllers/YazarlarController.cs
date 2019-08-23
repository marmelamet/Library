using Library.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    public class YazarlarController : Controller
    {
        private readonly DBContext db;
        public YazarlarController()
        {
            db = new DBContext();
        }

        // GET: Yazarlar
        public ActionResult Index()
        {
            var yazarlar = db.Yazarlar.ToList();
            return View(yazarlar);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View(new Yazarlar());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Yazarlar yazarlar)
        {
            yazarlar.olusturmaTarihi = DateTime.Now;
            yazarlar.isActive = true;
            db.Yazarlar.Add(yazarlar);
            db.SaveChanges();
            return RedirectToAction("Index","Yazarlar");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var yazarlar = db.Yazarlar.Find(id);
            return View(yazarlar);
        }
        [HttpPost]
        public ActionResult Edit(Yazarlar yazarlar)
        {
            db.Entry(yazarlar).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Yazarlar");
        }

        public ActionResult Delete(int id)
        {
            var yazarlar = db.Yazarlar.Find(id);
            return View(yazarlar);
        }

        [HttpPost]
        public ActionResult Delete(Yazarlar yazarlar)
        {
            var dyazar = db.Yazarlar.FirstOrDefault(c => c.ID == yazarlar.ID);
            db.Yazarlar.Remove(dyazar);
            db.SaveChanges();
            return RedirectToAction("Index", "Yazarlar");
        }
    }
}