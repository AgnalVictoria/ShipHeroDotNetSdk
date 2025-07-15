namespace ShipHero.SDK.Models;

/// <summary>
/// Represents a shipment in ShipHero
/// </summary>
public class Shipment
{
    /// <summary>
    /// Unique identifier for the shipment
    /// </summary>
    public string? Id { get; set; }
    
    /// <summary>
    /// Shipment number
    /// </summary>
    public string? ShipmentNumber { get; set; }
    
    /// <summary>
    /// Order ID
    /// </summary>
    public string? OrderId { get; set; }
    
    /// <summary>
    /// Order number
    /// </summary>
    public string? OrderNumber { get; set; }
    
    /// <summary>
    /// Shipment status
    /// </summary>
    public string? Status { get; set; }
    
    /// <summary>
    /// Shipping method
    /// </summary>
    public string? ShippingMethod { get; set; }
    
    /// <summary>
    /// Tracking number
    /// </summary>
    public string? TrackingNumber { get; set; }
    
    /// <summary>
    /// Carrier
    /// </summary>
    public string? Carrier { get; set; }
    
    /// <summary>
    /// Shipment items
    /// </summary>
    public List<ShipmentItem>? Items { get; set; }
    
    /// <summary>
    /// Shipping address
    /// </summary>
    public Address? ShippingAddress { get; set; }
    
    /// <summary>
    /// Shipment weight
    /// </summary>
    public decimal? Weight { get; set; }
    
    /// <summary>
    /// Shipment dimensions
    /// </summary>
    public Dimensions? Dimensions { get; set; }
    
    /// <summary>
    /// Shipping cost
    /// </summary>
    public decimal? ShippingCost { get; set; }
    
    /// <summary>
    /// Date shipped
    /// </summary>
    public DateTime? ShippedAt { get; set; }
    
    /// <summary>
    /// Date created
    /// </summary>
    public DateTime? CreatedAt { get; set; }
    
    /// <summary>
    /// Date last updated
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}

/// <summary>
/// Shipment item
/// </summary>
public class ShipmentItem
{
    /// <summary>
    /// Item ID
    /// </summary>
    public string? Id { get; set; }
    
    /// <summary>
    /// Product SKU
    /// </summary>
    public string? Sku { get; set; }
    
    /// <summary>
    /// Product name
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Quantity shipped
    /// </summary>
    public int Quantity { get; set; }
    
    /// <summary>
    /// Unit price
    /// </summary>
    public decimal? UnitPrice { get; set; }
}

/// <summary>
/// Request to create a new shipment
/// </summary>
public class CreateShipmentRequest
{
    /// <summary>
    /// Order ID
    /// </summary>
    public required string OrderId { get; set; }
    
    /// <summary>
    /// Shipping method
    /// </summary>
    public string? ShippingMethod { get; set; }
    
    /// <summary>
    /// Carrier
    /// </summary>
    public string? Carrier { get; set; }
    
    /// <summary>
    /// Tracking number
    /// </summary>
    public string? TrackingNumber { get; set; }
    
    /// <summary>
    /// Shipment items
    /// </summary>
    public List<ShipmentItem>? Items { get; set; }
    
    /// <summary>
    /// Shipping address
    /// </summary>
    public Address? ShippingAddress { get; set; }
    
    /// <summary>
    /// Shipment weight
    /// </summary>
    public decimal? Weight { get; set; }
    
    /// <summary>
    /// Shipment dimensions
    /// </summary>
    public Dimensions? Dimensions { get; set; }
    
    /// <summary>
    /// Shipping cost
    /// </summary>
    public decimal? ShippingCost { get; set; }
}

/// <summary>
/// Request to update an existing shipment
/// </summary>
public class UpdateShipmentRequest
{
    /// <summary>
    /// Shipment status
    /// </summary>
    public string? Status { get; set; }
    
    /// <summary>
    /// Shipping method
    /// </summary>
    public string? ShippingMethod { get; set; }
    
    /// <summary>
    /// Carrier
    /// </summary>
    public string? Carrier { get; set; }
    
    /// <summary>
    /// Tracking number
    /// </summary>
    public string? TrackingNumber { get; set; }
    
    /// <summary>
    /// Shipment items
    /// </summary>
    public List<ShipmentItem>? Items { get; set; }
    
    /// <summary>
    /// Shipping address
    /// </summary>
    public Address? ShippingAddress { get; set; }
    
    /// <summary>
    /// Shipment weight
    /// </summary>
    public decimal? Weight { get; set; }
    
    /// <summary>
    /// Shipment dimensions
    /// </summary>
    public Dimensions? Dimensions { get; set; }
    
    /// <summary>
    /// Shipping cost
    /// </summary>
    public decimal? ShippingCost { get; set; }
}

/// <summary>
/// Tracking information
/// </summary>
public class TrackingInfo
{
    /// <summary>
    /// Tracking number
    /// </summary>
    public string? TrackingNumber { get; set; }
    
    /// <summary>
    /// Carrier
    /// </summary>
    public string? Carrier { get; set; }
    
    /// <summary>
    /// Current status
    /// </summary>
    public string? Status { get; set; }
    
    /// <summary>
    /// Estimated delivery date
    /// </summary>
    public DateTime? EstimatedDelivery { get; set; }
    
    /// <summary>
    /// Tracking events
    /// </summary>
    public List<TrackingEvent>? Events { get; set; }
}

/// <summary>
/// Tracking event
/// </summary>
public class TrackingEvent
{
    /// <summary>
    /// Event timestamp
    /// </summary>
    public DateTime? Timestamp { get; set; }
    
    /// <summary>
    /// Event location
    /// </summary>
    public string? Location { get; set; }
    
    /// <summary>
    /// Event description
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Event status
    /// </summary>
    public string? Status { get; set; }
} 