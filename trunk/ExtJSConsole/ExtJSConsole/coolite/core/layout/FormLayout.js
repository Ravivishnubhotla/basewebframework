
// @source core/layout/FormLayout.js

Ext.layout.FormLayout.override({
    // private
    renderItem : function (c, position, target) {
        if (c && !c.rendered && c.isFormField && c.inputType != "hidden") {
            var args = [c.id, c.fieldLabel,
                (this.labelStyle || "") + ";" + (c.labelStyle || ""),
                this.elementStyle || "",
                typeof c.labelSeparator == "undefined" ? this.labelSeparator : c.labelSeparator,
                (c.itemCls || this.container.itemCls || "") + (c.hideLabel ? " x-hide-label" : ""),
                c.clearCls || "x-form-clear-left",
                c.labelCls || ""
            ];
            
            if (typeof position == "number") {
                position = target.dom.childNodes[position] || null;
            }
            
            if (position) {
                c.formItem = this.fieldTpl.insertBefore(position, args);
            } else {
                c.formItem = this.fieldTpl.append(target, args);
            }
            
            c.label = Ext.get(c.formItem).child("label.x-form-item-label");
            c.render("x-form-el-" + c.id);
            
            if (this.renderHidden && c != this.activeItem) {
                c.hide();
            }
        } else {
            Ext.layout.FormLayout.superclass.renderItem.apply(this, arguments);
        }
    },

    setContainer : function (ct) {
        Ext.layout.FormLayout.superclass.setContainer.call(this, ct);

        if (ct.labelAlign) {
            ct.addClass("x-form-label-" + ct.labelAlign);
        }

        this.elementStyle = this.elementStyle || "";
        this.labelStyle = this.labelStyle || "";

        if (ct.hideLabels) {
            this.labelStyle += "display:none";
            this.elementStyle += "padding-left:0;";
            this.labelAdjust = 0;
        } else {
            this.labelSeparator = ct.labelSeparator || this.labelSeparator;
            ct.labelWidth = ct.labelWidth || 100;
            
            if (typeof ct.labelWidth == "number") {
                var pad = (typeof ct.labelPad == "number" ? ct.labelPad : 5);
                this.labelAdjust = ct.labelWidth + pad;
                this.labelStyle += "width:" + ct.labelWidth + "px;";
                this.elementStyle += "padding-left:" + (ct.labelWidth + pad) + "px";
            }
            
            if (ct.labelAlign == "top") {
                this.labelStyle += "width:auto;";
                this.labelAdjust = 0;
                this.elementStyle += "padding-left:0;";
            }
        }

        if (!this.fieldTpl) {
            // the default field template used by all form layouts
            var t = new Ext.Template(
                '<div class="x-form-item {5}" tabIndex="-1">',
                    '<label for="{0}" style="{2}" class="x-form-item-label {7}">{1}{4}</label>',
                    '<div class="x-form-element" id="x-form-el-{0}" style="{3}">',
                    '</div><div class="{6}"></div>',
                '</div>');
            t.disableFormats = true;
            t.compile();
            Ext.layout.FormLayout.prototype.fieldTpl = t;
        }
    }
});