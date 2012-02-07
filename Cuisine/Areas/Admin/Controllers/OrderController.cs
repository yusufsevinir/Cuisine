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
    [Authorize(Roles = "Administrator")]
    public class OrderController : Controller
    {
        private CuisineEntities db = new CuisineEntities();

        //
        // GET: /Admin/Order/

        public ViewResult Index()
        {
            return View(db.Orders.ToList());
        }

        //
        // GET: /Admin/Order/Details/5

        public ViewResult Details(Guid id)
        {
            Order order = db.Orders.Find(id);
            return View(order);
        }

        //
        // GET: /Admin/Order/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Admin/Order/Create

        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderId = Guid.NewGuid();
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(order);
        }
        
        //
        // GET: /Admin/Order/Edit/5
 
        public ActionResult Edit(Guid id)
        {
            Order order = db.Orders.Find(id);
            return View(order);
        }

        //
        // POST: /Admin/Order/Edit/5

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        //
        // GET: /Admin/Order/Delete/5
 
        public ActionResult Delete(Guid id)
        {
            Order order = db.Orders.Find(id);
            return View(order);
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