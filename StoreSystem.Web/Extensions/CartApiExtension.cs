using Microsoft.AspNetCore.Authorization;

namespace StoreSystem.Web.Extensions;

public static class CartApiExtension
{
    public static void RegisterCartAPIs(this WebApplication app)
    {
        app.MapGet("/api/cart", (Cart cart) => cart);
        app.MapGet("/api/cart/totalAmount", (Cart cart) => cart.TotalAmount);

        app.MapPost("/api/cart/add/{id:int}-{count:int}", [Authorize]
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

        app.MapDelete("/api/cart/clear", (Cart cart) => cart.Clear());
    }
}
