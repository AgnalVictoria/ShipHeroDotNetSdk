using Microsoft.Extensions.Logging;
using ShipHero.SDK.Http;
using ShipHero.SDK.Interfaces;
using ShipHero.SDK.Models;

namespace ShipHero.SDK.Api;

/// <summary>
/// Products API implementation using GraphQL
/// </summary>
public class ProductsApi : IProductsApi
{
    private readonly ShipHeroGraphQLClient _graphQLClient;
    private readonly ILogger<ProductsApi> _logger;

    public ProductsApi(ShipHeroGraphQLClient graphQLClient, ILogger<ProductsApi> logger)
    {
        _graphQLClient = graphQLClient;
        _logger = logger;
    }

    /// <summary>
    /// Get all products
    /// </summary>
    public async Task<List<Product>> GetAllAsync()
    {
        _logger.LogInformation("Getting all products");

        var query = @"
            query GetProducts {
                products {
                    id
                    sku
                    name
                    description
                    price
                    weight
                    dimensions {
                        length
                        width
                        height
                    }
                    category
                    brand
                    images
                    tags
                    isActive
                    createdAt
                    updatedAt
                }
            }";

        var response = await _graphQLClient.ExecuteQueryAsync<ProductsResponse>(query);
        return response?.Products ?? new List<Product>();
    }

    /// <summary>
    /// Get product by ID
    /// </summary>
    public async Task<Product?> GetByIdAsync(string id)
    {
        _logger.LogInformation("Getting product by ID: {Id}", id);

        var query = @"
            query GetProduct($id: ID!) {
                product(id: $id) {
                    id
                    sku
                    name
                    description
                    price
                    weight
                    dimensions {
                        length
                        width
                        height
                    }
                    category
                    brand
                    images
                    tags
                    isActive
                    createdAt
                    updatedAt
                }
            }";

        var variables = new { id };
        var response = await _graphQLClient.ExecuteQueryAsync<ProductResponse>(query, variables);
        return response?.Product;
    }

    /// <summary>
    /// Get product by SKU
    /// </summary>
    public async Task<Product?> GetBySkuAsync(string sku)
    {
        _logger.LogInformation("Getting product by SKU: {Sku}", sku);

        var query = @"
            query GetProductBySku($sku: String!) {
                productBySku(sku: $sku) {
                    id
                    sku
                    name
                    description
                    price
                    weight
                    dimensions {
                        length
                        width
                        height
                    }
                    category
                    brand
                    images
                    tags
                    isActive
                    createdAt
                    updatedAt
                }
            }";

        var variables = new { sku };
        var response = await _graphQLClient.ExecuteQueryAsync<ProductResponse>(query, variables);
        return response?.Product;
    }

    /// <summary>
    /// Create a new product
    /// </summary>
    public async Task<Product> CreateAsync(CreateProductRequest request)
    {
        _logger.LogInformation("Creating new product with SKU: {Sku}", request.Sku);

        var mutation = @"
            mutation CreateProduct($input: CreateProductInput!) {
                createProduct(input: $input) {
                    id
                    sku
                    name
                    description
                    price
                    weight
                    dimensions {
                        length
                        width
                        height
                    }
                    category
                    brand
                    images
                    tags
                    isActive
                    createdAt
                    updatedAt
                }
            }";

        var variables = new { input = request };
        var response = await _graphQLClient.ExecuteMutationAsync<ProductResponse>(mutation, variables);
        return response?.Product ?? throw new InvalidOperationException("Failed to create product");
    }

    /// <summary>
    /// Update an existing product
    /// </summary>
    public async Task<Product> UpdateAsync(string id, UpdateProductRequest request)
    {
        _logger.LogInformation("Updating product with ID: {Id}", id);

        var mutation = @"
            mutation UpdateProduct($id: ID!, $input: UpdateProductInput!) {
                updateProduct(id: $id, input: $input) {
                    id
                    sku
                    name
                    description
                    price
                    weight
                    dimensions {
                        length
                        width
                        height
                    }
                    category
                    brand
                    images
                    tags
                    isActive
                    createdAt
                    updatedAt
                }
            }";

        var variables = new { id, input = request };
        var response = await _graphQLClient.ExecuteMutationAsync<ProductResponse>(mutation, variables);
        return response?.Product ?? throw new InvalidOperationException("Failed to update product");
    }

    /// <summary>
    /// Delete a product
    /// </summary>
    public async Task DeleteAsync(string id)
    {
        _logger.LogInformation("Deleting product with ID: {Id}", id);

        var mutation = @"
            mutation DeleteProduct($id: ID!) {
                deleteProduct(id: $id) {
                    success
                    message
                }
            }";

        var variables = new { id };
        await _graphQLClient.ExecuteMutationAsync<DeleteProductResponse>(mutation, variables);
    }
}

/// <summary>
/// Response wrapper for products list
/// </summary>
public class ProductsResponse
{
    public List<Product>? Products { get; set; }
}

/// <summary>
/// Response wrapper for single product
/// </summary>
public class ProductResponse
{
    public Product? Product { get; set; }
}

/// <summary>
/// Response wrapper for delete operation
/// </summary>
public class DeleteProductResponse
{
    public bool Success { get; set; }
    public string? Message { get; set; }
} 