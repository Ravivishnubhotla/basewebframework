
// @source core/Viewport.js

/**
* @class Coolite.Ext.Viewport
* @extends Ext.Container
* A specialized contentContainer representing the viewable application area (the browser viewport).<br/>
*/
Coolite.Ext.Viewport = Ext.extend(Ext.Container, {
    initComponent : function () {
        Coolite.Ext.Viewport.superclass.initComponent.call(this);
        var html = document.getElementsByTagName("html")[0];
        html.className += " x-viewport";
        html.style.height = "100%";
        this.el = Ext.get(this.renderTo || document.forms[0]);
        this.el.setHeight = this.el.setWidth = this.el.setSize = Ext.emptyFn;
        this.el.dom.scroll = "no";
        this.allowDomMove = false;
        this.autoWidth = this.autoHeight = true;
        Ext.EventManager.onWindowResize(this.fireResize, this);
        this.renderTo = this.el;
        
        Ext.getBody().applyStyles({
            overflow : "hidden",
            margin   : "0",
            padding  : "0",
            border   : "0px none",
            height   : "100%"
        });
        
        this.el.applyStyles({ height : "100%", width : "100%" });
    },

    fireResize : function (w, h) {
        this.fireEvent("resize", this, w, h, w, h);
    }
});

Ext.reg("cooliteviewport", Coolite.Ext.Viewport);