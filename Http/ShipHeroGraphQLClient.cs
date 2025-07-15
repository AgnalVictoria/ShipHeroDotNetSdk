using System.Text.Json;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.Extensions.Logging;
using ShipHero.SDK.Exceptions;
using ShipHero.SDK.Models;

namespace ShipHero.SDK.Http;

/// <summary>
/// GraphQL client for ShipHero API
/// </summary>
public class ShipHeroGraphQLClient : IDisposable
{
    private readonly GraphQLHttpClient _graphQLClient;
    private readonly ILogger<ShipHeroGraphQLClient> _logger;
    private readonly JsonSerializerOptions _jsonOptions;
    private AuthResponse? _authResponse;
    private readonly ShipHeroOptions _options;

    public ShipHeroGraphQLClient(ShipHeroOptions options, ILogger<ShipHeroGraphQLClient> logger)
    {
        _options = options;
        _logger = logger;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };

        // Configure GraphQL client
        var graphQLOptions = new GraphQLHttpClientOptions
        {
            EndPoint = new Uri($"{options.BaseUrl}/graphql"),
            HttpMessageHandler = new HttpClientHandler()
        };

        _graphQLClient = new GraphQLHttpClient(graphQLOptions, new NewtonsoftJsonSerializer());
        _graphQLClient.HttpClient.Timeout = options.Timeout;
    }

    /// <summary>
    /// Authenticate with ShipHero and get access token
    /// </summary>
    public async Task<AuthResponse> AuthenticateAsync()
    {
        try
        {
            _logger.LogInformation("Authenticating with ShipHero");

            var authRequest = new
            {
                username = _options.Username,
                password = _options.Password
            };

            var json = JsonSerializer.Serialize(authRequest, _jsonOptions);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _graphQLClient.HttpClient.PostAsync($"{_options.BaseUrl}/auth/token", content);
            
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ShipHeroAuthenticationException($"Authentication failed: {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            _authResponse = JsonSerializer.Deserialize<AuthResponse>(responseContent, _jsonOptions);

            if (_authResponse?.AccessToken == null)
            {
                throw new ShipHeroAuthenticationException("Failed to obtain access token");
            }

            // Set authorization header for future requests
            _graphQLClient.HttpClient.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authResponse.AccessToken);

            _logger.LogInformation("Successfully authenticated with ShipHero");
            return _authResponse;
        }
        catch (Exception ex) when (ex is not ShipHeroException)
        {
            _logger.LogError(ex, "Error during authentication");
            throw new ShipHeroAuthenticationException("Authentication failed", ex);
        }
    }

    /// <summary>
    /// Refresh the access token using the refresh token
    /// </summary>
    public async Task<AuthResponse> RefreshTokenAsync()
    {
        if (_authResponse?.RefreshToken == null)
        {
            throw new ShipHeroAuthenticationException("No refresh token available");
        }

        try
        {
            _logger.LogInformation("Refreshing access token");

            var refreshRequest = new
            {
                refresh_token = _authResponse.RefreshToken
            };

            var json = JsonSerializer.Serialize(refreshRequest, _jsonOptions);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _graphQLClient.HttpClient.PostAsync($"{_options.BaseUrl}/auth/refresh", content);
            
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ShipHeroAuthenticationException($"Token refresh failed: {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            _authResponse = JsonSerializer.Deserialize<AuthResponse>(responseContent, _jsonOptions);

            if (_authResponse?.AccessToken == null)
            {
                throw new ShipHeroAuthenticationException("Failed to refresh access token");
            }

            // Update authorization header
            _graphQLClient.HttpClient.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authResponse.AccessToken);

            _logger.LogInformation("Successfully refreshed access token");
            return _authResponse;
        }
        catch (Exception ex) when (ex is not ShipHeroException)
        {
            _logger.LogError(ex, "Error during token refresh");
            throw new ShipHeroAuthenticationException("Token refresh failed", ex);
        }
    }

    /// <summary>
    /// Execute a GraphQL query
    /// </summary>
    public async Task<T?> ExecuteQueryAsync<T>(string query, object? variables = null)
    {
        try
        {
            // Ensure we have a valid token
            if (_authResponse?.AccessToken == null)
            {
                await AuthenticateAsync();
            }

            _logger.LogDebug("Executing GraphQL query: {Query}", query);

            var request = new GraphQLRequest
            {
                Query = query,
                Variables = variables
            };

            var response = await _graphQLClient.SendQueryAsync<T>(request);

            if (response.Errors?.Any() == true)
            {
                var errorMessage = string.Join("; ", response.Errors.Select(e => e.Message));
                _logger.LogError("GraphQL query errors: {Errors}", errorMessage);
                throw new ShipHeroApiException($"GraphQL query failed: {errorMessage}", 400);
            }

            return response.Data;
        }
        catch (Exception ex) when (ex is not ShipHeroException)
        {
            _logger.LogError(ex, "Error executing GraphQL query");
            throw new ShipHeroApiException("GraphQL query execution failed", 0, null, ex);
        }
    }

    /// <summary>
    /// Execute a GraphQL mutation
    /// </summary>
    public async Task<T?> ExecuteMutationAsync<T>(string mutation, object? variables = null)
    {
        try
        {
            // Ensure we have a valid token
            if (_authResponse?.AccessToken == null)
            {
                await AuthenticateAsync();
            }

            _logger.LogDebug("Executing GraphQL mutation: {Mutation}", mutation);

            var request = new GraphQLRequest
            {
                Query = mutation,
                Variables = variables
            };

            var response = await _graphQLClient.SendMutationAsync<T>(request);

            if (response.Errors?.Any() == true)
            {
                var errorMessage = string.Join("; ", response.Errors.Select(e => e.Message));
                _logger.LogError("GraphQL mutation errors: {Errors}", errorMessage);
                throw new ShipHeroApiException($"GraphQL mutation failed: {errorMessage}", 400);
            }

            return response.Data;
        }
        catch (Exception ex) when (ex is not ShipHeroException)
        {
            _logger.LogError(ex, "Error executing GraphQL mutation");
            throw new ShipHeroApiException("GraphQL mutation execution failed", 0, null, ex);
        }
    }

    public void Dispose()
    {
        _graphQLClient?.Dispose();
    }
} 