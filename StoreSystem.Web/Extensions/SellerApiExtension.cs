using System.Security.Claims;

namespace StoreSystem.Web.Extensions;

public static class SellerApiExtension
{
    public static void RegisterSellerAPIs(this WebApplication app)
    {
        app.MapGet("/api/seller/get", 
            async (HttpContext context, ISellerRepository sellerRepository) =>
            {
                var phone = context.User.Identity?.Name;
                if (phone is null) return Results.Problem();

                var seller = await sellerRepository.GetByPhone(phone); // TODO: Some check

                context.Session.Set("seller", seller!);
                return Results.Json(seller);
            });
    }
}
