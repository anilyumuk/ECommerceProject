using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Admin.Controllers
{

    public class OrderDetailController : Controller
    {
        OrderRepository oRep;
        OrderDetailRepository odRep;
        ProductRepository pRep;

        public OrderDetailController()
        {
            oRep = new OrderRepository();
            odRep = new OrderDetailRepository();
            pRep = new ProductRepository();

        }





        public ActionResult OrderDetailList(int id)
        {

            return View(oRep.Find(id));
        }

        [HttpPost]
        public ActionResult OrderDetailListValue(int id, FormCollection collection)
        {
            List<OrderDetail> currentData = odRep.Where(x => x.OrderID == id);
            int indexer = 0;
            foreach (OrderDetail element in currentData)
            {
                element.Value = collection.GetValues("valueName")[indexer];
                indexer++;
                odRep.Update(element);
            }
            return RedirectToAction("ProductDetail", new { id = id });
        }



        public ActionResult OrderDetail(int id)
        {
            return View(odRep.Where(x => x.OrderID == id));
        }



        public ActionResult OrderDetailAdd(int id)
        {
            ViewBag.ProductList = pRep.GetAll();
            return View(oRep.Find(id));
        }

        [HttpPost]
        public ActionResult OrderDetailAdd(Product item, FormCollection collection)
        {
            foreach (string element in collection.GetValues("checkbox"))
            {
                int id = Convert.ToInt32(element);
                OrderDetail pa = new OrderDetail();
                pa.OrderID = item.ID;
                pa.ProductID = id;
                odRep.Add(pa);

            }

            return RedirectToAction("OrderDetailList", new { id = item.ID });
        }
    }
}
