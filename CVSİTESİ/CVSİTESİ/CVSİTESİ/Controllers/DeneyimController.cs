using CVSİTESİ.Models.Entity;
using CVSİTESİ.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVSİTESİ.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var değerler = repo.List();
            return View(değerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();

        }
        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyimlerim p)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == p.ID);
            t.Başlık = p.Başlık;
            t.AltBaşlık = p.AltBaşlık;
            t.Tarih = p.Tarih;
            t.Açıklama = p.Açıklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}