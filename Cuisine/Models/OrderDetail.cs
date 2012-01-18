namespace Cuisine.Models
{
    public class OrderDetail
    {
        public System.Guid OrderDetailId { get; set; }
        public System.Guid OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
