
// @source core/utils/TaskManager.js

Coolite.Ext.TaskResponse = { stopTask : -1, stopAjax : -2 };

Coolite.Ext.TaskManager = function (config) {
    Ext.apply(this, config || {});
    this.initManager.defer(this.autoRunDelay || 50, this);
};

Ext.extend(Coolite.Ext.TaskManager, Ext.util.Observable, {
    tasksConfig : [],
    getTasks    : function () {
        return this.tasks;
    },

    initManager : function () {
        this.runner = new Ext.util.TaskRunner(this.interval || 10);

        var task;        
        this.tasks = [];

        for (var i = 0; i < this.tasksConfig.length; i++) {
            task = this.createTask(this.tasksConfig[i]);
            this.tasks.push(task);

            if (task.executing && task.autoRun) {
                this.startTask(task);
            }
        }
    },

    getTask : function (id) {
        if (typeof id == "object") {
            return id;
        } else if (typeof id == "string") {
            for (var i = 0; this.tasks.length; i++) {
                if (this.tasks[i].id == id) {
                    return this.tasks[i];
                }
            }
        } else if (typeof id == "number") {
            return this.tasks[id];
        }
        return null;
    },

    startTask : function (task) {
        if (this.executing) {
            return;
        }

        task = this.getTask(task);

        if (task.onstart) {
            task.onstart.apply(task.scope || task);
        }

        this.runner.start(task);
    },

    stopTask : function (task) {
        this.runner.stop(this.getTask(task));
    },

    startAll : function () {
        for (var i = 0; i < this.tasks.length; i++) {
            this.startTask(this.tasks[i]);
        }
    },

    stopAll : function () {
        this.runner.stopAll();
    },

    //private
    createTask : function (config) {
        return Ext.apply({}, config, {
            owner     : this,
            executing : true,
            interval  : 1000,
            autoRun   : true,
            onStop    : function (t) {
                this.executing = false;

                if (this.onstop) {
                    this.onstop();
                }
            },
            run : function () {
                if (this.clientRun) {
                    var rt = this.clientRun.apply(arguments);

                    if (rt === Coolite.Ext.TaskResponse.stopAjax) {
                        return;
                    } else if (rt === Coolite.Ext.TaskResponse.stopTask) {
                        return false;
                    }
                }

                if (this.serverRun) {
                    var o = this.serverRun();
                    o.control = this.owner;
                    Coolite.AjaxEvent.request(o);
                }
            }
        });
    }
});