// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#surveyTable').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/2.1.3/i18n/tr.json'
        }
    });

    $('#deletedSurveyTable').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/2.1.3/i18n/tr.json'
        }
    });
});
