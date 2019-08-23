using Library.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    [Authorize]
    public class RaflarController : Controller
    {
        private readonly DBContext db;
        public RaflarController()
        {
            db = new DBContext();
        }
        // GET: Raflar
        public ActionResult Index()
        {
            var raflar = db.Raflar.Include("Turler").ToList();
            return View(raflar);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.TurList = db.Turler.ToList();
            return View(new Raflar());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Raflar raflar)
        {
            raflar.olusturmaTarihi = DateTime.Now;
            raflar.isActive = true;
            db.Raflar.Add(raflar);
            db.SaveChanges();
            return RedirectToAction("Index", "Raflar");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
          
            ViewBag.TurList = db.Turler.ToList();
           
            var raflar = db.Raflar.Find(id);
            return View(raflar);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Raflar raflar)
        {
            db.Entry(raflar).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Raflar");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var raflar = db.Raflar.Find(id);
            return View(raflar);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Raflar raflar)
        {
            var draf = db.Raflar.FirstOrDefault(c => c.ID == raflar.ID);
            db.Raflar.Remove(draf);
            db.SaveChanges();
            return RedirectToAction("Index", "Raflar");
        }
    }
}