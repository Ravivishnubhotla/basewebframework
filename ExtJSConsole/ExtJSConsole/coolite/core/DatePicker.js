
// @source core/DatePicker.js

Ext.DatePicker.prototype.initComponent = Ext.DatePicker.prototype.initComponent.createSequence(function () {
    var fn = function () { 
        this.getInputField().setValue(this.getValue().dateFormat("Y-m-d\\Th:i:s")); 
    };
    
    this.on("render", fn, this);
    this.on("select", fn, this);
});

Ext.DatePicker.prototype.onRender = Ext.DatePicker.prototype.onRender.createSequence(function (el) {
    this.getInputField().render(this.el.parent() || this.el);
});

Ext.DatePicker.override({
    getInputField : function () {
        if (!this.inputField) {
            this.inputField = new Ext.form.Hidden({ id : this.id + "_Input", name : this.id + "_Input" });
        }
        
        return this.inputField;
    }
});