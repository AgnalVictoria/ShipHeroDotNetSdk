using Microsoft.Extensions.Logging;
using ShipHero.SDK.Http;
using ShipHero.SDK.Interfaces;
using ShipHero.SDK.Models;

namespace ShipHero.SDK.Api;

/// <summary>
/// Orders API implementation
/// </summary>
public class OrdersApi : IOrdersApi
{
    private readonly ShipHeroHttpClient _httpClient;
    private readonly ILogger<OrdersApi> _logger;

    public OrdersApi(ShipHeroHttpClient httpClient, ILogger<OrdersApi> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    /// <summary>
    /// Get all orders
    /// </summary>
    public async Task<List<Order>> GetAllAsync()
    {
        _logger.LogInformation("Getting all orders");
        return await _httpClient.GetAsync<List<Order>>("/orders") ?? new List<Order>();
    }

    /// <summary>
    /// Get order by ID
    /// </summary>
    public async Task<Order?> GetByIdAsync(string id)
    {
        _logger.LogInformation("Getting order by ID: {Id}", id);
        return await _httpClient.GetAsync<Order>($"/orders/{id}");
    }

    /// <summary>
    /// Get order by order number
    /// </summary>
    public async Task<Order?> GetByOrderNumberAsync(string orderNumber)
    {
        _logger.LogInformation("Getting order by order number: {OrderNumber}", orderNumber);
        return await _httpClient.GetAsync<Order>($"/orders/number/{orderNumber}");
    }

    /// <summary>
    /// Create a new order
    /// </summary>
    public async Task<Order> CreateAsync(CreateOrderRequest request)
    {
        _logger.LogInformation("Creating new order with order number: {OrderNumber}", request.OrderNumber);
        var result = await _httpClient.PostAsync<Order>("/orders", request);
        return result ?? throw new InvalidOperationException("Failed to create order");
    }

    /// <summary>
    /// Update an existing order
    /// </summary>
    public async Task<Order> UpdateAsync(string id, UpdateOrderRequest request)
    {
        _logger.LogInformation("Updating order with ID: {Id}", id);
        var result = await _httpClient.PutAsync<Order>($"/orders/{id}", request);
        return result ?? throw new InvalidOperationException("Failed to update order");
    }

    /// <summary>
    /// Cancel an order
    /// </summary>
    public async Task<Order> CancelAsync(string id)
    {
        _logger.LogInformation("Cancelling order with ID: {Id}", id);
        var result = await _httpClient.PostAsync<Order>($"/orders/{id}/cancel");
        return result ?? throw new InvalidOperationException("Failed to cancel order");
    }
} 