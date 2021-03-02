using ChanEngine.Entities.Models;
using ChanEngine.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChanEngine.Console
{
    class Program
    {
        private static IServiceProvider _provider;
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            _provider = services.BuildServiceProvider();

            try
            {
                var orderLines = await GetBestSoldProducts();
                DisplayMostSoldProducts(orderLines);
                
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Something went wrong: {ex}");
            }
        }
        private static void DisplayMostSoldProducts(List<Line> orderLines)
        {
            int num = 1;

            System.Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("\nNUMBER  |  PRODUCT TITLE\t\t\t\t  | \tGTIN\t   | QUANTITY SOLD  |  QUANTITY STOCK");
            System.Console.WriteLine("-------------------------------------------------------------------------------------------------------------");

            foreach (var product in orderLines)
            {
                var stock = GetProductStock(product.MerchantProductNo).Result;

                System.Console.WriteLine($"{num++}\t|  {product.Description}\t  | {product.Gtin}  |  \t{product.Quantity}\t    | {stock.ToString()}");
                System.Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            }
            System.Console.ResetColor();
        }

        private static async Task<List<Line>> GetBestSoldProducts()
        {
            return await _provider.GetRequiredService<IHttpClientOrderService>().GetMostSoldProducts();
        }

        private static async Task<int> GetProductStock(string merchantProductNo)
        {
            return await _provider.GetRequiredService<IHttpClientProductService>().GetProductStock(merchantProductNo);
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IHttpClientOrderService, HttpClientOrderService>();
            services.AddScoped<IHttpClientProductService, HttpClientProductService>();

        }
    }
}
