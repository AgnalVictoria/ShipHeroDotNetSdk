using Microsoft.Extensions.Logging;
using Moq;
using ShipHero.SDK;
using ShipHero.SDK.Exceptions;
using ShipHero.SDK.Models;
using ShipHero.SDK.Interfaces;

namespace ShipHero.SDK.Tests;

/// <summary>
/// Unit tests for ShipHero client
/// </summary>
public class ShipHeroClientTests
{
    private readonly Mock<ILogger<ShipHeroClient>> _loggerMock;
    private readonly ShipHeroOptions _options;

    public ShipHeroClientTests()
    {
        _loggerMock = new Mock<ILogger<ShipHeroClient>>();
        _options = new ShipHeroOptions
        {
            Username = "test@example.com",
            Password = "test-password",
            BaseUrl = "https://public-api.shiphero.com",
            Timeout = TimeSpan.FromSeconds(30)
        };
    }

    [Fact]
    public void Constructor_WithValidOptions_ShouldCreateClient()
    {
        // Act
        var client = new ShipHeroClient(_options, _loggerMock.Object);

        // Assert
        Assert.NotNull(client);
        Assert.NotNull(client.Products);
        Assert.NotNull(client.Orders);
        Assert.NotNull(client.Inventory);
        Assert.NotNull(client.Warehouses);
        Assert.NotNull(client.Shipments);
    }

    [Fact]
    public void Constructor_WithNullOptions_ShouldThrowArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new ShipHeroClient(null!, _loggerMock.Object));
    }

    [Fact]
    public void Constructor_WithNullLogger_ShouldThrowArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new ShipHeroClient(_options, null!));
    }

    [Fact]
    public void Constructor_WithEmptyUsername_ShouldThrowArgumentException()
    {
        // Arrange
        var options = new ShipHeroOptions
        {
            Username = "",
            Password = "test-password",
            BaseUrl = "https://public-api.shiphero.com"
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new ShipHeroClient(options, _loggerMock.Object));
    }

    [Fact]
    public void Constructor_WithEmptyPassword_ShouldThrowArgumentException()
    {
        // Arrange
        var options = new ShipHeroOptions
        {
            Username = "test@example.com",
            Password = "",
            BaseUrl = "https://public-api.shiphero.com"
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new ShipHeroClient(options, _loggerMock.Object));
    }

    [Fact]
    public void Constructor_WithEmptyBaseUrl_ShouldThrowArgumentException()
    {
        // Arrange
        var options = new ShipHeroOptions
        {
            Username = "test@example.com",
            Password = "test-password",
            BaseUrl = ""
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new ShipHeroClient(options, _loggerMock.Object));
    }
}

/// <summary>
/// Unit tests for ShipHero options
/// </summary>
public class ShipHeroOptionsTests
{
    [Fact]
    public void DefaultOptions_ShouldHaveCorrectDefaults()
    {
        // Act
        var options = new ShipHeroOptions
        {
            Username = "test@example.com",
            Password = "test-password"
        };

        // Assert
        Assert.Equal("https://public-api.shiphero.com", options.BaseUrl);
        Assert.Equal(TimeSpan.FromSeconds(30), options.Timeout);
        Assert.True(options.AutoRefreshTokens);
        Assert.Null(options.RetryPolicy);
    }

    [Fact]
    public void RetryPolicy_ShouldHaveCorrectDefaults()
    {
        // Act
        var retryPolicy = new RetryPolicy();

        // Assert
        Assert.Equal(3, retryPolicy.MaxRetries);
        Assert.Equal(TimeSpan.FromSeconds(1), retryPolicy.RetryDelay);
        Assert.True(retryPolicy.UseExponentialBackoff);
    }
}

/// <summary>
/// Unit tests for model validation
/// </summary>
public class ModelValidationTests
{
    [Fact]
    public void CreateProductRequest_WithRequiredFields_ShouldBeValid()
    {
        // Arrange
        var request = new CreateProductRequest
        {
            Sku = "TEST-SKU",
            Name = "Test Product"
        };

        // Act & Assert
        Assert.Equal("TEST-SKU", request.Sku);
        Assert.Equal("Test Product", request.Name);
    }

    [Fact]
    public void CreateOrderRequest_WithRequiredFields_ShouldBeValid()
    {
        // Arrange
        var request = new CreateOrderRequest
        {
            OrderNumber = "ORD-001",
            Items = new List<OrderItem>
            {
                new() { Sku = "SKU-001", Quantity = 1 }
            }
        };

        // Act & Assert
        Assert.Equal("ORD-001", request.OrderNumber);
        Assert.Single(request.Items);
        Assert.Equal("SKU-001", request.Items[0].Sku);
        Assert.Equal(1, request.Items[0].Quantity);
    }

    [Fact]
    public void UpdateInventoryRequest_WithRequiredFields_ShouldBeValid()
    {
        // Arrange
        var request = new UpdateInventoryRequest
        {
            Sku = "SKU-001",
            QuantityChange = 10,
            Reason = "Stock replenishment"
        };

        // Act & Assert
        Assert.Equal("SKU-001", request.Sku);
        Assert.Equal(10, request.QuantityChange);
        Assert.Equal("Stock replenishment", request.Reason);
    }
} 