using System;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json;
using System.Threading.Tasks;
using Trading212.API.Configuration;
using Trading212.API.Endpoints;

namespace Trading212.API;

public class TradingApiClient : ITradingApiClient
{
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly string _baseUrl;

    public TradingApiClient(HttpClient httpClient, ApiConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration.BaseUrl;
    }
}
