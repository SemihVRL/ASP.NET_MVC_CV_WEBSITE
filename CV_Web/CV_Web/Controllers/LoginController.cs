using CV_Web.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CV_Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult LoginIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginIndex(TBLADMİN P)
        {
            DbCvEntities1 dbCvEntities1 = new DbCvEntities1();
            var degerler = dbCvEntities1.TBLADMİN.FirstOrDefault
                (x => x.KullaniciAdi == P.KullaniciAdi
                     && x.Sifre == P.Sifre); ;
            if (degerler != null)
            {
                FormsAuthentication.SetAuthCookie(degerler.KullaniciAdi, false);
                Session["KullaniciAdi"] = degerler.KullaniciAdi.ToString();
                return RedirectToAction("HakkimdaIndex", "Hakkimda");
            }

            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı.";
                return RedirectToAction("LoginIndex", "Login");
            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("LoginIndex", "Login");
        }




    }
}
