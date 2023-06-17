using Microsoft.EntityFrameworkCore;
using StoreSystem.Dal.Extensions;
using StoreSystem.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddStoreSystemDbContext(connectionString);
builder.Services.AddRepositories();
builder.Services.AddSingleton<Cart>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseDefaultFiles();
app.UseStaticFiles();

// MENU
app.RegisterMenu();

app.RegisterProductsAPIs();
app.RegisterCartAPIs();
app.RegisterCustomerAPIs();

app.Run();
