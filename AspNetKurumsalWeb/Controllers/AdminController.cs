using AspNetKurumsalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetKurumsalWeb.Controllers
{
    public class AdminController : Controller
    {
        KurumsalDBEntities db = new KurumsalDBEntities();

        public ActionResult Index()
        {
            var sorgu = db.Kategoris.ToList();
            return View(sorgu);
        }
    }
}