using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {
        AppUserRepository AppRep;
        public AppUserController()
        {
            AppRep = new AppUserRepository();
        }
        
        public ActionResult AppUserList()
        {
            return View(AppRep.GetAll());
        }

        public ActionResult AppUserByID(int id)
        {
            return View(AppRep.Find(id));
        }

        

        public ActionResult AddAppUser()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddCategory(AppUser item)
        {
            AppRep.Add(item);
            return RedirectToAction("AppUserList");
        }


        public ActionResult UpdateAppUser(int id)
        {
            return View(AppRep.Find(id));
        }

        [HttpPost]

        public ActionResult UpdateAppUser(AppUser item)
        {
            AppRep.Update(item);
            return RedirectToAction("AppUserList");
        }


        public ActionResult DeleteAppUser(int id)
        {
            AppRep.Delete(AppRep.Find(id));
            return RedirectToAction("ApUserList");
        }





    }
}