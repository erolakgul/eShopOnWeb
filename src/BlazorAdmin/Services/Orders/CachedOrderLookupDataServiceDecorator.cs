using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorShared.Interfaces;
using BlazorShared.Interfaces.Orders;
using BlazorShared.Models;
using Microsoft.Extensions.Logging;

namespace BlazorAdmin.Services.Orders;

public class CachedOrderLookupDataServiceDecorator<TLookupData, TReponse>
    : IOrderLookupDataService<TLookupData>
    where TLookupData : LookupData
    where TReponse : ILookupDataResponse<TLookupData>
{
    private readonly ILocalStorageService _localStorageService;
    private readonly OrderLookupDataService<TLookupData, TReponse> _orderStatusService;
    private ILogger<CachedOrderLookupDataServiceDecorator<TLookupData, TReponse>> _logger;

    public CachedOrderLookupDataServiceDecorator(ILocalStorageService localStorageService,
        OrderLookupDataService<TLookupData, TReponse> orderStatusService, 
        ILogger<CachedOrderLookupDataServiceDecorator<TLookupData, TReponse>> logger)
    {
        _localStorageService = localStorageService;
        _orderStatusService = orderStatusService;
        _logger = logger;
    }

    public async Task<List<TLookupData>> List()
    {
        string key = typeof(TLookupData).Name;
        var cacheEntry = await _localStorageService.GetItemAsync<CacheEntry<List<TLookupData>>>(key);

        if (cacheEntry != null)
        {
            _logger.LogInformation($"Loading {key} from local storage.");
            if (cacheEntry.DateCreated.AddMinutes(1) > DateTime.UtcNow)
            {
                return cacheEntry.Value;
            }
            else
            {
                _logger.LogInformation($"Cache expired; removing {key} from local storage.");
                await _localStorageService.RemoveItemAsync(key);
            }
        }

        var types = await _orderStatusService.List();

        var entry = new CacheEntry<List<TLookupData>>(types);
        await _localStorageService.SetItemAsync(key, entry);

        return types;
    }
}
