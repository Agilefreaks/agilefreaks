var express = require('express');
var router = express.Router();

router.post('/contact', function(req, res, next) {
  res.render('index', { title: 'AgileFreaks', notification: 'Message sent.' });
});

module.exports = router;
