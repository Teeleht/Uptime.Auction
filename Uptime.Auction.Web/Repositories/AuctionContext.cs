using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uptime.Auction.Web.Repositories
{
    public class AuctionContext: DbContext
    {
        public AuctionContext(DbContextOptions<AuctionContext> options)
               : base(options)
        {
        }

        public DbSet<Core.Auction> Auctions { get; set; }
    }
}
