$(document).ready(function ()
{
    $("navbar-logout.logout").fadeOut();
    $("navbar-login.login").click(function () {
        $("navbar-login.login").fadeIn();
    });
}
);