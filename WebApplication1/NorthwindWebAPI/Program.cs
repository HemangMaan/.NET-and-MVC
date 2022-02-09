using DatawindDataAccess.Infrastructure;
using DatawindDataAccess.Models;
using NorthwindWebAPI.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BFLUsersContext>(contextOptions =>
{
    contextOptions.UseSqlServer(
        @"Data Source=(LocalDB)\MSSQLLocalDB;Database=BFLUsers;Integrated Security=True;Connect Timeout=30"
        );
});
builder.Services.AddScoped<IUserServices, UserServices>();


builder.Services.AddSingleton<iCategoryRepository<Category,int>, CategoryDBRepository>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
//app.UseAuthorization();
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
