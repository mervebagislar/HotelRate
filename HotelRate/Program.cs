//using HotelRate2.Data.Concrete.EfCore;
using HotelRate2.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession();
builder.Services.AddControllersWithViews(
    options =>
    {
        options.ModelBinderProviders.Insert(0, new CustomFormCollectionModelBinderProvider());
    });

builder.Services.AddDbContext<HotelDbContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")


    ));
//{
//    //var config = builder.Configuration;
//    //var connectionString = config.GetConnectionString("mssql_connection");
//    //option.UseSqlServer(connectionString);
//});
var app = builder.Build();

app.UseSession();

app.UseStaticFiles(new StaticFileOptions()
{
    RequestPath = "/wwwroot"
});
app.MapControllerRoute("main", "{controller=Giris}/{action=Index}/{id?}");

app.Run();

