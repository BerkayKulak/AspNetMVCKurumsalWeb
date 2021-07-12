using AspNetKurumsalWeb.Models;
using AspNetKurumsalWeb.Models.DataContext;
using AspNetKurumsalWeb.Models.Model;
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var login = db.Admin.Where(x => x.Eposta == admin.Eposta).SingleOrDefault();
            if(login.Eposta==admin.Eposta && login.Sifre == admin.Sifre)
            {
                Session["adminId"] = login.AdminId;
                Session["eposta"] = login.Eposta;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Uyari = "Kullanıcı adı yada şifre yanlış";
            return View(admin);
        }

        public ActionResult Logout()
        {
            Session["adminId"] = null;
            Session["eposta"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }
    }
}