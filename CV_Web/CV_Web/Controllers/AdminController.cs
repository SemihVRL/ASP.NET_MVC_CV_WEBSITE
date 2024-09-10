using CV_Web.Models.EntityFramework;
using CV_Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Web.Controllers
{
  
    public class AdminController : Controller
    {
        // GET: Admin
        AdminRepository repo = new AdminRepository();
        public ActionResult AdminIndex()
        {
            var liste = repo.List();
            return View(liste);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(TBLADMİN p)
        {
            repo.TAdd(p);
            return RedirectToAction("AdminIndex");
        }

        public ActionResult Sil(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            repo.TRemove(degerler);
            return RedirectToAction("AdminIndex");
        }
        [HttpGet]
        public ActionResult AdminDüzenle(int id)
        {
            var degerler=repo.Find(x => x.ID == id);
            return View(degerler);

        }
        [HttpPost]
        public ActionResult AdminDüzenle(TBLADMİN p)
        {
            var degerler = repo.Find(x => x.ID == p.ID);
            degerler.ID= p.ID;
            degerler.KullaniciAdi= p.KullaniciAdi;
            degerler.Sifre= p.Sifre;
            repo.TUpdate(degerler);
            return RedirectToAction("AdminIndex");

        }
    }
}