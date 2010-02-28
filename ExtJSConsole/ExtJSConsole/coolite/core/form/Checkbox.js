
// @source core/form/Checkbox.js

// Checkbox/Radio cumulative bugfix
// http://www.extjs.com/forum/showthread.php?t=44603
Ext.override(Ext.form.Checkbox, {
    setBoxLabel : function (label) {
        if (this.labelEl) {
            this.labelEl.dom.innerHTML = label;
        } else {
            this.boxLabel = label;
            
            this.labelEl = this.innerWrap.createChild({
                tag     : "label",
                htmlFor : this.el.id,
                cls     : "x-form-cb-label",
                html    : this.boxLabel
            });
        }
    },
    
	onRender: function (ct, position) {
		Ext.form.Checkbox.superclass.onRender.call(this, ct, position);
		
		if (this.inputValue !== undefined) {
			this.el.dom.value = this.inputValue;
		}
		
		this.innerWrap = this.el.wrap({
			cls : this.baseCls + "-wrap-inner"
		});
		
		this.wrap = this.innerWrap.wrap({
		    cls : this.baseCls + "-wrap"
		});
		
		this.imageEl = this.innerWrap.createChild({
			tag : "img",
			src : Ext.BLANK_IMAGE_URL,
			cls : this.baseCls
		});
		
		if (this.boxLabel) {
			this.labelEl = this.innerWrap.createChild({
				tag     : "label",
				htmlFor : this.el.id,
				cls     : "x-form-cb-label",
				html    : this.boxLabel
			});
		}
		
		if (this.checked) {
			this.setValue(true);
		} else {
			this.checked = this.el.dom.checked;
		}
		
		this.originalValue = this.checked;
		
		if (!Ext.isEmpty(this.cls)) {
            this.wrap.addClass(this.cls);
        }
	},
	
	afterRender : function () {
		Ext.form.Checkbox.superclass.afterRender.call(this);
		this.imageEl[this.checked ? "addClass" : "removeClass"](this.checkedCls);
	},
	
	initCheckEvents : function () {
		this.innerWrap.addClassOnOver(this.overCls);
		this.innerWrap.addClassOnClick(this.mouseDownCls);
		this.innerWrap.on("click", this.onClick, this);
	},
	
	onFocus : function (e) {
		Ext.form.Checkbox.superclass.onFocus.call(this, e);
		this.innerWrap.addClass(this.focusCls);
	},
	
	onBlur : function (e) {
		Ext.form.Checkbox.superclass.onBlur.call(this, e);
		this.innerWrap.removeClass(this.focusCls);
	},
	
	onClick : function (e) {
		if (e.getTarget().htmlFor != this.el.dom.id) {
			if (e.getTarget() !== this.el.dom) {
				this.el.focus();
			}
			
			if (!this.disabled && !this.readOnly) {
				this.toggleValue();
			}
		}
	},
	
	onEnable  : Ext.form.Checkbox.superclass.onEnable,
	
	onDisable : Ext.form.Checkbox.superclass.onDisable,
	
	onKeyUp   : undefined,
	
	setValue  : function (v) {
		var checked = this.checked;
		
		this.checked = (v === true || v === "true" || v == "1" || String(v).toLowerCase() == "on");
		
		if (this.rendered) {
			this.el.dom.checked = this.checked;
			this.el.dom.defaultChecked = this.checked;
			this.imageEl[this.checked ? "addClass" : "removeClass"](this.checkedCls);
		}
		
		if (checked != this.checked) {
			this.fireEvent("check", this, this.checked);
		
			if (this.handler) {
				this.handler.call(this.scope || this, this, this.checked);
			}
		}
	},
    
	getResizeEl : function () {
		return this.wrap;
	}
});

Ext.override(Ext.form.Radio, {
	checkedCls : "x-form-radio-checked"
});