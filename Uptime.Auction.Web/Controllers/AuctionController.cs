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
                    Item = "eheh",
                    Start = DateTime.Now,
                },

                new Models.Auction
                {
                    Item = "ihih",
                    Start = DateTime.Now,
                }
            };
            return View(model);
        }


        [HttpGet("[action]")]
        public IActionResult Detail()
        {
            // TODO: ühe oksjoni andmed
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Bid()
        {
            // TODO: panustamine
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Create()
        {
            // TODO: oksjoni loomine
            return View();
        }
    }
}