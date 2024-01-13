// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    // Enable jQuery functions 
    $('#testTab').tabs();
    $('#testAcc').accordion();
    $('#pepTab').tabs();
    $('#underAcc').accordion({ heightStyle: 'panel' });
    $('#gradAcc').accordion({ heightStyle: 'panel' });
    $('#minors').accordion({ heightStyle: 'panel' });
    $('#NewsAcc').accordion({ heightStyle: 'panel' });
    new DataTable("#coopTableTable");
    new DataTable("#employmentTableTable");

    // turn everything on
    $('#allPeople').fadeIn(1000);
    $('#allDegrees').fadeIn(1000);
    $('#minors').fadeIn(1000);
    $('#employment').fadeIn(1000);
    $('#allNews').fadeIn(1000);
});

/**
 * Enables the popup for the Minors.cshtml page
 */
$('.course').magnificPopup({
    type: 'inline',
    midClick: true
})