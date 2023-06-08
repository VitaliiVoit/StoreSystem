using Microsoft.EntityFrameworkCore;
using StoreSystem.Dal.Extensions;
using StoreSystem.Dal.Repositories;
using StoreSystem.Dal.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddStoreSystemDbContext(connectionString);

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderRecordRepository, OrderRecordRepository>();
builder.Services.AddScoped<ISellRepository, SellRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World");

app.Run();
