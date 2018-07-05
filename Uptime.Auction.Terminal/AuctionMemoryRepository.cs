using System;
using System.Collections.Generic;
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
        }

        public List<Core.Auction> GetActive()
        {
            return auctions.Where(x => x.End > DateTime.Now).ToList();
        }

        public Core.Auction GetById(int id)
        {
            return auctions.First(x => x.Id == auctionId && x.End > DateTime.Now);
        }

        public void Update(Core.Auction auction)
        {
            throw new NotImplementedException();
        }
    }
}
