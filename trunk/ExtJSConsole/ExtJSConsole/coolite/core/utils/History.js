
// @source core/utils/History.js

Ext.History.init = Ext.History.init.createInterceptor(function (onReady, scope) {
    if (this.listeners) {
        this.on(this.listeners);
        delete this.listeners;
    }
});