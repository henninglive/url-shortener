using Microsoft.EntityFrameworkCore;
using UrlShortener.Web.Database;
using UrlShortener.Web.Services;

namespace UrlShortener.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        
        // Add Controllers
        builder.Services.AddControllers();
        
        // Add database context
        builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        );

        // Add services
        builder.Services.AddScoped<IUrlService, UrlService>();

        var app = builder.Build();
        
        // Create and migrate database
        using (var serviceScope = app.Services.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
            context.Database.Migrate();
        }

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        //app.UseAuthorization();

        app.MapRazorPages();
        
        app.MapControllers();

        app.Run();
    }
}