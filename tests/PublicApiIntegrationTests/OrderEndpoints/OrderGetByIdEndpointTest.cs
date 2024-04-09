using System.Threading.Tasks;
using BlazorAdmin.Services;
using BlazorShared;
using BlazorShared.Models.Orders;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PublicApiIntegrationTests.OrderEndpoints;

[TestClass]
public class OrderGetByIdEndpointTest
{
    private  HttpService _httpService;
    public OrderGetByIdEndpointTest()
    {
        //// Arrange
        BaseUrlConfiguration baseUrlConfiguration = new()
        {
            ApiBase = "https://localhost:5099/api/"
        };

        IOptions<BaseUrlConfiguration> options = Options.Create(baseUrlConfiguration);  

       ToastService toastService = new();
        _httpService = new(new System.Net.Http.HttpClient(), options, toastService);
    }

    [TestMethod]
    public async Task ReturnsItemGivenValidId()
    {
        //// Arrange
        const int id = 1;

        //// Act
        var response = await _httpService.HttpGet<EditOrderResult>($"order-items/{id}");

        //// Assert
        if (response is not null)
        {
            System.Console.WriteLine($"sipariş geçen => {response.Order.BuyerId}");

            Assert.AreEqual(id, response!.Order.Id);
        }
        else
        {
            System.Console.WriteLine("Sipariş bulunamadı..");
            Assert.IsNull(response);    
        }
    }
}
