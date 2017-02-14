$(function () {

    $("#drop-currency li a").click(function () {

        $("#currency").text("currency: " + $(this).text());
        $("#currency").val($(this).text());
    });


    $("#drop-language li a").click(function () {

        $("#language").text("language: " + $(this).text());
        $("#language").val($(this).text());
    });


    $("#drop-category li a").click(function () {

        $("#category").text($(this).text());
        $("#category").val($(this).text());


        search = $(".search-field").val();
        cat = $("#category").val();

        //if (cat == 'undefined' || cat == "Categories" ||cat == null || cat=="") {
        //    cat =null;
        //}

        $.ajax({
            type: "post",
            url: "/Home/Search",
            data: { keywork: search, cat: cat },
            success: function (res) {
                //$(".homebanner-holder").html("");
                $(".homebanner-holder").html(res).replaceAll();
            }
        });
        
    });


});