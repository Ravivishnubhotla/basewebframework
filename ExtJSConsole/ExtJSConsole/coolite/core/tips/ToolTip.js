
// @source core/tips/ToolTip.js

Ext.ToolTip.override({
    initTarget : function () {
        var targetEl = Ext.get(this.target);
        
        if (!Ext.isEmpty(targetEl)) {
            this.initTargetEvents(targetEl);
        } else {
            var getTargetTask = new Ext.util.DelayedTask(function (task) {
                targetEl = Ext.get(this.target);
                
                if (!Ext.isEmpty(targetEl)) {
                    this.initTargetEvents(targetEl);
                    task.cancel();
                } else {
                    task.delay(500, undefined, this, [task]);
                }
            }, this);
            getTargetTask.delay(1, undefined, this, [getTargetTask]);
        }
    },

    initTargetEvents : function (targetEl) {
        this.target = targetEl;
        this.target.on("mouseover", this.onTargetOver, this);
        this.target.on("mouseout", this.onTargetOut, this);
        this.target.on("mousemove", this.onMouseMove, this);
    }
});