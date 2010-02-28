
// @source data/DataSourceProxy.js

Coolite.Ext.DataSourceProxy = function () {
    Coolite.Ext.DataSourceProxy.superclass.constructor.call(this);
};

Ext.extend(Coolite.Ext.DataSourceProxy, Ext.data.DataProxy, {
    ro          : {},
    isDataProxy : true,
    load        : function (params, reader, callback, scope, arg) {
        if (this.fireEvent("beforeload", this, params) !== false) {
            this.ro = {
                params   : params || {},
                request  : {
                    callback : callback,
                    scope    : scope,
                    arg      : arg
                },
                reader   : reader,
                callback : this.loadResponse,
                scope    : this
            };

            var config = {}, 
                ac = scope.ajaxEventConfig;
                
            ac.userSuccess = this.successHandler;
            ac.userFailure = this.errorHandler;
            ac.extraParams = params;
            ac.enforceFailureWarning = !this.hasListener("loadexception");

            Ext.apply(config, ac, { control : scope, eventType : "postback", action : "refresh" });
            Coolite.AjaxEvent.request(config);
        } else {
            callback.call(scope || this, null, arg, false);
        }
    },

    successHandler : function (response, result, context, type, action, extraParams) {
        var p = context.proxy;

        try {
            var responseObj = result.serviceResponse;
            result = { success : responseObj.Success, msg : responseObj.Msg || null, data : responseObj.Data || {} };
        } catch (e) {
            context.fireEvent("loadexception", context, {}, response, e);
            p.ro.request.callback.call(p.ro.request.scope, null, p.ro.request.arg, false);
            if (p.ro.request.scope.showWarningOnFailure) {
                Coolite.AjaxEvent.showFailure(response, e.message);
            }
            return;
        }

        if (result.success === false) {
            context.fireEvent("loadexception", context, {}, response, { message : result.msg });
            p.ro.request.callback.call(p.ro.request.scope, null, p.ro.request.arg, false);
            
            if (p.ro.request.scope.showWarningOnFailure) {
                Coolite.AjaxEvent.showFailure(response, result.msg);
            }
            
            return;
        }

        try {
            var meta = p.ro.reader.meta;

            if (Ext.isEmpty(meta.totalProperty)) {
                meta.totalProperty = "totalCount";
            }

            if (Ext.isEmpty(meta.root)) {
                meta.root = "data";
            }

            if (Ext.isEmpty(result.data[meta.root])) {
                result.data[meta.root] = [];
            }

            if (p.ro.reader.isArrayReader) {
                result = p.ro.reader.readRecords(result.data.data);
            } else {
                result = p.ro.reader.readRecords(result.data);
            }

        } catch (ex) {
            p.fireEvent("loadexception", p, p.ro, response, ex);
            p.ro.request.callback.call(p.ro.request.scope, null, p.ro.request.arg, false);
            
            if (p.ro.request.scope.showWarningOnFailure) {
                Coolite.AjaxEvent.showFailure(response, ex.message);
            }
            
            return;
        }
        p.fireEvent("load", p, p.ro, p.ro.request.arg);
        p.ro.request.callback.call(p.ro.request.scope, result, p.ro.request.arg, true);

    },

    errorHandler : function (response, result, context, type, action, extraParams) {
        var p = context.proxy;
        
        p.fireEvent("loadexception", p, p.ro, response);
        p.ro.request.callback.call(p.ro.request.scope, null, p.ro.request.arg, false);
        
        if (p.ro.request.scope.showWarningOnFailure) {
            Coolite.AjaxEvent.showFailure(response, response.responseText);
        }
    }
});