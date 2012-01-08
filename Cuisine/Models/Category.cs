using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cuisine.Models
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
