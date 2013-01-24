$(document).ready(function () {
	/* Features tabs */
    $('#featuresTab a').click(function(e) {
        e.preventDefault();
        $(this).tab('show');
    });

	/* testimonial */
	$('.testimonials-slider').bxSlider({
	  mode: 'fade',
	  captions: true,
	  controls: false
	});

	/* Placeholder for older browsers */
	$('input[placeholder], textarea[placeholder]').placeholder();
});