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

            if (viewModel == null) {
                viewModel = new ProductOrderViewModel
                {
                    Product = context.Products.ToList<Product>(),
                    Category = context.Categories.ToList<Category>()
                };
                Session["ProductOrderViewModel"] = viewModel;
            }
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

        public ActionResult RemoveFromCart(int productId)
        {
            var viewModel = (ProductOrderViewModel)Session["ProductOrderViewModel"];

            foreach (Cart cart in viewModel.CartItems)
            {
                if (cart.ProductId == productId)
                {
                    viewModel.CartTotal -= cart.Product.Price*cart.Count;
                    viewModel.CartItems.Remove(cart);
                    break;
                }
            }
            
            Session["ProductOrderViewModel"] = viewModel;
            return View("ShoppingCart", viewModel);
        }
        
        public ActionResult GetOrderDetails()
        {
            return View("Order");
        }

        public ActionResult ViewBasket()
        {            
            return View("ShoppingCart", (ProductOrderViewModel)Session["ProductOrderViewModel"]);
        }

        [HttpPost]
        public ActionResult Order(Order newOrder)
        {
            try
            { 
                Order order = new Order();
                order.OrderId = Guid.NewGuid();
                order.FirstName = newOrder.FirstName.ToString();
                order.LastName = Request.Form["txtLastName"].ToString();
                order.OrderDate = DateTime.UtcNow;
                order.Phone = HttpContext.Request.Form["txtPhone"].ToString();
                order.PostalCode = HttpContext.Request.Form["txtPostCode"].ToString();
                order.Address = Request.Form["txtAddress"].ToString();
                order.Email = HttpContext.Request.Form["txtEmail"].ToString();
                order.OrderDetails = new List<OrderDetail>();
                
                ProductOrderViewModel viewData = (ProductOrderViewModel) Session["ProductOrderViewModel"];
                order.Total = viewData.CartTotal;
                foreach(var cart in viewData.CartItems)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderDetailId = Guid.NewGuid();
                    orderDetail.OrderId = order.OrderId;
                    orderDetail.ProductId = cart.ProductId;
                    orderDetail.Quantity = cart.Count;
                    orderDetail.UnitPrice = cart.Product.Price;
                    orderDetail.Product = cart.Product;
                    orderDetail.Order = order;
                    order.OrderDetails.Add(orderDetail);
                }


                context.SaveChanges();
                Session["ProductOrderViewModel"] = null;
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
