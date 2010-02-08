
// @source core/menu/DatFieldMenuItem.js

Coolite.Ext.DateFieldMenuItem = function (config) {
    Coolite.Ext.DateFieldMenuItem.superclass.constructor.call(this, new Ext.form.DateField(config.dateField), config);
    this.dateField = this.component;
    
    this.dateField.menu = new Ext.menu.DateMenu({
        allowOtherMenus : true
    });

    this.dateField.on("render", function (dateField) {
        dateField.getEl().swallowEvent("click");
    });
};

Ext.extend(Coolite.Ext.DateFieldMenuItem, Ext.menu.Adapter, {
    hideOnClick : false,
    canActivate : false,
    
    onRender    : function (container) {
        Coolite.Ext.DateFieldMenuItem.superclass.onRender.call(this, container);

        this.el.swallowEvent(["keydown", "keypress"]);
        
        Ext.each(["keydown", "keypress"], function (eventName) {
            this.el.on(eventName, function (e) {
                if (e.isNavKeyPress()) {
                    e.stopPropagation();
                }
            }, this);
        }, this);

        if (Ext.isGecko) {
            container.setOverflow("auto");
            var containerSize = container.getSize();
            this.dateField.wrap.setStyle("position", "fixed");
            container.setSize(containerSize);
        }
    }
});