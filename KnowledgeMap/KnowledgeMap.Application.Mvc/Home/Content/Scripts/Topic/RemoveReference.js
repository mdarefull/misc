$(document).ready(function () {
    var removeHiddenInputId = "refRemoveHiddenInputId";
    var removeBtnClass = ".refRemoveBtn";
    var btnDataValName = "referenceid";
    var removeModalId = "#refRemovalConfirmationModal";
    var cancelButtonId = "#refRemoveCancelButton";

    var idHiddenInput = document.getElementById(removeHiddenInputId);

    // Set the refId to the hiddenInput when I clicked the button.
    $(removeBtnClass).click(function (e) {
        var refId = e.currentTarget.dataset[btnDataValName];
        idHiddenInput.attributes["value"].value = refId;
    });

    var modal = $(removeModalId);

    // On modal show, focus on the cancel button.
    modal.on("shown.bs.modal", function () {
        $(cancelButtonId).focus();
    });

    // Hide the modal at form submition.
    $("form", modal).submit(function (e) {
        modal.modal('hide');
    })

    // On modal hidden, reset the hiddenInput value for safety reasons.
    modal.on("hidden.bs.modal", function () {
        idHiddenInput.attributes["value"].value = -1;
    });
});