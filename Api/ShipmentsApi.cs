using Microsoft.Extensions.Logging;
using ShipHero.SDK.Http;
using ShipHero.SDK.Interfaces;
using ShipHero.SDK.Models;

namespace ShipHero.SDK.Api;

/// <summary>
/// Shipments API implementation
/// </summary>
public class ShipmentsApi : IShipmentsApi
{
    private readonly ShipHeroHttpClient _httpClient;
    private readonly ILogger<ShipmentsApi> _logger;

    public ShipmentsApi(ShipHeroHttpClient httpClient, ILogger<ShipmentsApi> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    /// <summary>
    /// Get all shipments
    /// </summary>
    public async Task<List<Shipment>> GetAllAsync()
    {
        _logger.LogInformation("Getting all shipments");
        return await _httpClient.GetAsync<List<Shipment>>("/shipments") ?? new List<Shipment>();
    }

    /// <summary>
    /// Get shipment by ID
    /// </summary>
    public async Task<Shipment?> GetByIdAsync(string id)
    {
        _logger.LogInformation("Getting shipment by ID: {Id}", id);
        return await _httpClient.GetAsync<Shipment>($"/shipments/{id}");
    }

    /// <summary>
    /// Get shipment by shipment number
    /// </summary>
    public async Task<Shipment?> GetByShipmentNumberAsync(string shipmentNumber)
    {
        _logger.LogInformation("Getting shipment by shipment number: {ShipmentNumber}", shipmentNumber);
        return await _httpClient.GetAsync<Shipment>($"/shipments/number/{shipmentNumber}");
    }

    /// <summary>
    /// Create a new shipment
    /// </summary>
    public async Task<Shipment> CreateAsync(CreateShipmentRequest request)
    {
        _logger.LogInformation("Creating new shipment for order ID: {OrderId}", request.OrderId);
        var result = await _httpClient.PostAsync<Shipment>("/shipments", request);
        return result ?? throw new InvalidOperationException("Failed to create shipment");
    }

    /// <summary>
    /// Update an existing shipment
    /// </summary>
    public async Task<Shipment> UpdateAsync(string id, UpdateShipmentRequest request)
    {
        _logger.LogInformation("Updating shipment with ID: {Id}", id);
        var result = await _httpClient.PutAsync<Shipment>($"/shipments/{id}", request);
        return result ?? throw new InvalidOperationException("Failed to update shipment");
    }

    /// <summary>
    /// Track a shipment
    /// </summary>
    public async Task<TrackingInfo?> TrackAsync(string trackingNumber, string? carrier = null)
    {
        _logger.LogInformation("Tracking shipment with tracking number: {TrackingNumber}", trackingNumber);
        var endpoint = carrier != null 
            ? $"/shipments/track/{trackingNumber}?carrier={carrier}"
            : $"/shipments/track/{trackingNumber}";
        return await _httpClient.GetAsync<TrackingInfo>(endpoint);
    }
} 