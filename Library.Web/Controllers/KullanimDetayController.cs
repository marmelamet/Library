using Library.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    [Authorize]
    public class KullanimDetayController : Controller
    {
        private readonly DBContext db;
        public KullanimDetayController()
        {
            db = new DBContext();
        }

        // GET: KullanimDetay
        public ActionResult Index()
        {
            
            var kullanimDetay = db.KullanimDetay.ToList();
            kullanimDetay.ForEach(c =>
            {
                if (c.iadeTarihi.HasValue && c.teslimTarihi.HasValue)
                {
                    DateTime iadeTarihi = c.iadeTarihi.Value;
                    var teslimTarihi = c.teslimTarihi.Value;
                    int gunSayisi = (iadeTarihi - teslimTarihi).Days;
                    if (gunSayisi > 30)
                    {
                        c.ceza = (gunSayisi - 30) * 0.5M;
                    }
                    else
                    {
                        c.ceza = 0;
                    }
                }
                else
                {
                    DateTime baslamaTarihi = c.teslimTarihi.Value;
                    DateTime bitisTarihi = DateTime.Now;

                    TimeSpan kalangun = bitisTarihi - baslamaTarihi;
                    double toplamGun = kalangun.TotalDays;
                    c.gunSayisi = Convert.ToInt32(toplamGun);
                    //c.ceza = 0;
                  //  c.teslimTarihi = c.teslimTarihi.Value;
                  //  c.gunSayisi = Convert.ToInt32(DateTime.Now.Day) - Convert.ToInt32(c.teslimTarihi.Value);


                   

                }
            });
            return View(kullanimDetay);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.KitapList = db.Kitaplar.Where(c => (c.KullanimDetays.Count() > 0 && c.KullanimDetays.OrderByDescending(a => a.olusturmaTarihi).FirstOrDefault().iadeTarihi <= DateTime.Now) || c.KullanimDetays.Count()==0).ToList();
            ViewBag.KullaniciList = db.Kullanicilar.ToList();
            return View(new KullanimDetay());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(KullanimDetay kullanimDetay)
        {
            kullanimDetay.olusturmaTarihi = DateTime.Now;
            kullanimDetay.isActive = true;
            db.KullanimDetay.Add(kullanimDetay);
            db.SaveChanges();
            return RedirectToAction("Index", "KullanimDetay");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.KitapList = db.Kitaplar.ToList();
            ViewBag.KullaniciList = db.Kullanicilar.ToList();
            var kullanimDetay = db.KullanimDetay.Find(id);
            return View(kullanimDetay);
        }

        [HttpPost]
        public ActionResult Edit(KullanimDetay kullanimDetay)
        {
            db.Entry(kullanimDetay).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "KullanimDetay");
        }

        public ActionResult Delete(int id)
        {
            var kullanimDetay = db.KullanimDetay.Find(id);
            return View(kullanimDetay);
        }

        [HttpPost]
        public ActionResult Delete(KullanimDetay kullanimDetay)
        {
            var dkullanimDetay = db.KullanimDetay.FirstOrDefault(c => c.ID == kullanimDetay.ID);
            db.KullanimDetay.Remove(dkullanimDetay);
            db.SaveChanges();
            return RedirectToAction("Index", "KullanimDetay");
        }


        public ActionResult IadeAl (int id)
        {
            var kd = db.KullanimDetay.FirstOrDefault(c => c.ID == id);
            DateTime baslamaTarihi = kd.teslimTarihi.Value;
            DateTime bitisTarihi = DateTime.Now;

            TimeSpan kalangun = bitisTarihi - baslamaTarihi;
            double toplamGun = kalangun.TotalDays;
            kd.gunSayisi = Convert.ToInt32(toplamGun);

            kd.iadeTarihi = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index", "KullanimDetay");
        }
    }
}