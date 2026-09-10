using System.Net.Http.Json;
using SmartX.Shared.Contracts;

namespace SmartX.Client.Services;

/// <summary>
/// Thin typed wrapper around <see cref="HttpClient"/> for talking to the gateway API.
/// Every page/component calls the API through this class instead of using HttpClient
/// directly, so the endpoint URLs and (de)serialisation live in one place.
/// </summary>
public sealed class SmartXApiClient(HttpClient http)
{
    private readonly HttpClient _http = http;

    /// <summary>
    /// Phase 1 round-trip check: fetch the gateway identity/health payload.
    /// </summary>
    public async Task<GatewayInfo?> GetGatewayInfoAsync(CancellationToken ct = default)
        => await _http.GetFromJsonAsync<GatewayInfo>("api/gateway/info", ct);
}
