using CV_Web.Models.EntityFramework;
using CV_Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Web.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult DeneyimIndex()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(TBLDENEYİM p)
        {
           repo.TAdd(p);
           return RedirectToAction("DeneyimIndex");
        }
        public ActionResult DeneyimSil(int id)
        {
            TBLDENEYİM t = repo.Find(x => x.ID==id);
            repo.TRemove(t);
            return RedirectToAction("DeneyimIndex");

        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TBLDENEYİM t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(TBLDENEYİM p)
        {
            TBLDENEYİM t = repo.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.Baslik=p.Baslik;
            t.AltBaslik=p.AltBaslik;
            t.Tarih=p.Tarih;
            t.Aciklama=p.Aciklama;
            repo.TUpdate(t);
            return RedirectToAction("DeneyimIndex");
        }
    }
}