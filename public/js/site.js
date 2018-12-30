$(document).ready(function() {

    /* Slider image */
    $("#slider").backstretch("../img/workspace_quote.jpg");


    /* Stiky navigation */
    var sticky = new Waypoint.Sticky({
        element: $('#sticky-navigation-wrap'),
        stuckClass: 'sticky',
        offset: -300
    });

    /* Animate smooth scroll on page */
    $('.navbar ul li a').bind("click",
        function(e) {
            e.preventDefault();

            var topOffset = -80;
            if (this.hash === '#features') {
                topOffset = -260;
            }

            $('html, body').animate({
                scrollTop: $(this.hash).offset().top + topOffset
            }, 100, 'linear');
        });

    /* Features tabs */
    $('#featuresTab a').click(function(e) {
        e.preventDefault();
        $(this).tab('show');
    });

    /* testimonial */
    $('.testimonials-slider').slick({
        infinite: false,
        dots: true,
        arrows: false
    });

    /* Placeholder for older browsers */
    $('input[placeholder], textarea[placeholder]').placeholder();

    var errorMessage = $('#error-message').val();
    if (errorMessage !== '') {
        humane.log(errorMessage, { addnCls: 'humane-jackedup-error' });
    }

    var successMessage = $('#success-message').val();
    if (successMessage !== '') {
        humane.log(successMessage, { addnCls: 'humane-jackedup-success' });
    }
});
