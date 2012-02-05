using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Cuisine.Models;

namespace Cuisine.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        CuisineEntities storeDB = new CuisineEntities();

        public ActionResult Index()
        {
            // Get most popular albums
            var albums = GetDeals();
            return View(albums);
        }

        private List<Product> GetDeals()
        {            
            return storeDB.Products.Where(p=>p.Category.Name == "Deals").ToList();
        }

        public ActionResult Contact()
        {
            return View("Contact");
        }
    }
}