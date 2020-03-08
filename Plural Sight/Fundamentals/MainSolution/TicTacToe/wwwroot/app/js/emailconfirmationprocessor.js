"use strict";

function checkEmailConfirmationStatus(email) {
    var address = `/CheckEmailConfirmationStatus?email=${email}`;
    $.get(address)
        .then(d => {
            if (d === "ok") {
                clearInterval(interval);
                location.reload();
            }
        }).catch(err => {
            alert("Could not confirm email.");
            console.dir(err);
        });
}