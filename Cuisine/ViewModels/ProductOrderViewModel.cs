using System.Collections.Generic;
using Cuisine.Models;

namespace Cuisine.ViewModels
{
    public class ProductOrderViewModel
    {

        public List<Cart> CartItems { get; set; }
        public List<Product> Product { get; set; }
        public List<Category> Category { get; set; }
        public decimal CartTotal { get; set; }

        public ProductOrderViewModel()
        {
            CartItems = new List<Cart>();
            Product = new List<Product>();
            Category = new List<Category>();
            CartTotal = 0;
        }
    }
}