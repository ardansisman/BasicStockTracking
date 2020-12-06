$(document).ajaxStart(function () {
    $("#btnGonder").attr("disabled", true);
    $(".modal-ajax-start").show();
});

$(document).ajaxStop(function () {
    $("#btnGonder").removeAttr("disabled");
    $(".modal-ajax-start").hide();
});

$("#btnGonder").click(function () {
    
    var formData = $("#formLoginAJAX").serializeArray();
    var postData = {};
    for (item in formData) {
        postData[formData[item].name] = formData[item].value;
    }
    var ajaxUrl = $(this).data("url");

    $.ajax({
        url: ajaxUrl,
        method: "POST",
        data: postData,
        dataType: JSON,
        success: function (response) {
            if (response.success) {
                window.location.href = "/Home/Info";
                $(".error-message-wrapper").show();
                $(".error-message-wrapper #message").html(response.message);
            }
            else {
                alert(response.message)
            }
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
});