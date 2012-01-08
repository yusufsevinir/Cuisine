using System.Collections.Generic;
using Cuisine.Models;

namespace Cuisine.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}