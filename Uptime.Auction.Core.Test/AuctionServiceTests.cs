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
        private Mock<IAuctionRepository> auctionRepositoryMock;

        [TestInitialize]
        public void SetUp()
        {
            auctionRepositoryMock = new Mock<IAuctionRepository>();
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

        // new tests
        [TestMethod]
        public void TestShowList()
        {
            auctionService.ShowList();
        }

        [TestMethod]
        public void TestBid()
        {
            var auction = new Auction
            {
                Id = 1,
                Item = "ese",
                StartingPrice = 30,
                CurrentPrice = 30,
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(100)
            };

            auctionRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(auction);
            auctionService.Bid(1, 500);
        }

        [TestMethod]
        public void TestBid_InvalidId()
        {
            var auction = new Auction
            {
                Id = 1,
                Item = "ese",
                StartingPrice = 30,
                CurrentPrice = 30,
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(100)
            };

            auctionRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(auction);
            var exception = Assert.ThrowsException<Exception>(() => auctionService.Bid(-3, 500));
            Assert.AreEqual("Invalid auction ID", exception.Message);
        }

        [TestMethod]
        public void TestBid_BidNeedsToBeBigger()
        {
            var auction = new Auction
            {
                Id = 1,
                Item = "ese",
                StartingPrice = 30,
                CurrentPrice = 30,
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(100)
            };

            auctionRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(auction);
            var exception = Assert.ThrowsException<Exception>(() => auctionService.Bid(1, 20));
            Assert.AreEqual("Bid needs to be bigger than current price.", exception.Message);
        }

        [TestMethod]
        public void TestBid_NoAuctionWithId()
        {
            var exception = Assert.ThrowsException<Exception>(() => auctionService.Bid(555, 200));
            Assert.AreEqual("There's no auction with that ID", exception.Message);

        }
    }
}
