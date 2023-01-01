using CVSİTESİ.Models.Entity;
using CVSİTESİ.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVSİTESİ.Controllers
{
    
    public class EğitimController : Controller
    {
        GenericRepository<TblEğitimlerim> repo = new GenericRepository<TblEğitimlerim>();
        // GET: Eğitim
        public ActionResult Index()
        {
            var eğitim = repo.List();
            return View(eğitim);
        }
        [HttpGet]
        public ActionResult EğitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EğitimEkle(TblEğitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EğitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        } 
        public ActionResult EğitimSil(int id)
        {
            var eğitim = repo.Find(x => x.ID == id);
            repo.TDelete(eğitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EğitimDüzenle(int id)
        {
            var eğitim = repo.Find(x => x.ID == id);
            return View(eğitim);
        }
        [HttpPost]
        public ActionResult EğitimDüzenle(TblEğitimlerim t)
        {
            if (!ModelState.IsValid)
            {
                return View("EğitimDüzenle");
            }
            var eğitim = repo.Find(x => x.ID == t.ID);
            eğitim.Başlık = t.Başlık;
            eğitim.AltBaşlık1 = t.AltBaşlık1;
            eğitim.AltBaşlık2 = t.AltBaşlık2;
            eğitim.Tarih = t.Tarih;
            eğitim.GNO = t.GNO;
            repo.TUpdate(eğitim);
            return RedirectToAction("Index");
        }
    }
}