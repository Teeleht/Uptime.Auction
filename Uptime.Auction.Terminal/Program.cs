using System;
using System.Collections.Generic;
using Uptime.Auction.Core;

namespace Uptime.Auction.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            var auctionMemoryRepository = new AuctionMemoryRepository();
            var auctionService = new AuctionService(auctionMemoryRepository);
            Console.WriteLine("Hello!");

            var dict = new Dictionary<string, Action<AuctionService>>
            {
                ["c"] = Create,
                ["s"] = ShowList,
                ["b"] = Bid,
            };

            string input;
            while ((input = Ask()) != "q")
            {
                if (dict.ContainsKey(input))
                {
                    dict[input](auctionService);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }

        private static string Ask()
        {
            string input;

            Console.WriteLine();
            Console.Write("What do you want to do? c - create new auction / s - show all active auctions / b - bid: ");
            input = Console.ReadLine();

            return input;
        }
        private static void Create(AuctionService auctionService)
        {
            string input;
            // name
            Console.Write("Enter the name of an item: ");
            input = Console.ReadLine();
            string item = input;

            // starting price
            Console.Write("Enter the starting price of " + item + ": ");
            input = Console.ReadLine();
            double startingPrice;

            while (!Double.TryParse(input, out startingPrice) || Convert.ToDouble(input) < 0)
            {
                Console.Write("An error occured. Enter the starting price of " + item + ": ");
                input = Console.ReadLine();
            }

            // end time
            Console.Write("Enter the end time of your auction (yyyy-MM-dd): ");
            input = Console.ReadLine();
            DateTime endTime;

            while (!DateTime.TryParse(input, out endTime))
            {
                Console.Write("An error occured. Enter the end time of your auction (yyyy-MM-dd): ");
                input = Console.ReadLine();
            }

            // add auction to list
            auctionService.Create(item, startingPrice, endTime);

            Console.WriteLine("You created an auction: ");
        }

        private static void Bid(AuctionService auctionService)
        {
            string input;
            Console.Write("Enter the ID of the auction: ");
            input = Console.ReadLine();
            int biddingId;

            while (!Int32.TryParse(input, out biddingId) || Convert.ToInt32(input) < 0)
            {
                Console.Write("An error occured. Enter the ID of the auction: ");
                input = Console.ReadLine();
            }

            //ask price
            Console.Write("Enter the bid: ");
            input = Console.ReadLine();
            double bidPrice;

            while (!Double.TryParse(input, out bidPrice) || Convert.ToDouble(input) < 0)
            {
                Console.Write("An error occured. Enter the bid: ");
                input = Console.ReadLine();
            }

            // find auction, check current price and id
            auctionService.Bid(biddingId, bidPrice);
        }

        private static void ShowList(AuctionService auctionService)
        {
            foreach (var i in auctionService.ShowList())
            {
                Console.WriteLine();
                Console.WriteLine("Id: " + i.Id);
                Console.WriteLine("Item: " + i.Item);
                Console.WriteLine("Starting price: " + i.StartingPrice);
                Console.WriteLine("Current price: " + i.CurrentPrice);
                Console.WriteLine("Started: " + i.Start.ToString("yyyy-MM-dd"));
                Console.WriteLine("Ends: " + i.End.ToString("yyyy-MM-dd"));
            }
        }
    }
}
