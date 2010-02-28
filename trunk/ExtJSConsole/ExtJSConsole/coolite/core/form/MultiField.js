
// @source core/form/MultiField.js

Coolite.Ext.MultiField = Ext.extend(Ext.form.Field, {
    defaultAutoCreate : { cls : "x-hide-display" },
    
    initValue  : Ext.emptyFn,
    setValue   : Ext.emptyFn,
    getValue   : Ext.emptyFn,
    onRender   : function (ct, position) {
        Coolite.Ext.MultiField.superclass.onRender.call(this, ct, position);
        
        if (this.ownerCt) {
            this.ownerCt.bubble(function (c) {
                if (c.form) {
                    this.form = c.form;
                    return false;
                }
            }, this);
        }

        this.fields = this.fields || [];
        
        if (!Ext.isArray(this.fields)) {
            this.fields = [this.fields];
        }
        
        if (this.fields.length > 0) {
            this.wrap = this.el.wrap();
            
            var fields = [];
            
            for (var i = 0; i < this.fields.length; i++) {
                var fieldCt = this.wrap.createChild({ cls : "x-field-multi" }),
                    field = new Ext.ComponentMgr.create(this.fields[i]);
                    
                field.render(fieldCt);
                fields.push(field);
                
                if (this.form && field.isFormField) {
                    this.form.items.add(field);
                }
            }
            
            this.fields = fields;
        }
    }
});

Ext.reg("coolitemultifield", Coolite.Ext.MultiField);