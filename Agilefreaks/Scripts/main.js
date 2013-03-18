$(document).ready(function () {

    /* Slider image */
    $("#slider").backstretch("../Content/img/workspace_01.jpg");


    /* Stiky navigation */

    $('#sticky-navigation-wrap').waypoint('sticky', {
        stuckClass: 'sticky',
        offset: -300
    });

    /* Animate smooth scroll on page */
    $('.navbar ul li a').bind("click", function (e) {
        e.preventDefault();
        target = this.hash;

        topOffset = -100;
        if ($(this).hasClass('features')) {
            topOffset = -160;
        }
        $.scrollTo(target, 1000, { offset: topOffset });

    })


    /* Features tabs */
    $('#featuresTab a').click(function (e) {
        e.preventDefault();
        $(this).tab('show');
    })

    /* testimonial */
    $('.testimonials-slider').bxSlider({
        mode: 'fade',
        captions: true,
        controls: false
    });

    /* Placeholder for older browsers */
    $('input[placeholder], textarea[placeholder]').placeholder();

    /* notification */
    var notification = $('#notification').val();
    if (notification != '') {
        humane.log(notification);
    }
});