namespace ShipHero.SDK.Models;

/// <summary>
/// Represents an order in ShipHero
/// </summary>
public class Order
{
    /// <summary>
    /// Unique identifier for the order
    /// </summary>
    public string? Id { get; set; }
    
    /// <summary>
    /// Order number
    /// </summary>
    public string? OrderNumber { get; set; }
    
    /// <summary>
    /// Order status
    /// </summary>
    public string? Status { get; set; }
    
    /// <summary>
    /// Customer information
    /// </summary>
    public Customer? Customer { get; set; }
    
    /// <summary>
    /// Order items
    /// </summary>
    public List<OrderItem>? Items { get; set; }
    
    /// <summary>
    /// Shipping address
    /// </summary>
    public Address? ShippingAddress { get; set; }
    
    /// <summary>
    /// Billing address
    /// </summary>
    public Address? BillingAddress { get; set; }
    
    /// <summary>
    /// Order total
    /// </summary>
    public decimal? Total { get; set; }
    
    /// <summary>
    /// Shipping cost
    /// </summary>
    public decimal? ShippingCost { get; set; }
    
    /// <summary>
    /// Tax amount
    /// </summary>
    public decimal? TaxAmount { get; set; }
    
    /// <summary>
    /// Currency code
    /// </summary>
    public string? Currency { get; set; }
    
    /// <summary>
    /// Payment method
    /// </summary>
    public string? PaymentMethod { get; set; }
    
    /// <summary>
    /// Shipping method
    /// </summary>
    public string? ShippingMethod { get; set; }
    
    /// <summary>
    /// Order notes
    /// </summary>
    public string? Notes { get; set; }
    
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
/// Customer information
/// </summary>
public class Customer
{
    /// <summary>
    /// Customer ID
    /// </summary>
    public string? Id { get; set; }
    
    /// <summary>
    /// Customer email
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Customer first name
    /// </summary>
    public string? FirstName { get; set; }
    
    /// <summary>
    /// Customer last name
    /// </summary>
    public string? LastName { get; set; }
    
    /// <summary>
    /// Customer phone
    /// </summary>
    public string? Phone { get; set; }
}

/// <summary>
/// Order item
/// </summary>
public class OrderItem
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
    /// Quantity ordered
    /// </summary>
    public int Quantity { get; set; }
    
    /// <summary>
    /// Unit price
    /// </summary>
    public decimal? UnitPrice { get; set; }
    
    /// <summary>
    /// Total price for this item
    /// </summary>
    public decimal? TotalPrice { get; set; }
}

/// <summary>
/// Address information
/// </summary>
public class Address
{
    /// <summary>
    /// First name
    /// </summary>
    public string? FirstName { get; set; }
    
    /// <summary>
    /// Last name
    /// </summary>
    public string? LastName { get; set; }
    
    /// <summary>
    /// Company name
    /// </summary>
    public string? Company { get; set; }
    
    /// <summary>
    /// Street address line 1
    /// </summary>
    public string? Address1 { get; set; }
    
    /// <summary>
    /// Street address line 2
    /// </summary>
    public string? Address2 { get; set; }
    
    /// <summary>
    /// City
    /// </summary>
    public string? City { get; set; }
    
    /// <summary>
    /// State/province
    /// </summary>
    public string? State { get; set; }
    
    /// <summary>
    /// Postal code
    /// </summary>
    public string? PostalCode { get; set; }
    
    /// <summary>
    /// Country
    /// </summary>
    public string? Country { get; set; }
    
    /// <summary>
    /// Phone number
    /// </summary>
    public string? Phone { get; set; }
}

/// <summary>
/// Request to create a new order
/// </summary>
public class CreateOrderRequest
{
    /// <summary>
    /// Order number
    /// </summary>
    public required string OrderNumber { get; set; }
    
    /// <summary>
    /// Customer information
    /// </summary>
    public Customer? Customer { get; set; }
    
    /// <summary>
    /// Order items
    /// </summary>
    public required List<OrderItem> Items { get; set; }
    
    /// <summary>
    /// Shipping address
    /// </summary>
    public Address? ShippingAddress { get; set; }
    
    /// <summary>
    /// Billing address
    /// </summary>
    public Address? BillingAddress { get; set; }
    
    /// <summary>
    /// Order total
    /// </summary>
    public decimal? Total { get; set; }
    
    /// <summary>
    /// Shipping cost
    /// </summary>
    public decimal? ShippingCost { get; set; }
    
    /// <summary>
    /// Tax amount
    /// </summary>
    public decimal? TaxAmount { get; set; }
    
    /// <summary>
    /// Currency code
    /// </summary>
    public string? Currency { get; set; }
    
    /// <summary>
    /// Payment method
    /// </summary>
    public string? PaymentMethod { get; set; }
    
    /// <summary>
    /// Shipping method
    /// </summary>
    public string? ShippingMethod { get; set; }
    
    /// <summary>
    /// Order notes
    /// </summary>
    public string? Notes { get; set; }
}

/// <summary>
/// Request to update an existing order
/// </summary>
public class UpdateOrderRequest
{
    /// <summary>
    /// Order status
    /// </summary>
    public string? Status { get; set; }
    
    /// <summary>
    /// Customer information
    /// </summary>
    public Customer? Customer { get; set; }
    
    /// <summary>
    /// Order items
    /// </summary>
    public List<OrderItem>? Items { get; set; }
    
    /// <summary>
    /// Shipping address
    /// </summary>
    public Address? ShippingAddress { get; set; }
    
    /// <summary>
    /// Billing address
    /// </summary>
    public Address? BillingAddress { get; set; }
    
    /// <summary>
    /// Order total
    /// </summary>
    public decimal? Total { get; set; }
    
    /// <summary>
    /// Shipping cost
    /// </summary>
    public decimal? ShippingCost { get; set; }
    
    /// <summary>
    /// Tax amount
    /// </summary>
    public decimal? TaxAmount { get; set; }
    
    /// <summary>
    /// Currency code
    /// </summary>
    public string? Currency { get; set; }
    
    /// <summary>
    /// Payment method
    /// </summary>
    public string? PaymentMethod { get; set; }
    
    /// <summary>
    /// Shipping method
    /// </summary>
    public string? ShippingMethod { get; set; }
    
    /// <summary>
    /// Order notes
    /// </summary>
    public string? Notes { get; set; }
} 