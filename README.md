# ShipHero .NET SDK

A comprehensive .NET SDK for integrating with the ShipHero GraphQL API. This SDK provides easy-to-use methods for interacting with ShipHero's e-commerce and fulfillment platform using GraphQL.

## Features

- **Complete GraphQL API Coverage**: All major ShipHero GraphQL endpoints
- **Strongly Typed Models**: Full C# models for all API responses
- **Async/Await Support**: Modern async programming patterns
- **Dependency Injection**: Built-in DI support
- **Logging Integration**: Comprehensive logging support
- **Error Handling**: Robust error handling with custom exceptions
- **Automatic Authentication**: JWT token management with automatic refresh

## Installation

```bash
dotnet add package ShipHero.SDK
```

## Quick Start

### Basic Usage

```csharp
using ShipHero.SDK;

// Configure the client
var client = new ShipHeroClient(new ShipHeroOptions
{
    Username = "your-email@example.com",
    Password = "your-password",
    BaseUrl = "https://public-api.shiphero.com"
});

// Authenticate (optional - will be done automatically on first request)
await client.AuthenticateAsync();

// Get products
var products = await client.Products.GetAllAsync();

// Create an order
var order = new CreateOrderRequest
{
    OrderNumber = "ORD-001",
    CustomerEmail = "customer@example.com",
    Items = new List<OrderItem>
    {
        new() { Sku = "SKU-001", Quantity = 2 }
    }
};

var createdOrder = await client.Orders.CreateAsync(order);
```

### Dependency Injection

```csharp
// In Program.cs or Startup.cs
services.AddShipHero(options =>
{
    options.Username = Configuration["ShipHero:Username"];
    options.Password = Configuration["ShipHero:Password"];
    options.BaseUrl = Configuration["ShipHero:BaseUrl"];
});

// In your service
public class OrderService
{
    private readonly IShipHeroClient _shipHeroClient;
    
    public OrderService(IShipHeroClient shipHeroClient)
    {
        _shipHeroClient = shipHeroClient;
    }
    
    public async Task<Order> CreateOrderAsync(CreateOrderRequest request)
    {
        return await _shipHeroClient.Orders.CreateAsync(request);
    }
}
```

## Authentication

The SDK uses JWT authentication with automatic token refresh. You provide your ShipHero username and password, and the SDK handles:

- Initial authentication to get access and refresh tokens
- Automatic token refresh when tokens expire
- Bearer token authentication for all GraphQL requests

## API Coverage

### Products
- Get all products
- Get product by ID
- Get product by SKU
- Create product
- Update product
- Delete product

### Orders
- Get all orders
- Get order by ID
- Get order by order number
- Create order
- Update order
- Cancel order

### Inventory
- Get inventory levels
- Update inventory
- Get inventory history

### Warehouses
- Get all warehouses
- Get warehouse by ID
- Create warehouse
- Update warehouse

### Shipments
- Get all shipments
- Get shipment by ID
- Get shipment by shipment number
- Create shipment
- Update shipment
- Track shipment

## Configuration

The SDK supports configuration through `ShipHeroOptions`:

```csharp
var options = new ShipHeroOptions
{
    Username = "your-email@example.com",
    Password = "your-password",
    BaseUrl = "https://public-api.shiphero.com",
    Timeout = TimeSpan.FromSeconds(30),
    AutoRefreshTokens = true,
    RetryPolicy = new RetryPolicy
    {
        MaxRetries = 3,
        RetryDelay = TimeSpan.FromSeconds(1)
    }
};
```

## Error Handling

The SDK provides custom exceptions for different error scenarios:

```csharp
try
{
    var product = await client.Products.GetByIdAsync("product-id");
}
catch (ShipHeroApiException ex)
{
    // Handle API-specific errors
    Console.WriteLine($"API Error: {ex.Message}");
}
catch (ShipHeroAuthenticationException ex)
{
    // Handle authentication errors
    Console.WriteLine($"Auth Error: {ex.Message}");
}
```

## Logging

The SDK integrates with Microsoft.Extensions.Logging:

```csharp
services.AddShipHero(options =>
{
    options.Username = "your-email@example.com";
    options.Password = "your-password";
    options.BaseUrl = "https://public-api.shiphero.com";
})
.AddLogging(builder =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Debug);
});
```

## GraphQL Queries

The SDK uses GraphQL queries and mutations under the hood. Here's an example of the GraphQL queries being executed:

```graphql
query GetProducts {
  products {
    id
    sku
    name
    description
    price
    weight
    dimensions {
      length
      width
      height
    }
    category
    brand
    images
    tags
    isActive
    createdAt
    updatedAt
  }
}
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests
5. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Support

For support, please refer to the [ShipHero API Documentation](https://developer.shiphero.com/getting-started) or create an issue in this repository. 