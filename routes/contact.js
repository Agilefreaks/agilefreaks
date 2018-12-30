const express = require('express');
const router = express.Router();
const sgMail = require('@sendgrid/mail');
const toEmail = "office@agilefreaks.com";

sgMail.setApiKey(process.env.SENDGRID_API_KEY);

router.post('/contact', function(req, res, next) {
    const name = req.body.name;
    const email = req.body.email;
    const message = req.body.message;
    const msg = {
        to: toEmail,
        from: email,
        replyTo: email,
        subject: "[AgileFreaks.com] " + name,
        text: message
    };

    sgMail.send(msg)
        .then(function () {
            res.render('index', { successMessage: 'Message sent.' });
        })
        .catch(function (e) {
            res.render('index', { errorMessage: 'There has been an error processing your request. Please try sending the email manually to ' + toEmail });
        });

});

module.exports = router;
