
// @source core/menu/ElementMenuItem.js

Coolite.Ext.ElementMenuItem = function (cfg) {
    this.target = cfg.target;
    Coolite.Ext.ElementMenuItem.superclass.constructor.call(this, cfg);
};

Ext.extend(Coolite.Ext.ElementMenuItem, Ext.menu.BaseItem, {
    hideOnClick   : false,
    itemCls       : "x-menu-item",
    shift         : true,
    targetElement : "element",

    getComponent : function () {
        if (Ext.isEmpty(this.baseEl.id)) {
            return null;
        }
        
        var cmp = Ext.getCmp(this.baseEl.id);
        
        if (Ext.isEmpty(cmp)) {
            return null;
        }
        
        return cmp;
    },

    // private
    onRender : function (container) {
        if (this.target.getEl) {
            this.el = this.target.getEl();
        } else {
            this.el = Ext.get(this.target);
        }
        
        var cmp = Ext.getCmp(this.el.id);       
        
        this.parentMenu.on("show", function () {
            if (!Ext.isEmpty(cmp)) {
                if (cmp.doLayout) {
                    cmp.doLayout();
                }

                if (cmp.syncSize) {
                    cmp.syncSize();
                }
            }
        });

        if (Ext.isIE) {
            this.parentMenu.shadow = false;
            this.parentMenu.el.shadow = false;

            if (!Ext.isEmpty(cmp)) {
                cmp.shadow = false;
                cmp.el.shadow = false;
            }
        }

        if (this.shift) {
            this.el.applyStyles({ "margin-left": "23px" });
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
            container.removeClass("x-menu-list-item");
            container.setStyle({ 
                width  : "", 
                height : "" 
            });
            
            if (this.shift) {
                this.el.applyStyles({ "margin-left": "24px" });
            }
        }
        
        this.baseEl = this.el;
        
        if (this.targetElement === "wrap" && !Ext.isEmpty(cmp)) {            
            this.el = cmp.wrap;
        }

        Coolite.Ext.ElementMenuItem.superclass.onRender.apply(this, arguments);
    },

    activate : function () {
        if (this.disabled) {
            return false;
        }

        var cmp = this.getComponent();
        
        if (Ext.isEmpty(cmp)) {
            return false;
        }

        this.cmp.focus();
        this.fireEvent("activate", this);
        
        return true;
    },

    // private
    deactivate : function () {
        this.fireEvent("deactivate", this);
    },

    // private
    disable : function () {
        var cmp = this.getComponent();
        
        if (Ext.isEmpty(cmp)) {
            return;
        }
        
        this.cmp.disable();
        
        Coolite.Ext.ElementMenuItem.superclass.disable.call(this);
    },

    // private
    enable : function () {
        var cmp = this.getComponent();
        
        if (Ext.isEmpty(cmp)) {
            return;
        }
        
        this.cmp.enable();
        Coolite.Ext.ElementMenuItem.superclass.enable.call(this);
    }
});
