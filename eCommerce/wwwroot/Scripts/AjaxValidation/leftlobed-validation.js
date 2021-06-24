
(function ($, $validator) {
    //$validator = $validator || $.validator;
    //if ($validator) {
    //    $validator.addMethod("serverError", function (value, element) {
    //        return this.optional(element) || $(element).data("serverError-value") != value;
    //    }, $validator.format("{0} is not a valid value"));
    //}

    //$.ajaxPrefilter(function (options, originalOptions, jqXHR) {
    //    // Based on: http://lithostech.com/2011/04/jquery-deferreds-and-the-jquery-promise-method/
    //    var jqXHRWrapper = $.Deferred(function (defer) {
    //        jqXHR
    //            .done(defer.resolve)
    //            .fail(function(jqXHR, status, thrownError) {
    //                jqXHR.isResponseValidationErrors = false;
    //                if (thrownError === "Bad Request" &&
    //                    jqXHR.responseJSON &&
    //                    jqXHR.responseJSON.TypeName === "ValidationErrors") {
    //                    jqXHR.isResponseValidationErrors = true;
    //                }
    //                defer.rejectWith(this, [jqXHR, status, thrownError]);
    //            });
    //    });
    //    jqXHRWrapper.promise(jqXHR);
    //    jqXHR.success = jqXHR.done;
    //    jqXHR.error = jqXHR.fail;
    //});

    $(document).ajaxError(function (event, jqXHR, settings, thrownError) {

        if (jqXHR.status === 400 && jqXHR.responseJSON.TypeName === "ValidationErrors") {
            var errors = $(jqXHR.responseJSON.Value);
            errors.each(function () {
                var that = this;
                $('[name="' + that.Key + '"]').each(function () {
                    $(this).data("serverError-value", $(this).val());
                    var form = $(this).closest("form").attr('id');
                    form = form == null ? null : "#" + form;
                    $(form + ' span[data-valmsg-for="' + that.Key + '"]').html(that.Message);
                    $(form + ' input[name="' + that.Key + '"]').css({ "border": "1px red solid" });

                    $('form :input').change(function () {
                        $(form + ' span[data-valmsg-for="' + that.Key + '"]').html("");
                        $(form + ' input[name="' + that.Key + '"]').css({ "border-color": "rgba(29, 37, 59, 0.5)" });
                    });
                    //console.log(form);
                    //if (form.validate) {
                    //    var validator = form.validate();
                    //    validator.element(this);
                    //}
                });
            });
        }
    });

})(jQuery, jQuery.validator);
