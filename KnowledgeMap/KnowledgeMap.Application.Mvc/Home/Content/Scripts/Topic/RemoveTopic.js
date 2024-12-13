$(document).ready(function () {
    var removeHiddenInputId = "topicRemoveHiddenInputId";
    var removeBtnClass = ".topicRemoveBtn";
    var btnDataValName = "topicid";
    var removeModalId = "#topicRemovalConfirmationModal";
    var cancelButtonId = "#topicRemoveCancelButton";

    var idHiddenInput = document.getElementById(removeHiddenInputId);

    // Set the topicId to the hiddenInput when I clicked the remove button.
    $(removeBtnClass).click(function (e) {
        var topicId = e.currentTarget.dataset[btnDataValName];
        idHiddenInput.attributes["value"].value = topicId;
    });

    var modal = $(removeModalId);

    // On modal show, focus on the cancel button.
    modal.on("shown.bs.modal", function () {
        $(cancelButtonId).focus();
    });

    // Hide the modal at form submition.
    $("form", modal).submit(function (e) {
        modal.modal("hide");
    });

    // On modal hidden, reset the hiddenInput value and the checkboxes for safety reasons.
    modal.on("hidden.bs.modal", function () {
        idHiddenInput.attributes["value"].value = -1;
        $("form", modal)[0].reset();
    });
});