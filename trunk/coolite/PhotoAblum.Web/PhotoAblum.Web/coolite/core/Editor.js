
// @source core/Editor.js

Ext.Editor.override({
    activateEvent : "click",    
    
    initTarget : function () {
        if (this.isSeparate) {
            this.field = Ext.ComponentMgr.create(this.field, "textfield");
        }
        
        if (!Ext.isEmpty(this.target, false)) {            
            var targetEl = Coolite.Ext.getEl(this.target);
            
            if (!Ext.isEmpty(targetEl)) {
                this.initTargetEvents(targetEl);
            } else {
                var getTargetTask = new Ext.util.DelayedTask(function (task) {
                    targetEl = Ext.get(this.target);
                    
                    if (!Ext.isEmpty(targetEl)) {                            
                        this.initTargetEvents(targetEl);
                        task.cancel();
                        delete this.getTargetTask;
                    } else {
                        task.delay(500, undefined, this, [task]);
                    }
                }, this);
                this.getTargetTask = getTargetTask;
                getTargetTask.delay(1, undefined, this, [getTargetTask]);
            }
        } 
    },
    
    retarget : function (target) {
        if (this.getTargetTask) {
            this.getTargetTask.cancel();
            delete this.getTargetTask;
        }
        
        if (this.target && this.target.un && !Ext.isEmpty(this.activateEvent, false)) {
            this.target.un(this.activateEvent, this.activateFn, this);
        }
        
        this.initTargetEvents(target);            
    },

    initTargetEvents : function (targetEl) {
        this.target = targetEl;
        
        var ed = this,
            activate = function () {
                if (!ed.disabled) {
                    ed.startEdit(this);
                }
            };
        
        this.activateFn = activate;
        
        if (!Ext.isEmpty(this.activateEvent, false)) {
            this.target.on(this.activateEvent, activate);            
        }
    }
});

Ext.Editor.prototype.initComponent = Ext.Editor.prototype.initComponent.createSequence(function () {
    this.initTarget();
    this.parentEl = document.forms.length == 1 ? document.forms[0] : document.body;
});