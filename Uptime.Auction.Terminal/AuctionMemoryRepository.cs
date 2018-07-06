using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uptime.Auction.Core;

namespace Uptime.Auction.Terminal
{
    public class AuctionMemoryRepository : IAuctionRepository
    {
        private List<Core.Auction> auctions = new List<Core.Auction>();
        private int currentId = 1;
        public int Create(string name, double startingPrice, DateTime endTime)
        {
            var auction = new Core.Auction
            {
                Id = currentId,
                Item = name,
                StartingPrice = startingPrice,
                CurrentPrice = startingPrice,
                Start = DateTime.Now,
                End = endTime
            };

            auctions.Add(auction);

            currentId += 1;
            return auction.Id;
        }

        public List<Core.Auction> GetActive()
        {
            return auctions.Where(x => x.End > DateTime.Now).ToList();
        }

        public Core.Auction GetById(int auctionId)
        {
            try
            {
                return auctions.First(x => x.Id == auctionId && x.End > DateTime.Now);
            }
            catch (System.InvalidOperationException)
            {
                throw new Exception("There's no auction with that ID");
            }
        }

        public void Update(Core.Auction auction)
        {
            var a = auctions.First(x => x.Id == auction.Id);

            a.Id = auction.Id;
            a.Item = auction.Item;
            a.StartingPrice = auction.StartingPrice;
            a.CurrentPrice = auction.CurrentPrice;
            a.Start = auction.Start;
            a.End = auction.End;
        }
    }
}
