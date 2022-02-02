using Microsoft.EntityFrameworkCore;
using WebApplication1.Infrastructure;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

//Add the services to the DI Container
/*builder.Services.AddSingleton<IRepository<Product, int>, ProductListRepository>();*/
builder.Services.AddSingleton<IRepository<Product, int>, ProductDBRepository>();
builder.Services.AddSingleton<IRepository<Category, int>, CategoryDBRepository>();
builder.Services.AddDbContext<NorthWindContext>(contextOptions =>
{
    contextOptions.UseSqlServer(
        @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hemang\Documents\northwind.mdf;Integrated Security=True;Connect Timeout=30");
});
/*
    AssScoped -> Creates one object and injects it into the dependencies throughout this request.
    AddTransient -> creates new object for each dependency and injects it
    AddSingleton -> creates one object across all requests and dependencies and inject
 */


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
