using Microsoft.Extensions.Logging;
using ShipHero.SDK;
using ShipHero.SDK.Models;

namespace ShipHero.SDK.Examples;

/// <summary>
/// Basic usage examples for the ShipHero SDK
/// </summary>
public static class BasicUsage
{
    /// <summary>
    /// Example of basic client usage
    /// </summary>
    public static async Task BasicClientExample()
    {
        // Configure the client
        var options = new ShipHeroOptions
        {
            Username = "your-email@example.com",
            Password = "your-password",
            BaseUrl = "https://public-api.shiphero.com",
            Timeout = TimeSpan.FromSeconds(30)
        };
        
        // Create logger (in real applications, use dependency injection)
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<ShipHeroClient>();
        
        // Create client
        var client = new ShipHeroClient(options, logger);
        
        try
        {
            // Authenticate (optional - will be done automatically on first request)
            var authResponse = await client.AuthenticateAsync();
            Console.WriteLine($"Authenticated successfully! Token expires in {authResponse.ExpiresIn} seconds.");
            
            // Get all products
            var products = await client.Products.GetAllAsync();
            Console.WriteLine($"Found {products.Count} products");
            
            // Get a specific product
            var product = await client.Products.GetBySkuAsync("SKU-001");
            if (product != null)
            {
                Console.WriteLine($"Product: {product.Name} - Price: {product.Price}");
            }
            
            // Create a new product
            var newProduct = new CreateProductRequest
            {
                Sku = "SKU-002",
                Name = "Example Product",
                Description = "This is an example product",
                Price = 29.99m,
                Weight = 1.5m,
                Category = "Electronics"
            };
            
            var createdProduct = await client.Products.CreateAsync(newProduct);
            Console.WriteLine($"Created product with ID: {createdProduct.Id}");
            
            // Get all orders
            var orders = await client.Orders.GetAllAsync();
            Console.WriteLine($"Found {orders.Count} orders");
            
            // Create a new order
            var newOrder = new CreateOrderRequest
            {
                OrderNumber = "ORD-001",
                Customer = new Customer
                {
                    Email = "customer@example.com",
                    FirstName = "John",
                    LastName = "Doe"
                },
                Items = new List<OrderItem>
                {
                    new() { Sku = "SKU-001", Quantity = 2, UnitPrice = 29.99m }
                },
                ShippingAddress = new Address
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Address1 = "123 Main St",
                    City = "New York",
                    State = "NY",
                    PostalCode = "10001",
                    Country = "US"
                },
                Total = 59.98m,
                Currency = "USD"
            };
            
            var createdOrder = await client.Orders.CreateAsync(newOrder);
            Console.WriteLine($"Created order with ID: {createdOrder.Id}");
            
            // Get inventory for a product
            var inventory = await client.Inventory.GetBySkuAsync("SKU-001");
            if (inventory != null)
            {
                Console.WriteLine($"Inventory for SKU-001: {inventory.AvailableQuantity} available");
            }
            
            // Update inventory
            var updateRequest = new UpdateInventoryRequest
            {
                Sku = "SKU-001",
                QuantityChange = 10,
                Reason = "Stock replenishment"
            };
            
            var updatedInventory = await client.Inventory.UpdateAsync(updateRequest);
            Console.WriteLine($"Updated inventory: {updatedInventory.AvailableQuantity} available");
            
            // Get all warehouses
            var warehouses = await client.Warehouses.GetAllAsync();
            Console.WriteLine($"Found {warehouses.Count} warehouses");
            
            // Get all shipments
            var shipments = await client.Shipments.GetAllAsync();
            Console.WriteLine($"Found {shipments.Count} shipments");
            
            // Track a shipment
            var trackingInfo = await client.Shipments.TrackAsync("1Z999AA1234567890");
            if (trackingInfo != null)
            {
                Console.WriteLine($"Tracking status: {trackingInfo.Status}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    /// <summary>
    /// Example of dependency injection usage
    /// </summary>
    public static async Task DependencyInjectionExample()
    {
        // Configure services
        var services = new ServiceCollection();
        
        services.AddLogging(builder => builder.AddConsole());
        services.AddShipHero(options =>
        {
            options.Username = "your-email@example.com";
            options.Password = "your-password";
            options.BaseUrl = "https://public-api.shiphero.com";
            options.Timeout = TimeSpan.FromSeconds(30);
        });
        
        // Build service provider
        var serviceProvider = services.BuildServiceProvider();
        
        // Get client from DI
        var client = serviceProvider.GetRequiredService<IShipHeroClient>();
        
        try
        {
            // Authenticate
            var authResponse = await client.AuthenticateAsync();
            Console.WriteLine($"Authenticated successfully! Token expires in {authResponse.ExpiresIn} seconds.");
            
            // Use the client
            var products = await client.Products.GetAllAsync();
            Console.WriteLine($"Found {products.Count} products");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
} 