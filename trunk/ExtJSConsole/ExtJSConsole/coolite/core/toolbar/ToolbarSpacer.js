
// @source core/toolbar/ToolbarSpacer.js

Coolite.Ext.ToolbarSpacer = function (config) {
    Coolite.Ext.ToolbarSpacer.superclass.constructor.call(this);
    config = config || {};
    this.width = config.width;

    this.render = function (td) {
        Coolite.Ext.ToolbarSpacer.superclass.render.call(this, td);
        if (!Ext.isEmpty(this.width)) {
            Ext.fly(this.el).removeClass("ytb-spacer").setWidth(this.width);
        }
    };
};

Ext.extend(Coolite.Ext.ToolbarSpacer, Ext.Toolbar.Spacer);

Ext.reg("coolitetbspacer", Coolite.Ext.ToolbarSpacer);