
// @source core/form/AjaxMethod.js

Coolite.AjaxMethod = {
    request : function (name, options) {
        options = options || {};

        if (typeof options !== "object") {
            /*LOCALIZE*/
            throw { message : "The AjaxMethod options object is an invalid type: typeof " + typeof options };
        }

        if (!Ext.isEmpty(name) && typeof name === "object" && Ext.isEmptyObj(options)) {
            options = name;
        }

        var obj = {
            name              : options.cleanRequest ? undefined : (options.name || name),
            cleanRequest      : options.cleanRequest,
            url               : options.url,
            control           : Ext.isEmpty(options.control) ? null : { id : options.control },
            eventType         : options.specifier || "public",
            type              : options.type || "submit",
            method            : options.method || "POST",
            eventMask         : options.eventMask,
            extraParams       : options.params,
            ajaxMethodSuccess : options.success,
            ajaxMethodFailure : options.failure,
            viewStateMode     : options.viewStateMode,
            userSuccess       : function (response, result, control, eventType, action, extraParams, o) {
                if (!Ext.isEmpty(o.ajaxMethodSuccess)) {
                    result = Ext.isEmpty(result.result, true) ? (result.d || result) : result.result;
                    o.ajaxMethodSuccess(result, response, extraParams, o);
                }
            },
            userFailure       : function (response, result, control, eventType, action, extraParams, o) {
                if (!Ext.isEmpty(o.ajaxMethodFailure)) {
                    o.ajaxMethodFailure(result.errorMessage, response, extraParams, o);
                }
            }
        };

        Coolite.AjaxEvent.request(Ext.apply(options, obj));
    }
};