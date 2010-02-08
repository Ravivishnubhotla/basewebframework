
// @source core/buttons/Button.js

Ext.override(Ext.Button, {
    setTooltip : function (tooltip) {
        this.tooltip = tooltip;
        
        var btnEl = this.getEl().child(this.buttonSelector);
        
        if (typeof tooltip == "object") {
            Ext.QuickTips.register(Ext.apply({
                target : btnEl.id
            }, tooltip));
        } else {
            btnEl.dom[this.tooltipType] = tooltip;
        }
    },
	
	getPressedField : function () {
        if (!this.pressedField) {
            this.pressedField = new Ext.form.Hidden({ id : this.id + "_Pressed", name : this.id + "_Pressed" });
        }
        return this.pressedField;
    },
    
    menuArrow : true,
    
    toggleMenuArrow : function () {
        if (this.menuArrow === false) {
            this.showMenuArrow();
            this.menuArrow = true;
        } else {
            this.hideMenuArrow();
            this.menuArrow = false;
        }
    },
    
    showMenuArrow : function () {
        this.el.child(this.menuClassTarget).addClass("x-btn-with-menu");
    },
    
    hideMenuArrow : function () {
        this.el.child(this.menuClassTarget).removeClass("x-btn-with-menu");
    }
});

Ext.Button.prototype.onRender = Ext.Button.prototype.onRender.createSequence(function (el) {
    if (this.enableToggle || !Ext.isEmpty(this.toggleGroup)) {
        this.getPressedField().render(this.el.parent() || this.el);
    }
    
    if (this.flat) {
        this.el.wrap({ cls : "x-toolbar x-inline-toolbar" }); 
    }
    
    if (this.menuArrow === false) {
        this.hideMenuArrow();
    }
});