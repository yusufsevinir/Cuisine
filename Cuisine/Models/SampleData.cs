using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Cuisine.Models
{
    public class SampleData : DropCreateDatabaseAlways<CuisineEntities>
    //DropCreateDatabaseIfModelChanges<CuisineEntities>
    {
        protected override void Seed(CuisineEntities context)
        {
            var categories = new List<Category>
            {
                new Category { Name = "Starters" },
                new Category { Name = "Kebabs" },
                new Category { Name = "Combination Kebabs" },
                new Category { Name = "Chargrilled Burgers" },
                new Category { Name = "Chicken & Fish" },
                new Category { Name = "Extras" },
                new Category { Name = "Desserts" },
                new Category { Name = "Soft Drinks" }                
            };

            
            new List<Product>
            {
//                new Product { Name = "The Best Of Men At Work", Category = categories.Single(g => g.Name == "Rock"), Price = 8.99M, ProductImageUrl = "/Content/Images/placeholder.gif" },
                new Product {Name = "Humus", Category = categories.Single(s=>s.Name == "Starters"),Price = 2.50M,ProductImageUrl ="/Content/Images/placeholder.jpg" },
                new Product {Name = "Onion Rings (10 PCS)", Category = categories.Single(s=>s.Name == "Starters"),Price = 2.00M, ProductImageUrl ="/Content/Images/placeholder.jpg" },
                new Product {Name = "Lamb Doner", Category = categories.Single(s=>s.Name == "Kebabs"),Price = 2.50M,ProductImageUrl ="/Content/Images/placeholder.jpg" },
                new Product {Name = "Chicken Doner", Category = categories.Single(s=>s.Name == "Kebabs"),Price = 2.50M,ProductImageUrl ="/Content/Images/placeholder.jpg" },
                new Product {Name = "Chicken Kebab", Category = categories.Single(s=>s.Name == "Kebabs"),Price = 2.50M,ProductImageUrl ="/Content/Images/placeholder.jpg" },
                new Product {Name = "Shish Kebab", Category = categories.Single(s=>s.Name == "Kebabs"),Price = 8.50M,ProductImageUrl ="/Content/Images/placeholder.jpg" },
                new Product {Name = "Kofte Doner", Category = categories.Single(s=>s.Name == "Kebabs"),Price = 5.50M,ProductImageUrl ="/Content/Images/placeholder.jpg" },
                
                //new Product { Name = "A Copland Celebration, Vol. I", Category = categories.Single(g => g.Name == "Classical"), Price = 8.99M, ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "Worlds", Category = categories.Single(g => g.Name == "Jazz"), Price = 8.99M, ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "For Those About To Rock We Salute You", Category = categories.Single(g => g.Name == "Rock"), Price = 8.99M,ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "Let There Be Rock", Category = categories.Single(g => g.Name == "Rock"), Price = 8.99M, ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "Balls to the Wall", Category = categories.Single(g => g.Name == "Rock"), Price = 8.99M, ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "Restless and Wild", Category = categories.Single(g => g.Name == "Rock"), Price = 8.99M, ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "The Best Of Van Halen, Vol. I", Category = categories.Single(g => g.Name == "Rock"),  ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "Van Halen III", Category = categories.Single(g => g.Name == "Rock"), Price = 8.99M, ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "Van Halen", Category = categories.Single(g => g.Name == "Rock"), Price = 8.99M,  ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "Axé Bahia 2001", Category = categories.Single(g => g.Name == "Pop"), Price = 8.99M, ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "Sambas De Enredo 2001", Category = categories.Single(g => g.Name == "Latin"), Price = 8.99M,  ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "Vozes do MPB", Category = categories.Single(g => g.Name == "Latin"), Price = 8.99M, ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "Contraband", Category = categories.Single(g => g.Name == "Rock"), Price = 8.99M,  ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "Vinicius De Moraes", Category = categories.Single(g => g.Name == "Latin"), Price = 8.99M, ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "Bach: Goldberg Variations", Category = categories.Single(g => g.Name == "Classical"), Price = 8.99M, ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "Bartok: Violin & Viola Concertos", Category = categories.Single(g => g.Name == "Classical"), Price = 8.99M, ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "Bach: The Cello Suites", Category = categories.Single(g => g.Name == "Classical"), Price = 8.99M, ProductImageUrl = "/Content/Images/placeholder.gif" },
                //new Product { Name = "Ao Vivo [IMPORT]", Category = categories.Single(g => g.Name == "Latin"), Price = 8.99M, ProductImageUrl = "/Content/Images/placeholder.gif" },
            }.ForEach(a => context.Products.Add(a));
        }
    }
}