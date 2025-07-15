using Microsoft.Extensions.Logging;
using ShipHero.SDK;
using ShipHero.SDK.Models;

namespace ShipHero.SDK.Examples;

/// <summary>
/// Console application demonstrating ShipHero SDK usage
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("ShipHero .NET SDK Example");
        Console.WriteLine("==========================");
        Console.WriteLine();

        // Check if credentials are provided
        var username = Environment.GetEnvironmentVariable("SHIPHERO_USERNAME");
        var password = Environment.GetEnvironmentVariable("SHIPHERO_PASSWORD");
        
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            Console.WriteLine("Please set the SHIPHERO_USERNAME and SHIPHERO_PASSWORD environment variables");
            Console.WriteLine("Example: set SHIPHERO_USERNAME=your-email@example.com");
            Console.WriteLine("Example: set SHIPHERO_PASSWORD=your-password");
            return;
        }

        try
        {
            // Configure the client
            var options = new ShipHeroOptions
            {
                Username = username,
                Password = password,
                BaseUrl = "https://public-api.shiphero.com",
                Timeout = TimeSpan.FromSeconds(30)
            };

            // Create logger
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<ShipHeroClient>();

            // Create client
            var client = new ShipHeroClient(options, logger);

            // Authenticate
            Console.WriteLine("Authenticating with ShipHero...");
            var authResponse = await client.AuthenticateAsync();
            Console.WriteLine($"Authentication successful! Token expires in {authResponse.ExpiresIn} seconds.");
            Console.WriteLine();

            // Demonstrate API usage
            await DemonstrateProductsApi(client);
            await DemonstrateOrdersApi(client);
            await DemonstrateInventoryApi(client);
            await DemonstrateWarehousesApi(client);
            await DemonstrateShipmentsApi(client);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            }
        }
    }

    static async Task DemonstrateProductsApi(IShipHeroClient client)
    {
        Console.WriteLine("Products API Demo");
        Console.WriteLine("-----------------");

        try
        {
            // Get all products
            var products = await client.Products.GetAllAsync();
            Console.WriteLine($"Found {products.Count} products");

            if (products.Any())
            {
                var firstProduct = products.First();
                Console.WriteLine($"First product: {firstProduct.Name} (SKU: {firstProduct.Sku})");

                // Get product by SKU
                var product = await client.Products.GetBySkuAsync(firstProduct.Sku!);
                if (product != null)
                {
                    Console.WriteLine($"Retrieved product: {product.Name} - Price: {product.Price}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Products API Error: {ex.Message}");
        }

        Console.WriteLine();
    }

    static async Task DemonstrateOrdersApi(IShipHeroClient client)
    {
        Console.WriteLine("Orders API Demo");
        Console.WriteLine("---------------");

        try
        {
            // Get all orders
            var orders = await client.Orders.GetAllAsync();
            Console.WriteLine($"Found {orders.Count} orders");

            if (orders.Any())
            {
                var firstOrder = orders.First();
                Console.WriteLine($"First order: {firstOrder.OrderNumber} - Status: {firstOrder.Status}");

                // Get order by order number
                var order = await client.Orders.GetByOrderNumberAsync(firstOrder.OrderNumber!);
                if (order != null)
                {
                    Console.WriteLine($"Retrieved order: {order.OrderNumber} - Total: {order.Total}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Orders API Error: {ex.Message}");
        }

        Console.WriteLine();
    }

    static async Task DemonstrateInventoryApi(IShipHeroClient client)
    {
        Console.WriteLine("Inventory API Demo");
        Console.WriteLine("------------------");

        try
        {
            // Get all inventory
            var inventory = await client.Inventory.GetAllAsync();
            Console.WriteLine($"Found {inventory.Count} inventory records");

            if (inventory.Any())
            {
                var firstInventory = inventory.First();
                Console.WriteLine($"First inventory: {firstInventory.Sku} - Available: {firstInventory.AvailableQuantity}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Inventory API Error: {ex.Message}");
        }

        Console.WriteLine();
    }

    static async Task DemonstrateWarehousesApi(IShipHeroClient client)
    {
        Console.WriteLine("Warehouses API Demo");
        Console.WriteLine("-------------------");

        try
        {
            // Get all warehouses
            var warehouses = await client.Warehouses.GetAllAsync();
            Console.WriteLine($"Found {warehouses.Count} warehouses");

            if (warehouses.Any())
            {
                var firstWarehouse = warehouses.First();
                Console.WriteLine($"First warehouse: {firstWarehouse.Name} - Active: {firstWarehouse.IsActive}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Warehouses API Error: {ex.Message}");
        }

        Console.WriteLine();
    }

    static async Task DemonstrateShipmentsApi(IShipHeroClient client)
    {
        Console.WriteLine("Shipments API Demo");
        Console.WriteLine("------------------");

        try
        {
            // Get all shipments
            var shipments = await client.Shipments.GetAllAsync();
            Console.WriteLine($"Found {shipments.Count} shipments");

            if (shipments.Any())
            {
                var firstShipment = shipments.First();
                Console.WriteLine($"First shipment: {firstShipment.ShipmentNumber} - Status: {firstShipment.Status}");

                if (!string.IsNullOrEmpty(firstShipment.TrackingNumber))
                {
                    // Track shipment
                    var trackingInfo = await client.Shipments.TrackAsync(firstShipment.TrackingNumber);
                    if (trackingInfo != null)
                    {
                        Console.WriteLine($"Tracking status: {trackingInfo.Status}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Shipments API Error: {ex.Message}");
        }

        Console.WriteLine();
    }
} 