using AspNetKurumsalWeb.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace AspNetKurumsalWeb.Controllers
{
    public class HomeController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Hizmetler = db.Hizmet.ToList().OrderByDescending(x => x.HizmetId);
                
            return View();
        }

        public ActionResult SliderPartial()
        {
            return View(db.Slider.ToList().OrderByDescending(x=>x.SliderId));
        }

        public ActionResult HizmetPartial()
        {
            return View(db.Hizmet.ToList().OrderByDescending(x=>x.HizmetId));
        }

        public ActionResult Hakkimizda()
        {
           
            return View(db.Hakkimizda.SingleOrDefault());
        }

        public ActionResult Hizmetlerimiz()
        {
            return View(db.Hizmet.ToList().OrderByDescending(x=>x.HizmetId));
        }

        public ActionResult Iletisim()
        {
            return View(db.Iletisim.SingleOrDefault());
        }

        [HttpPost]
        public ActionResult Iletisim(string adsoyad = null, string email = null,string konu = null,string mesaj = null)
        {
            if(adsoyad != null && email != null)
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "mail";
                WebMail.Password = "Your password";
                WebMail.SmtpPort = 587;
                WebMail.Send("mail", konu, email + "</br>" + mesaj);
                ViewBag.Uyari = "Mesajınız başarıyla gönderildi";

            }
            else
            {
                ViewBag.Uyari = "Hata Oluştu. Tekrar Deneyiniz.";
            }
            return View();
        }

        public ActionResult Blog(int Sayfa = 1)
        {
 
            return View(db.Blog.Include("Kategori").OrderByDescending(x=>x.BlogId).ToPagedList(Sayfa,5));
        }

        public ActionResult BlogDetay(int id)
        {
            var blog = db.Blog.Include("Kategori").Where(x => x.BlogId == id).SingleOrDefault();
            return View(blog);
        }

        public ActionResult BlogKategoriPartial()
        {
            return PartialView(db.Kategori.Include("Blogs").ToList().OrderBy(x=>x.KategoriAd));
        }

        public ActionResult BlogKayitPartial()
        {
            return PartialView(db.Blog.ToList().OrderByDescending(x=>x.BlogId));
        }

        public ActionResult FooterPartial()
        {
            ViewBag.Hizmetler = db.Hizmet.ToList().OrderByDescending(x => x.HizmetId);

            ViewBag.Iletisim = db.Iletisim.SingleOrDefault();

            ViewBag.Blog = db.Blog.ToList().OrderByDescending(x => x.BlogId);
            return PartialView();
        }

      
    }
}
