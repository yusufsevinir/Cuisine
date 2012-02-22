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
        private CuisineEntities db = CuisineEntities.Entities;

        
        private string ErrorMessage = "";
        public ActionResult Index()
        {
            var viewModel = (ProductOrderViewModel)Session["ProductOrderViewModel"];
            if (viewModel == null)
            {
                viewModel = new ProductOrderViewModel
                                {
                                    Product = db.Products.ToList<Product>(),
                                    Category = db.Categories.ToList<Category>()
                                };
                Session["ProductOrderViewModel"] = viewModel;
            }
            return View(viewModel);
        }

        public ActionResult ViewWarning(bool success)
        {
            return View(success);
        }

        public ActionResult ViewError(string error)
        {
            return View(error);
        }

        public ActionResult AddToCart(int productId)
        {
            var viewModel = (ProductOrderViewModel)Session["ProductOrderViewModel"];

            if (viewModel == null) {
                viewModel = new ProductOrderViewModel
                {
                    Product = db.Products.ToList<Product>(),
                    Category = db.Categories.ToList<Category>()
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
                newCart.Product = db.Products.FirstOrDefault(p => p.ProductId == productId);
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
        public ActionResult Order(Order order)
        {
            try
            {
                if (ValidateInput(order))
                {                 
                    order.OrderDate = DateTime.UtcNow;
                    order.Status = (byte)OrderStatus.New;
                    order.OrderId = Guid.NewGuid();
                    order.Description = order.Description ?? "";
                    ProductOrderViewModel viewData = (ProductOrderViewModel)Session["ProductOrderViewModel"];
                    order.Total = viewData.CartTotal;
                    foreach (var cart in viewData.CartItems)
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderDetailId = Guid.NewGuid();
                        orderDetail.Quantity = cart.Count;
                        orderDetail.UnitPrice = cart.Product.Price;
                        orderDetail.ProductId = cart.ProductId;
                        orderDetail.OrderId = order.OrderId;
                        db.OrderDetails.Add(orderDetail);
                    }

                    db.Orders.Add(order);                    
                    db.SaveChanges();                    
                    Session["ProductOrderViewModel"] = null;
                    return Json(new Order { IsSuccess = true, ErrorMessage = "" });                
                }
            }
            catch(Exception ex)
            {
                return Json(new Order { IsSuccess = false, ErrorMessage = ErrorMessage });
            }
            return Json(new Order { IsSuccess = false, ErrorMessage = ErrorMessage });
        }

        public ActionResult ClearCart()
        {
            var viewModel = new ProductOrderViewModel
            {
                Product = db.Products.ToList<Product>(),
                Category = db.Categories.ToList<Category>()
            };
            Session["ProductOrderViewModel"] = viewModel;

            return View("ShoppingCart",viewModel);  
        }

        private bool ValidateInput(Models.Order newOrder)
        {
            ProductOrderViewModel viewData = (ProductOrderViewModel)Session["ProductOrderViewModel"];
            
            bool isValid = true;
            if (newOrder == null)
            {
                ErrorMessage = "Please enter all the required fields";
                isValid = false;
            }
            else if (newOrder.FirstName == "")
            {
                ErrorMessage = "Please enter first name!";
                isValid = false;
            }
            else if (newOrder.LastName == "")
            {
                ErrorMessage = "Please enter last name!";
                isValid = false;
            }
            else if (newOrder.Address == "")
            {
                ErrorMessage = "Please enter address details!";
                isValid = false;
            }
            else if (newOrder.Phone == "")
            {
                ErrorMessage = "Please enter phone number!";
                isValid = false;
            }
            else if (newOrder.PostalCode == "")
            {
                ErrorMessage = "Please enter post code!";
                isValid = false;
            }
            else if (newOrder.Email == "" || newOrder.Email.ToString().Contains("@") == false)
            {
                ErrorMessage = "Please enter email address!";
                isValid = false;
            }
            else if (viewData.CartTotal < 11) 
            {
                ErrorMessage = "You need to spend £11 or more to order!";
                isValid = false;
            }
            return isValid;
        }
    }
}
