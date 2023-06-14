using Microsoft.EntityFrameworkCore;
using StoreSystem.Dal.Extensions;
using StoreSystem.Dal.Repositories.Interfaces;
using StoreSystem.Domain.Entities;
using StoreSystem.Domain.Models;

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
app.Map("/home", () => Results.Redirect("/"));
app.Map("/products", async context => 
    await context.Response.WriteAsync(File.ReadAllText("wwwroot/products.html")));
app.Map("/order", async context =>
	await context.Response.WriteAsync(File.ReadAllText("wwwroot/order.html")));


app.MapGet("/api/products", async (IProductRepository productRepository) 
   => await productRepository.GetAll());

// Add new Product to database
app.MapPost("/api/products/add", 
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

app.MapDelete("/api/products/remove/{id:int}",
	async (int id, IProductRepository productRepository) =>
	{
		Product? product = await productRepository.GetById(id);
		if (product is null) return Results.BadRequest(new { Message = "Not Found" });

		productRepository.Delete(product);

		return Results.Json(product);
	});

app.MapGet("/api/cart", (Cart cart) => cart);
app.MapGet("/api/cart/totalAmount", (Cart cart) => cart.TotalAmount);

app.MapPost("/api/cart/add/{id:int}-{count:int}", 
	async (int id, int count, Cart cart, IProductRepository productRepository) =>
	{
		Product? product = await productRepository.GetById(id);
		if (product is null) return Results.BadRequest(new { Message = "Not Found" });

		cart.Add(product, count);

		return Results.Json(product);
	});

app.MapPut("/api/cart/updateCount/{id:int}-{count:int}",
	(int id, int count, Cart cart) =>
	{
        Product? product = cart.FirstOrDefault(p => p.Key.Id == id).Key;
        if (product is null) return Results.BadRequest(new { Message = "Not Found" });

		cart.UpdateCount(product, count);

		return Results.Json(product);
    });

app.MapDelete("/api/cart/remove/{id:int}", (int id, Cart cart) =>
{
	Product? product = cart.FirstOrDefault(p => p.Key.Id == id).Key;
	if (product is null) return Results.BadRequest(new { Message = "Not Found" });

	cart.Remove(product);

	return Results.Json(product);
});

app.Run();
