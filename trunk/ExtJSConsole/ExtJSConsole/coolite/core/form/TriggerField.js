
// @source core/form/TriggerField.js

Ext.form.TriggerField.override({
    syncSize : function () {
        delete this.lastSize;

        this.setSize(this.autoWidth ? undefined : this.el.getWidth(), this.autoHeight ? undefined : this.el.getHeight());
        this.wrap.setWidth(this.el.getWidth() + this.trigger.getWidth());
        this.el.setWidth(this.el.getWidth() + this.trigger.getWidth());

        if (this.list && this.listWidth === undefined) {
            this.syncList();
        } else if (this.initList) {
            this.initList();
            this.syncList();
        }

        return this;
    },   

    syncList : function () {
        var lw = Math.max(this.el.getWidth() + this.trigger.getWidth(), this.minListWidth);
        this.list.setWidth(lw);
        this.innerList.setWidth(lw - this.list.getFrameWidth("lr"));
    },

    afterRender : function () {
        Ext.form.TriggerField.superclass.afterRender.call(this);
        var y;
        
        if (Ext.isIE && !Ext.isIE8 && !this.hideTrigger && this.el.getY() != (y = this.trigger.getY())) {
            this.el.position();
            this.el.setY(y);
        }

        if (Ext.isIE8 && !this.hideTrigger) {
            this.el.setStyle("position", "relative");
            this.el.setStyle("top", "0px");
        }
    }
});

Coolite.Ext.TriggerField = Ext.extend(Ext.form.TriggerField, {
    syncSize : function () {
        delete this.lastSize;

        this.setSize(this.autoWidth ? undefined : this.el.getWidth() + this.getTriggersWidth(), this.autoHeight ? undefined : this.el.getHeight());
        this.wrap.setWidth(this.el.getWidth() + this.getTriggersWidth());
        this.el.setWidth(this.el.getWidth());

        if (this.list && this.listWidth === undefined) {
            this.syncList();
        } else if (this.initList) {
            this.initList();
            this.syncList();
        }

        return this;
    },
    
    getTriggersWidth : function () {
        var width = 0;
        
        Ext.each(this.triggers, function (trigger) {
            if (trigger.isVisible()) {
                width += trigger.getWidth();
            }
        });
        
        return width;
    },
    
    initComponent : function () {
        Coolite.Ext.TriggerField.superclass.initComponent.call(this);

        this.addEvents("triggerclick");

        if (this.triggersConfig) {
            var cn = [];
            
            for (var i = 0; i < this.triggersConfig.length; i++) {
                var trigger = this.triggersConfig[i],
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

            this.triggerConfig = { 
                tag : "span", 
                cls : "x-form-twin-triggers", 
                cn  : cn 
            };
        }
    },

    getTrigger : function (index) {
        return this.triggers[index];
    },

    initTrigger : function () {
        var ts = this.trigger.select(".x-form-trigger", true), triggerField = this;
        
        this.wrap.setStyle("overflow", "hidden");
        
        ts.each(function (t, all, index) {
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

            t.on("click", this.onTriggerClick, this, { index : index, t : t, preventDefault : true });
            t.addClassOnOver("x-form-trigger-over");
            t.addClassOnClick("x-form-trigger-click");
        }, this);
        
        this.triggers = ts.elements;
    },

    onTriggerClick : function (evt, el, o) {
        if (!this.disabled) {
            this.fireEvent("triggerclick", this, o.t, o.index, evt);
        }
    }
});

Ext.reg("coolitetrigger", Coolite.Ext.TriggerField);