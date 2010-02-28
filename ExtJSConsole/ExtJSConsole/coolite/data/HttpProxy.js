// @source data/HttpProxy.js

Ext.data.HttpProxy.prototype.load = Ext.data.HttpProxy.prototype.load.createInterceptor(function (params, reader, callback, scope, arg) {
    if (this.conn.json) {
        this.conn.jsonData = params;
    }
});