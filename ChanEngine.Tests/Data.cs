using ChanEngine.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChanEngine.Tests
{
    public static class Data
    {
        public static List<Content> GetDummyData()
        {
            var orderLines = new List<Content>
            {
                new Content
                {
                    OrderLines = new List<Line>
                    {
                        new Line{MerchantProductNo="1", Description="Zwarte T-Shirt", Gtin="1122334455", Quantity= 1},
                        new Line{MerchantProductNo="1", Description="Zwarte T-Shirt", Gtin="1122334455", Quantity= 1},
                        new Line{MerchantProductNo="1", Description="Zwarte T-Shirt", Gtin="1122334455", Quantity= 1},
                        new Line{MerchantProductNo="1", Description="Zwarte T-Shirt", Gtin="1122334455", Quantity= 1},
                        new Line{MerchantProductNo="1", Description="Zwarte T-Shirt", Gtin="1122334455", Quantity= 1},
                        new Line{MerchantProductNo="1", Description="Zwarte T-Shirt", Gtin="1122334455", Quantity= 1},
                        new Line{MerchantProductNo="1", Description="Zwarte T-Shirt", Gtin="1122334455", Quantity= 1},
                        new Line{MerchantProductNo="1", Description="Zwarte T-Shirt", Gtin="1122334455", Quantity= 1},
                        new Line{MerchantProductNo="1", Description="Zwarte T-Shirt", Gtin="1122334455", Quantity= 1},
                        new Line{MerchantProductNo="1", Description="Zwarte T-Shirt", Gtin="1122334455", Quantity= 1},
                        new Line{MerchantProductNo="1", Description="Zwarte T-Shirt", Gtin="1122334455", Quantity= 1},
                        new Line{MerchantProductNo="1", Description="Zwarte T-Shirt", Gtin="1122334455", Quantity= 1},
                        new Line{MerchantProductNo="1", Description="Zwarte T-Shirt", Gtin="1122334455", Quantity= 1},
                        new Line{MerchantProductNo="2", Description="Witte T-Shirt", Gtin="9922334455", Quantity= 1},
                        new Line{MerchantProductNo="2", Description="Witte T-Shirt", Gtin="9922334455", Quantity= 1},
                        new Line{MerchantProductNo="2", Description="Witte T-Shirt", Gtin="9922334455", Quantity= 1},
                        new Line{MerchantProductNo="2", Description="Witte T-Shirt", Gtin="9922334455", Quantity= 1},
                        new Line{MerchantProductNo="2", Description="Witte T-Shirt", Gtin="9922334455", Quantity= 1},
                        new Line{MerchantProductNo="2", Description="Witte T-Shirt", Gtin="9922334455", Quantity= 1},
                        new Line{MerchantProductNo="2", Description="Witte T-Shirt", Gtin="9922334455", Quantity= 1},
                        new Line{MerchantProductNo="2", Description="Witte T-Shirt", Gtin="9922334455", Quantity= 1},
                        new Line{MerchantProductNo="2", Description="Witte T-Shirt", Gtin="9922334455", Quantity= 1},
                        new Line{MerchantProductNo="2", Description="Witte T-Shirt", Gtin="9922334455", Quantity= 1},
                        new Line{MerchantProductNo="2", Description="Witte T-Shirt", Gtin="9922334455", Quantity= 1},
                        new Line{MerchantProductNo="3", Description="Gele T-Shirt", Gtin="8822334455", Quantity= 1},
                        new Line{MerchantProductNo="3", Description="Gele T-Shirt", Gtin="8822334455", Quantity= 1},
                        new Line{MerchantProductNo="3", Description="Gele T-Shirt", Gtin="8822334455", Quantity= 1},
                        new Line{MerchantProductNo="3", Description="Gele T-Shirt", Gtin="8822334455", Quantity= 1},
                        new Line{MerchantProductNo="3", Description="Gele T-Shirt", Gtin="8822334455", Quantity= 1},
                        new Line{MerchantProductNo="3", Description="Gele T-Shirt", Gtin="8822334455", Quantity= 1},
                        new Line{MerchantProductNo="3", Description="Gele T-Shirt", Gtin="8822334455", Quantity= 1},
                        new Line{MerchantProductNo="3", Description="Gele T-Shirt", Gtin="8822334455", Quantity= 1},
                        new Line{MerchantProductNo="4", Description="Blauwe T-Shirt", Gtin="7722334455", Quantity= 1},
                        new Line{MerchantProductNo="4", Description="Blauwe T-Shirt", Gtin="7722334455", Quantity= 1},
                        new Line{MerchantProductNo="4", Description="Blauwe T-Shirt", Gtin="7722334455", Quantity= 1},
                        new Line{MerchantProductNo="4", Description="Blauwe T-Shirt", Gtin="7722334455", Quantity= 1},
                        new Line{MerchantProductNo="4", Description="Blauwe T-Shirt", Gtin="7722334455", Quantity= 1},
                        new Line{MerchantProductNo="4", Description="Blauwe T-Shirt", Gtin="7722334455", Quantity= 1},
                        new Line{MerchantProductNo="5", Description="Paarse T-Shirt", Gtin="0122334455", Quantity= 1},
                        new Line{MerchantProductNo="5", Description="Paarse T-Shirt", Gtin="0122334455", Quantity= 1},
                        new Line{MerchantProductNo="5", Description="Paarse T-Shirt", Gtin="0122334455", Quantity= 1},
                        new Line{MerchantProductNo="6", Description="Rode T-Shirt", Gtin="8122334455", Quantity= 1},
                        new Line{MerchantProductNo="6", Description="Rode T-Shirt", Gtin="8122334455", Quantity= 1},
                        new Line{MerchantProductNo="7", Description="Groene T-Shirt", Gtin="5122334455", Quantity= 1}
                    }
                }
            };
         
            return orderLines;
        }

    }
}
