// JavaScript for animations and form handling
$(document).ready(function () {
    // Button hover animations
    $('.btn-animated').hover(
        function () {
            $(this).addClass('animate__animated animate__pulse');
        },
        function () {
            $(this).removeClass('animate__animated animate__pulse');
        }
    );

    // Fade in main content
    $('main').addClass('animate__animated animate__fadeIn');
});