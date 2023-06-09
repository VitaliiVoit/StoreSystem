using Microsoft.EntityFrameworkCore;
using StoreSystem.Dal.Extensions;

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

//app.MapGet("/", () => "Hello World");

app.Run();
