$(document).ready(function () {
    $('#slideshowHolder').cycle({
        fx: 'scrollDown',
        speed: 600,
        timeout: 2000
    });
    $('#wallLink').click(function () {
        $('#wallContainer:visible').slideUp();
        $('#wallContainer:hidden').slideDown();
    });
});

var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-26603022-1']);
_gaq.push(['_trackPageview']);

(function () {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
})();