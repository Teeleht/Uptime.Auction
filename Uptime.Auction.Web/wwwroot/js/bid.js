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

    if (bidButton)
        bidButton.addEventListener("click", bidButtonClicked, false);


    var form = document.getElementById("create");
    var date = moment().format("YYYY-MM-DD HH:mm:ss");

    function validateForm(e) {
        var name = form.elements["Item"].value;
        var startingPrice = document.forms["create"]["StartingPrice"].value;
        var endTime = document.forms["create"]["End"].value;

        if (name == "") {
            alert("Items name must be filled out");
            e.preventDefault();
        }
        else if (startingPrice <= 0 || isNaN(startingPrice)) {
            alert("Invalid starting price");
            e.preventDefault();
        }
        else if (endTime <= date) {
            alert("End time must be greater than start time");
            e.preventDefault();
        }
    }

    form.addEventListener("submit", validateForm, false);
});