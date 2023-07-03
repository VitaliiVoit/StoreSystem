using StoreSystem.Domain.Models;
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
        app.MapPost("/api/seller/sell",
            async (HttpContext context, 
                    Cart cart, 
                    IOrderRepository orderRepository, 
                    IOrderRecordRepository orderRecordRepository,
                    ISellRepository sellRepository) =>
            {
                if (!cart.Any()) return Results.BadRequest(new { Message = "Cart is empty" });

                var seller = context.Session.Get<Seller>("seller");
                if (seller is null) return Results.BadRequest(new { Message = "Seller is null" });

                Customer? customer = context.Session.Get<Customer>("customer");
                if (customer is null) return Results.BadRequest(new { Message = "Customer is null" });

                var order = CreateOrder(customer, orderRepository);

                AddOrderRecords(order, cart, orderRecordRepository);

                PlaceSell(order, seller, cart.TotalAmount, sellRepository);

                return Results.Ok();
            });
    }

    private static Order CreateOrder(Customer customer, IOrderRepository orderRepository)
    {
        Order order = new() { CustomerId = customer.Id };
        orderRepository.Add(order);
        return order;
    }

    private static void AddOrderRecords(Order order, Cart cart, IOrderRecordRepository orderRecordRepository)
    {
        foreach (var pair in cart)
        {
            var orderRecord = new OrderRecord
            {
                OrderId = order.Id,
                ProductId = pair.Key.Id,
                ProductCount = pair.Value,
            };
            orderRecordRepository.Add(orderRecord);
        }
    }

    private static void PlaceSell(Order order, Seller seller, decimal totalAmount, ISellRepository sellRepository)
    {
        var sell = new Sell()
        {
            OrderId = order.Id,
            SellerId = seller.Id,
            TotalAmount = totalAmount
        };
        sellRepository.Add(sell);
    }
}
