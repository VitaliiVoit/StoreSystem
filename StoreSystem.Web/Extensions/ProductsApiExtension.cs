namespace StoreSystem.Web.Extensions;

public static class ProductsApiExtension
{
    public static void RegisterProductsAPIs(this WebApplication app)
    {
        app.MapGet("/api/products", async (IProductRepository productRepository)
            => await productRepository.GetAll());

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
    }
}
