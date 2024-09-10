using CV_Web.Models.EntityFramework;
using CV_Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Web.Controllers
{
    public class YeteneklerController : Controller
    {
        // GET: Yetenek
        //GenericRepository<TBLYETENEKLERİM> repo= new GenericRepository<TBLYETENEKLERİM>
        YeteneklerRepository repo=new YeteneklerRepository();
        public ActionResult YetenekIndex()
        {
            var yetenek = repo.List();
            return View(yetenek);
        }
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(TBLYETENEKLERİM p)
        {
            repo.TAdd(p);
            return RedirectToAction("YetenekIndex");

        }

        public ActionResult YetenekSil(int id)
        {
            TBLYETENEKLERİM t = repo.Find(x => x.ID == id);
            repo.TRemove(t);
            return RedirectToAction("YetenekIndex");
        }
        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            TBLYETENEKLERİM t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult YetenekGetir(TBLYETENEKLERİM p)
        {
            TBLYETENEKLERİM t = repo.Find(x => x.ID == p.ID);
            t.ID= p.ID;
            t.Yetenek = p.Yetenek;
            t.Oran = p.Oran;
            repo.TUpdate(t);
            return RedirectToAction("YetenekIndex");
        }

    }
}
