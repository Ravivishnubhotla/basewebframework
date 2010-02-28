
// @source core/menu/DateItem.js

Coolite.Ext.DateItem = function (config) {
    Coolite.Ext.DateItem.superclass.constructor.call(this, new Ext.DatePicker(config.picker || {}), config);
    this.picker = this.component;
    this.addEvents("select");

    this.picker.on("render", function (picker) {
        picker.getEl().swallowEvent("click");
        picker.container.addClass("x-menu-date-item");
    });

    this.picker.on("select", this.onSelect, this);
};

Ext.extend(Coolite.Ext.DateItem, Ext.menu.Adapter, {
    // private
    onSelect : function (picker, date) {
        this.fireEvent("select", this, date, picker);
        Coolite.Ext.DateItem.superclass.handleClick.call(this);
    }
});