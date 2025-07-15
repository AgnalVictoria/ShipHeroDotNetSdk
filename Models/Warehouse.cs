namespace ShipHero.SDK.Models;

/// <summary>
/// Represents a warehouse in ShipHero
/// </summary>
public class Warehouse
{
    /// <summary>
    /// Unique identifier for the warehouse
    /// </summary>
    public string? Id { get; set; }
    
    /// <summary>
    /// Warehouse name
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Warehouse code
    /// </summary>
    public string? Code { get; set; }
    
    /// <summary>
    /// Warehouse address
    /// </summary>
    public Address? Address { get; set; }
    
    /// <summary>
    /// Contact information
    /// </summary>
    public Contact? Contact { get; set; }
    
    /// <summary>
    /// Whether the warehouse is active
    /// </summary>
    public bool? IsActive { get; set; }
    
    /// <summary>
    /// Warehouse type
    /// </summary>
    public string? Type { get; set; }
    
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
/// Contact information
/// </summary>
public class Contact
{
    /// <summary>
    /// Contact name
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Contact email
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Contact phone
    /// </summary>
    public string? Phone { get; set; }
}

/// <summary>
/// Request to create a new warehouse
/// </summary>
public class CreateWarehouseRequest
{
    /// <summary>
    /// Warehouse name
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// Warehouse code
    /// </summary>
    public string? Code { get; set; }
    
    /// <summary>
    /// Warehouse address
    /// </summary>
    public Address? Address { get; set; }
    
    /// <summary>
    /// Contact information
    /// </summary>
    public Contact? Contact { get; set; }
    
    /// <summary>
    /// Warehouse type
    /// </summary>
    public string? Type { get; set; }
}

/// <summary>
/// Request to update an existing warehouse
/// </summary>
public class UpdateWarehouseRequest
{
    /// <summary>
    /// Warehouse name
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Warehouse code
    /// </summary>
    public string? Code { get; set; }
    
    /// <summary>
    /// Warehouse address
    /// </summary>
    public Address? Address { get; set; }
    
    /// <summary>
    /// Contact information
    /// </summary>
    public Contact? Contact { get; set; }
    
    /// <summary>
    /// Whether the warehouse is active
    /// </summary>
    public bool? IsActive { get; set; }
    
    /// <summary>
    /// Warehouse type
    /// </summary>
    public string? Type { get; set; }
} 