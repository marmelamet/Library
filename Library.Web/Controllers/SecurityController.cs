using Library.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using System.IO;

namespace Library.Web.Controllers
{
    public class SecurityController : Controller
    {
        private readonly DBContext db;
        private object bodyScreen;

        public SecurityController()
        {
            db = new DBContext();
        }
        // GET: Security
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Kullanicilar kullanicilar)
        {
            var user = db.Kullanicilar.FirstOrDefault(c => c.email == kullanicilar.email && c.sifre == kullanicilar.sifre);
            if (user != null)
            {
                kullanicilar.ID = user.ID;
                kullanicilar.ad = user.ad;
                kullanicilar.adres = user.adres;
                kullanicilar.Roller = new Roller
                {
                    rolAdi = user.Roller.rolAdi
                };
                kullanicilar.soyad = user.soyad;
                kullanicilar.TCKimlik = user.TCKimlik;


                var authTicket = new FormsAuthenticationTicket(1, user.email, DateTime.Now, DateTime.Now.AddDays(1), true, JsonConvert.SerializeObject(kullanicilar));
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(authCookie);
                return RedirectToAction("Index", "Home");
            }
            TempData["Hata"] = "Kullanıcı bulunamadı!";
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            ViewBag.SehirList = db.iller.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Kullanicilar kullanicilar)
        {
            kullanicilar.rolID = 2;
            db.Kullanicilar.Add(kullanicilar);
            db.SaveChanges();
            var user = db.Kullanicilar.Include("Roller").FirstOrDefault(c => c.email == kullanicilar.email && c.sifre == kullanicilar.sifre);

            kullanicilar.ID = user.ID;
            kullanicilar.ad = user.ad;
            kullanicilar.adres = user.adres;
            kullanicilar.Roller = new Roller
            {
                rolAdi = user.Roller.rolAdi
            };
            kullanicilar.soyad = user.soyad;
            kullanicilar.TCKimlik = user.TCKimlik;

            var authTicket = new FormsAuthenticationTicket(1, user.email, DateTime.Now, DateTime.Now.AddDays(1), true, JsonConvert.SerializeObject(kullanicilar));
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}
    
