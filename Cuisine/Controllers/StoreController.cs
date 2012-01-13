using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cuisine.Models;

namespace Cuisine.Controllers
{
    public class StoreController : Controller
    {
        CuisineEntities storeDB = new CuisineEntities();

        //
        // GET: /Store/

        public ActionResult Index()
        {
            var categories = storeDB.Categories.ToList();
            return View(categories);
        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string category)
        {
            var categoryModel = storeDB.Categories.Include("Products").SingleOrDefault(c => c.Name == category);
            // Retrieve Category and its Associated Products from database
            //var genreModel = storeDB.Categories.Include("Products")
            //    .Single(g => g.Name == genre);

            return View(categoryModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            var album = storeDB.Products.Find(id);

            return View(album);
        }

        //
        // GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = storeDB.Categories.ToList();

            return PartialView(categories);
        }

    }
}