using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.DB;

namespace Library.Web.Controllers
{
    [Authorize]
    public class RollerController : Controller
    {
        private readonly DBContext db;
        public RollerController()
        {
            db = new DBContext();
        }
        // GET: Roller
        public ActionResult Index()
        {
            var rol = db.Roller.ToList();
            return View(rol);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View(new Roller());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Roller roller)
        {
            db.Roller.Add(roller);
            db.SaveChanges();
            return RedirectToAction("Index", "Roller");
        }

        public ActionResult Edit(int id)
        {
            var roller = db.Roller.Find(id);
            return View(roller);
        }

        [HttpPost]
        public ActionResult Edit(Roller roller)
        {
            db.Entry(roller).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Roller");
        }

        public ActionResult Delete(int id)
        {
            var roller = db.Roller.Find(id);
            return View(roller);
        }

        [HttpPost]
        public ActionResult Delete(Roller roller)
        {
            var droller = db.Roller.FirstOrDefault(c => c.ID == roller.ID);
            db.Roller.Remove(droller);
            db.SaveChanges();
            return RedirectToAction("Index", "Roller");
        }
    }
}