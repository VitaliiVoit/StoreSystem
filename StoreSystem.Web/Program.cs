using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using StoreSystem.Dal.Extensions;
using StoreSystem.Web.Extensions;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => options.LoginPath = "/login");
builder.Services.AddAuthorization();

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

app.UseAuthentication();
app.UseAuthorization();

// MENU
app.RegisterMenu();

app.RegisterProductsAPIs();
app.RegisterCartAPIs();
app.RegisterCustomerAPIs();
app.RegisterAuthorizationAPIs();

app.Run();
