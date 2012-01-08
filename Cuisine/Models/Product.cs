using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Cuisine.Models
{
    [Bind(Exclude = "AlbumId")]
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "An Product Title is required")]
        [StringLength(160)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00,
            ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }       

        [DisplayName("Product Art URL")]
        [StringLength(1024)]
        public string ProductImageUrl { get; set; }

        public ProductSize Size { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }

    public enum ProductSize
    {        
        Large,
        Small
    }
}