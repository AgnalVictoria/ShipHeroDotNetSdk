using Microsoft.Extensions.Logging;
using ShipHero.SDK.Api;
using ShipHero.SDK.Interfaces;
using ShipHero.SDK.Models;

namespace ShipHero.SDK;

/// <summary>
/// Main ShipHero client implementation using GraphQL
/// </summary>
public class ShipHeroClient : IShipHeroClient, IDisposable
{
    /// <summary>
    /// Products API
    /// </summary>
    public IProductsApi Products { get; }
    
    /// <summary>
    /// Orders API
    /// </summary>
    public IOrdersApi Orders { get; }
    
    /// <summary>
    /// Inventory API
    /// </summary>
    public IInventoryApi Inventory { get; }
    
    /// <summary>
    /// Warehouses API
    /// </summary>
    public IWarehousesApi Warehouses { get; }
    
    /// <summary>
    /// Shipments API
    /// </summary>
    public IShipmentsApi Shipments { get; }

    private readonly ShipHeroGraphQLClient _graphQLClient;

    /// <summary>
    /// Initialize a new instance of the ShipHero client
    /// </summary>
    public ShipHeroClient(ShipHeroOptions options, ILogger<ShipHeroClient> logger)
    {
        if (options == null)
            throw new ArgumentNullException(nameof(options));
        
        if (logger == null)
            throw new ArgumentNullException(nameof(logger));
        
        if (string.IsNullOrEmpty(options.Username))
            throw new ArgumentException("Username is required", nameof(options));
        
        if (string.IsNullOrEmpty(options.Password))
            throw new ArgumentException("Password is required", nameof(options));

        // Create GraphQL client
        _graphQLClient = new Http.ShipHeroGraphQLClient(options, logger);
        
        // Initialize API clients
        Products = new ProductsApi(_graphQLClient, logger);
        Orders = new OrdersApi(_graphQLClient, logger);
        Inventory = new InventoryApi(_graphQLClient, logger);
        Warehouses = new WarehousesApi(_graphQLClient, logger);
        Shipments = new ShipmentsApi(_graphQLClient, logger);
    }

    /// <summary>
    /// Authenticate with ShipHero
    /// </summary>
    public async Task<AuthResponse> AuthenticateAsync()
    {
        return await _graphQLClient.AuthenticateAsync();
    }

    /// <summary>
    /// Refresh the access token
    /// </summary>
    public async Task<AuthResponse> RefreshTokenAsync()
    {
        return await _graphQLClient.RefreshTokenAsync();
    }

    public void Dispose()
    {
        _graphQLClient?.Dispose();
    }
} 