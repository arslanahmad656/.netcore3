"use strict";

var interval;

function attchEmailConfirmationEvent(email) {
    interval = setInterval(() => checkEmailConfirmationStatus(email), 5000);
}