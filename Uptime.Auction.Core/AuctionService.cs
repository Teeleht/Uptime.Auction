﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uptime.Auction.Core
{
    public class AuctionService
    {
        private IAuctionRepository auctionRepository;

        public AuctionService(IAuctionRepository auctionRepository)
        {
            this.auctionRepository = auctionRepository;
        }

        public void Create(string name, double startingPrice, DateTime endTime)
        {
            auctionRepository.Create(name, startingPrice, endTime);
        }

        public void Bid(int auctionId, double bidPrice)
        {
            var auction = auctionRepository.GetById(auctionId);

            if (auction.CurrentPrice < bidPrice)
            {
                auction.CurrentPrice = bidPrice;
                auctionRepository.Update(auction);
            }
            else
            {
                throw new Exception("Bid needs to be bigger than current price.");
            }  
        }

        public IEnumerable<Auction> ShowList()
        {
            return auctionRepository.GetActive();
        }
    }
}
