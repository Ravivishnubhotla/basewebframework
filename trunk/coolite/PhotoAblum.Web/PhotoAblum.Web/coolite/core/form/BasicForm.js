
// @source core/form/BasicForm.js

Ext.form.BasicForm.override({
    getValues : function (asString) {
        var isForm = !Ext.isEmpty(this.el.dom.elements),
            fs = Ext.lib.Ajax.serializeForm(isForm ? this.el.dom : this.el.up("form").dom, isForm ? undefined : this.el);
        
        if (asString === true) {
            return fs;
        }
        
        return Ext.urlDecode(fs);
    }
});