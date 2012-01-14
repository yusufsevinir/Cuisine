using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cuisine.Models;

namespace Cuisine.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListByCategory(int? id)
        {
            CuisineEntities entities = new CuisineEntities();
            return View("ListByCategory", entities.Products.Where(p => p.CategoryId == id).AsEnumerable<Product>());

        }

    }
}
