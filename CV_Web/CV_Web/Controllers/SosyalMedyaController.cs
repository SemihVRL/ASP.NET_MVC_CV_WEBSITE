using CV_Web.Models.EntityFramework;
using CV_Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Web.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya

        SosyalMedyaRepository repo = new SosyalMedyaRepository();
        public ActionResult SosyalMedyaIndex()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Ekle(TBLSOSYALMEDYA p)
        {
            repo.TAdd(p);
            return RedirectToAction("SosyalMedyaIndex");
        }

       

        [HttpGet]
        public ActionResult Getir(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult Getir(TBLSOSYALMEDYA p)
        {
            var t = repo.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.Ad=p.Ad;
            t.Link = p.Link;
            t.ikon = p.ikon;
            t.Durum = true;
            repo.TUpdate(t);
            return RedirectToAction("SosyalMedyaIndex");

        }

        public ActionResult Aktif(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.Durum = true;
            repo.TUpdate(hesap);
            return RedirectToAction("SosyalMedyaIndex");
        }

        public ActionResult Pasif(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("SosyalMedyaIndex");
        }

        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.Durum = false;
            repo.TRemove(hesap);
            return RedirectToAction("SosyalMedyaIndex");
        }


    }
}