using System;

namespace Uptime.Auction.Core
{
    public class Auction
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double StartingPrice { get; set; }
        public double CurrentPrice { get; set; }


    }
}
