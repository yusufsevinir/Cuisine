using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cuisine.ViewModels;
using Cuisine.Models;

namespace Cuisine.Controllers
{
    public class OrderController : Controller
    {
        private CuisineEntities context = new CuisineEntities();
        //
        // GET: /Order/

        public ActionResult Index()
        {
            var viewModel = (ProductOrderViewModel)Session["ProductOrderViewModel"];
            if (viewModel == null)
            {
                viewModel = new ProductOrderViewModel
                                {
                                    Product = context.Products.ToList<Product>(),
                                    Category = context.Categories.ToList<Category>()
                                };
                Session["ProductOrderViewModel"] = viewModel;
            }
            return View(viewModel);
        }

        public ActionResult AddToCart(int productId)
        {
            var viewModel = (ProductOrderViewModel)Session["ProductOrderViewModel"];
            var newCart = new Cart();
            bool exist = false;
            
            foreach (Cart cart in viewModel.CartItems)
            {
                if (cart.ProductId == productId)
                {
                    cart.Count++;
                    viewModel.CartTotal += cart.Product.Price;
                    exist = true;
                }                    
            }
            if (!exist)
            {
                newCart.CartId = Guid.NewGuid().ToString();
                newCart.Product = context.Products.FirstOrDefault(p => p.ProductId == productId);
                newCart.ProductId = productId;
                newCart.DateCreated = DateTime.UtcNow;
                newCart.Count = 1;
                viewModel.CartTotal += newCart.Product.Price;
                viewModel.CartItems.Add(newCart);
            }
            Session["ProductOrderViewModel"] = viewModel;
            return View("ShoppingCart",viewModel);
        }

        public ActionResult ViewBasket()
        {            
            return View("ShoppingCart", (ProductOrderViewModel)Session["ProductOrderViewModel"]);
        }
    }
}
