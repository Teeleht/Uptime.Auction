using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uptime.Auction.Web.Models
{
    public class BidModel
    {
        public int AuctionId { get; set; }
        public double BidPrice { get; set; }
    }
}
