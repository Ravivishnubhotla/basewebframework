
// @source core/form/TriggerComboBox.js

Coolite.Ext.TriggerComboBox = Ext.extend(Ext.form.ComboBox, {
    initComponent : function () {
        Coolite.Ext.TriggerComboBox.superclass.initComponent.call(this);

        this.addEvents("triggerclick");

        if (this.triggersConfig) {

            var cn = [], triggerCfg;

            for (var i = 0; i < this.triggersConfig.length; i++) {
                var trigger = this.triggersConfig[i];
                
                triggerCfg = {
                    tag        : "img",
                    "ext:qtip" : trigger.qtip || "",
                    src        : Ext.BLANK_IMAGE_URL,
                    cls        : "x-form-trigger" + (trigger.triggerCls || "") + " " + (trigger.iconCls || "x-form-ellipsis-trigger")
                };

                if (trigger.hideTrigger) {
                    Ext.apply(triggerCfg, { style : "display:none" });
                }
                cn.push(triggerCfg);
            }

            triggerCfg = {
                tag : "img",
                src : Ext.BLANK_IMAGE_URL,
                cls : "x-form-trigger"
            };

            if (this.hideTrigger) {
                Ext.apply(triggerCfg, { style : "display:none" });
            }
            
            cn.push(triggerCfg);

            this.triggerConfig = { tag : "span", cls : "x-form-twin-triggers", cn : cn };
        }
    },

    getTrigger : function (index) {
        return this.triggers[index];
    },

    initTrigger : function () {
        if (!this.triggersConfig) {
            Coolite.Ext.TriggerComboBox.superclass.initTrigger.call(this);
            return;
        }

        var ts = this.trigger.select(".x-form-trigger", true), triggerField = this;
        
        this.wrap.setStyle("overflow", "hidden");
        
        ts.each(function (t, all, index, length) {
            t.hide = function () {
                var w = triggerField.wrap.getWidth();
                this.dom.style.display = "none";
                triggerField.el.setWidth(w - triggerField.trigger.getWidth());
            };
            
            t.show = function () {
                var w = triggerField.wrap.getWidth();
                this.dom.style.display = "";
                triggerField.el.setWidth(w - triggerField.trigger.getWidth());
            };

            if (index == (all.getCount() - 1)) {
                t.on("click", this.onTriggerClick, this);
            } else {
                t.on("click", this.onCustomTriggerClick, this, { index : index, t : t, preventDefault : true });
            }

            t.addClassOnOver("x-form-trigger-over");
            t.addClassOnClick("x-form-trigger-click");
        }, this);
        
        this.triggers = ts.elements;
    },

    onCustomTriggerClick : function (evt, el, o) {
        if (!this.disabled) {
            this.fireEvent("triggerclick", this, o.t, o.index, evt);
        }
    },
    
    setValue : function (v) {
        Coolite.Ext.TriggerComboBox.superclass.setValue.call(this, v);
        this.getSelectedIndexField().setValue(this.getSelectedIndex());
    }
});

Ext.reg("coolitetriggercombo", Coolite.Ext.TriggerComboBox);