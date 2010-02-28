
// @source core/form/TextField.js

Ext.override(Ext.form.TextField, {
    truncate    : true,
    
    afterRender : function () {
        Ext.form.TextField.superclass.afterRender.call(this);
        
        if (this.maxLength !== Number.MAX_VALUE && this.truncate === true) {
            this.el.dom.setAttribute("maxlength", this.maxLength);
        }
    }
});