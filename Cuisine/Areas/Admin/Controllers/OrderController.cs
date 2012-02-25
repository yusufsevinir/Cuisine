using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cuisine.Models;

namespace Cuisine.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class OrderController : Controller
    {
        private CuisineEntities db = new CuisineEntities();

        //
        // GET: /Admin/Order/

        public ViewResult Index()
        {
            return View(db.Orders.Where(o=>o.Status == (byte)OrderStatus.New).OrderBy(o=>o.OrderDate).ToList());
        } 

        public ViewResult History()
        {
            return View(db.Orders.Where(o=>o.Status == (byte)OrderStatus.Shipped).OrderByDescending(o=>o.OrderDate).Take(100).ToList());
        }

        //
        // GET: /Admin/Order/Details/5

        public ViewResult Details(Guid id)
        {
            Order order = db.Orders.Find(id);
            return View(order);
        }
        public ActionResult Shipped(Guid id)
        {
            Order order = db.Orders.Find(id);
            order.Status =(byte)OrderStatus.Shipped;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Admin/Order/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {            
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}