using ChanEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChanEngine.Tests
{
    public class HttpClientOrderTests
    {
        [Fact]
        public void TopFiveSoldItemsQuery_ReturnsExpectedResults()
        {
            var httpOrderService = new HttpClientOrderService();

            var topFive = httpOrderService.TopFiveSoldItemsQuery(Data.GetDummyData());
            var firstArticle = topFive.First();
            var lastArticleWithin = topFive.Last();

            Assert.True(topFive.Count == 5);
            Assert.True(topFive.FirstOrDefault(f => f.MerchantProductNo == "6") == null);
            Assert.True(topFive.FirstOrDefault(f => f.MerchantProductNo == "7") == null);
            Assert.Equal(firstArticle.MerchantProductNo, "1");
            Assert.Equal(firstArticle.Description, "Zwarte T-Shirt");
            Assert.Equal(lastArticleWithin.MerchantProductNo, "5");
            Assert.Equal(lastArticleWithin.Description, "Paarse T-Shirt");
        }
    }
}
