using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        OrderRepository ORep;
        public OrderController()
        {
            ORep = new OrderRepository();
        }
      
        public ActionResult OrderList()
        {
            return View(ORep.GetAll());
        }

        public ActionResult OrderByID(int id)
        {
            return View(ORep.Find(id));
        }

        

        public ActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddOrder(Order item)
        {
            ORep.Add(item);
            return RedirectToAction("OrderList");
        }


        public ActionResult UpdateOrder(int id)
        {
            return View(ORep.Find(id));
        }

        [HttpPost]

        public ActionResult UpdateOrder(Order item)
        {
            ORep.Update(item);
            return RedirectToAction("OrderList");
        }


        public ActionResult DeleteOrder(int id)
        {
            ORep.Delete(ORep.Find(id));
            return RedirectToAction("OrderList");
        }
    }
}