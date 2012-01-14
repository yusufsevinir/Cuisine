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
            ProductOrderViewModel viewModel = new ProductOrderViewModel();
            viewModel.Product = context.Products.ToList<Product>();
            viewModel.Category = context.Categories.ToList<Category>();
            Session["ProductOrderViewModel"] = viewModel;
            return View(viewModel);
        }

        public ActionResult AddToCart(int productId)
        {
            ProductOrderViewModel viewModel = (ProductOrderViewModel) Session["ProductOrderViewModel"];
            if (viewModel.CartItems.Count > 0)
            {
                foreach (Cart cart in viewModel.CartItems)
                {
                    if (cart.ProductId == productId)
                    {
                        cart.Count++;
                        viewModel.CartTotal += cart.Product.Price;
                    }
                    
                }
            }
            else
            {
                Cart cart = new Cart();
                cart.CartId = Guid.NewGuid().ToString();
                cart.Product = context.Products.FirstOrDefault(p => p.ProductId == productId);
                cart.ProductId = productId;
                cart.DateCreated = DateTime.UtcNow;
                cart.Count = 1;
                viewModel.CartItems.Add(cart);
                viewModel.CartTotal += cart.Product.Price;
            }
            //Cart cart = new Cart();
            //cart.
            //viewModel.CartItems.Add(
            return View("Index",viewModel);
        }
    }
}
