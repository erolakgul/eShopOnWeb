﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Interfaces.Orders;
public interface IOrderLookupDataService<TLookupData> where TLookupData : LookupData
{
    Task<List<TLookupData>> List();
}
