using CV_Web.Models.EntityFramework;
using CV_Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Web.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        HobiRepository repo = new HobiRepository();

        [HttpGet]
        public ActionResult HobiIndex()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpPost]
        public ActionResult HobiIndex(TBLHOBİLERİM p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Hobi1 = p.Hobi1;
            t.Hobi2 = p.Hobi2;
            t.Hobi3 = p.Hobi3;
            repo.TUpdate(t);
            return RedirectToAction("HobiIndex");
        }
    }
}