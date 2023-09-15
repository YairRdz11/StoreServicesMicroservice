using Microsoft.EntityFrameworkCore;
using StoreService.Api.ShoppingCart.Persistant;
using StoreService.Api.ShoppingCart.RemoteInterfaces;
using StoreService.Api.ShoppingCart.RemoteServices;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<ShoppingCartContext>(option =>
{
    option.UseMySQL(builder.Configuration.GetConnectionString("DatabaseConnection"));
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddHttpClient("Books", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Books"]);
});
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

app.UseAuthorization();

app.MapControllers();

app.Run();
