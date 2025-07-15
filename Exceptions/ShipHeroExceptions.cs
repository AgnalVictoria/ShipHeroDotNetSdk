namespace ShipHero.SDK.Exceptions;

/// <summary>
/// Base exception for ShipHero SDK
/// </summary>
public class ShipHeroException : Exception
{
    public ShipHeroException(string message) : base(message) { }
    
    public ShipHeroException(string message, Exception innerException) : base(message, innerException) { }
}

/// <summary>
/// Exception thrown when there's an API-specific error
/// </summary>
public class ShipHeroApiException : ShipHeroException
{
    /// <summary>
    /// HTTP status code
    /// </summary>
    public int StatusCode { get; }
    
    /// <summary>
    /// API error code
    /// </summary>
    public string? ErrorCode { get; }
    
    public ShipHeroApiException(string message, int statusCode, string? errorCode = null) 
        : base(message)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }
    
    public ShipHeroApiException(string message, int statusCode, string? errorCode, Exception innerException) 
        : base(message, innerException)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }
}

/// <summary>
/// Exception thrown when authentication fails
/// </summary>
public class ShipHeroAuthenticationException : ShipHeroException
{
    public ShipHeroAuthenticationException(string message) : base(message) { }
    
    public ShipHeroAuthenticationException(string message, Exception innerException) : base(message, innerException) { }
}

/// <summary>
/// Exception thrown when a resource is not found
/// </summary>
public class ShipHeroNotFoundException : ShipHeroException
{
    public ShipHeroNotFoundException(string message) : base(message) { }
    
    public ShipHeroNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}

/// <summary>
/// Exception thrown when there's a validation error
/// </summary>
public class ShipHeroValidationException : ShipHeroException
{
    /// <summary>
    /// Validation errors
    /// </summary>
    public Dictionary<string, string[]>? Errors { get; }
    
    public ShipHeroValidationException(string message, Dictionary<string, string[]>? errors = null) 
        : base(message)
    {
        Errors = errors;
    }
    
    public ShipHeroValidationException(string message, Dictionary<string, string[]>? errors, Exception innerException) 
        : base(message, innerException)
    {
        Errors = errors;
    }
}

/// <summary>
/// Exception thrown when rate limiting is exceeded
/// </summary>
public class ShipHeroRateLimitException : ShipHeroException
{
    /// <summary>
    /// Time to wait before retrying
    /// </summary>
    public TimeSpan? RetryAfter { get; }
    
    public ShipHeroRateLimitException(string message, TimeSpan? retryAfter = null) 
        : base(message)
    {
        RetryAfter = retryAfter;
    }
    
    public ShipHeroRateLimitException(string message, TimeSpan? retryAfter, Exception innerException) 
        : base(message, innerException)
    {
        RetryAfter = retryAfter;
    }
} 