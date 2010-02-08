
// @source core/menu/ColorMenu.js

Coolite.Ext.ColorMenu = function (config) {
    Coolite.Ext.ColorMenu.superclass.constructor.call(this, config);
    this.plain = true;
    var ci = new Coolite.Ext.ColorItem(config);
    this.add(ci);
    this.palette = ci.palette;
};

Ext.extend(Coolite.Ext.ColorMenu, Ext.menu.Menu);