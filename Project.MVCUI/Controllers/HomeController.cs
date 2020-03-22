using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.COMMON.Tools;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class HomeController : Controller
    {

        AppUserRepository apRep;
        public HomeController()
        {
            apRep = new AppUserRepository();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(AppUser item)
        {
            AppUser yakalanan = apRep.Default(x => x.UserName == item.UserName);

            string decrypted = DantexCrypt.DeCrypt(yakalanan.Password);

            if (item.Password == decrypted && yakalanan != null && yakalanan.Role ==MODEL.Enums.UserRole.Admin)
            {

                if (yakalanan.Role==MODEL.Enums.UserRole.Admin)
                {
                    if (!yakalanan.IsActive)
                    {
                        AktifKontrol();
                        
                    }
                    Session["admin"] = yakalanan;
                    return RedirectToAction("CategoryList", "Category", new { area = "Admin" });
                }
                else if(yakalanan.Role ==MODEL.Enums.UserRole.Member)
                {
                    if (!yakalanan.IsActive)
                    {
                        AktifKontrol();
                        
                    }
                    Session["member"] = yakalanan;
                    return RedirectToAction("ShoppingList","Member");
                }


              
            }


            ViewBag.KullaniciYok = "Kullanıcı bulunamadı";
            return View();
        }


        private ActionResult AktifKontrol()
        {
            ViewBag.AktifDegil = "Lutfen hesabınızı aktif hale getiriniz...Mailinizi kontrol ediniz...";
            return View("Login");
        }


    }
}