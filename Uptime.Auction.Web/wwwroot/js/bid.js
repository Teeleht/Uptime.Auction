window.addEventListener("DOMContentLoaded", () => {

    var bidButton = document.getElementById("bid-button");

    function bidButtonClicked() {
        var bidInput = document.getElementById("bid-input");
        if (bidInput.value) {
            $.ajax({
                type: "POST",
                url: "/bid",
                data: bidInput.value,
                success: function (data) {
                    alert("jee");
                },
                contentType: "application/json",
                datatype: "json",
            });
        }
    }

    bidButton.addEventListener("click", bidButtonClicked, false);
});