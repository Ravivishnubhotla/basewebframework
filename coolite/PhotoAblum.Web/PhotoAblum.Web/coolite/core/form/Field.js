
// @source core/form/Field.js

Ext.form.Field.override({
    hideWithLabel : true,

    setReadOnly : function (readOnly) {
        if (this.rendered) {
            this.el.dom.setAttribute("readOnly", readOnly);
            this.el.dom.readOnly = readOnly;
        } else {
            this.readOnly = readOnly;
        }
    },

    getReadOnly : function () {
        return this.rendered ? this.el.dom.readOnly : this.readOnly;
    },

    adjustWidth : function (tag, w) {
        if (typeof w == "number" && (Ext.isIE6 || !Ext.isStrict) && /input|textarea/i.test(tag) && !this.inEditor) {
            return w - 3;
        }
        
        return w;
    },

    hideNote : function () {
        if (!Ext.isEmpty(this.note, false) && this.noteEl) {        
            this.noteEl.addClass("x-hide-" + this.hideMode);
        }
    },
    
    showNote : function () {
        if (!Ext.isEmpty(this.note, false) && this.noteEl) {        
            this.noteEl.removeClass("x-hide-" + this.hideMode);
        }
    },
    
    setNote : function (t, encode) {
        this.note = t;
        
        if (this.rendered) {
            this.noteEl.dom.innerHTML = encode !== false ? Ext.util.Format.htmlEncode(t) : t;
        }
    },
    
    setNoteCls : function (cls) {
        if (this.rendered) {
            this.noteEl.removeClass(this.noteCls);
            this.noteEl.addClass(cls);
        }
        
        this.noteCls = cls;
    },
	
	hideFieldLabel : function () {
        if (this.label && this.hideWithLabel) {

            var parent = this.getActionEl().parent(".x-form-item");
            
            if (!Ext.isEmpty(parent)) {
                parent.addClass("x-hide-" + this.hideMode);
            }                
        }
    },
    
    showFieldLabel : function () {
        if (this.label && this.hideWithLabel) {

            var parent = this.getActionEl().parent(".x-form-item");
            
            if (!Ext.isEmpty(parent)) {
                parent.removeClass("x-hide-" + this.hideMode);
            }                 
        }
    }
});

Ext.form.Field.prototype.initComponent = Ext.form.Field.prototype.initComponent.createSequence(function () {
    this.on("hide", function () {
		this.hideFieldLabel();

        if (!Ext.isEmpty(this.note, false)) {
            this.hideNote();
        }
    });

    this.on("show", function () {
        this.showFieldLabel();

        if (!Ext.isEmpty(this.note, false)) {
            this.showNote();
        }
    });

    this.on("render", function () {
        if (this.hidden) {
            this.hideFieldLabel();
        }   
		
		if (!Ext.isEmpty(this.note, false)) {
            this.wrap = this.wrap || this.el.wrap();

            var beforeEl = undefined;
            
            this.note = this.noteEncode ? Ext.util.Format.htmlEncode(this.note) : this.note;

            if (this.noteAlign == "top") {
                this.noteEl = Ext.DomHelper.insertBefore(this.wrap, { cls: "x-field-note " + (this.noteCls || ""), html: this.note });
                
                if (this.hidden) {
                    this.hideNote();
                }
                
                return;
            }

            this.noteEl = this.wrap.createChild({ cls: "x-field-note " + (this.noteCls || ""), html: this.note }, beforeEl);
            
            if (this.hidden) {
                this.hideNote();
            }
        }
    });
});