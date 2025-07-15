using Microsoft.Extensions.Logging;
using ShipHero.SDK.Http;
using ShipHero.SDK.Interfaces;
using ShipHero.SDK.Models;

namespace ShipHero.SDK.Api;

/// <summary>
/// Warehouses API implementation
/// </summary>
public class WarehousesApi : IWarehousesApi
{
    private readonly ShipHeroHttpClient _httpClient;
    private readonly ILogger<WarehousesApi> _logger;

    public WarehousesApi(ShipHeroHttpClient httpClient, ILogger<WarehousesApi> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    /// <summary>
    /// Get all warehouses
    /// </summary>
    public async Task<List<Warehouse>> GetAllAsync()
    {
        _logger.LogInformation("Getting all warehouses");
        return await _httpClient.GetAsync<List<Warehouse>>("/warehouses") ?? new List<Warehouse>();
    }

    /// <summary>
    /// Get warehouse by ID
    /// </summary>
    public async Task<Warehouse?> GetByIdAsync(string id)
    {
        _logger.LogInformation("Getting warehouse by ID: {Id}", id);
        return await _httpClient.GetAsync<Warehouse>($"/warehouses/{id}");
    }

    /// <summary>
    /// Create a new warehouse
    /// </summary>
    public async Task<Warehouse> CreateAsync(CreateWarehouseRequest request)
    {
        _logger.LogInformation("Creating new warehouse with name: {Name}", request.Name);
        var result = await _httpClient.PostAsync<Warehouse>("/warehouses", request);
        return result ?? throw new InvalidOperationException("Failed to create warehouse");
    }

    /// <summary>
    /// Update an existing warehouse
    /// </summary>
    public async Task<Warehouse> UpdateAsync(string id, UpdateWarehouseRequest request)
    {
        _logger.LogInformation("Updating warehouse with ID: {Id}", id);
        var result = await _httpClient.PutAsync<Warehouse>($"/warehouses/{id}", request);
        return result ?? throw new InvalidOperationException("Failed to update warehouse");
    }

    /// <summary>
    /// Delete a warehouse
    /// </summary>
    public async Task DeleteAsync(string id)
    {
        _logger.LogInformation("Deleting warehouse with ID: {Id}", id);
        await _httpClient.DeleteAsync($"/warehouses/{id}");
    }
} 