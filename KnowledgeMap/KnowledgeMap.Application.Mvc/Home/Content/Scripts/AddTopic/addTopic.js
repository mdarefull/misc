$(document).ready(function () {
    var bodyId = "#addTopicBody";
    var cancelBtnId = "#addTopicCancelButton";
    $(cancelBtnId).focus();

    var checkboxDataValName = "referenceid";
    var form = $(bodyId + " form");
    var referencesCB = $("input[data-" + checkboxDataValName + "]");

    form.submit(function () {
        if (form.valid()) {
            var j = 0;
            for (var i = 0; i < referencesCB.length; i++) {
                var checkBox = referencesCB[i];
                if (checkBox.checked) {
                    var referenceId = checkBox.dataset[checkboxDataValName];
                    var hidden = $("<input type='hidden' name='References[" + j++ + "].Id' value='" + referenceId + "'/>");
                    form.append(hidden);
                }
            }
        }
    });
});