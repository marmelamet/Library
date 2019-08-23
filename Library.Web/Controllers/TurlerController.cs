using Library.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    [Authorize]
    public class TurlerController : Controller
    {
        private readonly DBContext db;
        public TurlerController()
        {
            db = new DBContext();
        }
        // GET: Turler
        public ActionResult Index()
        {
            var turler = db.Turler.ToList();
            return View(turler);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View(new Turler());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Turler turler)
        {
            db.Turler.Add(turler);
            db.SaveChanges();
            return RedirectToAction("Index", "Turler");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var turler = db.Turler.Find(id);
            return View(turler);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Turler turler)
        {
            db.Entry(turler).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Turler");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var turler = db.Turler.Find(id);
            return View(turler);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Turler turler)
        {
            var dtur = db.Turler.FirstOrDefault(c => c.ID == turler.ID);
            db.Turler.Remove(dtur);
            db.SaveChanges();
            return RedirectToAction("Index", "Turler");
        }
    }
}