// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#table-contacts').DataTable();

    $('.btn-total-contacts').click(function () {
        var userId = $(this).attr('user-id');

        $.ajax({
            type: 'GET',
            url: '/User/ListContactByUserId/' + userId,
            success: function (result) {
                $("#contactUserList").html(result);
                $('#modalContactUser').modal();
                getDatatable('#table-contacts-user');
            }
        });
    });
})

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});