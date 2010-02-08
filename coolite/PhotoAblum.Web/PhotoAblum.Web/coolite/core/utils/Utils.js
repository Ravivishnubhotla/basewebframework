
// @source core/utils/Utils.js

/**
 * Determines if the object is empty
 * @param {object} obj The object to test if empty.
 * @return {Boolean} Returns true|false
 */
Ext.isEmptyObj = function (obj) {
    if (!(!Ext.isEmpty(obj) && typeof obj == "object")) {
        return false;
    }

    for (var p in obj) {
        return false;
    }
    
    return true;
};

Coolite.Ext.clone = function (o) {
    if (!o || "object" !== typeof o) {
        return o;
    }
    var c = "[object Array]" === Object.prototype.toString.call(o) ? [] : {},
        p, 
        v;
        
    for (p in o) {
        if (o.hasOwnProperty(p)) {
            v = o[p];
            
            if (v && "object" === typeof v) {
                c[p] = Coolite.Ext.clone(v);
            }
            else {
                c[p] = v;
            }
        }
    }
    return c;
};

Coolite.Ext.on = function (target, eventName, handler, scope, mode, cfg) {
    var el = target;
    
    if (typeof target == "string") {
        el = Ext.get(target);
    }

    if (!Ext.isEmpty(el)) {
        if (mode && mode == "client") {
            el.on(eventName, handler.fn, scope, handler);
        } else {
            el.on(eventName, handler, scope, cfg);
        }
    }
};

Coolite.Ext.lazyInit = function (controls) {
    if (!Ext.isArray(controls)) { 
        return; 
    }
    
    var cmp, i;
    
    for (i = 0; i < controls.length; i++) {
        cmp = Ext.getCmp(controls[i]);
        
        if (!Ext.isEmpty(cmp)) {
            window[controls[i]] = cmp;
        }
    }
};

Coolite.Ext.setValues = function (controls, commit) {
    if (!Ext.isArray(controls)) { 
        return; 
    }
    
    for (var i = 0; i < controls.length; i++) {
        var control = Ext.getCmp(controls[i][0]),
            value = controls[i][1];
        if (!Ext.isEmpty(control)) {
            control.setValue(value);
            control.clearInvalid();
            
            if (commit) {
                control.originalValue = control.getValue();
            }
        } else {
            Ext.ComponentMgr.onAvailable(controls[i][0], function (c) {
                c.setValue(value);
                c.clearInvalid();
                
                if (commit) {
                    c.originalValue = c.getValue();
                }
            });      
        }       
    }
};

Coolite.Ext.doPostBack = function (config) {
    if (config.before) {
        if (config.before(config.control, config.extraParams || {}) === false) {
            return;
        }
    }

    if (config.extraParams) {
        var form = document.forms[0];
        
        if (!Ext.isEmpty(form)) {
            form = Ext.get(form);
            
            var id = "__CoolitePostBackParams",
                el = form.insertFirst({
                    tag  : "input", 
                    id   : id, 
                    name : id, 
                    type : "hidden" 
                });
            
            el.dom.value = Ext.encode(config.extraParams);
        }
    }

    config.fn();
};

Coolite.Ext.getEl = function (el) {
    if (el.isComposite) {
        return el;
    }
    
    if (el.getEl) {
        return el.getEl();
    }

    if (el.el) {
        return el.el;
    }

    var cmp = Ext.getCmp(el);
    
    if (!Ext.isEmpty(cmp)) {
        return cmp.getEl();
    }

    return Ext.get(el);
};

if (typeof RegExp.escape !== "function") {
    RegExp.escape = function (s) {
        
        if ("string" !== typeof s) {
            return s;
        }
        
        return s.replace(/([.*+?\^=!:${}()|\[\]\/\\])/g, "\\$1");
    };
}