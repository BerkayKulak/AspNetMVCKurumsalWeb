using AspNetKurumsalWeb.Models.DataContext;
using AspNetKurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AspNetKurumsalWeb.Controllers
{
    public class HizmetController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();
        // GET: Hizmet
        public ActionResult Index()
        {
            return View(db.Hizmet.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Hizmet hizmet,HttpPostedFileBase ResimURL)
        {
            if(ModelState.IsValid)
            {
                if (ResimURL != null)
                {
                    //// güncelleme işlememizi yok comment aldık
                    //if (System.IO.File.Exists(Server.MapPath(kimlik.LogoURL)))
                    //{
                    //    System.IO.File.Delete(Server.MapPath(kimlik.LogoURL));
                    //}

                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string logoname = ResimURL.FileName + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Hizmet/" + logoname);

                    hizmet.ResimURL = "/Uploads/Hizmet/" + logoname;

                }
                db.Hizmet.Add(hizmet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hizmet);
        }


    }

    
}