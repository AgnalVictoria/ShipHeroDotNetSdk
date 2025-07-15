namespace ShipHero.SDK.Models;

/// <summary>
/// Configuration options for the ShipHero SDK
/// </summary>
public class ShipHeroOptions
{
    /// <summary>
    /// Your ShipHero username/email
    /// </summary>
    public required string Username { get; set; }
    
    /// <summary>
    /// Your ShipHero password
    /// </summary>
    public required string Password { get; set; }
    
    /// <summary>
    /// The base URL for the ShipHero GraphQL API
    /// </summary>
    public string BaseUrl { get; set; } = "https://public-api.shiphero.com";
    
    /// <summary>
    /// HTTP client timeout
    /// </summary>
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
    
    /// <summary>
    /// Retry policy configuration
    /// </summary>
    public RetryPolicy? RetryPolicy { get; set; }
    
    /// <summary>
    /// Whether to automatically refresh tokens
    /// </summary>
    public bool AutoRefreshTokens { get; set; } = true;
}

/// <summary>
/// Retry policy configuration
/// </summary>
public class RetryPolicy
{
    /// <summary>
    /// Maximum number of retries
    /// </summary>
    public int MaxRetries { get; set; } = 3;
    
    /// <summary>
    /// Delay between retries
    /// </summary>
    public TimeSpan RetryDelay { get; set; } = TimeSpan.FromSeconds(1);
    
    /// <summary>
    /// Whether to use exponential backoff
    /// </summary>
    public bool UseExponentialBackoff { get; set; } = true;
}

/// <summary>
/// Authentication response from ShipHero
/// </summary>
public class AuthResponse
{
    /// <summary>
    /// Access token for API requests
    /// </summary>
    public string? AccessToken { get; set; }
    
    /// <summary>
    /// Refresh token for getting new access tokens
    /// </summary>
    public string? RefreshToken { get; set; }
    
    /// <summary>
    /// Token expiration time in seconds
    /// </summary>
    public int ExpiresIn { get; set; }
    
    /// <summary>
    /// Token scope
    /// </summary>
    public string? Scope { get; set; }
    
    /// <summary>
    /// Token type
    /// </summary>
    public string? TokenType { get; set; }
} 