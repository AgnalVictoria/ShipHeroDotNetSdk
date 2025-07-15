namespace ShipHero.SDK.Models;

/// <summary>
/// Represents a product in ShipHero
/// </summary>
public class Product
{
    /// <summary>
    /// Unique identifier for the product
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
    /// Product description
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Product price
    /// </summary>
    public decimal? Price { get; set; }
    
    /// <summary>
    /// Product weight
    /// </summary>
    public decimal? Weight { get; set; }
    
    /// <summary>
    /// Product dimensions
    /// </summary>
    public Dimensions? Dimensions { get; set; }
    
    /// <summary>
    /// Product category
    /// </summary>
    public string? Category { get; set; }
    
    /// <summary>
    /// Product brand
    /// </summary>
    public string? Brand { get; set; }
    
    /// <summary>
    /// Product images
    /// </summary>
    public List<string>? Images { get; set; }
    
    /// <summary>
    /// Product tags
    /// </summary>
    public List<string>? Tags { get; set; }
    
    /// <summary>
    /// Whether the product is active
    /// </summary>
    public bool? IsActive { get; set; }
    
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
/// Product dimensions
/// </summary>
public class Dimensions
{
    /// <summary>
    /// Length in inches
    /// </summary>
    public decimal? Length { get; set; }
    
    /// <summary>
    /// Width in inches
    /// </summary>
    public decimal? Width { get; set; }
    
    /// <summary>
    /// Height in inches
    /// </summary>
    public decimal? Height { get; set; }
}

/// <summary>
/// Request to create a new product
/// </summary>
public class CreateProductRequest
{
    /// <summary>
    /// Product SKU
    /// </summary>
    public required string Sku { get; set; }
    
    /// <summary>
    /// Product name
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// Product description
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Product price
    /// </summary>
    public decimal? Price { get; set; }
    
    /// <summary>
    /// Product weight
    /// </summary>
    public decimal? Weight { get; set; }
    
    /// <summary>
    /// Product dimensions
    /// </summary>
    public Dimensions? Dimensions { get; set; }
    
    /// <summary>
    /// Product category
    /// </summary>
    public string? Category { get; set; }
    
    /// <summary>
    /// Product brand
    /// </summary>
    public string? Brand { get; set; }
    
    /// <summary>
    /// Product images
    /// </summary>
    public List<string>? Images { get; set; }
    
    /// <summary>
    /// Product tags
    /// </summary>
    public List<string>? Tags { get; set; }
}

/// <summary>
/// Request to update an existing product
/// </summary>
public class UpdateProductRequest
{
    /// <summary>
    /// Product name
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Product description
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Product price
    /// </summary>
    public decimal? Price { get; set; }
    
    /// <summary>
    /// Product weight
    /// </summary>
    public decimal? Weight { get; set; }
    
    /// <summary>
    /// Product dimensions
    /// </summary>
    public Dimensions? Dimensions { get; set; }
    
    /// <summary>
    /// Product category
    /// </summary>
    public string? Category { get; set; }
    
    /// <summary>
    /// Product brand
    /// </summary>
    public string? Brand { get; set; }
    
    /// <summary>
    /// Product images
    /// </summary>
    public List<string>? Images { get; set; }
    
    /// <summary>
    /// Product tags
    /// </summary>
    public List<string>? Tags { get; set; }
    
    /// <summary>
    /// Whether the product is active
    /// </summary>
    public bool? IsActive { get; set; }
} 