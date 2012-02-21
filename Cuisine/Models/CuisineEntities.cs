using System.Data.Entity;
using System.Web;

namespace Cuisine.Models
{
    public class CuisineEntities : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public static CuisineEntities Entities
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["db"] == null)
                {
                    HttpContext.Current.Items["db"] = new CuisineEntities();
                }
                return HttpContext.Current.Items["db"] as CuisineEntities;
            }
            set
            {
                if (HttpContext.Current != null)
                    HttpContext.Current.Items["db"] = value;
            }
        }
    }
}