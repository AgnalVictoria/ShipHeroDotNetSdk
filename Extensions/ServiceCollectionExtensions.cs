using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShipHero.SDK.Http;
using ShipHero.SDK.Interfaces;
using ShipHero.SDK.Models;

namespace ShipHero.SDK.Extensions;

/// <summary>
/// Service collection extensions for ShipHero SDK
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add ShipHero SDK services to the service collection
    /// </summary>
    public static IServiceCollection AddShipHero(this IServiceCollection services, Action<ShipHeroOptions> configureOptions)
    {
        // Configure options
        var options = new ShipHeroOptions();
        configureOptions(options);
        
        // Validate required options
        if (string.IsNullOrEmpty(options.Username))
            throw new ArgumentException("Username is required", nameof(options));
        
        if (string.IsNullOrEmpty(options.Password))
            throw new ArgumentException("Password is required", nameof(options));
        
        if (string.IsNullOrEmpty(options.BaseUrl))
            throw new ArgumentException("Base URL is required", nameof(options));
        
        // Register options
        services.AddSingleton(options);
        
        // Register GraphQL client
        services.AddScoped<ShipHeroGraphQLClient>();
        
        // Register API implementations
        services.AddScoped<ProductsApi>();
        services.AddScoped<OrdersApi>();
        services.AddScoped<InventoryApi>();
        services.AddScoped<WarehousesApi>();
        services.AddScoped<ShipmentsApi>();
        
        // Register main client
        services.AddScoped<IShipHeroClient, ShipHeroClient>();
        
        return services;
    }
    
    /// <summary>
    /// Add ShipHero SDK services to the service collection with configuration from IConfiguration
    /// </summary>
    public static IServiceCollection AddShipHero(this IServiceCollection services, IConfiguration configuration, string sectionName = "ShipHero")
    {
        var options = new ShipHeroOptions();
        configuration.GetSection(sectionName).Bind(options);
        
        return services.AddShipHero(opt =>
        {
            opt.Username = options.Username;
            opt.Password = options.Password;
            opt.BaseUrl = options.BaseUrl;
            opt.Timeout = options.Timeout;
            opt.RetryPolicy = options.RetryPolicy;
            opt.AutoRefreshTokens = options.AutoRefreshTokens;
        });
    }
} 