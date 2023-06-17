namespace StoreSystem.Web.Extensions;

public static class CustomerApiExetension
{
    public static void RegisterCustomerAPIs(this WebApplication app)
    {
        app.MapGet("/api/customers", async (ICustomerRepository customerRepository)
            => await customerRepository.GetAll());

        app.MapPost("/api/customers/add",
            async (HttpContext context, ICustomerRepository customerRepository) =>
            {
                Customer? customer;
                try
                {
                    customer = await context.Request.ReadFromJsonAsync<Customer>();
                    if (customer is null) return Results.BadRequest(new { Message = "Customer is null" });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }

                customerRepository.Add(customer);

                return Results.Json(customer);
            });
    }
}
