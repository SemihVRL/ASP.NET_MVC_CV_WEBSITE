using CV_Web.Models.EntityFramework;
using CV_Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Web.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika

        SertifikaRepository repo = new SertifikaRepository();
        public ActionResult SertifikaIndex()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SertifikaEkle()
        {

            return View();

        }
        [HttpPost]
        public ActionResult SertifikaEkle(TBLSERTİFİKALARIM p)
        {
            repo.TAdd(p);
            return RedirectToAction("SertifikaIndex");

        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {

            var degerler = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(degerler);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(TBLSERTİFİKALARIM t)
        {
            TBLSERTİFİKALARIM sertifika = repo.Find(x => x.ID == t.ID);
            sertifika.ID = t.ID;
            sertifika.Aciklama = t.Aciklama;
            sertifika.Tarih = t.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("SertifikaIndex");

        }
        public ActionResult SertifikaSil(int id)
        {
            var degerler=repo.Find(x => x.ID == id);
            repo.TRemove(degerler);
            return RedirectToAction("SertifikaIndex");

        }



    }
}