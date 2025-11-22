// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//given function is jquery code to show the datePicker 
$(function () {

    $("#petAdoptedDate").datepicker({
        dateFormat: "dd-mm-yy"   // jQuery UI syntax
    });
});