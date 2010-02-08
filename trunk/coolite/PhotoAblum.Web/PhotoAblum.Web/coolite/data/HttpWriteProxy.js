
// @source data/HttpWriteProxy.js

Coolite.Ext.HttpWriteProxy = function (conn) {
    Coolite.Ext.HttpWriteProxy.superclass.constructor.call(this);
    this.conn = conn;
    this.useAjax = !conn || !conn.events;
    
    if (conn && conn.handleSaveResponseAsXml) {
        this.handleSaveResponseAsXml = conn.handleSaveResponseAsXml;
    }
};

Ext.extend(Coolite.Ext.HttpWriteProxy, Ext.data.HttpProxy, {
    handleSaveResponseAsXml : false,
    save : function (params, reader, callback, scope, arg) {
        if (this.fireEvent("beforesave", this, params) !== false) {
            var o = {
                params   : params || {},
                request  : {
                    callback : callback,
                    scope    : scope,
                    arg      : arg
                },
                reader   : reader,
                scope    : this,
                callback : this.saveResponse
            };
            
            if (this.useAjax) {
                Ext.applyIf(o, this.conn);
                o.url = this.conn.url;
                
                if (this.activeRequest) {
                    Ext.Ajax.abort(this.activeRequest);
                }
                this.activeRequest = Ext.Ajax.request(o);
            } else {
                this.conn.reequest(o);
            }
        } else {
            callback.call(scope || this, null, arg, false);
        }
    },

    saveResponse : function (o, success, response) {
        delete this.activeRequest;
        
        if (!success) {
            this.fireEvent("saveexception", this, o, response, { message : response.statusText });
            o.request.callback.call(o.request.scope, null, o.request.arg, false);
            return;
        }
        
        var result;
        
        try {
            if (!this.handleSaveResponseAsXml) {
                var json = response.responseText,
                    responseObj = eval("(" + json + ")");
                    
                result = {
                    success : responseObj.Success,
                    msg     : responseObj.Msg,
                    data    : responseObj.Data
                };
            }
            else {
                var doc = response.responseXML,
                    root = doc.documentElement || doc,
                    q = Ext.DomQuery,
                    sv = q.selectValue("Success", root, false);
                    
                success = sv !== false && sv !== "false";
                
                result = { success : success, msg : q.selectValue("Msg", root, "") };
            }
        } catch (e) {
            this.fireEvent("saveexception", this, o, response, e);
            o.request.callback.call(o.request.scope, null, o.request.arg, false);
            return;
        }
        
        this.fireEvent("save", this, o, o.request.arg);
        o.request.callback.call(o.request.scope, result, o.request.arg, true);
    }
});