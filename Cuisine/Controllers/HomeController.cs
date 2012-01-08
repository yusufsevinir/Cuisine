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
            var albums = GetTopSellingAlbums(5);

            return View(albums);
        }

        private List<Product> GetTopSellingAlbums(int count)
        {
            // Group the order details by Product and return
            // the albums with the highest count

            return storeDB.Products
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }
    }
}