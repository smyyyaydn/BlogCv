using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVSİTESİ.Models.Entity;
using CVSİTESİ.Repositories;

namespace CVSİTESİ.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
        public ActionResult Index(TblHobilerim p)
        {
            //TblHobilerim t = new TblHobilerim();
            var t = repo.Find(x => x.ID == 1);
            t.Açıklama1 = p.Açıklama1;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}