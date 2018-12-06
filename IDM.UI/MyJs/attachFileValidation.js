$(function () {
    $.validator.setDefaults({
        errorClass: 'help-block',
        highlight: function (element) {
            $(element)
                .closest('.form-group')
                .addClass('has-error');
        },
        unhighlight: function (element) {
            $(element)
                .closest('.form-group')
                .removeClass('has-error');
        },
    });

    $.validator.addMethod('onlyDigit', function (value, element) {
        return this.optional(element)
        || value.length >= 1
        && /^\d+$/.test(value);
    }, 'sadece reqem')
    $("#myform").validate({
        rules: {
            dfTitle: {
                required: true,
            },
            dfPageCount: {
                required: true,
                onlyDigit: true,
            },
            file: {
                required: true,
            }
        },
        messages: {
            dfTitle: {
                required: "Sənədin adını daxil edin!",
            },
            dfPageCount: {
                required: "Səhifə sayısını daxil edin!",
            },
            file: {
                required: "Sənədi yükləyin!",
            },
        }
    });
})