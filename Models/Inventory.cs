namespace ShipHero.SDK.Models;

/// <summary>
/// Represents inventory information for a product
/// </summary>
public class Inventory
{
    /// <summary>
    /// Product SKU
    /// </summary>
    public string? Sku { get; set; }
    
    /// <summary>
    /// Product name
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Available quantity
    /// </summary>
    public int AvailableQuantity { get; set; }
    
    /// <summary>
    /// Reserved quantity
    /// </summary>
    public int ReservedQuantity { get; set; }
    
    /// <summary>
    /// Total quantity
    /// </summary>
    public int TotalQuantity { get; set; }
    
    /// <summary>
    /// Warehouse ID
    /// </summary>
    public string? WarehouseId { get; set; }
    
    /// <summary>
    /// Warehouse name
    /// </summary>
    public string? WarehouseName { get; set; }
    
    /// <summary>
    /// Last updated
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}

/// <summary>
/// Inventory update request
/// </summary>
public class UpdateInventoryRequest
{
    /// <summary>
    /// Product SKU
    /// </summary>
    public required string Sku { get; set; }
    
    /// <summary>
    /// Warehouse ID
    /// </summary>
    public string? WarehouseId { get; set; }
    
    /// <summary>
    /// Quantity to add (positive) or subtract (negative)
    /// </summary>
    public int QuantityChange { get; set; }
    
    /// <summary>
    /// Reason for the inventory change
    /// </summary>
    public string? Reason { get; set; }
}

/// <summary>
/// Inventory history entry
/// </summary>
public class InventoryHistory
{
    /// <summary>
    /// Entry ID
    /// </summary>
    public string? Id { get; set; }
    
    /// <summary>
    /// Product SKU
    /// </summary>
    public string? Sku { get; set; }
    
    /// <summary>
    /// Warehouse ID
    /// </summary>
    public string? WarehouseId { get; set; }
    
    /// <summary>
    /// Quantity change
    /// </summary>
    public int QuantityChange { get; set; }
    
    /// <summary>
    /// Previous quantity
    /// </summary>
    public int PreviousQuantity { get; set; }
    
    /// <summary>
    /// New quantity
    /// </summary>
    public int NewQuantity { get; set; }
    
    /// <summary>
    /// Reason for the change
    /// </summary>
    public string? Reason { get; set; }
    
    /// <summary>
    /// User who made the change
    /// </summary>
    public string? ChangedBy { get; set; }
    
    /// <summary>
    /// Date of the change
    /// </summary>
    public DateTime? ChangedAt { get; set; }
} 