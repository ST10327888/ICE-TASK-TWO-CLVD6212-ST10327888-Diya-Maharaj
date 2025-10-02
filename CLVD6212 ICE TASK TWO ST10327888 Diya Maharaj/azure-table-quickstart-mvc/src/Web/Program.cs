using Microsoft.Extensions.Azure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Azure.Data.Tables;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Register TableService wrapper
builder.Services.AddSingleton<TableService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
