using ChannelEngineAssessmentLogic.Interfaces;
using System;
using System.Text;

namespace ChannelEngineAssessmentConsole
{
    class Application
    {
        private readonly IOrderService _orderService;

        public Application(IOrderService orderService)
        {
            _orderService = orderService;
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
    }
}
