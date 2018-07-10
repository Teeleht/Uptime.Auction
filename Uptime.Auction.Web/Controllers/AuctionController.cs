using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uptime.Auction.Core;
using Uptime.Auction.Web.Models;

namespace Uptime.Auction.Web.Controllers
{
    [Route("[controller]")]
    [Route("")]
    [Authorize]
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
            var auctions = auctionService.ShowList();
            
            return View(auctions);
        }


        [HttpGet("[action]")]
        public IActionResult Details(int auctionId)
        {

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
            auctionService.Bid(bid.AuctionId, bid.BidPrice);
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult Create()
        {
            var auction = new Core.Auction();
            return View(auction);
        }

        [HttpPost("[action]")]
        public IActionResult Create(Core.Auction auction)
        {
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

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (login.Username == "Teele" && login.Password == "jou")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.Username),
                    new Claim(ClaimTypes.Role, "Administrator"),
                };

                var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. Required when setting the 
                    // ExpireTimeSpan option of CookieAuthenticationOptions 
                    // set with AddCookie. Also required when setting 
                    // ExpiresUtc.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

                return RedirectToAction("Index");
            }
            else
            {
                return View(login);
            }


            

        }


    }
}