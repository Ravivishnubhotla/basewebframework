
// @source core/menu/ColorItem.js

Coolite.Ext.ColorItem = function (config) {
    Coolite.Ext.ColorItem.superclass.constructor.call(this, new Ext.ColorPalette(config.palette), config);
    this.palette = this.component;
    this.relayEvents(this.palette, ["select"]);

    if (this.selectHandler) {
        this.on("select", this.selectHandler, this.scope);
    }
};

Ext.extend(Coolite.Ext.ColorItem, Ext.menu.Adapter);