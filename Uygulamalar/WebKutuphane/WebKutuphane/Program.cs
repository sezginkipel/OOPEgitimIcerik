using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebKutuphane.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebKutuphaneContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebKutuphaneContext") ?? throw new InvalidOperationException("Connection string 'WebKutuphaneContext' not found.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
