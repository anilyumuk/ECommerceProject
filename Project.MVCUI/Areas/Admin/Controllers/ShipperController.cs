using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Admin.Controllers
{
    public class ShipperController : Controller
    {
        // GET: Admin/Shipper
        ShipperRepository SRep;
        public ShipperController()
        {
            SRep = new ShipperRepository();
        }
        
        public ActionResult ShipperList()
        {
            return View(SRep.GetAll());
        }

        public ActionResult ShipperByID(int id)
        {
            return View(SRep.Find(id));
        }

        

        public ActionResult AddShipper()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddCategory(Shipper item)
        {
            SRep.Add(item);
            return RedirectToAction("ShipperList");
        }


        public ActionResult UpdateShipper(int id)
        {
            return View(SRep.Find(id));
        }

        [HttpPost]

        public ActionResult UpdateShipper(Shipper item)
        {
            SRep.Update(item);
            return RedirectToAction("ShipperList");
        }


        public ActionResult DeleteShipper(int id)
        {
            SRep.Delete(SRep.Find(id));
            return RedirectToAction("ShipperList");
        }





    }
}