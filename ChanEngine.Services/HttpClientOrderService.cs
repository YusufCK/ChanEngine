using ChanEngine.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChanEngine.Services
{
    public interface IHttpClientOrderService
    {
        Task<List<Line>> GetMostSoldProducts();
    }
    public class HttpClientOrderService : IHttpClientOrderService
    {
        private static readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://api-dev.channelengine.net/api/v2/"),
            Timeout = new TimeSpan(0, 0, 30),
        };

        public async Task<List<Line>> GetMostSoldProducts()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("X-CE-KEY", "541b989ef78ccb1bad630ea5b85c6ebff9ca3322");

            using (var response = await _httpClient.GetAsync("orders/?statuses=in_progress"))
            {
                response.EnsureSuccessStatusCode();
                var jsonOpts = new JsonSerializerOptions {PropertyNameCaseInsensitive = true };

                var stream = await response.Content.ReadAsStreamAsync();

                var orders = await JsonSerializer.DeserializeAsync<Orders>(stream, jsonOpts);

                return TopFiveSoldItemsQuery(orders.Content);
            }
        }

        public List<Line> TopFiveSoldItemsQuery(List<Content> orders)
        {
            var MostSoldItemsQuery =
                orders.SelectMany(o => o.Orders)
                          .GroupBy(p => new { p.Description, p.Gtin, p.MerchantProductNo })
                          .Select(p => new Line()
                          {
                              Description = p.First().Description,
                              Gtin = p.First().Gtin,
                              MerchantProductNo = p.First().MerchantProductNo,
                              Quantity = p.Sum(q => q.Quantity)
                          })
                          .OrderByDescending(q => q.Quantity)
                          .Take(5)
                          .ToList();

            return MostSoldItemsQuery;
        }
    }
}
