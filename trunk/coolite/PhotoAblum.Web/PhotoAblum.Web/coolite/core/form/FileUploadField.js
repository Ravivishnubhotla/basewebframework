
// @source core/form/FileUploadField.js

Ext.form.FileUploadField = Ext.extend(Ext.form.TextField, {
    buttonText   : "Browse...",
    buttonOnly   : false,
    buttonOffset : 3,
    // private
    readOnly     : true,
    autoSize     : Ext.emptyFn,

    // private
    initComponent : function () {
        Ext.form.FileUploadField.superclass.initComponent.call(this);

        this.addEvents("fileselected");
    },

    // private
    onRender : function (ct, position) {
        Ext.form.FileUploadField.superclass.onRender.call(this, ct, position);

        this.wrap = this.el.wrap({ cls : "x-form-field-wrap x-form-file-wrap" });
        this.el.addClass("x-form-file-text");
        this.el.dom.removeAttribute("name");

        this.createFileInput();

        var btnCfg = Ext.applyIf(this.buttonCfg || {}, {
            text    : this.buttonText,
            disabled : this.disabled,
            iconCls : this.iconCls
        });
        
        this.button = new Ext.Button(Ext.apply(btnCfg, {
            renderTo : this.wrap,
            cls      : "x-form-file-btn" + (btnCfg.iconCls ? (btnCfg.text ? " x-btn-text-icon" : " x-btn-icon") : "")
        }));

        if (this.buttonOnly) {
            this.el.hide();
            this.wrap.setWidth(this.button.getEl().getWidth());
        }
    },

    createFileInput : function () {
        if (this.fileInput) {
            this.fileInput.remove();
        }

        this.fileInput = this.wrap.createChild({
            id   : this.getFileInputId(),
            name : this.name || this.getFileInputId(),
            cls  : "x-form-file",
            tag  : "input",
            type : "file",
            size : 1
        });

        this.fileInput.on("change", function () {
            var v = this.fileInput.dom.value;
            this.setValue(v);
            this.fireEvent("fileselected", this, v);
        }, this);
        
        if (this.disabled) {
            this.fileInput.dom.disabled = true;
        }
    },

    // private
    getFileInputId : function () {
        return this.id + "-file";
    },

    // private
    onResize : function (w, h) {
        Ext.form.FileUploadField.superclass.onResize.call(this, w, h);

        this.wrap.setWidth(w);

        if (!this.buttonOnly) {
            w = this.wrap.getWidth() - this.button.getEl().getWidth() - this.buttonOffset;
            this.el.setWidth(w);
        }
    },

    // private
    preFocus : Ext.emptyFn,

    // private
    getResizeEl : function () {
        return this.wrap;
    },

    // private
    getPositionEl : function () {
        return this.wrap;
    },

    // private
    alignErrorIcon : function () {
        this.errorIcon.alignTo(this.wrap, "tl-tr", [2, 0]);
    },

    reset : function () {
        Ext.form.FileUploadField.superclass.reset.call(this);
        this.createFileInput();
    },
    
    setDisabled : function (disabled) {
        Ext.form.FileUploadField.superclass.setDisabled.call(this, disabled);
        this.button.setDisabled(disabled);
        
        if (this.fileInput) {
            this.fileInput.dom.disabled = disabled;
        }
    }
});

Ext.reg("fileuploadfield", Ext.form.FileUploadField);