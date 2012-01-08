using System.ComponentModel.DataAnnotations;

namespace Cuisine.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Product Product { get; set; }
    }
}