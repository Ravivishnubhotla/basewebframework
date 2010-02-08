
// @source core/utils/Observable.js

(function () {
    Ext.util.Observable.prototype.constructor = Ext.util.Observable.prototype.constructor.createInterceptor(function () {
        if (this.initialConfig) {
            var id = this.initialConfig.proxyId || this.initialConfig.id;
            
            if (!Ext.isEmpty(id, false)) {
                window[id] = this;
            }
        }
    });

    Ext.util.Observable.prototype.constructor.prototype = Ext.util.Observable.prototype;

    var fns = {}, v;

    for (var i in Ext.util.Observable) {
        v = Ext.util.Observable[i];
        
        if (typeof v == "function") {
            fns[i] = v;
        }
    }

    Ext.util.Observable = Ext.util.Observable.prototype.constructor;
    Ext.applyIf(Ext.util.Observable, fns);
})();

Ext.override(Ext.util.Observable, {
    fireEvent : function () {
        if (!(this.isAjaxInit || false)) {
            this.isAjaxInit = true;
            this.ajaxListeners = {};
            
            if (this.ajaxEvents) {
                this.addAjaxListener(this.ajaxEvents);
            }
        }

        if (this.eventsSuspended !== true) {
            var ce = this.events[arguments[0].toLowerCase()],
                answer = true;
                
            if (typeof ce == "object") {
                answer = ce.fire.apply(ce, Array.prototype.slice.call(arguments, 1));
            }

            if (answer !== false) {
                var ace = this.ajaxListeners[arguments[0].toLowerCase()];
                if (typeof ace == "object") {
                    return ace.fire.apply(ace, Array.prototype.slice.call(arguments, 1));
                }
            }

            return answer;
        }
        return true;
    },

    addAjaxListener : function (eventName, fn, scope, o) {
        if (typeof eventName == "object") {
            o = eventName;
            for (var e in o) {
                if (this.filterOptRe.test(e)) {
                    continue;
                }
                
                if (typeof o[e] == "function") {
                    // shared options
                    this.addAjaxListener(e, o[e], o.scope, o);
                } else {
                    // individual options
                    this.addAjaxListener(e, o[e].fn, o[e].scope, o[e]);
                }
            }
            return;
        }
        o = (!o || typeof o == "boolean") ? {} : o;
        
        eventName = eventName.toLowerCase();
        
        var ce = this.ajaxListeners[eventName] || true;
        
        if (typeof ce == "boolean") {
            ce = new Ext.util.Event(this, eventName);
            this.ajaxListeners[eventName] = ce;
        }
        if (Ext.isEmpty(o.delay)) {
            o.delay = 20;
        }
        ce.addListener(fn, scope, o);
    }
});