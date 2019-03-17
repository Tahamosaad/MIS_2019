$(document).ready(function () {
    $(document).ready(function () {

        $('#topMenu > ul > li > a').click(function () {
            $('#topMenu ul').removeClass('active');
            $(this).closest('ul').addClass('active');

            var checkElement = $(this).next().next();
            if ((checkElement.is('#categoryNav')) && (checkElement.is(':visible'))) {
                $(this).closest('ul').removeClass('active');
                $(this).closest("#categoryNav").slideUp('normal');
            }
            if ((checkElement.is('#categoryNav')) && (!checkElement.is(':visible'))) {
                $(this).closest("#categoryNav").slideDown('normal');
            }
            if ($(this).closest('li').find('ul').children().length == 0) {
                return true;
            } else {
                return false;
            }
        });

    });

});