using ShipHero.SDK.Models;

namespace ShipHero.SDK.Interfaces;

/// <summary>
/// Main interface for the ShipHero client
/// </summary>
public interface IShipHeroClient
{
    /// <summary>
    /// Products API
    /// </summary>
    IProductsApi Products { get; }
    
    /// <summary>
    /// Orders API
    /// </summary>
    IOrdersApi Orders { get; }
    
    /// <summary>
    /// Inventory API
    /// </summary>
    IInventoryApi Inventory { get; }
    
    /// <summary>
    /// Warehouses API
    /// </summary>
    IWarehousesApi Warehouses { get; }
    
    /// <summary>
    /// Shipments API
    /// </summary>
    IShipmentsApi Shipments { get; }
}

/// <summary>
/// Products API interface
/// </summary>
public interface IProductsApi
{
    /// <summary>
    /// Get all products
    /// </summary>
    Task<List<Product>> GetAllAsync();
    
    /// <summary>
    /// Get product by ID
    /// </summary>
    Task<Product?> GetByIdAsync(string id);
    
    /// <summary>
    /// Get product by SKU
    /// </summary>
    Task<Product?> GetBySkuAsync(string sku);
    
    /// <summary>
    /// Create a new product
    /// </summary>
    Task<Product> CreateAsync(CreateProductRequest request);
    
    /// <summary>
    /// Update an existing product
    /// </summary>
    Task<Product> UpdateAsync(string id, UpdateProductRequest request);
    
    /// <summary>
    /// Delete a product
    /// </summary>
    Task DeleteAsync(string id);
}

/// <summary>
/// Orders API interface
/// </summary>
public interface IOrdersApi
{
    /// <summary>
    /// Get all orders
    /// </summary>
    Task<List<Order>> GetAllAsync();
    
    /// <summary>
    /// Get order by ID
    /// </summary>
    Task<Order?> GetByIdAsync(string id);
    
    /// <summary>
    /// Get order by order number
    /// </summary>
    Task<Order?> GetByOrderNumberAsync(string orderNumber);
    
    /// <summary>
    /// Create a new order
    /// </summary>
    Task<Order> CreateAsync(CreateOrderRequest request);
    
    /// <summary>
    /// Update an existing order
    /// </summary>
    Task<Order> UpdateAsync(string id, UpdateOrderRequest request);
    
    /// <summary>
    /// Cancel an order
    /// </summary>
    Task<Order> CancelAsync(string id);
}

/// <summary>
/// Inventory API interface
/// </summary>
public interface IInventoryApi
{
    /// <summary>
    /// Get inventory levels for all products
    /// </summary>
    Task<List<Inventory>> GetAllAsync();
    
    /// <summary>
    /// Get inventory for a specific product
    /// </summary>
    Task<Inventory?> GetBySkuAsync(string sku);
    
    /// <summary>
    /// Update inventory for a product
    /// </summary>
    Task<Inventory> UpdateAsync(UpdateInventoryRequest request);
    
    /// <summary>
    /// Get inventory history for a product
    /// </summary>
    Task<List<InventoryHistory>> GetHistoryAsync(string sku);
}

/// <summary>
/// Warehouses API interface
/// </summary>
public interface IWarehousesApi
{
    /// <summary>
    /// Get all warehouses
    /// </summary>
    Task<List<Warehouse>> GetAllAsync();
    
    /// <summary>
    /// Get warehouse by ID
    /// </summary>
    Task<Warehouse?> GetByIdAsync(string id);
    
    /// <summary>
    /// Create a new warehouse
    /// </summary>
    Task<Warehouse> CreateAsync(CreateWarehouseRequest request);
    
    /// <summary>
    /// Update an existing warehouse
    /// </summary>
    Task<Warehouse> UpdateAsync(string id, UpdateWarehouseRequest request);
    
    /// <summary>
    /// Delete a warehouse
    /// </summary>
    Task DeleteAsync(string id);
}

/// <summary>
/// Shipments API interface
/// </summary>
public interface IShipmentsApi
{
    /// <summary>
    /// Get all shipments
    /// </summary>
    Task<List<Shipment>> GetAllAsync();
    
    /// <summary>
    /// Get shipment by ID
    /// </summary>
    Task<Shipment?> GetByIdAsync(string id);
    
    /// <summary>
    /// Get shipment by shipment number
    /// </summary>
    Task<Shipment?> GetByShipmentNumberAsync(string shipmentNumber);
    
    /// <summary>
    /// Create a new shipment
    /// </summary>
    Task<Shipment> CreateAsync(CreateShipmentRequest request);
    
    /// <summary>
    /// Update an existing shipment
    /// </summary>
    Task<Shipment> UpdateAsync(string id, UpdateShipmentRequest request);
    
    /// <summary>
    /// Track a shipment
    /// </summary>
    Task<TrackingInfo?> TrackAsync(string trackingNumber, string? carrier = null);
} 