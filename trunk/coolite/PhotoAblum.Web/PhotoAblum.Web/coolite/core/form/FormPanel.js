
// @source core/form/FormPanel.js

Ext.form.FormPanel.override({
    initComponent : function () {
        this.form = this.createForm();

        this.bodyCfg = {
            tag    : "form",
            cls    : this.baseCls + "-body",
            method : this.method || "POST",
            id     : this.formId || Ext.id()
        };
        
        if (this.fileUpload) {
            this.bodyCfg.enctype = "multipart/form-data";
        }

        if (this.isInForm) {
            this.bodyCfg.tag = "div";
        }

        Ext.FormPanel.superclass.initComponent.call(this);

        this.initItems();

        this.addEvents(
            /**
            * @event clientvalidation
            * If the monitorValid config option is true, this event fires repetitively to notify of valid state
            * @param {Ext.form.FormPanel} this
            * @param {Boolean} valid true if the form has passed client-side validation
            */
            "clientvalidation"
        );

        this.relayEvents(this.form, ["beforeaction", "actionfailed", "actioncomplete"]);
    },
    
    /// TODO: override default functionality to check if each item 
    /// has a .isValid function before calling. 
    bindHandler : function () {
        var valid = true;
        
        this.form.items.each(function (f) {
            /// TODO: OLD 
            //if (!f.isValid(true)) {
            
            /// TODO: NEW
            if (f.isValid && !f.isValid(true)) {
                valid = false;
                return false;
            }
        });
        
        if (this.buttons) {
            for (var i = 0, len = this.buttons.length; i < len; i++) {
                var btn = this.buttons[i];
                
                if (btn.formBind === true && btn.disabled === valid) {
                    btn.setDisabled(!valid);
                }
            }
        }
        this.fireEvent("clientvalidation", this, valid);
    },
	
	isValid : function () {
        return this.getForm().isValid();
    },
    
    validate : function () {
        return this.getForm().isValid();
    },
    
    isDirty : function () {
        return this.getForm().isDirty();
    },
    
    getName : function () {
        return this.id || '';
    },
    
    clearInvalid : function () {
        return this.getForm().clearInvalid();
    },
    
    markInvalid : function (msg) {
        return this.getForm().markInvalid(msg);
    },
    
    getValue : function () {
        return this.getForm().getValues();
    },
    
    setValue : function (value) {
        return this.getForm().setValues(value);
    },
    
    reset : function () {
        return this.getForm().reset();
    }
});