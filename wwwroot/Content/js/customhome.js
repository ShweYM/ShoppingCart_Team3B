// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {

    "use strict"

    var init = "";
    var counter = 0;

    // Initial Cart
    $("#counter").html(init);

    // Add Items To Basket
    function addToBasket() {
        counter++;
        $("#counter").html(counter).animate({
            'opacity': '0'
        }, 300, function () {
            $("#counter").delay(300).animate({
                'opacity': '1'
            })
        })
    }

    // Add To Basket Animation
    $("button").on("click", function () {
        addToBasket(); $(this).parent().parent().find(".product_overlay").css({
            'transform': ' translateY(0px)',
            'opacity': '1',
            'transition': 'all ease-in-out .45s'
        }).delay(1500).queue(function () {
            $(this).css({
                'transform': 'translateY(-500px)',
                'opacity': '0',
                'transition': 'all ease-in-out .45s'
            }).dequeue();
        });
    });

    //Search
    //function keySearch(e) {
    //    clearTimeout(timeout);

    //    timeout = setTimeout(() => {
    //        Search(e);
    //    }, 500);
    //}

    //function Search() {
    //    productname = $('#txt_productname').val().trim();
    //    productlist();
    //}



    //var currentRequest;
    //function productlist() {
    //    currentRequest = $.ajax({
    //        cache: false,
    //        url: '@Url.Action("SearchProduct", "Home")',
    //        data: { productname:productname },

    //        beforeSend: function () {
    //            if (currentRequest != null) {
    //                currentRequest.abort();
    //            }
    //            isLoading = true;
    //            hasResult = false;
    //            loading.show();
    //        },
    //        success: function () {
    //            window.location()                             
    //        },
    //        complete: function () {
    //            isLoading = false;
    //            loading.hide();
    //        }
    //    });
    //}

    HomeView();

});

function HomeView() {
    $.ajax({
        cache: false,
        url: '@Url.Action("HomeViewIndex", "Home")',
        data: {},

        beforeSend: function () {

        },
        success: function (result) {
            if (result != null) {
                $('#div_HomeView').empty().append(result)
            }
            else {
                alert("Fail");
            }
        },
        complete: function () {

        }
    });
}

function Add() {
    $.ajax({
        cache: false,
        url: '@Url.Action("HomeViewIndex", "Home")',
        data: {},

        beforeSend: function () {

        },
        success: function (result) {
            if (result != null) {
                $('#div_HomeView').empty().append(result)
            }
            else {
                alert("Fail");
            }
        },
        complete: function () {

        }
    });
}

