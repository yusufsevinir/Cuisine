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
                new Category { Name = "Soft Drinks" },   
                new Category { Name = "Deals" },   
                new Category { Name = "Kids Menu" },   
            };

            
            new List<Product>
            {
//                new Product { Name = "The Best Of Men At Work", Category = categories.Single(g => g.Name == "Rock"), Price = 8.99M, ProductImageUrl = "/Content/Images/placeholder.gif" },
                new Product {Name = "Humus", 
                    Category = categories.Single(s=>s.Name == "Starters"),
                    Price = 2.50M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = "Ground chick peas with olive oil"
                },
                new Product {Name = "Onion Rings (10 PCS)", 
                    Category = categories.Single(s=>s.Name == "Starters"),
                    Price = 2.00M, 
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "Lamb Doner", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 3.80M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg", 
                    Description = "Slices of lamb,minced,seasoned & cooked on an upright spear",
                    Size = Convert.ToByte(ProductSize.Small)
                },
                new Product {Name = "Lamb Doner", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 4.80M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg", 
                    Description = "Slices of lamb,minced,seasoned & cooked on an upright spear",
                    Size = Convert.ToByte(ProductSize.Large)
                },
                new Product {Name = "Chicken Doner", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 4.00M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = "Slices of chicken, seasoned & cooked on an upright spear",
                    Size = Convert.ToByte(ProductSize.Small)
                },
                new Product {Name = "Chicken Doner", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 5.00M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = "Slices of chicken, seasoned & cooked on an upright spear",
                    Size = Convert.ToByte(ProductSize.Large)
                },
                new Product {Name = "Chicken Kebab", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 4.20M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = "Cubes of chicken, marinated in garlic curry powder & tomato pure",
                    Size = Convert.ToByte(ProductSize.Small)
                },
                new Product {Name = "Chicken Kebab", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 5.90M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = "Cubes of chicken, marinated in garlic curry powder & tomato pure",
                    Size = Convert.ToByte(ProductSize.Large)
                },
                new Product {Name = "Shish Kebab", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 4.20M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg", 
                    Description = "Cubes of lamb, marinated in vegetable oil, lemon juice & charcoal grill",
                    Size = Convert.ToByte(ProductSize.Small)
                },
                new Product {Name = "Shish Kebab", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 5.90M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg", 
                    Description = "Cubes of lamb, marinated in vegetable oil, lemon juice & charcoal grill",
                    Size = Convert.ToByte(ProductSize.Large)
                },
                new Product {Name = "Kofte Kebab", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 4.20M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = "Minced lamb, skewered with onion, peppers, spices & charcoal grilled",
                    Size = Convert.ToByte(ProductSize.Small)
                },
                new Product {Name = "Kofte Kebab", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 5.90M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = "Minced lamb, skewered with onion, peppers, spices & charcoal grilled",
                    Size = Convert.ToByte(ProductSize.Large)
                },
                new Product {Name = "Mixed Kebab", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 8.00M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = "1 skewer each of kofte,shish & slices of doner"
                },
                new Product {Name = "Halep Kebab", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 5.50M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = "Doner, served on sliced pitta bread topped with special sauce"
                },
                new Product {Name = "Adana Kebab", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 5.50M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = "Kofte, served on sliced pitta bread, topped with special sauce"
                },
                new Product {Name = "Chargoal Grill Special", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 10.00M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = "1 skewer each of special shish,chicken,kofte & slices of doner"
                },
                new Product {Name = "Lamb Doner Meat & Chips", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 4.70M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = "",
                    Size = Convert.ToByte(ProductSize.Small)
                },
                new Product {Name = "Lamb Doner Meat & Chips", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 6.30M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = "",
                    Size = Convert.ToByte(ProductSize.Large)
                },
                new Product {Name = "Lamb Doner Meat & Chips & Salad", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 5.20M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = "",
                    Size = Convert.ToByte(ProductSize.Small)
                },
                new Product {Name = "Lamb Doner Meat & Chips & Salad", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 6.80M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = "",
                    Size = Convert.ToByte(ProductSize.Large)
                },
                new Product {Name = "Chicken Doner Meat & Chips", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 5.20M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = "",
                    Size = Convert.ToByte(ProductSize.Small)
                },
                new Product {Name = "Chicken Doner Meat & Chips", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 6.50M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = "",
                    Size = Convert.ToByte(ProductSize.Large)
                },
                new Product {Name = "Chicken Doner Meat & Chips & Salad", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 5.70M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = "",
                    Size = Convert.ToByte(ProductSize.Small)
                },
                new Product {Name = "Chicken Doner Meat & Chips & Salad", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 7.00M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = "",
                    Size = Convert.ToByte(ProductSize.Large)
                },
                new Product {Name = "Portion of Lamb Doner", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 2.50M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = ""
                },
                new Product {Name = "Portion of Chicken Doner", 
                    Category = categories.Single(s=>s.Name == "Kebabs"),
                    Price = 3.00M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg" ,
                    Description = ""
                },






                new Product {Name = "Shish & Doner", 
                    Category = categories.Single(s=>s.Name == "Combination Kebabs"),
                    Price = 5.90M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "Shish & Kofte", 
                    Category = categories.Single(s=>s.Name == "Combination Kebabs"),
                    Price = 5.90M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "Kofte & Doner", 
                    Category = categories.Single(s=>s.Name == "Combination Kebabs"),
                    Price = 5.90M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "Shish & Chicken", 
                    Category = categories.Single(s=>s.Name == "Combination Kebabs"),
                    Price = 5.90M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "Doner & Chicken", 
                    Category = categories.Single(s=>s.Name == "Combination Kebabs"),
                    Price = 5.90M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "Chicken & Kofte", 
                    Category = categories.Single(s=>s.Name == "Combination Kebabs"),
                    Price = 5.90M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },



                new Product {Name = "1/4 Pounder", 
                    Category = categories.Single(s=>s.Name == "Chargrilled Burgers"),
                    Price = 2.60M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "1/4 Pounder With Cheese", 
                    Category = categories.Single(s=>s.Name == "Chargrilled Burgers"),
                    Price = 2.80M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "1/2 Pounder With Cheese", 
                    Category = categories.Single(s=>s.Name == "Chargrilled Burgers"),
                    Price = 4.20M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "CheeseBurger", 
                    Category = categories.Single(s=>s.Name == "Chargrilled Burgers"),
                    Price = 1.70M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "VegeBurger", 
                    Category = categories.Single(s=>s.Name == "Chargrilled Burgers"),
                    Price = 2.60M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },



                new Product {Name = "Chicken Sandwich", 
                    Category = categories.Single(s=>s.Name == "Chicken & Fish"),
                    Price = 3.50M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = "Filled of chicken served with salad & mayonnaise"
                },
                new Product {Name = "6 Chicken Nuggets & Chips", 
                    Category = categories.Single(s=>s.Name == "Chicken & Fish"),
                    Price = 3.50M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "12 Chicken Nuggets & Chips", 
                    Category = categories.Single(s=>s.Name == "Chicken & Fish"),
                    Price = 5.00M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "12 Scampi & Chips", 
                    Category = categories.Single(s=>s.Name == "Chicken & Fish"),
                    Price = 4.70M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "Cod & Chips", 
                    Category = categories.Single(s=>s.Name == "Chicken & Fish"),
                    Price = 4.50M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },



                new Product {Name = "Chips", 
                    Category = categories.Single(s=>s.Name == "Extras"),
                    Price = 1.30M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = "",
                    Size = Convert.ToByte(ProductSize.Small)
                },
                new Product {Name = "Chips", 
                    Category = categories.Single(s=>s.Name == "Extras"),
                    Price = 2.00M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = "",
                    Size = Convert.ToByte(ProductSize.Large)
                },
                new Product {Name = "Chips & Cheese", 
                    Category = categories.Single(s=>s.Name == "Extras"),
                    Price = 3.00M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "Chips in pitta bread", 
                    Category = categories.Single(s=>s.Name == "Extras"),
                    Price = 2.50M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = "",
                },
                new Product {Name = "Chips in pitta bread with lamb doner", 
                    Category = categories.Single(s=>s.Name == "Extras"),
                    Price = 5.00M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "Chips in pitta bread with chicken doner", 
                    Category = categories.Single(s=>s.Name == "Extras"),
                    Price = 5.50M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "Salad Kebab", 
                    Category = categories.Single(s=>s.Name == "Extras"),
                    Price = 2.00M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "Kebab Roll", 
                    Category = categories.Single(s=>s.Name == "Extras"),
                    Price = 3.30M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "Pitta Bread", 
                    Category = categories.Single(s=>s.Name == "Extras"),
                    Price = 0.30M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "Pot of Sauce", 
                    Category = categories.Single(s=>s.Name == "Extras"),
                    Price = 0.30M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },



                new Product {Name = "3 Baklavas", 
                    Category = categories.Single(s=>s.Name == "Desserts"),
                    Price = 2.00M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "Rumbaba", 
                    Category = categories.Single(s=>s.Name == "Desserts"),
                    Price = 1.80M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },

                new Product {Name = "Cans", 
                    Category = categories.Single(s=>s.Name == "Soft Drinks"),
                    Price = 0.70M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = ""
                },
                new Product {Name = "1.5 Ltr Bottles", 
                    Category = categories.Single(s=>s.Name == "Soft Drinks"),
                    Price = 1.80M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = "Coke,Diet Coke,Seven Up,Fanta"
                },
                new Product {Name = "Meal Deal 1", 
                    Category = categories.Single(s=>s.Name == "Deals"),
                    Price = 4.50M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = "1/4 pounder with cheese, chips & drink"
                },
                new Product {Name = "Meal Deal 2", 
                    Category = categories.Single(s=>s.Name == "Deals"),
                    Price = 5.20M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = "Chicken fillet sandwich, chips & drink"
                },
                 new Product {Name = "Meal Deal 3", 
                    Category = categories.Single(s=>s.Name == "Deals"),
                    Price = 5.90M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = "1/2 pounder with cheese, chips & drink"
                },
                 new Product {Name = "Family Special", 
                    Category = categories.Single(s=>s.Name == "Deals"),
                    Price = 16.00M,
                    ProductImageUrl ="/Content/Images/placeholder.jpg",
                    Description = "1 skewer each of special shish, chicken,kofte, slices of doner, humus, 2 chips, mix salad, 2 pittas, bottle of soft drink"
                }
            }.ForEach(a => context.Products.Add(a));
        }
    }
}