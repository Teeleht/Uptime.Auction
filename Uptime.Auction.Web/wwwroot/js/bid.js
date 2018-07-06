window.addEventListener("DOMContentLoaded", () => {

    var bidButton = document.getElementById("bid-button");

    function bidButtonClicked() {
        var bidPrice = document.getElementById("bid-input");
        var auctionId = bidPrice.getAttribute("data-auction-id");
        if (bidPrice.value) {
            $.ajax({
                type: "POST",
                url: "/bid",
                data: JSON.stringify( { AuctionId: parseInt(auctionId), BidPrice: parseFloat(bidPrice.value) }),
                success: function (data) {
                    window.location.reload();
                },
                contentType: "application/json",
                datatype: "json",
            });
        }
    }

    bidButton.addEventListener("click", bidButtonClicked, false);
});