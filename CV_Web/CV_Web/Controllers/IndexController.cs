using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Web.Models.EntityFramework;
namespace CV_Web.Controllers
{
    [AllowAnonymous]
    public class IndexController : Controller
    {

      
        // GET: Index
        DbCvEntities1 dbcv = new DbCvEntities1();
        public ActionResult Index()
        {
            var degerler = dbcv.TBLHAKKIMDA.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var deneyim = dbcv.TBLDENEYİM.ToList();
            return PartialView(deneyim);
        }

        public PartialViewResult Egitimler()
        {
            var egitim = dbcv.TBLEGİTİMLERİM.ToList();
            return PartialView(egitim);
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = dbcv.TBLSOSYALMEDYA.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }

        public PartialViewResult Yetenekler()
        {
            var yetenek = dbcv.TBLYETENEKLERİM.ToList();
            return PartialView(yetenek);
        }
        public PartialViewResult Hobiler()
        {
            var hobi = dbcv.TBLHOBİLERİM.ToList();
            return PartialView(hobi);
        }
        public PartialViewResult Sertifika()
        {
            var sertifika = dbcv.TBLSERTİFİKALARIM.ToList();
            return PartialView(sertifika);
        }
        [HttpGet]
        public PartialViewResult İletisim()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult İletisim(TBLİLETİSİM tbliletisim)
        {
            tbliletisim.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            dbcv.TBLİLETİSİM.Add(tbliletisim);
            dbcv.SaveChanges();
            return PartialView();
        }
    }
}