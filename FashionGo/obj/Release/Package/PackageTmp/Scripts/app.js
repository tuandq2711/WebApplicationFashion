(function ($) {
    $(document).ready(function () {
        $('.link').tooltip();
    });
})(jQuery);


jQuery(function ($) {

    $(window).load(function () {

        var sporganiclife = $('#sp-smart-slider.sp-awetive-layout').find('.sp-slider-items');

        $('#sp-smart-slider .controller-prev').on('click', function () {
            sporganiclife.spSmartslider('prev');
        });


        $('#sp-smart-slider .controller-next').on('click', function () {
            sporganiclife.spSmartslider('next');
        });
    });



    $(window).on('scroll', function () {


    });

    var spAwetiveLayout = $('#sp-smart-slider.sp-awetive-layout').find('.sp-slider-items');
    var spAwetiveIndicators = $('#sp-smart-slider.sp-awetive-layout').find('.slide-indicators > li');

    spAwetiveLayout.spSmartslider({
        autoplay: 1,
        interval: 8000,
        delay: 0,
        fullWidth: false
    });


    var OldTime;

    spAwetiveIndicators.on('click', function (event) {
        event.stopPropagation();

        if (OldTime) {
            var DiffTime = event.timeStamp - OldTime;
            if (DiffTime < 1000) {
                return false;
            }
        }

        OldTime = event.timeStamp;

        spAwetiveLayout.spSmartslider('goTo', $(this).index());
        //spAwetiveIndicators.removeClass('active');
        //$(this).addClass('active');
    });

    spAwetiveLayout.spSmartslider('onSlide', function (index) {
        //spAwetiveIndicators.removeClass('active');
        //spAwetiveIndicators.get(index).addClass('active');
    });

    $('.slide-indicators > li').click(function () {
        var hasClass = $('.slide-indicators > li').hasClass('active');
        spAwetiveIndicators.removeClass('active');
        $(this).addClass('active');
    })

});
