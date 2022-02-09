using Microsoft.EntityFrameworkCore;
using WebApplication1.Infrastructure;
using WebApplication1.Models;
using DatawindDataAccess;
using DatawindDataAccess.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/account/login";
        options.AccessDeniedPath = "/home/accessdenied";
        options.ExpireTimeSpan = TimeSpan.FromSeconds(10);
    });


//Add the services to the DI Container
/*builder.Services.AddSingleton<IRepository<Product, int>, ProductListRepository>();*/
builder.Services.AddSingleton<IRepository<Product, int>, ProductDBRepository>();
builder.Services.AddSingleton<iCategoryRepository<
    DatawindDataAccess.Models.Category, int>, 
    DatawindDataAccess.Infrastructure.CategoryDBRepository>();

builder.Services.AddDbContext<NorthWindContext>(contextOptions =>
{
    contextOptions.UseSqlServer(
        @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hemang\Documents\northwind.mdf;Integrated Security=True;Connect Timeout=30");
});
builder.Services.AddDbContext<AuthenticationContext>(contextOptions =>
{
    contextOptions.UseSqlServer(
        @"Data Source=(LocalDB)\MSSQLLocalDB;Database=BFLUsers;Integrated Security=True;Connect Timeout=30");
});

//Add the appsettings data sections to the application, so that the lists can be injected where required.
builder.Services.Configure<List<User>>(builder.Configuration.GetSection("Users"));
builder.Services.Configure<List<Role>>(builder.Configuration.GetSection("Roles"));
builder.Services.Configure<List<UserRoles>>(builder.Configuration.GetSection("UserRoles"));
builder.Services.AddScoped<IUserServices, UserServices>();
/*
    AssScoped -> Creates one object and injects it into the dependencies throughout this request.
    AddTransient -> creates new object for each dependency and injects it
    AddSingleton -> creates one object across all requests and dependencies and inject
 */


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddWebOptimizer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseWebOptimizer();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
