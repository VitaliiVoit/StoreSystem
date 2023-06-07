using Microsoft.EntityFrameworkCore;
using StoreSystem.Dal.Extensions;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddStoreSystemDbContext(connectionString);

var app = builder.Build();

app.MapGet("/", () => "Hello World");

app.Run();
