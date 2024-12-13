// 1 - Because I use validations, I will dimiss the model after the form.submit instead than when clicking save.
// 2 - If the modal is dismissed, reset the form data.
$(document).ready(function () {
    var newModalId = "#refNewCreationModal";
    var cancelButtonId = "#addCancelButton";

    var modal = $(newModalId);

    // On modal show, focus on the cancel button.
    modal.on("shown.bs.modal", function () {
        $(cancelButtonId, modal).focus();
    });

    // On form submit, if the form is valid, hide the modal.
    $("form", modal).submit(function (e) {
        var form = $(e.currentTarget);
        if (form.valid())
            modal.modal('hide');
    });

    // On modal hidden, reset the form content.
    modal.on("hidden.bs.modal", function () {
        $("form", modal)[0].reset();
    });
});