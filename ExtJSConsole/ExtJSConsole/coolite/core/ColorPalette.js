
// @source core/ColorPalette.js

Ext.override(Ext.ColorPalette, {
    silentSelect : function (color) {
        color = color.replace("#", "");
        
        if (color != this.value || this.allowReselect) {
            var el = this.el;
            
            if (this.value) {
                el.child("a.color-" + this.value).removeClass("x-color-palette-sel");
            }
            
            if (!Ext.isEmpty(color, false)) {
                el.child("a.color-" + color).addClass("x-color-palette-sel");
            } else {
                color = null;
            }
            
            this.value = color;
        }
    },
	
	getColorField : function () {
        if (!this.colorField) {
            this.colorField = new Ext.form.Hidden({ id : this.id + "_Color", name : this.id + "_Color" });
        }
        
        return this.colorField;
    }
});

Ext.ColorPalette.prototype.onRender = Ext.ColorPalette.prototype.onRender.createSequence(function (el) {
    this.getColorField().render(this.el.parent() || this.el);
});