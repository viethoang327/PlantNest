using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlantNestApp.Models;

namespace PlantNestApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<CategoryInProduct> categoryInProducts { get; set; }
        public DbSet <Order> orders { get; set; }
        public DbSet <OrderDetail> ordersDetail { get; set; }
        public DbSet <News> news { get; set; }
        public DbSet <NewsCategory> newsCategories { get; set; }
        public DbSet <NewsInCategory> newsInCategories { get; set; }
        public DbSet <CategoryType> categoriesType { get; set; }
        public DbSet <Cart> carts { get; set; }
        public DbSet <ConFig> conFigs { get; set; }
        public DbSet <Slide> slides { get; set; }

    }
}