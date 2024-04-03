using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Threading.Tasks;
using BlazorShared.Attributes;
using BlazorShared.Interfaces;
using BlazorShared.Interfaces.Orders;
using BlazorShared.Models;
using Microsoft.Extensions.Logging;

namespace BlazorAdmin.Services.Orders;

public class OrderLookupDataService<TLookupData, TReponse>
                                                : IOrderLookupDataService<TLookupData>
                                                where TLookupData : LookupData
                                                where TReponse : ILookupDataResponse<TLookupData>
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<OrderLookupDataService<TLookupData, TReponse>> _logger;
    private readonly string _apiUrl;

    public OrderLookupDataService(HttpClient httpClient, 
        ILogger<OrderLookupDataService<TLookupData, TReponse>> logger, 
        string apiUrl)
    {
        _httpClient = httpClient;
        _logger = logger;
        _apiUrl = apiUrl;
    }

    public async Task<List<TLookupData>> List()
    {
        var endpointName = typeof(TLookupData).GetCustomAttribute<EndpointAttribute>().Name;
        _logger.LogInformation($"Fetching {typeof(TLookupData).Name} from API. Enpoint : {endpointName}");

        var response = await _httpClient.GetFromJsonAsync<TReponse>($"{_apiUrl}{endpointName}");
        return response.List;
    }
}
