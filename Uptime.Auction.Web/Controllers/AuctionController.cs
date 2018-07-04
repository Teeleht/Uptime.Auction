using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Uptime.Auction.Web.Controllers
{
    [Route("[controller]")]
    [Route("")]
    public class AuctionController : Controller
    {

        [Route("[action]")]
        [Route("")]
        public IActionResult Index()
        {
            // TODO: nimekiri oksjonitest
            // id, endtime, algpanus, bootstrap
            var model = new List<Models.Auction>
            {
                new Models.Auction
                {
                    Id = 1,
                    Item = "Ring",
                    Start = DateTime.Now,
                    End = new DateTime(2019, 4, 5),
                    StartingPrice = 300,
                    CurrentPrice = 300,

                },

                new Models.Auction
                {
                    Id = 2,
                    Item = "Painting",
                    Start = DateTime.Now,
                    End = new DateTime(2019, 4, 5),
                    StartingPrice = 400,
                    CurrentPrice = 400,
                }
            };
            return View(model);
        }


        [HttpGet("[action]")]
        public IActionResult Details()
        {
            // TODO: ühe oksjoni andmed, razoroksjon 
            var model = new Models.Auction
            {
                Id = 2,
                Item = "Painting",
                Start = DateTime.Now,
                End = new DateTime(2019, 4, 5),
                StartingPrice = 400,
                CurrentPrice = 400,
            };

            return View(model);
        }

        [HttpPost("[action]")]
        public IActionResult Bid(double model)
        {
            // TODO: panustamine
            return View();
        }

        [HttpGet("[action]")]
        public IActionResult Create()
        {
            // TODO: oksjoni loomine
            var model = new Models.Auction();
            return View(model);
        }

        [HttpPost("[action]")]
        public IActionResult Create(Models.Auction model)
        {
            // TODO: oksjoni loomine
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        
    }
}