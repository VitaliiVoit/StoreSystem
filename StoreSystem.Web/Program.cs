using Microsoft.EntityFrameworkCore;
using StoreSystem.Dal.Extensions;
using StoreSystem.Dal.Repositories.Interfaces;
using StoreSystem.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddStoreSystemDbContext(connectionString);
builder.Services.AddRepositories();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseDefaultFiles();
app.UseStaticFiles();

// MENU
app.Map("/home", () => Results.Redirect("/"));
app.Map("/products", async context => 
    await context.Response.WriteAsync(File.ReadAllText("wwwroot/products.html")));

app.MapGet("/api/products", async (IProductRepository productRepository) 
   => await productRepository.GetAll());

// Add new Product to database
app.MapPost("/api/products/addproduct", 
    async (HttpContext context, IProductRepository productRepository) =>
{
    Product? product;
	try
	{
		product = await context.Request.ReadFromJsonAsync<Product>();
		if (product is null) return Results.BadRequest(new { Message = "Product is null" });
	}
	catch (Exception ex)
	{
		return Results.BadRequest(ex.Message);
	}

	productRepository.Add(product);

	return Results.Json(product);
});

app.Run();
