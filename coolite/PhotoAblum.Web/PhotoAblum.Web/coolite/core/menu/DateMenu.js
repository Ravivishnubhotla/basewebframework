
// @source core/menu/DateMenu.js

Coolite.Ext.DateMenu = function (config) {
    Coolite.Ext.DateMenu.superclass.constructor.call(this, config);
    this.plain = true;

    var ae = config.ajaxEvents,
        listeners = config.listeners,
        di;
        
    config.ajaxEvents = undefined;
    config.listeners = undefined;

    di = new Coolite.Ext.DateItem(config);

    config.ajaxEvents = ae;
    config.listeners = listeners;

    this.add(di);
    this.picker = di.picker;
    this.relayEvents(di, ["select"]);

    this.on("beforeshow", function () {
        if (this.picker) {
            this.picker.hideMonthPicker(true);
        }
    }, this);
};

Ext.extend(Coolite.Ext.DateMenu, Ext.menu.Menu, {
    cls : "x-date-menu",

    // private
    beforeDestroy : function () {
        this.picker.destroy();
    }
});