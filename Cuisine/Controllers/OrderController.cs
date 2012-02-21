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

        private string ErrorMessage = "";
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
                if (ValidateInput(newOrder))
                {
                    Order order = new Order();
                    order.OrderId = Guid.NewGuid();
                    order.FirstName = newOrder.FirstName.ToString();
                    order.LastName = newOrder.LastName.ToString();
                    order.OrderDate = DateTime.UtcNow;
                    order.Status = (byte) OrderStatus.New;
                    order.Phone = newOrder.Phone.ToString();
                    order.PostalCode = newOrder.PostalCode.ToString();
                    order.Description = newOrder.Description ?? "";
                    order.Address = newOrder.Address.ToString();
                    order.Email = newOrder.Email.ToString();
                    context.Orders.Add(order);

                    ProductOrderViewModel viewData = (ProductOrderViewModel)Session["ProductOrderViewModel"];
                    order.Total = viewData.CartTotal;
                    foreach (var cart in viewData.CartItems)
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderDetailId = Guid.NewGuid();
                        orderDetail.OrderId = order.OrderId;
                        orderDetail.ProductId = cart.ProductId;
                        orderDetail.Quantity = cart.Count;
                        orderDetail.UnitPrice = cart.Product.Price;
                        orderDetail.Product = cart.Product;
                        orderDetail.Order = order;
                        context.OrderDetails.Add(orderDetail);
                    }

                    context.SaveChanges();
                    Session["ProductOrderViewModel"] = null;
                    return Json(new Order { IsSuccess = true, ErrorMessage = "" });
                }
            }
            catch(Exception ex)
            {
                return Json(new Order { IsSuccess = false, ErrorMessage = "" });
            }
            return Json(new Order { IsSuccess = false, ErrorMessage = ErrorMessage });
        }

        public ActionResult ClearCart()
        {
            var viewModel = new ProductOrderViewModel
            {
                Product = context.Products.ToList<Product>(),
                Category = context.Categories.ToList<Category>()
            };
            Session["ProductOrderViewModel"] = viewModel;

            return View("ShoppingCart",viewModel);  
        }

        private bool ValidateInput(Models.Order newOrder)
        {
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
            return isValid;
        }
    }
}
