﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("navbar-logout.logout").fadeOut();
    $("navbar-login.login").click(function () {
        $("navbar-login.login").fadeIn();
    });
});