using Microsoft.Extensions.Logging;
using ShipHero.SDK.Http;
using ShipHero.SDK.Interfaces;
using ShipHero.SDK.Models;

namespace ShipHero.SDK.Api;

/// <summary>
/// Inventory API implementation
/// </summary>
public class InventoryApi : IInventoryApi
{
    private readonly ShipHeroHttpClient _httpClient;
    private readonly ILogger<InventoryApi> _logger;

    public InventoryApi(ShipHeroHttpClient httpClient, ILogger<InventoryApi> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    /// <summary>
    /// Get inventory levels for all products
    /// </summary>
    public async Task<List<Inventory>> GetAllAsync()
    {
        _logger.LogInformation("Getting all inventory levels");
        return await _httpClient.GetAsync<List<Inventory>>("/inventory") ?? new List<Inventory>();
    }

    /// <summary>
    /// Get inventory for a specific product
    /// </summary>
    public async Task<Inventory?> GetBySkuAsync(string sku)
    {
        _logger.LogInformation("Getting inventory for SKU: {Sku}", sku);
        return await _httpClient.GetAsync<Inventory>($"/inventory/{sku}");
    }

    /// <summary>
    /// Update inventory for a product
    /// </summary>
    public async Task<Inventory> UpdateAsync(UpdateInventoryRequest request)
    {
        _logger.LogInformation("Updating inventory for SKU: {Sku}", request.Sku);
        var result = await _httpClient.PostAsync<Inventory>("/inventory/update", request);
        return result ?? throw new InvalidOperationException("Failed to update inventory");
    }

    /// <summary>
    /// Get inventory history for a product
    /// </summary>
    public async Task<List<InventoryHistory>> GetHistoryAsync(string sku)
    {
        _logger.LogInformation("Getting inventory history for SKU: {Sku}", sku);
        return await _httpClient.GetAsync<List<InventoryHistory>>($"/inventory/{sku}/history") ?? new List<InventoryHistory>();
    }
} 