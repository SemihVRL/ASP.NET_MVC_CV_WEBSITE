using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Web.Models.EntityFramework;
using CV_Web.Repositories;

namespace CV_Web.Controllers
{
    public class İletisimController : Controller
    {
        // GET: İletisim

        İletisimRepository repo = new İletisimRepository();

       
        public ActionResult İletisimIndex()
        {
            var degerler = repo.List();
            return View(degerler);
        }
    }
}