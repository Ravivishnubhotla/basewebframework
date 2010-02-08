
// @source core/form/NumberField.js

Ext.form.NumberField.prototype.setValue = Ext.form.NumberField.prototype.setValue.createSequence(function (v) {
    if (this.trimTrailedZeros === false) {
        var value = this.getValue();
        
        if (!Ext.isEmpty(value, false)) {
            this.setRawValue(value.toFixed(this.decimalPrecision));
        }
    }
});