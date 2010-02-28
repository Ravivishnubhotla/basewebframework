
// @source core/menu/EditMenuItem.js

Coolite.Ext.EditMenuItem = function (config) {
    Coolite.Ext.EditMenuItem.superclass.constructor.call(this, new Ext.form.TextField(config.textbox), config);
    this.textbox = this.component;
    this.addEvents("select");
    
    this.textbox.on("render", function (textbox) {
        textbox.getEl().swallowEvent("click");
    });
};

Ext.extend(Coolite.Ext.EditMenuItem, Ext.menu.Adapter, {
    onRender : function (container) {
        Coolite.Ext.EditMenuItem.superclass.onRender.call(this, container);

        this.el.swallowEvent(["keydown", "keypress"]);
        
        Ext.each(["keydown", "keypress"], function (eventName) {
            this.el.on(eventName, function (e) {
                if (e.isNavKeyPress()) {
                    e.stopPropagation();
                }
            }, this);
        }, this);

        if (Ext.isGecko) {
            this.el.setOverflow("auto");
            var containerSize = container.getSize();
            this.textbox.getEl().setStyle("position", "fixed");
            container.setSize(containerSize);
        }
    }
});