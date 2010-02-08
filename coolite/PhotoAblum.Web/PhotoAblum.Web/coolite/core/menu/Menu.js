
// @source core/menu/Menu.js

Ext.override(Ext.menu.Menu, {
    lastTargetIn : function (cmp) {
        return Ext.fly(cmp.getEl ? cmp.getEl() : cmp).contains(this.trg);
    },

    createEl : function () {
        var frm = document.body;
        
        /*
            If one <form>, then assume we're in a <form runat="server">
        */
        if (document.forms.length == 1) {
            frm = document.forms[0];
        }        
        
        return new Ext.Layer({
            cls       : "x-menu",
            shadow    : this.shadow,
            shim      : this.shim || true,
            constrain : false,
            parentEl  : this.parentEl || frm,
            zindex    : 15000
        });
    },
        
    autoWidth : function () {
        var el = this.el, 
            ul = this.ul, 
            w = this.width, 
            m = this.minWidth,
            t;
            
        if (!el) {
            return;
        }
        
        if (w) {
            el.setWidth(w);
        } else if (Ext.isIE && !Ext.isIE8) {
            el.setWidth(this.minWidth);
            t = el.dom.offsetWidth; // force recalc
            el.setWidth(ul.getWidth() + el.getFrameWidth("lr"));
        } else if (m && m > (el.getWidth() + el.getFrameWidth("lr"))) {
            el.setWidth(m);
        }
    }
});