$(function () {

    /***************/
    $('#zoom').slideUp(0);

    $('.stack img').click(function () {
        $('.zoom').attr("src", $(this).attr("src"));
        $('#zoom').slideDown(1000);
        location.href = "#zoom";
    });

    /***************/

    var banner_element = $('#banner').find('.s_element');
    var size = banner_element.size();

    var t = setInterval(function () { next_back('next'); }, 5000);

    $('#banner .ant').click(function () {
        clearInterval(t)
        next_back('back');
    });

    $('#banner .sgt').click(function () {
        clearInterval(t);
        next_back('next');
    });


    function next_back(type) {
        banner_element.each(function (index, value) {
            if ($(value).hasClass('s_visible')) {
                alternar_efectos($(value), 'out');
                $(value).removeClass('s_visible');

                if (type == "next") {

                    if (index + 1 < size) {
                        alternar_efectos($(banner_element.get(index + 1)), 'in');
                        $(banner_element.get(index + 1)).addClass('s_visible');
                        return false;
                    }
                    else {
                        alternar_efectos($(banner_element.get(0)), 'in');
                        $(banner_element.get(0)).addClass('s_visible');
                        return false;
                    }
                }
                else if (type == "back") {
                    if (index == 0) {
                        alternar_efectos($(banner_element.get(size - 1)), 'in');
                        $(banner_element.get(size - 1)).addClass('s_visible');
                        return false;
                    }
                    else {
                        alternar_efectos($(banner_element.get(index - 1)), 'in');
                        $(banner_element.get(index - 1)).addClass('s_visible');
                        return false;
                    }
                }
            }
        });
    }

    function alternar_efectos(element, efect) {
        var type = Math.floor((Math.random() * 3) + 1);
        console.log(type);
        var time = 1500;
        if (efect == 'out') {
            switch (type) {
                case 1:
                    element.hide(time);
                    break;
                default:
                    element.slideUp(time);
                    break;
            }
        }
        else if (efect == 'in') {
            switch (type) {
                case 1:
                    element.show(time);
                    break;
                case 2:
                    element.slideDown(time);
                    break;
                default:
                    element.fadeIn(time);
                    break;
            }
        }
    }


    /*  EFECTOS DE CARGA    */
    $('img.foto').click(function () { location.href = $(this).attr('alt') });
    var x = $('.item');
    x.find('header').hide(0);
    x.find('aside').hide(0);
    x.find('section').hide(0);
    x.find('footer').hide(0);

    $.each(x, function (index, value) {
        $(value).find('header').delay(200).show(500, function () {
            $(value).find('aside').delay(200).show(500, function () {
                $(value).find('section').delay(200).show(500, function () {
                    $(value).find('footer').delay(200).show(500, function () {

                        $(value).find('header').css({
                            WebkitTransition: 'all 1.5s ease',
                            MozTransition: 'all 1.5s ease',
                            MsTransition: 'all 1.5s ease',
                            OTransition: 'all 1.5s ease',
                            transition: 'all 1.5s ease'
                        });
                        $(value).find('aside').css({
                            WebkitTransition: 'all 1.5s ease',
                            MozTransition: 'all 1.5s ease',
                            MsTransition: 'all 1.5s ease',
                            OTransition: 'all 1.5s ease',
                            transition: 'all 1.5s ease'
                        });
                        $(value).find('section').css({
                            WebkitTransition: 'all 1.5s ease',
                            MozTransition: 'all 1.5s ease',
                            MsTransition: 'all 1.5s ease',
                            OTransition: 'all 1.5s ease',
                            transition: 'all 1.5s ease'
                        });
                        $(value).find('footer').css({
                            WebkitTransition: 'all 1.5s ease',
                            MozTransition: 'all 1.5s ease',
                            MsTransition: 'all 1.5s ease',
                            OTransition: 'all 1.5s ease',
                            transition: 'all 1.5s ease'
                        });

                    });
                });
            });
        });
    });


});