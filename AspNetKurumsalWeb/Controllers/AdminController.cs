using AspNetKurumsalWeb.Models;
using AspNetKurumsalWeb.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetKurumsalWeb.Controllers
{
    public class AdminController : Controller
    {

        //KurumsalDB db = new KurumsalDB();
        KurumsalDBContext db = new KurumsalDBContext();

        public ActionResult Index()
        {
            var sorgu = db.Kategori.ToList();
            return View(sorgu);
        }
    }
}