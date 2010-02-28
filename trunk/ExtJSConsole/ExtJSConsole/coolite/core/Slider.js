
// @source core/Slider.js

Ext.Slider.prototype.onRender = Ext.Slider.prototype.onRender.createSequence(function (el) {
    this.getValueField().render(this.el.parent() || this.el);
});

Ext.Slider.override({
    getValueField : function () {
        if (!this.valueField) {
            this.valueField = new Ext.form.Hidden({ id : this.id + "_Value", name : this.id + "_Value" });
        }
        
        return this.valueField;
    }
});