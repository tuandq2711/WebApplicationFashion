// Add to cart button
jQuery(function ($) {

    $("ul#productTab li a").on('shown.bs.tab', function (e) {
        var isTab = $(this).attr('href');
        var reviewTab = $('#review-tab').val();
        if (isTab == '#reviews' && reviewTab == 0) {
            $('#review-tab').val(1);
            loadReviewPagination();
        }
    });

    $(document).ready(function () {
        $(".review-pagination-list").eshopPagination({
            containerID: "wrap-review",
            perPage: 5,
        });
    });


    $(document).ready(function () {

        $("#cart-item").load("/Cart/_PartialCart");

    });


    jQuery(function ($) {
        $(document).delegate(".quantity, .spquantity", "change", function () {
            pid = $(this).attr("data-id");
            qty = $(this).val();
            $.ajax({
                url: "/Cart/Update",
                data: { id: pid, quantity: qty },
                success: function (response) {
                    $("#eshop-cart-total").text($.number(response.Count));
                    $("#Amount-" + pid).text($.number(response.Amount));
                    $(".nn-cart-total").text($.number(response.Total));
                    $("#cart-item").load("/Cart/_PartialCart");
                },
                complete: function () {
                    updateOrderSummary();
                }
            });
        });
    });


});

function deleteFromCart(pid) {
    var tr = jQuery(".row-" + pid);
    jQuery.ajax({
        url: "/Cart/Remove",
        data: { id: pid },
        beforeSend: function () {
            jQuery('.wait').html('<img src="Assets/Frontend/components/com_eshop/assets/images/loading.gif" alt="" />');
        },
        success: function (response) {
            jQuery('.wait').html('');
            jQuery("#eshop-cart-total").text(response.Count);

            jQuery("#cart-item").load("/Cart/_PartialCart");
            if (tr.length) {
                tr.remove();
            }
            //tr.hide(500);
        },
        complete: function () {
            updateOrderSummary();
        }
    });
    return false;
}

function flyToCart(pid) {

    var ty = jQuery("#addToCart").closest('.product').find('#' + pid);
    var img = jQuery("#product-image-" + pid);
    quatity = jQuery('#quantity_' + pid).val();
    if (quatity == 'undefined' || quatity == null) {
        quatity = 1;
    }

    jQuery.ajax({
        type: 'GET',
        dataType: 'json',
        url: 'Cart/Add',
        data: { id: pid, quatity: quatity },
        beforeSend: function () {
            jQuery('.add-to-cart').attr('disabled', true);
            jQuery('.add-to-cart').after('<span class="wait">&nbsp;<img src="Assets/Frontend/components/com_eshop/assets/images/loading.gif" /></span>');
        },
        complete: function () {
            jQuery('.add-to-cart').attr('disabled', false);
            jQuery('.wait').remove();
        },
        success: function (result) {
            //alert(result.Count);
            jQuery("#eshop-cart-total").text(result.Count);
        }
    }).done(function (response) {
        //Load giỏ hàng
        jQuery("#cart-item").load("/Cart/_PartialCart")

        flyToElement(jQuery(img), jQuery('#eshop-cart'));

        jQuery("html, body").animate({ scrollTop: 0 }, 2000);

        //Mở giỏ hàng
        //jQuery('.eshop-content').slideToggle();

        //Đóng giỏ hàng sau 8s
        setTimeout(function () {
            //jQuery('.eshop-content').hide();
        }, 8000);

    }).fail(function () {
        alert("fail");
    });

    return false;
}


function updateOrderSummary() {

    jQuery.ajax({
        url: '/Order/getOrderInfo',
        type: 'Get',
        dataType: 'json',
        success: function (response) {
            jQuery("#orderTransportCost").text(jQuery.number(response.TransportCost) + "đ");
            jQuery("#orderDiscount").text(jQuery.number(response.Discount) + "đ");
            jQuery("#totalOrder").text(jQuery.number(response.OrderTotal) + "đ");
            jQuery("#discountDescription").html(response.DiscountDescription);
        },
        error: function (err) {
            alert("Lỗi hệ thống, ấn F5 để refresh lại trình duyệt để tiếp tục.");
        }
    });
}



function flyToElement(flyer, flyingTo, callBack /*callback is optional*/) {

    var func = jQuery(this);

    var divider = 3;

    var flyerClone = jQuery(flyer).clone();

    jQuery(flyerClone).css({
        position: 'absolute',
        width: '80px',
        height: 'auto',
        top: (jQuery(flyer).offset().top + (jQuery(flyer).width() / 2)) + "px",
        left: (jQuery(flyer).offset().left + (jQuery(flyer).height() / 2)) + "px",
        opacity: 1,
        'z-index': 1000
    });

    jQuery('body').append(jQuery(flyerClone));

    var gotoX = jQuery(flyingTo).offset().left + (jQuery(flyingTo).width() / 2) - (jQuery(flyerClone).width() / divider) / 2;
    var gotoY = jQuery(flyingTo).offset().top + (jQuery(flyingTo).height() / 2) - (jQuery(flyerClone).height() / divider) / 2;

    jQuery(flyerClone).animate({
        opacity: 0.4,
        left: gotoX,
        top: gotoY,
        width: jQuery(flyerClone).width() / divider,
        height: jQuery(flyerClone).height() / divider
    }, 700,
    function () {
        jQuery(flyingTo).fadeOut('fast', function () {
            jQuery(flyingTo).fadeIn('fast', function () {
                jQuery(flyerClone).fadeOut('fast', function () {
                    jQuery(flyerClone).remove();
                    if (callBack != null) {
                        callBack.apply(func);
                    }
                });
            });
        });
    });

    return false;
}

function flyFromElement(flyer, flyingTo, callBack /*callback is optional*/) {
    var func = jQuery(this);

    var divider = 3;

    var beginAtX = jQuery(flyingTo).offset().left + (jQuery(flyingTo).width() / 2) - (jQuery(flyer).width() / divider) / 2;
    var beginAtY = jQuery(flyingTo).offset().top + (jQuery(flyingTo).width() / 2) - (jQuery(flyer).height() / divider) / 2;

    var gotoX = jQuery(flyer).offset().left;
    var gotoY = jQuery(flyer).offset().top;

    var flyerClone = jQuery(flyer).clone();

    jQuery(flyerClone).css({
        position: 'absolute',
        top: beginAtY + "px",
        left: beginAtX + "px",
        opacity: 0.4,
        'z-index': 1000,
        width: jQuery(flyer).width() / divider,
        height: jQuery(flyer).height() / divider
    });
    jQuery('body').append(jQuery(flyerClone));

    jQuery(flyerClone).animate({
        opacity: 1,
        left: gotoX,
        top: gotoY,
        width: jQuery(flyer).width(),
        height: jQuery(flyer).height()
    }, 700,
    function () {
        jQuery(flyerClone).remove();
        jQuery(flyer).fadeOut('fast', function () {
            jQuery(flyer).fadeIn('fast', function () {
                if (callBack != null) {
                    callBack.apply(func);
                }
            });
        });
    });

    return false;
}
