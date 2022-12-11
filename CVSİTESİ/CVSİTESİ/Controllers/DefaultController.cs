using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVSİTESİ.Models.Entity;
namespace CVSİTESİ.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        dbcvsitesiEntities db = new dbcvsitesiEntities();
        
    public ActionResult Index()
        {
            var degerler = db.TblHakkımda.ToList();
            return View(degerler);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Eğitimlerim()
        {
            var eğitimler = db.TblEğitimlerim.ToList();
            return PartialView(eğitimler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TblHobilerim.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalarım()
        {
            var sertifikalar = db.TblSertifikalarım.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public PartialViewResult İletişim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult İletişim(Tblİletişim t)
        {
            db.Tblİletişim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }

}