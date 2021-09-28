using ChannelEngineAssessmentLogic.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace ChannelEngineAssessmentTest
{
    public class OrderTest
    {
        [Fact]
        public void CollectionOfOrdersReturnTopSoldProduct()
        {
            //given
            var orders = new List<Order>()
            {
                new Order
                {
                    Lines = new List<OrderLine>
                    {
                        new OrderLine
                        {
                            Quantity = 1,
                            MerchantProductNo = "first"
                        },
                        new OrderLine
                        {
                            Quantity = 2,
                            MerchantProductNo = "second"
                        }
                    }
                },
                new Order
                {
                    Lines = new List<OrderLine>
                    {
                        new OrderLine
                        {
                            Quantity = 1,
                            MerchantProductNo = "third"
                        }
                    }
                },
                new Order
                {
                    Lines = new List<OrderLine>
                    {
                        new OrderLine
                        {
                            Quantity = 6,
                            MerchantProductNo = "first"
                        }
                    }
                }
            };
            var expected = new Dictionary<string, int>
            {
                {"first", 7},
                {"second", 2},
                {"third", 1}
            };

            var collection = new CollectionOfOrders(orders);

            //when
            var result = collection.GetTopSoldProductsIds(5);

            //then
            Assert.Equal(expected, result);
        }
    }
}
