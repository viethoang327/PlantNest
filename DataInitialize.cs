using PlantNestApp.Data;
using PlantNestApp.Models;

namespace PlantNestApp
{
    public static class DataInitialize

    {
        public static void SeedData(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if ((context.categories.Any() || context.categoriesType.Any() ||
                context.products.Any() || context.categoryInProducts.Any() ||
                context.orders.Any() || context.ordersDetail.Any() ||
                context.newsCategories.Any() || context.news.Any() ||
                context.newsInCategories.Any())
                ) return;
            // CATEGORY TABLE
            var categories = new Category[]
            {
                new Category { Name = "Landscape Trees"},
                new Category { Name = "Bonsai Trees"},
                new Category { Name = "Flowering Plants"},

            };
            context.categories.AddRange(categories);
            context.SaveChanges();
            //CATEGORY TYPE TABLE
            var categoryTypes = new CategoryType[]
            {
                new CategoryType { Name = "Landscape Trees" },
                new CategoryType { Name = "Bonsai Trees" },
                new CategoryType { Name = "Flowering Plants" },
            };
            context.categoriesType.AddRange(categoryTypes);
            context.SaveChanges();
            // PRODUCT TABLE
            var products = new Product[]
               {
                    new Product
                    {
                        Name = "Beautiful Maple Tree",
                        Description = "A stunning landscape tree with colorful leaves.",
                        Image = "maple_tree.jpg",
                        Price = 50.99m,
                        Quantity = 10
                    },
                    new Product
                    {
                        Name = "Mini Bonsai",
                        Description = "A small and exquisite bonsai tree.",
                        Image = "mini_bonsai.jpg",
                        Price = 30.50m,
                        Quantity = 5
                    },
                    new Product
                    {
                        Name = "Colorful Rose Bush",
                        Description = "A collection of vibrant rose bushes.",
                        Image = "colorful_rose.jpg",
                        Price = 25.75m,
                        Quantity = 15
                    },
               };
            context.products.AddRange(products);
            context.SaveChanges();
            // CATEGORY IN PRODUCT TABLE
            var categoryInProducts = new CategoryInProduct[]
            {
                new CategoryInProduct { CategoryID = 1, ProductID = 1 },
                new CategoryInProduct { CategoryID = 2, ProductID = 2 },
                new CategoryInProduct { CategoryID = 3, ProductID = 3 },
            };
            context.categoryInProducts.AddRange(categoryInProducts);
            context.SaveChanges();
            // ORDER TABLE
            var orders = new Order[]
            {
                new Order
                {
                    Code = "ORD123",
                    Address = "123 Main St, City",
                    Phone = "123-456-7890",
                    TotalMoney = 150.25m,
                    Status = "Pending"
                },
                new Order
                {
                    Code = "ORD456",
                    Address = "456 Elm St, Town",
                    Phone = "987-654-3210",
                    TotalMoney = 75.50m,
                    Status = "Shipped"
                },
            };
            context.orders.AddRange(orders);
            context.SaveChanges();
            // ORDER DETAIL TABLE
            var orderDetails = new OrderDetail[]
            {
                new OrderDetail { ProductID = 1, OrderID = 1, Price = 50.99m, Quantity = 2 },
                new OrderDetail { ProductID = 2, OrderID = 1, Price = 30.50m, Quantity = 1 },
                new OrderDetail { ProductID = 3, OrderID = 2, Price = 25.75m, Quantity = 3 },
            };
            context.ordersDetail.AddRange(orderDetails);
            context.SaveChanges();
            // NEWS CATEGORY TABLE
            var newsCategories = new NewsCategory[]
            {
                new NewsCategory { Name = "Gardening Tips" },
                new NewsCategory { Name = "Plant Care" },
                new NewsCategory { Name = "New Arrivals" },
            };
            context.newsCategories.AddRange(newsCategories);
            context.SaveChanges();
            // NEWS TABLE
            var news = new News[]
            {
                new News
                {
                    Name = "Top 10 Gardening Hacks",
                    Description = "Learn the best tips and tricks for successful gardening.",
                    Image = "gardening_hacks.jpg"
                },
                new News
                {
                    Name = "Caring for Your Bonsai",
                    Description = "Discover the secrets to keeping your bonsai tree healthy and thriving.",
                    Image = "bonsai_care.jpg"
                },
            };
            context.news.AddRange(news);
            context.SaveChanges();
            // NEWS IN CATEGORY
            var newsInCategories = new NewsInCategory[]
            {
                new NewsInCategory { NewsCategoryID = 1, NewsID = 1 },
                new NewsInCategory { NewsCategoryID = 2, NewsID = 2 },
                new NewsInCategory { NewsCategoryID = 3, NewsID = 1 },
            };
            context.newsInCategories.AddRange(newsInCategories);
            context.SaveChanges();
        }



    }
}
