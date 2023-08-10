using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PlantNestApp.Data;
using PlantNestApp.Models;
using PlantNestApp.Repository;
using System.Text;

namespace PlantNestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<CustomerUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
			builder.Services.AddRazorPages();
			builder.Services.AddControllersWithViews();
			builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
			builder.Services.AddScoped<IProduct, ProductRepository>();
			builder.Services.AddScoped<ICategoryProduct, ProductCategoryRepository>();
			builder.Services.AddScoped<ICategoryInProductRepository, CategoryInProductRepository>();
			builder.Services.AddScoped<INew, NewRepository>();
			builder.Services.AddScoped<INewCate, NewCategoryRepository>();
			builder.Services.AddScoped<INewInCate, NewInCategoryRepository>();
			builder.Services.AddScoped<IOder, OderRepository>();
			builder.Services.AddScoped<IOderDetail, OderDetailRepopsitory>();
			builder.Services.AddScoped<ISlide, SlideRepository>();
			builder.Services.AddScoped<IConfig, ConfigRepository>();
			builder.Services.AddScoped<IAccountRepository, AccountRepository>();

			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.SaveToken = true;
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidAudience = builder.Configuration["JWT:ValidAudience"],
					ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
				};
			});



			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "My TechWiz API", Version = "v1" });
			});
			var app = builder.Build();
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
			}); 
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();
                DataInitialize.SeedData(context);
            }

			app.Run();
        }
    }
}