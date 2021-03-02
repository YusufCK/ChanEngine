using ChanEngine.Entities.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChanEngine.Services
{
    public interface IHttpClientProductService
    {
        Task<int> GetProductStock(string merchantProductNo);
        Task UpdateProductStock(string merchantProductNo, string quantity);
    }
    public class HttpClientProductService : IHttpClientProductService
    {
        private static readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://api-dev.channelengine.net/api/v2/"),
            Timeout = new TimeSpan(0, 0, 30),
        };

        public HttpClientProductService()
        {

        }

        public async Task<int> GetProductStock(string merchantProductNo)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("X-CE-KEY", "541b989ef78ccb1bad630ea5b85c6ebff9ca3322");

            using (var response = await _httpClient.GetAsync($"products/{merchantProductNo}", HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();

                var productStock = await JsonSerializer.DeserializeAsync<Content>(stream);

                return productStock.Product.Stock;
            }
        }

        public async Task UpdateProductStock(string merchantProductNo, string quantity)
        {
            //var patchDoc = new JsonPatchDocument<Product>();
            //patchDoc.Replace(p => p.Stock.ToString(), quantity);

            //var serializedDoc = JsonSerializer.Serialize(patchDoc);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("X-CE-KEY", "541b989ef78ccb1bad630ea5b85c6ebff9ca3322");

            var patchValues = Helper.GetPatchValues(quantity);

            var serializedJson = JsonSerializer.Serialize(patchValues);

            var request = new HttpRequestMessage(HttpMethod.Patch, $"products/{merchantProductNo}");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(serializedJson, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json-patch+json");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
