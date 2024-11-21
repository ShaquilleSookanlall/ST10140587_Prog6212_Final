using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ST10140587_Prog6212_Part2.Data;

namespace ST10140587_Prog6212_Part2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Configure Identity with role management
            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 6;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddControllersWithViews();

            // Configure logging to the console
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // For detailed error pages
                app.UseMigrationsEndPoint(); // For applying migrations easily
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); // Custom error handling in production
                app.UseHsts(); // Enforce HTTPS in production
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // Serve static files (e.g., uploads)

            app.UseRouting();

            // Add Authentication and Authorization middleware
            app.UseAuthentication();
            app.UseAuthorization();

            // Set Pending Claims as the default starting page
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Claims}/{action=TrackClaims}/{id?}");
            app.MapRazorPages(); // Map Identity UI Razor pages

            // Ensure the database is migrated and roles are seeded on startup
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate(); // Apply any pending migrations
                SeedRoles(services).Wait(); // Seed roles
            }

            app.Run();
        }

        private static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "Lecturer", "Manager", "Co-ordinator", "HR" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
