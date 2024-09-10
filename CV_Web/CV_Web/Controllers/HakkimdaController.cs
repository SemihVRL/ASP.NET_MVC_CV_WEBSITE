using CV_Web.Models.EntityFramework;
using CV_Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Web.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda

        HakkımdaRepository repo= new HakkımdaRepository();

        [HttpGet]
        public ActionResult HakkimdaIndex()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpPost]
        public ActionResult HakkimdaIndex(TBLHAKKIMDA p)
        {
            //TBLHAKKIMDA tBLHAKKIMDA = new TBLHAKKIMDA();
            var degerler = repo.Find(x => x.ID == 1);
            degerler.ID = p.ID;
            degerler.Adi = p.Adi;
            repo.TUpdate(degerler);
           return RedirectToAction("HakkimdaIndex");
        }


    }
}   