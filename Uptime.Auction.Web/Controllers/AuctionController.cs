using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uptime.Auction.Core;
using Uptime.Auction.Web.Models;

namespace Uptime.Auction.Web.Controllers
{
    [Route("[controller]")]
    [Route("")]
    public class AuctionController : Controller
    {
        private readonly AuctionService auctionService;

        public AuctionController(AuctionService auctionService)
        {
            this.auctionService = auctionService;
        }

        [Route("[action]")]
        [Route("")]
        public IActionResult Index()
        {
            // TODO: nimekiri oksjonitest
            var auctions = auctionService.ShowList();
            
            return View(auctions);
        }


        [HttpGet("[action]")]
        public IActionResult Details(int auctionId)
        {
            // TODO: ühe oksjoni andmed, razoroksjon 

            var auction = auctionService.ShowList().First(x => x.Id == auctionId && x.End > DateTime.Now);

            if (auction != null)
            {
                return View(auction);
            }
            else
            {
                throw new Exception("There's no auction with that ID");
            }
        }

        [HttpPost("[action]")]
        public IActionResult Bid([FromBody]BidModel bid)
        {
            // TODO: õige id-ga oksjon, muuta controllerit ja repot; update, save
            auctionService.Bid(bid.AuctionId, bid.BidPrice);
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult Create()
        {
            // TODO: oksjoni loomine
            var auction = new Core.Auction();
            return View(auction);
        }

        [HttpPost("[action]")]
        public IActionResult Create(Core.Auction auction)
        {
            // TODO: oksjoni loomine
            if (!ModelState.IsValid)
            {
                return View(auction);
            }
            else
            {
                auctionService.Create(auction.Item, auction.StartingPrice, auction.End);
                return RedirectToAction("Index");
            }
        }

        
    }
}