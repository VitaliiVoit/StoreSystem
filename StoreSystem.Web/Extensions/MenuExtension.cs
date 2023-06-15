namespace StoreSystem.Web.Extensions;

public static class MenuExtension
{
    public static void RegisterMenu(this WebApplication app)
    {
        app.Map("/home", () => Results.Redirect("/"));
        app.Map("/products", async context =>
            await context.Response.WriteAsync(File.ReadAllText("wwwroot/products.html")));
        app.Map("/order", async context =>
            await context.Response.WriteAsync(File.ReadAllText("wwwroot/order.html")));
    }
}
