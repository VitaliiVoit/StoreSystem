using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace StoreSystem.Web.Extensions;

public static class AuthorizationApiExtension
{
    public static void RegisterAuthorizationAPIs(this WebApplication app)
    {
        app.Map("/signup", async context
            => await context.Response.WriteAsync(File.ReadAllText("wwwroot/signup.html")));

        app.MapGet("/login", async context
            => await context.Response.WriteAsync(File.ReadAllText("wwwroot/login.html")));

        app.MapPost("/signup", async (HttpContext context, ISellerRepository sellerRepository) =>
        {
            var form = context.Request.Form;
            if (string.IsNullOrWhiteSpace(form["firstname"]) ||
                string.IsNullOrWhiteSpace(form["lastname"]) ||
                string.IsNullOrWhiteSpace(form["password"]) ||
                string.IsNullOrWhiteSpace(form["phone"]))
            {
                return Results.BadRequest(new { Message = "Error" });
            }

            var seller = await sellerRepository.GetByFullNameAndPhone($"{form["firstname"]} {form["lastname"]}", form["phone"]!);
            if (seller is not null) return Results.Problem("This seller already exists");

            seller = new Seller(form["firstname"]!, form["lastname"]!, form["phone"]!, form["password"]!);
            sellerRepository.Add(seller);

            return Results.Redirect("/login");
        });


        app.MapPost("/login", async (HttpContext context, ISellerRepository sellerRepository) =>
        {
            var form = context.Request.Form;
            if (string.IsNullOrWhiteSpace(form["password"]) ||
                string.IsNullOrWhiteSpace(form["phone"]))
            {
                return Results.BadRequest(new { Message = "Error" });
            }

            var seller = await sellerRepository.GetByPhoneAndPassword(form["phone"]!, form["password"]!);
            if (seller is null) return Results.Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.MobilePhone, seller.Phone),
                new Claim(ClaimTypes.Name, seller.FullName!),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return Results.Redirect("/");
        });

        app.MapGet("/logout", async (HttpContext context) =>
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Results.Redirect("/login");
        });
    }
}
