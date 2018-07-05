using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uptime.Auction.Core.Test
{
    [TestClass]
    public class AuctionServiceTests
    {
        private AuctionService auctionService;

        [TestInitialize]
        public void SetUp()
        {
            var auctionRepositoryMock = new Mock<IAuctionRepository>();
            auctionService = new AuctionService(auctionRepositoryMock.Object);
        }

        [TestMethod]
        public void TestCreate()
        {
            // arrange
            // act
            // assert
            auctionService.Create("suva", 32, DateTime.Now);
        }


    }
}
