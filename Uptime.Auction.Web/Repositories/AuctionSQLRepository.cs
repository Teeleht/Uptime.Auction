using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uptime.Auction.Core;

namespace Uptime.Auction.Web.Repositories
{
    public class AuctionSQLRepository : IAuctionRepository
    {
        private readonly AuctionContext context;

        public AuctionSQLRepository(AuctionContext context)
        {
            this.context = context;    
        }
        public int Create(string name, double startingPrice, DateTime endTime)
        {
            var auction = new Core.Auction
            {
                Item = name,
                StartingPrice = startingPrice,
                CurrentPrice = startingPrice,
                Start = DateTime.Now,
                End = endTime
            };
            context.Auctions.Add(auction);
            context.SaveChanges();


            return auction.Id;

        }

        public List<Core.Auction> GetActive()
        {
            return context.Auctions.Where(x => x.End > DateTime.Now).ToList();
        }

        public Core.Auction GetById(int id)
        {
            try
            {
                return context.Auctions.First(x => x.Id == id && x.End > DateTime.Now);
            }
            catch (InvalidOperationException)
            {
                throw new Exception("There's no auction with that ID");
            }
        }

        public void Update(Core.Auction auction)
        {
            var a = context.Auctions.First(x => x.Id == auction.Id);

            a.Item = auction.Item;
            a.StartingPrice = auction.StartingPrice;
            a.CurrentPrice = auction.CurrentPrice;
            a.Start = auction.Start;
            a.End = auction.End;

            context.SaveChanges();
        }
    }
}
