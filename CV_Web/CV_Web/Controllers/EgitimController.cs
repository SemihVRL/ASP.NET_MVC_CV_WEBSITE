using CV_Web.Models.EntityFramework;
using CV_Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Web.Controllers
{
    
    public class EgitimController : Controller
    {
        // GET: Egitim

         EgitimRepository repo= new EgitimRepository();

        
        public ActionResult EgitimIndex()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TBLEGİTİMLERİM p)
        {

            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("EgitimIndex");
        }

        public ActionResult EgitimSil(int id)
        {
            TBLEGİTİMLERİM t = repo.Find(x => x.ID == id);
            repo.TRemove(t);
            return RedirectToAction("EgitimIndex");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            TBLEGİTİMLERİM t = repo.Find(x => x.ID == id);
            return View (t);
        }

        [HttpPost]
        public ActionResult EgitimGetir(TBLEGİTİMLERİM p)
        {
            TBLEGİTİMLERİM t=repo.Find(x=>x.ID == p.ID);
            t.ID= p.ID;
            t.Baslik= p.Baslik;
            t.AltBaslik1 = p.AltBaslik1;
            t.AltBaslik2= p.AltBaslik2;
            t.GNO= p.GNO;
            t.Tarih= p.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("EgitimIndex");
        }
    }
}