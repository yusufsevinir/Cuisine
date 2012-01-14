using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cuisine.Models;

namespace Cuisine.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/

        public ActionResult Index()
        {
            CuisineEntities context = new CuisineEntities();

            return View(context.Categories.AsEnumerable<Category>());
        }

        public ActionResult CategoryListMenu()
        { 
            CuisineEntities context = new CuisineEntities();

            return View(context.Categories.AsEnumerable<Category>());
        }
    }
}
