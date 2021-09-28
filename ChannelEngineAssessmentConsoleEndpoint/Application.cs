using ChannelEngineAssessmentLogic.Interfaces;
using System;
using System.Text;
using System.Linq;

namespace ChannelEngineAssessmentConsole
{
    class Application
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public Application(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
            Console.WriteLine("Hello in Channel Engine App.");
        }

        public void Execute()
        {
            try
            {
                PrintBasicCommands();
                var command = Console.ReadLine();
                while (command != "e")
                {
                    switch (command)
                    {
                        case "1":
                            PrintOrdersInProgress();
                            break;
                        case "2":
                            PrintTopSoldProducts();
                            break;
                        case "3":
                            UpdateProductStock();
                            break;
                        default:
                            Console.WriteLine("Unknown command!");
                            break;
                    }
                    PrintBasicCommands();
                    command = Console.ReadLine();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an error:" + ex.Message);
                Execute();
            }
        }

        private void PrintBasicCommands()
        {
            Console.WriteLine("");
            Console.WriteLine("When you want to close application, please type 'e'.");
            Console.WriteLine("If not, here are options (type number to choose):");
            Console.WriteLine("1. Get all orders in status in progress");
            Console.WriteLine("2. Get top 5 sold products");
            Console.WriteLine("3. Set product stock to 25");
            Console.WriteLine("");
        }

        private void PrintOrdersInProgress()
        {
            var orders = _orderService.GetOrdersInProgress().Result;
            var count = 1;
            foreach(var order in orders)
            {
                var builder = new StringBuilder("Order id: ").Append(order.Id);
                builder.Append(" Channel Name: ").Append(order.ChannelName);
                builder.Append(" Total with VAT: ").Append(order.TotalInclVat);
                builder.Append(" VAT: ").Append(order.TotalVat);
                builder.Append(" Currency: ").Append(order.CurrencyCode);
                builder.Append(" Mail: ").Append(order.Email);
                builder.Append(" Phone: ").Append(order.Phone);
                builder.Append(" Order date: ").Append(order.OrderDate);

                Console.WriteLine("Order " + count + ":");
                Console.WriteLine(builder.ToString());
                count++;
            }
        }

        private void PrintTopSoldProducts()
        {
            var orders = _orderService.GetOrdersInProgress().Result;
            var topProducts = orders.GetTopSoldProductsIds(5);
            var products = _productService.GetProductsByIds(topProducts.Keys).Result;
            var count = 1;

            foreach (var topProduct in topProducts)
            {
                var product = products.First(p => string.Equals(p.MerchantProductNo, topProduct.Key));

                var builder = new StringBuilder(count.ToString()).Append(". Merchant number id: ").Append(topProduct.Key);
                builder.Append(" Name: ").Append(product.Name);
                builder.Append(" EAN: ").Append(product.Ean);
                builder.Append(" Total sold: ").Append(topProduct.Value);

                Console.WriteLine(builder.ToString());
                count++;
            }
        }

        private void UpdateProductStock()
        {
            PrintTopSoldProducts();
            Console.WriteLine("Please write Merchant number id of product you want to update");
            var number = Console.ReadLine();
            var result = _productService.UpdateProductStock(number).Result;
            if(result)
                Console.WriteLine("Successfully updated stock");
            else
                Console.WriteLine("Didn't work :(");
        }
    }
}
