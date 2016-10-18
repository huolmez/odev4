using ders4.Filters;
using ders4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ders4.Controllers
{
    [UserAuthorize]
    public class PanelController : Controller
    {
        // GET: Panel



        public List<Product> productList = new List<Product>(){
                new Product(){id=1,name = "kalem", detail = "mor", price = 22.00 },
                new Product(){id=2,name = "silgi", detail = "yesil", price = 11.00 },
                new Product(){id=3,name = "canta", detail = "mavi", price = 5.00 },
                new Product(){id=4,name = "masa", detail = "üçgen", price = 7.00 },
                new Product(){id=5,name = "sandalye", detail = "yeni", price = 19.00 }
          };

        public List<Class1> classlist = new List<Class1>(){
                new Class1(){isim = "Hüseyin",soyad="Ölmez",mail="olmezhuseyin7@gmail.com"  },
                new Class1(){isim = "Murat Onur",soyad="Çakmak",mail="mrtonrckmk@gmail.com"  },
                new Class1(){isim = "Yasin",soyad="Seyinoğlu",mail="yseyinoglu@gmail.com"  },
                new Class1(){isim = "Oğuz",soyad="Aslan",mail="ogaslan@gmail.com"  },
                new Class1(){isim = "Ferit",soyad="Arıbulan",mail="faribulan@gmail.com"  }
                
          };

        public List<Sikayet> sikayetList = new List<Sikayet>()
        {
            new Sikayet(){sikayet="dlhfgslhdfglhslfdhglşshdfglhsdlfhglshdfhghl"}
        };

        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["loginFailed"]) == false)
            {
                if (HttpContext.Application["hatali_giris"] == null)
            {
                HttpContext.Application["hatali_giris"] = 0;
            }

            HttpContext.Application["hatali_giris"] = Convert.ToInt16(HttpContext.Application["hatali_giris"]) + 1;

            ViewBag.hatali_giris = HttpContext.Application["hatali_giris"];
            }
           
            

            if (Request.Cookies["mesaj_gosterildimi"]  == null)
            {
                HttpCookie cookie = new HttpCookie("mesaj_gosterildimi", "evet");
                Response.Cookies.Add(cookie);
                ViewBag.ShowMessage = true;
            }

            ViewBag.name = Session["name"];

            return View(this.productList);
        }

        

       
        public ActionResult Sikayet()
        {
            return View(sikayetList);
        }

        public ActionResult Kisiler()
        {
            return View(classlist);
        }
    }
}