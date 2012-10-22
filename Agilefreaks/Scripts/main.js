$(document).ready(function () {
	$.backstretch("Content/img/bg.jpg");

	var endTime = new Date(2013, 1 - 1, 25);
	$('.count-down').countdown({until: endTime});
});