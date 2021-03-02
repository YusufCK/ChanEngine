using ChanEngine.Entities.Models;
using ChanEngine.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChanEngine.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHttpClientOrderService _orderService;
        private readonly IHttpClientProductService _productService;
        public ProductsController(IHttpClientOrderService orderService, IHttpClientProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _orderService.GetMostSoldProducts();
   
            var productList = new List<ProductDto>();
            foreach (var product in products)
            {
                var productDto = new ProductDto
                {
                    ProductName= product.Description,
                    MerchantProductNo = product.MerchantProductNo,
                    Gtin = product.Gtin,
                    QuantitySold = product.Quantity,
                    QuantityStock = await _productService.GetProductStock(product.MerchantProductNo)
                };
                await _productService.UpdateProductStock(products.ElementAt(3).MerchantProductNo, "25");
                productList.Add(productDto);
            }
            return View(productList);
        }
    }
}
