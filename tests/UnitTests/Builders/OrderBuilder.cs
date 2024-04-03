﻿using System.Collections.Generic;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.UnitTests.Builders;

public class OrderBuilder
{
    private Order _order;
    public string TestBuyerId => "12345";
    public int TestCatalogItemId => 234;
    public string TestProductName => "Test Product Name";
    public string TestPictureUri => "http://test.com/image.jpg";
    public decimal TestUnitPrice = 1.23m;
    public int TestUnits = 3;
    public CatalogItemOrdered TestCatalogItemOrdered { get; }

    public OrderBuilder()
    {
        TestCatalogItemOrdered = new CatalogItemOrdered(TestCatalogItemId, TestProductName, TestPictureUri);
        _order = WithDefaultValues();
    }

    public Order Build()
    {
        return _order;
    }

    public Order WithDefaultValues()
    {
        var orderItem = new OrderItem(TestCatalogItemOrdered, TestUnitPrice, TestUnits);
        var itemList = new List<OrderItem>() { orderItem };
        _order = new Order(TestBuyerId, new AddressBuilder().WithDefaultValues(), itemList,0);
        return _order;
    }

    public Order WithNoItems()
    {
        _order = new Order(TestBuyerId, new AddressBuilder().WithDefaultValues(), new List<OrderItem>(), 0);
        return _order;
    }

    public Order WithItems(List<OrderItem> items)
    {
        _order = new Order(TestBuyerId, new AddressBuilder().WithDefaultValues(), items, 0);
        return _order;
    }
}
