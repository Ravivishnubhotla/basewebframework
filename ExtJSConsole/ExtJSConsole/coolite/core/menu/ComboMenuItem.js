
// @source core/menu/ComboMenuItem.js

Coolite.Ext.ComboMenuItem = function (config) {
    Coolite.Ext.ComboMenuItem.superclass.constructor.call(this, new Ext.form.ComboBox(config.combobox), config);
    this.combo = this.component;
    this.addEvents("select");
    
    this.combo.on("render", function (combo) {
        combo.getEl().swallowEvent("click");
        
        if (combo.list) {
            combo.list.applyStyles("z-index:99999");
            combo.list.on("mousedown", function (e) {
                Ext.lib.Event.stopPropagation(e);
            });
        }
    });
};

Ext.extend(Coolite.Ext.ComboMenuItem, Ext.menu.Adapter, {
    hideOnClick : false,
    
    onSelect    : function (combo, record) {
        this.fireEvent("select", this, record);
        Coolite.Ext.ComboMenuItem.superclass.handleClick.call(this);
    },
    
    onRender : function (container) {
        Coolite.Ext.ComboMenuItem.superclass.onRender.call(this, container);

        if (Ext.isIE && this.combo.list) {
            this.combo.list.shadow = false;
        }

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
            this.combo.wrap.setStyle("position", "fixed");
            container.setSize(containerSize);
        }
    }
});