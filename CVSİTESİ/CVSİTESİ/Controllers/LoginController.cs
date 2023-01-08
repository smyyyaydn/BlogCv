using CVSİTESİ.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CVSİTESİ.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            dbcvsitesiEntities db = new dbcvsitesiEntities();
            var bilgi = db.TblAdmin.FirstOrDefault(x=>x.KullanıcıAdı==p.KullanıcıAdı && x.Şifre==p.Şifre );
            if(bilgi!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullanıcıAdı, false);
                Session["KullanıcıAdı"]= bilgi.KullanıcıAdı.ToString();
                return RedirectToAction("Index", "Deneyim");
            }

            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}