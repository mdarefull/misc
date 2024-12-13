$(document).ready(function () {
    var bodyId = "#topicViewBody";
    var collapseIconClass = ".collapseIcon";

    // Animate the collapse icons.
    $(bodyId + " " + collapseIconClass).click(function (e) {
        $(e.currentTarget).toggleClass("glyphicon-collapse-down")
                          .toggleClass("glyphicon-collapse-up");
    });
});