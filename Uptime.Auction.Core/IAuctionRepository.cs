using System;
using System.Collections.Generic;
using System.Text;

namespace Uptime.Auction.Core
{
    public interface IAuctionRepository
    {
        int Create(string name, double startingPrice, DateTime endTime);
        List<Auction> GetActive();
        Auction GetById(int id);
        void Update(Auction auction);
    }
}
