
// @source core/menu/MenuPanel.js

Coolite.Ext.MenuPanel = function (config) {
    Coolite.Ext.MenuPanel.superclass.constructor.call(this, config);
    this.menu.on("itemclick", this.setSelection, this);
};

Ext.extend(Coolite.Ext.MenuPanel, Ext.Panel, {
    saveSelection : true,
    selectedIndex : -1,
    fitHeight     : true,

    initComponent : function () {
        Coolite.Ext.MenuPanel.superclass.initComponent.call(this);

        if (this.selectedIndex > -1) {
            this.menu.items.get(this.selectedIndex).ctCls = "x-menu-item-active";
            this.getSelIndexField().setValue(this.selectedIndex);
        }

        this.menu.on("mouseout", this.onMenuMouseOut, this);
    },

    onMenuMouseOut : function (menu, e, t) {        
        if (!this.saveSelection) {
            return;
        }
        
        var index = this.menu.items.indexOf(t),
            selIndex = this.getSelIndexField().getValue();
            
        if (selIndex.length > 0 && index == selIndex) {
            t.container.addClass("x-menu-item-active");
        }
    },

    setSelectedIndex : function (index) {
        this.setSelection(this.menu.items.get(index));
    },

    getSelIndexField : function () {
        if (!this.selIndexField) {
            this.selIndexField = new Ext.form.Hidden({ 
                id   : this.id + "_SelIndex", 
                name : this.id + "_SelIndex" 
            });
        }
        
        return this.selIndexField;
    },

    setSelection : function (item, e) {
        if (this.saveSelection) {
            this.menu.items.each(function (item) {
                item.container.removeClass("x-menu-item-active");
            }, this.menu);

            item.container.addClass("x-menu-item-active");
        }

        this.getSelIndexField().setValue(this.menu.items.indexOf(item));
    },

    afterRender : function () {
        Coolite.Ext.MenuPanel.superclass.afterRender.call(this);
        
        var lay = this.menu.getEl();
        
        if (Ext.isIE) {
            lay.shadow = false;
        }

        this.body.appendChild(lay);
        lay.clearPositioning("auto");
        
        if (this.fitHeight) {
            lay.setSize("auto", "100%");
        } else {
            lay.setWidth("auto");
        }
        
        lay.applyStyles({ border : "0px" });
        lay.show();
        this.getSelIndexField().render(this.el.parent() || this.el);
    }
});

Ext.reg("coolitemenupanel", Coolite.Ext.MenuPanel);