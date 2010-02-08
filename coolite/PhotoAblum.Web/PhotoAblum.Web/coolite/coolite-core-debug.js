/*
 * @version   : 0.8.2 - Professional Edition (Coolite Professional License)
 * @author    : Coolite Inc. http://www.coolite.com/
 * @date      : 2009-12-21
 * @copyright : Copyright (c) 2006-2009, Coolite Inc. (http://www.coolite.com/). All rights reserved.
 * @license   : See license.txt and http://www.coolite.com/license/.
 */

Ext.ns("Coolite", "Coolite.Ext", "Coolite.AjaxMethods", "Ext.ux", "Ext.ux.plugins", "Ext.ux.layout");

Coolite.Ext.Version = "0.8.2";

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

// @source core/utils/Utils.js


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

// @source core/utils/Mask.js

Coolite.Ext.Mask = function () {
    var instance, 
        bmask, 
        init = function () {
            bmask = Ext.getBody().createChild({ style : "top:0;left:0;z-index:20000;position:absolute;background-color:transparent,width:100%,height:100%,zoom:1;"})
                    .enableDisplayMode("block")
                    .hide();
                    
            Ext.EventManager.onWindowResize(function () { 
                bmask.setSize(Ext.lib.Dom.getViewWidth(true), Ext.lib.Dom.getViewHeight(true)); 
            });
        };

    return {
        show : function (cfg) {
            this.hide();

            cfg = Ext.apply({
                msg    : Ext.LoadMask.prototype.msg,
                msgCls : "x-mask-loading",
                el     : Ext.getBody()
            }, cfg || {});

            if (cfg.el == Ext.getBody()) {
                if (Ext.isEmpty(bmask)) {
                    init();
                }
                
                bmask.setSize(Ext.lib.Dom.getViewWidth(true), Ext.lib.Dom.getViewHeight(true)).show();
                cfg.el = bmask;
            } else {
                cfg.el = Coolite.Ext.getEl(cfg.el);
            }
            
            cfg.el.mask(cfg.msg, cfg.msgCls);

            instance = cfg.el;
        },
        
        hide : function () {
            if (instance) {
                instance.unmask();
            }
            
            if (bmask) {
                bmask.hide();
            }
        }
    };
}();

// @source core/utils/VTypes.js

Ext.apply(Ext.form.VTypes, {
    daterange : function (val, field) {
        var date = field.parseDate(val),
            dispUpd = function (picker) {
                var ad = picker.activeDate;
                
                if (ad) {
                    picker.activeDate = null;
                    picker.update(ad);
                }
            };

        if (field.startDateField) {
            var sd = Ext.getCmp(field.startDateField);
            
            sd.maxValue = date;
            
            if (sd.menu && sd.menu.picker) {
                sd.menu.picker.maxDate = date;
                dispUpd(sd.menu.picker);
            }
        } else if (field.endDateField) {
            var ed = Ext.getCmp(field.endDateField);
            
            ed.minValue = date;
            
            if (ed.menu && ed.menu.picker) {
                ed.menu.picker.minDate = date;
                dispUpd(ed.menu.picker);
            }
        }
        return true;
    }
});

// @source core/Component.js

Ext.override(Ext.Component, {
    addPlugins : function (plugins) {
        if (Ext.isEmpty(this.plugins)) {
            this.plugins = [];
        } else if (!Ext.isArray(this.plugins)) {
            this.plugins = [this.plugins];
        }
        
        if (Ext.isArray(plugins)) {
            for (var i = 0; i < plugins.length; i++) {
                this.plugins.push(this.initPlugin(plugins[i]));
            }
        } else {
            this.plugins.push(this.initPlugin(plugins));
        }
    },
    
    getForm : function (id) {
        var form = Ext.isEmpty(id) ? this.el.up("form") : Ext.get(id);
        
        if (!Ext.isEmpty(form)) {
            Ext.apply(form, form.dom);
            
            form.submit = function () {
                form.dom.submit();
            };
        }
        
        return form;
    },
    
    setFieldLabel : function (text) {
        try {
            this.container.parent().child("label").update(text);
        } catch (e) { }
    }
});

// @source core/BoxComponent.js

Ext.BoxComponent.override({
    getWidth  : function () {
        return this.getSize().width;
    },
    
    getHeight : function () {
        return this.getSize().height;
    }
});

// @source core/Panel.js

Ext.Panel.override({
    addButton : function (config, handler, scope) {
        var bc = {
            handler    : handler,
            scope      : scope,
            minWidth   : this.minButtonWidth,
            hideParent : true
        };
        
        if (typeof config == "string") {
            bc.text = config;
        } else {
            Ext.apply(bc, config);
        }
        
        var btn = Ext.ComponentMgr.create(bc, "button");
        btn.ownerCt = this;
        
        if (!this.buttons) {
            this.buttons = [];
        }
        
        this.buttons.push(btn);
        return btn;
    },

    getCollapsedField : function () {
        if (!this.collapsedField) {
            this.collapsedField = new Ext.form.Hidden({ 
                id    : this.id + "_Collapsed", 
                name  : this.id + "_Collapsed", 
                value : this.collapsed || false 
            });
            this.collapsedField.render(this.el.parent() || this.el);
        }
        
        return this.collapsedField.el;
    },

    getBody : function () {
        if (this.iframe) {
            return this.iframe.dom.contentWindow;
        }
        
        return Ext.get(this.id + "_Body") || this.body;
    },

    setAutoScroll : function () {
        if (this.rendered && this.autoScroll) {
            var el = this.body || this.el;
            
            if (el) {
                el.setOverflow("auto");
                // Following line required to fix autoScroll
                el.dom.style.position = "relative";
            }
        }
        return this;
    },

    // private
    isIFrame : function (cfg) {
        var frame = false;
        
        if (typeof cfg == "string" && cfg.indexOf("://") >= 0) {
            frame = true;
        } else if (cfg.mode) {
            if (cfg.mode == "iframe") {
                frame = true;
            }
        } else if (cfg.url && cfg.url.indexOf("://") >= 0) {
            frame = true;
        } else if ((this.getAutoLoad().url && this.autoLoad.url.indexOf("://") >= 0) || (this.getAutoLoad().mode && this.autoLoad.mode == "iframe")) {
            frame = true;
        }

        return frame;
    },
    
    load : function (config) {
        if (!Ext.isEmpty(config) && !Ext.isEmptyObj(config)) {
            if (config.passParentSize) {
                config.params = config.params || {};
                config.params.width = this.body.getWidth(true);
                config.params.height = this.body.getHeight(true);
            }
            
            if (this.isIFrame(config)) {
                return this.loadIFrame(config);
            }

            var um = this.body.getUpdater();
            um.update.apply(um, arguments);
        }
        return this;
    },
    
    //do not remove and uncomment body
    doAutoLoad : function () {
        //this.load(this.getAutoLoad());
    },

    reload : function (nocache) {
        this.getAutoLoad().nocache = nocache || this.autoLoad.nocache;
        this.load(this.getAutoLoad());
    },

    getAutoLoad : function () {
        this.autoLoad = this.autoLoad || {};
        return this.autoLoad;
    },

    loadContent : function (config) {
        this.load(config);
    },
    
    clearContent : function () {
        if (this.iframe) {
            this.iframe.un("load", this.afterLoad, this);
            this.iframe.remove();            
            delete this.iframe;
            if (this.body.isMasked()) {
                this.body.unmask();
            }
        } else {
            this.body.innerHTML = "";
        }
    },

    // private
    loadIFrame : function (config) {
        var al = this.getAutoLoad(), url;

        if (typeof config == "string") {
            al.url = config;
        } else if (typeof config == "object") {
            Ext.apply(al, config);
        }
        
        if (Ext.isEmpty(al.url)) {
            return;
        }

        url = al.url;

        if (al.nocache === true) {
            url = url + ((url.indexOf("?") > -1) ? "&" : "?") + new Date().getTime();
        }

        if (al.params) {            
            var params = {};
            for (var key in al.params) {
                var ov = al.params[key];
                if (typeof ov == "function") {
                    params[key] = ov.call(window);
                } else {
                    params[key] = ov;
                }
            }
            params = Ext.urlEncode(params);
            url = url + ((url.indexOf("?") > -1) ? "&" : "?") + params;
        }
        
        if (al.showMask && Ext.isGecko) {
            
            this.body.mask(al.maskMsg || "Loading...", al.maskCls || "x-mask-loading");              
        }

        if (Ext.isEmpty(this.iframe)) {
            var iframeObj = {
                tag         : "iframe",
                width       : "100%",
                height      : "100%",
                frameborder : 0,
                id          : this.id + "_IFrame",
                name        : this.id + "_IFrame",
                cls         : al.cls || "",
                src         : url
            };
            
            this.iframe = Ext.get(Ext.DomHelper.insertFirst(this.body, iframeObj));            
            this.iframe.on("load", this.afterLoad, this);
            this.fireEvent("beforeupdate", this, { url : url, iframe : this.iframe });
        } else {
            this.iframe.dom.src = String.format("java{0}", "script:false");
            this.fireEvent("beforeupdate", this, { url : this.iframe.dom.src, iframe : this.iframe });
            this.iframe.dom.src = url;
        }
        
        if (al.showMask && !Ext.isGecko) {
            
            this.body.mask(al.maskMsg || "Loading...", al.maskCls || "x-mask-loading");              
        }
        
        this.autoLoad = al;
        return this;
    },
    
    afterLoad : function () {
        if (this.autoLoad.showMask) {
            this.body.unmask();
        }
        
        this.fireEvent("update", this, { iframe : this.iframe, url : this.iframe.dom.src });
    },

    autoLoadBeforeUpdate : function (el, url, params) {
        this.fireEvent("beforeupdate", this, { url : url, params : params });
        
        if (this.autoLoad.showMask) {
            
            this.body.mask(this.autoLoad.maskMsg || "Loading...", this.autoLoad.maskCls || "x-mask-loading");
        }
    },

    autoLoadUpdate : function (el, response) {
        if (this.autoLoad.showMask) {
            this.body.unmask();
        }
        
        this.fireEvent("update", this, { response : response });
    },

    autoLoadFailure : function (el, response) {
        if (this.autoLoad.showMask) {
            this.body.unmask();
        }
        
        this.fireEvent("failure", this, { response : response });
    },

    show : function () {
        Ext.Panel.superclass.show.call(this);
        
        if (Ext.isIE && this.hideMode == "offsets" && this.el) {
            this.el.repaint();
        }

        return this;
    }
});

Ext.Panel.prototype.beforeDestroy = Ext.Panel.prototype.beforeDestroy.createInterceptor(function () {
    if (this.iframe) {
        if (Ext.isIE) {
            this.iframe.dom.src = String.format("java{0}", "script:false");
            Ext.removeNode(this.iframe.dom);
        }
        this.iframe.remove();
    }
});

Ext.Panel.prototype.initComponent = Ext.Panel.prototype.initComponent.createSequence(function () {
    this.addEvents("beforeupdate", "update", "failure");

    if (this.autoLoad) {
        this.on("render", function () {
            var udr = this.getUpdater();
            
            udr.showLoadIndicator = false;

            udr.on("beforeupdate", this.autoLoadBeforeUpdate, this);
            udr.on("update", this.autoLoadUpdate, this);
            udr.on("failure", this.autoLoadFailure, this);
        }, this);

        var loadConfig = { delay : 10, single : true },
            triggerEvent = this.autoLoad.triggerEvent || "render";
            
        loadConfig.single = !(this.autoLoad.reloadOnEvent || false);

        if (Ext.isEmpty(this.autoLoad.manuallyTriggered) || this.autoLoad.manuallyTriggered !== true) {
            this.on(triggerEvent, function () {
                this.load(this.getAutoLoad());
            }, this, loadConfig);
        }
    }
    
    var refreshBars = function () {
        var bar = this.getBottomToolbar();
        
        if (bar && bar.el) {
            bar.el.repaint();
        }

        bar = this.getTopToolbar();
        
        if (bar && bar.el) {
            bar.el.repaint();
        }            
    };
    
    if (Ext.isIE) {
        this.on("show", refreshBars, this, { buffer : 100 });
        this.on("resize", refreshBars, this, { buffer : 100 });
    }
});

Ext.Panel.prototype.onCollapse = Ext.Panel.prototype.onCollapse.createSequence(function (doAnim, animArg) {
    var f = this.getCollapsedField();
    
    if (!Ext.isEmpty(f)) {
        f.dom.value = "true";
    }
});

Ext.Panel.prototype.onExpand = Ext.Panel.prototype.onExpand.createSequence(function (doAnim, animArg) {
    var f = this.getCollapsedField();
    
    if (!Ext.isEmpty(f)) {
        f.dom.value = "false";
    }
});

// @source core/layout/FitLayout.js


Coolite.Ext.FitLayout = Ext.extend(Ext.layout.FitLayout, {
    onLayout : function (ct, target) {
        Ext.layout.FitLayout.superclass.onLayout.call(this, ct, target);
        
        if (!this.container.collapsed) {
            if (target.dom == Ext.getBody().dom || target.dom == document.forms[0]) {
                this.setItemSize(this.activeItem || ct.items.itemAt(0), target.getViewSize());
            } else {
                this.setItemSize(this.activeItem || ct.items.itemAt(0), target.getStyleSize());
            }
        }
    }
});

Ext.reg("coolitefit", Coolite.Ext.FitLayout);

Ext.Container.LAYOUTS.coolitefit = Coolite.Ext.FitLayout;

// @source core/layout/AnchorLayout.js


Coolite.Ext.AnchorLayout = Ext.extend(Ext.layout.AnchorLayout, {
    monitorResize     : true,
    
    getAnchorViewSize : function (ct, target) {
        return ((target.dom == Ext.getBody().dom) || (target.dom == document.forms[0])) ?
                   target.getViewSize() : target.getStyleSize();
    }
});

Ext.reg("cooliteanchor", Coolite.Ext.AnchorLayout);

Ext.Container.LAYOUTS.cooliteanchor = Coolite.Ext.AnchorLayout;

// @source core/layout/CenterLayout.js

Ext.ux.layout.CenterLayout = Ext.extend(Coolite.Ext.FitLayout, {
    // private
    setItemSize : function (item, size) {
        this.container.addClass("ux-layout-center");
        item.addClass("ux-layout-center-item");
        
        if (item && size.height > 0) {
            if (item.width) {
                size.width = item.width;
            }
            item.setSize(size);
        }
    }
});

Ext.Container.LAYOUTS["ux.center"] = Ext.ux.layout.CenterLayout;

// @source core/layout/ColumnLayout.js


Coolite.Ext.ColumnLayout = Ext.extend(Ext.layout.ContainerLayout, {
    monitorResize : true,
    extraCls      : "x-column",
    scrollOffset  : 0,
    margin        : 0,
    split         : false,
    fitHeight     : false,

    // private
    isValidParent : function (c, target) {
        return (c.getPositionEl ? c.getPositionEl() : c.getEl()).dom.parentNode == this.innerCt.dom;
    },

    renderAll     : function (ct, target) {
        if (this.split && !this.splitBars) {
            this.splitBars = [];
            this.margin = 5;
        }

        Coolite.Ext.ColumnLayout.superclass.renderAll.apply(this, arguments);
    },

    // private
    onLayout : function (ct, target) {
        var cs = ct.items.items, len = cs.length, c, cel, i;

        if (!this.innerCt) {
            target.addClass("x-column-layout-ct");
            this.innerCt = target.createChild({ cls : "x-column-inner" });
            this.innerCt.createChild({ cls : "x-clear" });
        }
        
        this.renderAll(ct, this.innerCt);

        var size = Ext.isIE && ((target.dom != Ext.getBody().dom) && (target.dom != document.forms[0])) ? target.getStyleSize() : target.getViewSize();

        if (size.width < 1 && size.height < 1) { // display none?
            return;
        }

        var w = size.width - target.getPadding("lr") - this.scrollOffset,
            h = size.height - target.getPadding("tb");
        
        this.availableWidth = w;
        
        var pw = this.availableWidth, lastProportionedColumn;

        if (this.split) {
            this.minWidth = Math.min(pw / len, 100);
            this.maxWidth = pw - ((this.minWidth + 5) * (len ? (len - 1) : 1));
        }

        if (this.fitHeight) {
            this.innerCt.setSize(w, h);
        } else {
            this.innerCt.setWidth(w);
        }

        for (i = 0; i < len; i++) {
            c = cs[i];
            cel = c.getEl();

            if (this.margin && (i < (len - 1))) {
                cel.setStyle("margin-right", this.margin + "px");
            }
            
            if (c.columnWidth) {
                lastProportionedColumn = i;
            } else {
                pw -= (c.getSize().width + cel.getMargins("lr"));
            }
        }

        var remaining = (pw = pw < 0 ? 0 : pw),
            splitterPos = 0, cw;
        
        for (i = 0; i < len; i++) {
            c = cs[i];
            cel = c.getEl();
            
            if (c.columnWidth) {
                cw = (i == lastProportionedColumn) ? remaining : Math.floor(c.columnWidth * pw);
                
                if (this.fitHeight) {
                    c.setSize(cw - cel.getMargins("lr"), h);
                } else {
                    c.setSize(cw - cel.getMargins("lr"));
                }
                //c.setSize(cw - cel.getMargins("lr"), this.fitHeight ? h : null);
                remaining -= cw;
            } else if (this.fitHeight) {
                c.setHeight(h);
            }

            if (this.split) {
                cw = cel.getWidth();

                if (i < (len - 1)) {
                    splitterPos += cw;
                    
                    if (this.splitBars[i]) {
                        this.splitBars[i].el.setHeight(h);
                    } else {
                        this.splitBars[i] = new Ext.SplitBar(this.innerCt.createChild({
                            cls   : "x-layout-split x-layout-split-west",
                            style : {
                                top    : "0px",
                                left   : splitterPos + "px",
                                height : h + "px"
                            }
                        }), cel);
                        this.splitBars[i].index = i;
                        this.splitBars[i].leftComponent = c;
                        this.splitBars[i].addListener("resize", this.onColumnResize, this);
                        this.splitBars[i].minSize = this.minWidth;
                    }

                    splitterPos += this.splitBars[i].el.getWidth();
                }

                delete c.columnWidth;
            }
        }

        if (this.split) {
            this.setMaxWidths();
        }
    },

    //  On column resize, explicitly size the Components to the left and right of the SplitBar
    onColumnResize : function (sb, newWidth) {
        if (sb.dragSpecs.startSize) {
            sb.leftComponent.setWidth(newWidth);
            
            var items = this.container.items.items,
                expansion = newWidth - sb.dragSpecs.startSize,
                i, 
                c, 
                w,
                len;
            
            for (i = sb.index + 1, len = items.length; expansion && i < len; i++) {
                c = items[i];
                w = c.el.getWidth();
                    
                newWidth = w - expansion;
                
                if (newWidth < this.minWidth) {
                    c.setWidth(this.minWidth);
                } else if (newWidth > this.maxWidth) {
                    expansion -= (newWidth - this.maxWidth);
                    c.setWidth(this.maxWidth);
                } else {
                    c.setWidth(c.el.getWidth() - expansion);
                    break;
                }
            }
            this.setMaxWidths();
        }
    },

    setMaxWidths : function () {
        var items = this.container.items.items,
            spare = items[items.length - 1].el.dom.offsetWidth - 100;

        for (var i = items.length - 2; i > -1; i--) {
            var sb = this.splitBars[i], 
                sbel = sb.el, 
                c = items[i], 
                cel = c.el,
                itemWidth = cel.dom.offsetWidth;
                
            sbel.setStyle("left", (cel.getX() - Ext.fly(cel.dom.parentNode).getX() + itemWidth) + "px");
            sb.maxSize = itemWidth + spare;
            spare = itemWidth - 100;
        }
    },

    onResize : function () {
        if (this.split) {
            var items = this.container.items.items, tw = 0, c, i;
            
            if (items[0].rendered) {
                for (i = 0; i < items.length; i++) {
                    c = items[i];
                    tw += c.el.getWidth() + c.el.getMargins("lr");
                }
                
                for (i = 0; i < items.length; i++) {
                    c = items[i];
                    c.columnWidth = (c.el.getWidth() + c.el.getMargins("lr")) / tw;
                }
            }
        }
        
        Coolite.Ext.ColumnLayout.superclass.onResize.apply(this, arguments);
    }
});

Ext.reg("coolitecolumn", Coolite.Ext.ColumnLayout);

Ext.Container.LAYOUTS.coolitecolumn = Coolite.Ext.ColumnLayout;

// @source core/layout/ContainerLayout.js

Ext.layout.ContainerLayout.prototype.layout = Ext.layout.ContainerLayout.prototype.layout.createInterceptor(function () {
    if (this.activeItem) {
        this.activeItem = this.container.getComponent(this.activeItem);
    }
});

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

// @source core/layout/RowLayout.js

Ext.ux.RowLayout = Ext.extend(Ext.layout.ContainerLayout, {
    monitorResize : true,
    scrollOffset  : 0,
    margin        : 0,
    split         : false,

    // private
    isValidParent : function (c, target) {
        return (c.getPositionEl ? c.getPositionEl() : c.getEl()).dom.parentNode == this.innerCt.dom;
    },

    renderAll : function (ct, target) {
        if (this.split && !this.splitBars) {
            this.splitBars = [];
            this.margin = 5;
        }

        Ext.ux.RowLayout.superclass.renderAll.apply(this, arguments);
    },

    // private
    onLayout : function (ct, target) {
        var cs = ct.items.items, len = cs.length, c, cel, i;

        if (!this.innerCt) {
            target.addClass("x-column-layout-ct");
            this.innerCt = target.createChild({ cls : "x-column-inner" });
            this.innerCt.createChild({ cls : "x-clear" });
        }
        
        this.renderAll(ct, this.innerCt);

        var size = Ext.isIE && ((target.dom != Ext.getBody().dom) && (target.dom != document.forms[0])) ? target.getStyleSize() : target.getViewSize();

        if (size.height < 1 && size.height < 1) { // display none?
            return;
        }

        var w = size.height - target.getPadding("tb");
        
        this.availableHeight = w;
        
        var pw = this.availableHeight, lastProportionedColumn;

        if (this.split) {
            this.minHeight = Math.min(pw / len, 100);
            this.maxHeight = pw - ((this.minHeight + 5) * (len ? (len - 1) : 1));
        }

        this.innerCt.setHeight(w);

        for (i = 0; i < len; i++) {
            c = cs[i];
            cel = c.getEl();

            if (this.margin && (i < (len - 1))) {
                cel.setStyle("margin-bottom", this.margin + "px");
            }
            
            if (c.rowHeight) {
                lastProportionedColumn = i;
            } else {
                pw -= (c.getSize().height + cel.getMargins("tb"));
            }
        }

        var remaining = (pw = pw < 0 ? 0 : pw),
            splitterPos = 0, cw;
        
        for (i = 0; i < len; i++) {
            c = cs[i];
            cel = c.getEl();
            
            if (c.rowHeight) {
                cw = (i == lastProportionedColumn) ? remaining : Math.floor(c.rowHeight * pw);
                c.setHeight(cw - cel.getMargins("tb"));
                
                if (Ext.isEmpty(c.width)) {
                    var elWidth = size.width - target.getPadding("lr") - this.scrollOffset;
                    c.setWidth(elWidth);
                }
                //c.setSize(cw - cel.getMargins("tb"), this.fitHeight ? h : null);
                remaining -= cw;
            } else if (Ext.isEmpty(c.width)) {
                c.setWidth(size.width - target.getPadding("lr") - this.scrollOffset);                
            }

            if (this.split) {
                cw = cel.getHeight();

                if (i < (len - 1)) {
                    splitterPos += cw;
                    
                    this.splitBars[i] = new Ext.SplitBar(this.innerCt.createChild({
                        cls   : "x-layout-split x-layout-split-north",
                        style : {
                            left   : "0px",
                            top    : splitterPos + "px",
                            width  : "100%",
                            height : this.margin + "px"
                        }
                    }), cel, Ext.SplitBar.VERTICAL, Ext.SplitBar.TOP);
                   
                    this.splitBars[i].index = i;
                    this.splitBars[i].topComponent = c;
                    this.splitBars[i].addListener("resize", this.onColumnResize, this);
                    this.splitBars[i].minSize = this.minHeight;

                    splitterPos += this.splitBars[i].el.getHeight();
                }

                delete c.rowHeight;
            }
        }

        if (this.split) {
            this.setMaxHeights();
        }
    },

    //  On column resize, explicitly size the Components to the left and right of the SplitBar
    onColumnResize : function (sb, newHeight) {
        if (sb.dragSpecs.startSize) {
            sb.topComponent.el.setStyle("height", "");
            sb.topComponent.setHeight(newHeight);
            
            var items = this.container.items.items,
                expansion = newHeight - sb.dragSpecs.startSize;
            
            for (var i = sb.index + 1, len = items.length; expansion && i < len; i++) {
                var c = items[i],
                    w = c.el.getHeight();
                    
                newHeight = w - expansion;
                
                if (newHeight < this.minHeight) {
                    c.setHeight(this.minHeight);
                } else if (newHeight > this.maxHeight) {
                    expansion -= (newHeight - this.maxHeight);
                    c.setHeight(this.maxHeight);
                } else {
                    c.setHeight(c.el.getHeight() - expansion);
                    break;
                }
            }
            this.setMaxHeights();
        }
    },

    setMaxHeights : function () {
        var items = this.container.items.items,
            spare = items[items.length - 1].el.dom.offsetHeight - 100, i;

        for (i = items.length - 2; i > -1; i--) {
            var sb = this.splitBars[i], sbel = sb.el, c = items[i], cel = c.el,
                itemHeight = cel.dom.offsetHeight;
            
            sbel.setStyle("top", (cel.getY() - Ext.fly(cel.dom.parentNode).getY() + itemHeight) + "px");
            sb.maxSize = itemHeight + spare;
            spare = itemHeight - 100;
        }
    },

    onResize : function () {
        if (this.split) {
            var items = this.container.items.items, tw = 0, c, i;
            
            if (items[0].rendered) {
                for (i = 0; i < items.length; i++) {
                    c = items[i];
                    tw += c.el.getHeight() + c.el.getMargins("tb");
                }
                
                for (i = 0; i < items.length; i++) {
                    c = items[i];
                    c.rowHeight = (c.el.getHeight() + c.el.getMargins("tb")) / tw;
                }
            }
        }
        Ext.ux.RowLayout.superclass.onResize.apply(this, arguments);
    },

    renderItem : function (c) {
        Ext.ux.RowLayout.superclass.renderItem.apply(this, arguments);
        
        c.on("collapse", function () { 
            this.layout(); 
        }, this);
        
        c.on("expand", function () { 
            this.layout(); 
        }, this);
    }
});

Ext.Container.LAYOUTS["ux.row"] = Ext.ux.RowLayout;

// @source core/ajax/Ajax.js

Ext.apply(Ext.lib.Ajax, {
    serializeForm : function (form, parent) {
        if (typeof form == "string") {
            form = (document.getElementById(form) || document.forms[form]);
        }

        var el, name, val, disabled, data = [], hasSubmit = false;
        
        hasSubmit = form.ignoreAllSubmitFields || false;
        
        for (var i = 0; i < form.elements.length; i++) {
            el = form.elements[i];
            disabled = form.elements[i].disabled;
            name = form.elements[i].name;
            val = form.elements[i].value;

            if (!Ext.isEmpty(parent) && Ext.isEmpty(Ext.fly(form.elements[i]).parent("#" + parent.id))) {
                continue;
            }

            if (name) {
                switch (el.type) {
                case "select-one":
                case "select-multiple":
                    for (var j = 0; j < el.options.length; j++) {
                        if (el.options[j].selected) {
                            if (Ext.isIE) {
                                data.push(encodeURIComponent(name));
                                data.push("=");
                                data.push(encodeURIComponent(el.options[j].attributes.value.specified ? el.options[j].value : el.options[j].text));
                                data.push("&");
                                //data += encodeURIComponent(name) + "=" + encodeURIComponent(el.options[j].attributes.value.specified ? el.options[j].value : el.options[j].text) + "&";
                            } else {
                                data.push(encodeURIComponent(name));
                                data.push("=");
                                data.push(encodeURIComponent(el.options[j].hasAttribute("value") ? el.options[j].value : el.options[j].text));
                                data.push("&");
                                //data += encodeURIComponent(name) + "=" + encodeURIComponent(el.options[j].hasAttribute("value") ? el.options[j].value : el.options[j].text) + "&";
                            }
                        }
                    }
                    break;
                case "radio":
                case "checkbox":
                    if (el.checked) {
                        data.push(encodeURIComponent(name));
                        data.push("=");
                        data.push(encodeURIComponent(val));
                        data.push("&");
                        //data += encodeURIComponent(name) + "=" + encodeURIComponent(val) + "&";
                    }
                    break;
                case "file":
                case undefined:
                case "reset":
                case "button":
                    break;
                case "submit":
                    if (hasSubmit === false) {
                        data.push(encodeURIComponent(name));
                        data.push("=");
                        data.push(encodeURIComponent(val));
                        data.push("&");
                        //data += encodeURIComponent(name) + "=" + encodeURIComponent(val) + "&";
                        hasSubmit = true;
                    }
                    break;
                default:
                    data.push(encodeURIComponent(name));
                    data.push("=");
                    data.push(encodeURIComponent(val));
                    data.push("&");
                    //data += encodeURIComponent(name) + "=" + encodeURIComponent(val) + "&";
                    break;
                }
            }
        }
        
        data = data.join("");
        data = data.substr(0, data.length - 1);
        return data;
    }
});

// @source core/ajax/AjaxEvent.js

Coolite.AjaxEvent = new Ext.data.Connection({
    autoAbort      : false,
    
    confirmTitle   : "Confirmation",
    
    confirmMessage : "Are you sure?",

    doFormUpload : function (o, ps, url) {
        var id = Ext.id(),
            frame = document.createElement("iframe"),
            form;
            
        frame.id = id;
        frame.name = id;
        frame.className = "x-hidden";
        
        if (Ext.isIE) {
            frame.src = Ext.SSL_SECURE_URL;
        }
        
        document.body.appendChild(frame);

        if (Ext.isIE) {
            document.frames[id].name = id;
        }

        form = Ext.getDom(o.form);
        form.target = id;
        form.method = "POST";
        form.enctype = form.encoding = "multipart/form-data";
        
        if (url) {
            form.action = url;
        }

        var hiddens, hd;
        
        if (ps) { // add dynamic params
            hiddens = [];
            ps = Ext.urlDecode(ps, false);
            
            for (var k in ps) {
                if (ps.hasOwnProperty(k)) {
                    hd = document.createElement("input");
                    hd.type = "hidden";
                    hd.name = k;
                    hd.value = ps[k];
                    form.appendChild(hd);
                    hiddens.push(hd);
                }
            }
        }

        var cb = function () {
            var r = {
                responseText : "",
                responseXML  : null
            };

            r.argument = o ? o.argument : null;

            try {
                var doc, firstChild;
                
                if (Ext.isIE) {
                    doc = frame.contentWindow.document;
                } else {
                    doc = (frame.contentDocument || window.frames[id].document);
                }
                
                if (doc && doc.body) {
                    if (/textarea/i.test((firstChild = doc.body.firstChild || {}).tagName)) {
                        r.responseText = firstChild.value;
                    } else if (doc.body.innerText) {
                        r.responseText = doc.body.innerText;
                    } else if (doc.body.textContent) {
                        r.responseText = doc.body.textContent;
                    } else {
                        r.responseText = doc.body.innerHTML;
                    }
                }
                
                if (doc && doc.XMLDocument) {
                    r.responseXML = doc.XMLDocument;
                } else {
                    r.responseXML = doc;
                }
            }
            catch (e) {
                // ignore
            }

            Ext.EventManager.removeListener(frame, "load", cb, this);

            this.fireEvent("requestcomplete", this, r, o);

            Ext.callback(o.success, o.scope, [r, o]);
            Ext.callback(o.callback, o.scope, [o, true, r]);

            setTimeout(function () { 
                Ext.removeNode(frame); 
                form.target = "";
            }, 100);
        };

        Ext.EventManager.on(frame, "load", cb, this);
        
        form.submit();

        if (hiddens) { // remove dynamic params
            for (var i = 0, len = hiddens.length; i < len; i++) {
                Ext.removeNode(hiddens[i]);
            }
        }        
    },

    confirmRequest : function (ajaxEventConfig) {
        ajaxEventConfig = ajaxEventConfig || {};
        if (ajaxEventConfig.confirmation && ajaxEventConfig.confirmation.confirmRequest) {
            if (ajaxEventConfig.confirmation.beforeConfirm && ajaxEventConfig.confirmation.beforeConfirm(ajaxEventConfig) === false) {
                Coolite.AjaxEvent.request(ajaxEventConfig);
                return;
            }
            
            Ext.Msg.confirm(
                ajaxEventConfig.confirmation.title || this.confirmTitle,
                ajaxEventConfig.confirmation.message || this.confirmMessage,
                this.confirmAnswer.createDelegate(this, [ajaxEventConfig], true),
                this);
        } else {
            Coolite.AjaxEvent.request(ajaxEventConfig);
        }
    },

    confirmAnswer : function (btn, text, buttonConfig, ajaxEventConfig) {
        if (btn == "yes") {
            Coolite.AjaxEvent.request(ajaxEventConfig);
        }
    },

    serializeForm : function (form) {
        return Ext.lib.Ajax.serializeForm(form);
    },
    
    setValue : function (form, name, value) {
        var input = null, pe;
        
        var els = Ext.fly(form).select("input[name=" + name + "]");
        
        if (els.getCount() > 0) {
            input = els.elements[0];
        } else {
            input = document.createElement("input");
            input.setAttribute("name", name);
            input.setAttribute("type", "hidden");
        }
        
        input.setAttribute("value", value);
        
        pe = input.parentElement ? input.parentElement : input.parentNode;
        
        if (Ext.isEmpty(pe)) {
            form.appendChild(input);
            //form[name] = input;
        }
    },
    
    delayedF : function (el, remove) {
        if (!Ext.isEmpty(el)) {
            el.unmask();
            
            if (remove === true) {
                el.remove();
            }
        }
    },
    
    showFailure : function (response, errorMsg) {
        var bodySize = Ext.getBody().getViewSize(),
            width = (bodySize.width < 500) ? bodySize.width - 50 : 500,
            height = (bodySize.height < 300) ? bodySize.height - 50 : 300,
            win;

        if (Ext.isEmpty(errorMsg)) {
            errorMsg = response.responseText;
        }

        win = new Ext.Window({ 
            modal       : true, 
            width       : width, 
            height      : height, 
            title       : "Request Failure", 
            layout      : "fit", 
            maximizable : true,
            listeners   : {
                "maximize": {
                    fn : function (el) {
                        var v = Ext.getBody().getViewSize();
                        el.setSize(v.width, v.height);
                    },
                    scope : this
                },

                "resize": {
                    fn : function (wnd) {
                        var editor = Ext.getCmp("__ErrorMessageEditor");
                        var sz = wnd.body.getViewSize();
                        editor.setSize(sz.width, sz.height - 42);
                    }
                }
            },
            items : new Ext.form.FormPanel({
                baseCls     : "x-plain",
                layout      : "absolute",
                defaultType : "label",
                items : [
                    {
                        x    : 5,
                        y    : 5,
                        html : '<div class="x-window-dlg"><div class="ext-mb-error" style="width:32px;height:32px"></div></div>'
                    }, 
                    {
                        x    : 42,
                        y    : 6,
                        html : "<b>Status code: </b>"
                    }, 
                    {
                        x    : 125,
                        y    : 6,
                        text : response.status
                    }, 
                    {
                        x    : 42,
                        y    : 25,
                        html : "<b>Status text: </b>"
                    }, 
                    {
                        x    : 125,
                        y    : 25,
                        text : response.statusText
                    }, 
                    {
                        x     : 0,
                        y     : 42,
                        id    : "__ErrorMessageEditor",
                        xtype : "htmleditor",
                        enableAlignments : false,
                        enableColors     : false,
                        enableFont       : false,
                        enableFontSize   : false,
                        enableFormat     : false,
                        enableLinks      : false,
                        enableLists      : false,
                        enableSourceEdit : false,
                        readOnly         : true,
                        value            : errorMsg
                    }
                ]
            })
        });
        win.show();
    },
        
    parseResponse : function (response) {
        var text = response.responseText,
            xmlTpl = "<?xml",
            result = {},
            exception = false;

        result.success = true;

        try {
            if (response.responseText.match(/^<\?xml/) == xmlTpl) {
                //xml parsing      
                var xmlData = response.responseXML,
                    root = xmlData.documentElement || xmlData,
                    q = Ext.DomQuery;

                if (root.nodeName == "AjaxResponse") {
                    //root = q.select("AjaxResponse", root);
                    //success
                    var sv = q.selectValue("Success", root, true),
                        pSuccess = sv !== false && sv !== "false",
                        pErrorMessage = q.selectValue("ErrorMessage", root, ""),
                        pScript = q.selectValue("Script", root, ""),
                        pViewState = q.selectValue("ViewState", root, ""),
                        pViewStateEncrypted = q.selectValue("ViewStateEncrypted", root, ""),
                        pEventValidation = q.selectValue("EventValidation", root, ""),
                        pServiceResponse = q.selectValue("ServiceResponse", root, ""),
                        pUserParamsResponse = q.selectValue("ExtraParamsResponse", root, ""),
                        pResult = q.selectValue("Result", root, "");

                    if (!Ext.isEmpty(pSuccess)) {
                        Ext.apply(result, { success : pSuccess });
                    }

                    if (!Ext.isEmpty(pErrorMessage)) {
                        Ext.apply(result, { errorMessage : pErrorMessage });
                    }

                    if (!Ext.isEmpty(pScript)) {
                        Ext.apply(result, { script : pScript });
                    }

                    if (!Ext.isEmpty(pViewState)) {
                        Ext.apply(result, { viewState : pViewState });
                    }

                    if (!Ext.isEmpty(pViewStateEncrypted)) {
                        Ext.apply(result, { viewStateEncrypted : pViewStateEncrypted });
                    }

                    if (!Ext.isEmpty(pEventValidation)) {
                        Ext.apply(result, { eventValidation : pEventValidation });
                    }

                    if (!Ext.isEmpty(pServiceResponse)) {
                        Ext.apply(result, { serviceResponse : eval("(" + pServiceResponse + ")") });
                    }

                    if (!Ext.isEmpty(pUserParamsResponse)) {
                        Ext.apply(result, { extraParamsResponse : eval("(" + pUserParamsResponse + ")") });
                    }

                    if (!Ext.isEmpty(pResult)) {
                        Ext.apply(result, { result : eval("(" + pResult + ")") });
                    }

                    return { result : result, exception : false };
                }
                else {
                    return { result : response.responseXML, exception : false }; // root.text || root.textContent;
                }
            }

            //json parsing
            result = eval("(" + text + ")");

        } catch (e) {
            result.success = false;
            exception = true;
            
            if (response.responseText.length === 0) {
                result.errorMessage = "NORESPONSE";
            } else {
                result.errorMessage = "BADRESPONSE: " + e.message;
                result.responseText = response.responseText;
            }

            response.statusText = result.errorMessage;
        }

        return { result : result, exception : exception };
    },

    listeners : {
        beforerequest : {
            fn : function (conn, options) {
                var o = options || {};
                
                o.eventType = o.eventType || "event";

                var isInstance = o.eventType == "public",
                    submitConfig = {},
                    forms;
                    
                o.extraParams = o.extraParams || {};
                
                switch (o.eventType) {
                case "event"    :
                case "custom"   : 
                case "proxy"    :
                case "postback" :
                case "public"   :
                    if (isInstance) {
                        o.action = o.name;
                    }

                    o.control = o.control || {};
                    o.type = o.type || "submit";
                    o.viewStateMode = o.viewStateMode || "default";
                    o.action = o.action || "Click";
                    o.headers = { "X-Coolite": "delta=true" };

                    if (o.type == "submit") {
                        o.form = Ext.get(o.formProxyArg);

                        if (!Ext.isEmpty(o.form) && !Ext.isEmpty(o.form.id)) {
                            var cmp = Ext.getCmp(o.form.id);
                            
                            if (!Ext.isEmpty(cmp) && cmp.getForm && cmp.startMonitoring) {
                                if (cmp.form && cmp.form.el.dom.elements) {
                                    o.form = cmp.form.el;
                                } else {
                                    o.form = undefined;
                                }
                            }
                        }

                        if (Ext.isEmpty(o.form) && !Ext.isEmpty(o.control.el)) {
                            if (Ext.isEmpty(o.control.isComposite) || o.control.isComposite === false) {
                                o.form = o.control.el.up("form");
                            } else {
                                o.form = Ext.get(o.control.elements[0]).up("form");
                            }
                        }
                    } else if (o.type == "load" && Ext.isEmpty(o.method)) {
                        o.method = "GET";
                    }

                    if (Ext.isEmpty(o.form) && Ext.isEmpty(o.url)) {
                        forms = Ext.select("form").elements;

                        if (forms.length > 0) {
                            if (o.type == "submit") {
                                o.form = (forms.length > 0) ? Ext.get(forms[0]) : undefined;
                            }
                            else {
                                o.url = (forms.length > 0) ? forms[0].action : Coolite.Ext.Url || window.location.href;
                            }
                        }
                    }

                    var argument = String.format("{0}|{1}|{2}", o.proxyId || o.control.proxyId || o.control.id || "-", o.eventType, o.action);

                    if (!Ext.isEmpty(o.form)) {
                        this.setValue(o.form.dom, "__EVENTTARGET", Coolite.ScriptManager);
                        this.setValue(o.form.dom, "__EVENTARGUMENT", argument);
                        Ext.getDom(o.form).ignoreAllSubmitFields = true;
                    } else {
                        o.url = o.url || Coolite.Ext.Url || window.location.href;
                        Ext.apply(submitConfig, { __EVENTTARGET : Coolite.ScriptManager, __EVENTARGUMENT : argument });
                    }

                    if (o.viewStateMode != "default") {
                        Ext.apply(submitConfig, { viewStateMode : o.viewStateMode });
                    }

                    if (o.before) {                        
                        if (o.before(o.control, o.eventType, o.action, o.extraParams) === false) {
                            return false;
                        }
                    }
                    
                    if (this.fireEvent("beforeajaxrequest", o.control, o.eventType, o.action, o.extraParams, o) === false) {
                        return false;
                    }

                    if (!Ext.isEmpty(o.extraParams) && !Ext.isEmptyObj(o.extraParams)) {
                        Ext.apply(submitConfig, { extraParams : o.extraParams });
                    }

                    if (!Ext.isEmpty(o.serviceParams)) {
                        Ext.apply(submitConfig, { serviceParams : o.serviceParams });
                    }

                    if (!Ext.isEmpty(submitConfig) && !Ext.isEmptyObj(submitConfig)) {
                        o.params = { submitAjaxEventConfig : Ext.encode({ config : submitConfig }) };
                    } else {
                        o.params = {};
                    }
                    
                    if (!Ext.isEmpty(o.form)) {
                        var enctype = Ext.getDom(o.form).getAttribute("enctype");
                        
                        if ((enctype && enctype.toLowerCase() == "multipart/form-data") || o.isUpload) {
                            Ext.apply(o.params, { "__CooliteAjaxEventMarker": "delta=true" });
                        }
                    }

                    if (o.cleanRequest) {
                        o.params = Ext.apply({}, o.extraParams || {});
                        
                        for (var key in o.params) {
                            var ov = o.params[key];
                            
                            if (typeof ov == "object") {
                                o.params[key] = Ext.encode(ov);
                            }
                        }
                        
                        if (o.json) {
                            o.jsonData = o.params;                        
                        }
                    }

                    if (!Ext.isEmpty(o.form)) {
                        o.form.dom.action = o.form.dom.action || o.form.action || o.url || Coolite.Ext.Url || window.location.href;
                    }

                    break;
                case "static":
                    o.headers = { "X-Coolite": "delta=true,staticmethod=true" };

                    if (Ext.isEmpty(o.form) && Ext.isEmpty(o.url)) {
                        forms = Ext.select("form").elements;
                        o.url = (forms.length == 1 && !Ext.isEmpty(forms[0].action)) ? forms[0].action : Coolite.Ext.Url || window.location.href;
                    }

                    if (o.before) {
                        if (o.before(o.control, o.eventType, o.action, o.extraParams) === false) {
                            return false;
                        }
                    }
                    
                    if (this.fireEvent("beforeajaxrequest", o.control, o.eventType, o.action, o.extraParams, o) === false) {
                        return false;
                    }

                    o.params = Ext.apply(o.extraParams, { "_methodName_": o.name });
                    break;
                }

                o.scope = this;

                //--Common part----------------------------------------------------------

                var el, em = o.eventMask || {};
                
                if ((em.showMask === true)) {
                    switch (em.target || "page") {
                    case "this":
                        if (o.control.getEl) {
                            el = o.control.getEl();
                        } else if (o.control.dom) {
                            el = o.control;
                        }
                        break;
                    case "parent":
                        if (o.control.getEl) {
                            el = o.control.getEl().parent();
                        } else if (o.control.parent) {
                            el = o.control.parent();
                        }
                        break;
                    case "page":
                        var theHeight = "100%";
                        
                        if (window.innerHeight) {
                            theHeight = window.innerHeight + "px";
                        } else if (document.documentElement && document.documentElement.clientHeight) {
                            theHeight = document.documentElement.clientHeight + "px";
                        } else if (document.body) {
                            theHeight = document.body.clientHeight + "px";
                        }

                        el = Ext.getBody().createChild({ style : "position:absolute;left:0;top:0;width:100%;height:" + theHeight + ";z-index:20000;background-color:Transparent;" });
                        
                        var scroll = Ext.getBody().getScroll();
                        el.setLeftTop(scroll.left, scroll.top);
                        break;
                    case "customtarget":
                        var trg = em.customTarget || "";
                        el = Coolite.Ext.getEl(trg);
                        
                        if (Ext.isEmpty(el)) {
                            el = trg.getEl ? trg.getEl() : null;
                        }
                        
                        break;
                    }

                    if (!Ext.isEmpty(el)) {
                        el.mask(em.msg || Ext.LoadMask.prototype.msg, em.msgCls || Ext.LoadMask.prototype.msgCls);
                        o.el = el;
                    }
                }

                var removeMask = function (o) {
                    if (o.el !== undefined && o.el !== null) {
                        var delay = 0,
                            em = o.eventMask || {},
                            task;
                            
                        if (em && em.minDelay) {
                            delay = em.minDelay;
                        }

                        var remove = (em.target || "page") == "page";
                        
                        task = new Ext.util.DelayedTask(function (o, remove) {
                                o.scope.delayedF(o.el, remove);
                            }, o.scope, [o, remove]).delay(delay);
                    }
                };

                var executeScript = function (o, result, response) {
                    var delay = 0,
                        em = o.eventMask || {};
                        
                    if (em.minDelay) {
                        delay = em.minDelay;
                    }

                    var task = new Ext.util.DelayedTask(
                        function (o, result, response) {
                            if (result.script && result.script.length > 0) {
                                eval(result.script);
                            }
                            
                            this.fireEvent("ajaxrequestcomplete", response, result, o.control, o.eventType, o.action, o.extraParams, o);

                            if (o.userSuccess) {
                                o.userSuccess(response, result, o.control, o.eventType, o.action, o.extraParams, o);
                            }
                        },
                        o.scope, [o, result, response]).delay(delay);
                };


                o.failure = function (response, options) {
                    var o = options;
                    removeMask(o);
                    
                    if (this.fireEvent("ajaxrequestexception", response, { "errorMessage": response.statusText }, o.control, o.eventType, o.action, o.extraParams, o) === false) {
                        o.cancelFailureWarning = true;
                    }
                    
                    if (o.userFailure && (Ext.isEmpty(o.enforceFailureWarning) || !o.enforceFailureWarning)) {
                        o.userFailure(response, { "errorMessage": response.statusText }, o.control, o.eventType, o.action, o.extraParams, o);
                    } else if (o.showWarningOnFailure !== false && !o.cancelFailureWarning) {
                        o.scope.showFailure(response, "");
                    }
                };

                o.success = function (response, options) {
                    var o = options;
                    
                    removeMask(o);

                    var parsedResponse = o.scope.parseResponse(response);

                    if (!Ext.isEmpty(parsedResponse.result.documentElement)) {
                        executeScript(o, parsedResponse.result, response);
                        return;
                    }
                    
                    var result = parsedResponse.result,
                        exception = parsedResponse.exception;

                    if (result.success === false) {
                        if (this.fireEvent("ajaxrequestexception", response, result, o.control, o.eventType, o.action, o.extraParams, o) === false) {
                            o.cancelFailureWarning = true;
                        }
                        
                        if (o.userFailure && (Ext.isEmpty(o.enforceFailureWarning) || !o.enforceFailureWarning)) {
                            o.userFailure(response, result, o.control, o.eventType, o.action, o.extraParams, o);
                        } else {
                            if (o.showWarningOnFailure !== false && !o.cancelFailureWarning) {
                                var errorMsg = "";
                                
                                if (!exception && result.errorMessage && result.errorMessage.length > 0) {
                                    errorMsg = result.errorMessage;
                                }
                                
                                o.scope.showFailure(response, errorMsg);
                            }
                        }

                        return;
                    }

                    if (!Ext.isEmpty(result.viewState) && o.form !== null) {
                        o.scope.setValue(o.form.dom, "__VIEWSTATE", result.viewState);
                        delete result.viewState;

                        if (!Ext.isEmpty(result.viewStateEncrypted) && o.form !== null) {
                            o.scope.setValue(o.form.dom, "__VIEWSTATEENCRYPTED", result.viewStateEncrypted);
                            delete result.viewStateEncrypted;
                        }

                        if (!Ext.isEmpty(result.eventValidation) && o.form !== null) {
                            o.scope.setValue(o.form.dom, "__EVENTVALIDATION", result.eventValidation);
                            delete result.eventValidation;
                        }
                    }

                    executeScript(o, result, response);
                };
            }
        }
    }
});

Coolite.AjaxEvent.addEvents("beforeajaxrequest", "ajaxrequestcomplete", "ajaxrequestexception");

// @source core/form/AjaxMethod.js

Coolite.AjaxMethod = {
    request : function (name, options) {
        options = options || {};

        if (typeof options !== "object") {
            
            throw { message : "The AjaxMethod options object is an invalid type: typeof " + typeof options };
        }

        if (!Ext.isEmpty(name) && typeof name === "object" && Ext.isEmptyObj(options)) {
            options = name;
        }

        var obj = {
            name              : options.cleanRequest ? undefined : (options.name || name),
            cleanRequest      : options.cleanRequest,
            url               : options.url,
            control           : Ext.isEmpty(options.control) ? null : { id : options.control },
            eventType         : options.specifier || "public",
            type              : options.type || "submit",
            method            : options.method || "POST",
            eventMask         : options.eventMask,
            extraParams       : options.params,
            ajaxMethodSuccess : options.success,
            ajaxMethodFailure : options.failure,
            viewStateMode     : options.viewStateMode,
            userSuccess       : function (response, result, control, eventType, action, extraParams, o) {
                if (!Ext.isEmpty(o.ajaxMethodSuccess)) {
                    result = Ext.isEmpty(result.result, true) ? (result.d || result) : result.result;
                    o.ajaxMethodSuccess(result, response, extraParams, o);
                }
            },
            userFailure       : function (response, result, control, eventType, action, extraParams, o) {
                if (!Ext.isEmpty(o.ajaxMethodFailure)) {
                    o.ajaxMethodFailure(result.errorMessage, response, extraParams, o);
                }
            }
        };

        Coolite.AjaxEvent.request(Ext.apply(options, obj));
    }
};

// @source core/buttons/Button.js

Ext.override(Ext.Button, {
    setTooltip : function (tooltip) {
        this.tooltip = tooltip;
        
        var btnEl = this.getEl().child(this.buttonSelector);
        
        if (typeof tooltip == "object") {
            Ext.QuickTips.register(Ext.apply({
                target : btnEl.id
            }, tooltip));
        } else {
            btnEl.dom[this.tooltipType] = tooltip;
        }
    },
	
	getPressedField : function () {
        if (!this.pressedField) {
            this.pressedField = new Ext.form.Hidden({ id : this.id + "_Pressed", name : this.id + "_Pressed" });
        }
        return this.pressedField;
    },
    
    menuArrow : true,
    
    toggleMenuArrow : function () {
        if (this.menuArrow === false) {
            this.showMenuArrow();
            this.menuArrow = true;
        } else {
            this.hideMenuArrow();
            this.menuArrow = false;
        }
    },
    
    showMenuArrow : function () {
        this.el.child(this.menuClassTarget).addClass("x-btn-with-menu");
    },
    
    hideMenuArrow : function () {
        this.el.child(this.menuClassTarget).removeClass("x-btn-with-menu");
    }
});

Ext.Button.prototype.onRender = Ext.Button.prototype.onRender.createSequence(function (el) {
    if (this.enableToggle || !Ext.isEmpty(this.toggleGroup)) {
        this.getPressedField().render(this.el.parent() || this.el);
    }
    
    if (this.flat) {
        this.el.wrap({ cls : "x-toolbar x-inline-toolbar" }); 
    }
    
    if (this.menuArrow === false) {
        this.hideMenuArrow();
    }
});

// @source core/buttons/CycleButton.js

Ext.override(Ext.CycleButton, {
    initComponent : function () {
        this.addEvents("change");

        if (this.changeHandler) {
            this.on("change", this.changeHandler, this.scope || this);
            delete this.changeHandler;
        }

        this.itemCount = this.menu.items.length;

        this.menu.cls = "x-cycle-menu";
        
        var checked, item;
        
        for (var i = 0, len = this.itemCount; i < len; i++) {
            item = this.menu.items.itemAt(i);

            item.group = item.group || this.id;

            item.itemIndex = i;
            item.on("checkchange", this.checkHandler, this);
            item.scope = this;
            item.setChecked(item.checked || false, true);

            if (item.checked) {
                checked = item;
            }
        }
        this.setActiveItem(checked, true);
        Ext.CycleButton.superclass.initComponent.call(this);

        this.on("click", this.toggleSelected, this);
    }
});

// @source core/buttons/ImageButton.js

Coolite.Ext.ImageButton = Ext.extend(Ext.Button, {
    buttonSelector : "img",
    cls            : "",
    iconAlign      : "left",

    initComponent : function () {
        Coolite.Ext.ImageButton.superclass.initComponent.call(this);        
        
        if (this.imageUrl) {
            new Image().src = this.imageUrl;
        }

        if (this.overImageUrl) {
            new Image().src = this.overImageUrl;
        }

        if (this.disabledImageUrl) {
            new Image().src = this.disabledImageUrl;
        }

        if (this.pressedImageUrl) {
            new Image().src = this.pressedImageUrl;
        }
    },

    onRender : function (ct, position) {
        if (!this.el) {
            var img = document.createElement("img");
            img.id = this.getId();
            img.src = this.imageUrl;
            img.style.border = "none";
            img.style.cursor = "pointer";

            this.imgEl = Ext.get(img);
            this.el = this.imgEl;

            if (!Ext.isEmpty(this.imgEl.getAttributeNS("", "width"), false) ||
                !Ext.isEmpty(this.imgEl.getAttributeNS("", "height"), false)) {
                img.removeAttribute("width");
                img.removeAttribute("height");
            }

            if (this.altText) {
                img.setAttribute("alt", this.altText);
            }

            if (this.align && this.align !== "notset") {
                img.setAttribute("align", this.align);
            }

            if (this.pressed && this.pressedImageUrl) {
                img.src = this.pressedImageUrl;
            }

            if (this.disabled && this.disabledImageUrl) {
                img.src = this.disabledImageUrl;
            }

            if (this.tabIndex !== undefined) {
                img.tabIndex = this.tabIndex;
            }

            if (this.menu) {
                this.menu.on("show", this.onMenuShow, this);
                this.menu.on("hide", this.onMenuHide, this);
            }

            if (this.repeat) {
                var repeater = new Ext.util.ClickRepeater(this.imgEl,
                    typeof this.repeat == "object" ? this.repeat : {}
                );
                repeater.on("click", this.onClick, this);
            }

            this.imgEl.on(this.clickEvent, this.onClick, this);

            if (this.handleMouseEvents) {
                this.imgEl.on("mouseover", this.onMouseOver, this);
                this.imgEl.on("mousedown", this.onMouseDown, this);
            }

            if (!Ext.isEmpty(this.cls, false)) {
                this.el.dom.className = this.cls;
            }

            Ext.BoxComponent.superclass.onRender.call(this, ct, position);
        }

        if (this.tooltip) {
            if (typeof this.tooltip == "object") {
                Ext.QuickTips.register(Ext.apply({
                    target : this.imgEl.id
                }, this.tooltip));
            } else {
                this.imgEl.dom[this.tooltipType] = this.tooltip;
            }
        }


        Ext.ButtonToggleMgr.register(this);
    },

    afterRender : function () {
        Ext.Button.superclass.afterRender.call(this);
    },

    // private
    onMenuShow : function (e) {
        this.ignoreNextClick = 0;
        this.fireEvent("menushow", this, this.menu);
    },
    
    // private
    onMenuHide : function (e) {
        this.ignoreNextClick = this.restoreClick.defer(250, this);
        this.fireEvent("menuhide", this, this.menu);
    },

    toggle : function (state) {
        state = state === undefined ? !this.pressed : state;
        if (state != this.pressed) {
            if (state) {
                if (this.pressedImageUrl) {
                    this.imgEl.dom.src = this.pressedImageUrl;
                }
                
                this.pressed = true;
                this.fireEvent("toggle", this, true);
            } else {
                this.imgEl.dom.src = (this.monitoringMouseOver) ? this.overImageUrl : this.imageUrl;
                this.pressed = false;
                this.fireEvent("toggle", this, false);
            }
            
            if (this.toggleHandler) {
                this.toggleHandler.call(this.scope || this, this, state);
            }
        }
    },

    setText : function (t, encode) {
    },

    setDisabled : function (disabled) {
        this.disabled = disabled;
        if (disabled) {
            if (this.disabledImageUrl) {
                this.imgEl.dom.src = this.disabledImageUrl;
            }
        } else {
            this.imgEl.dom.src = this.imageUrl;
        }
    },

    // private
    onMouseOver : function (e) {
        if (!this.disabled) {
            var internal = e.within(this.el.dom, true);
            if (!internal) {
                if (this.overImageUrl && !this.pressed) {
                    this.imgEl.dom.src = this.overImageUrl;
                }

                if (!this.monitoringMouseOver) {
                    Ext.getDoc().on("mouseover", this.monitorMouseOver, this);
                    this.monitoringMouseOver = true;
                }
            }
        }
        this.fireEvent("mouseover", this, e);
    },

    // private
    onMouseOut : function (e) {
        if (!this.disabled && !this.pressed) {
            this.imgEl.dom.src = this.imageUrl;
        }
        
        this.fireEvent("mouseout", this, e);
    },

    onMouseDown : function (e) {
        if (!this.disabled && e.button === 0) {
            if (this.pressedImageUrl) {
                this.imgEl.dom.src = this.pressedImageUrl;
            }
            
            Ext.getDoc().on("mouseup", this.onMouseUp, this);
        }
    },
    
    // private
    onMouseUp : function (e) {
        if (e.button === 0) {
            this.imgEl.dom.src = (this.overImageUrl && this.monitoringMouseOver) ? this.overImageUrl : this.imageUrl;
            Ext.getDoc().un("mouseup", this.onMouseUp, this);
        }
    },
    
    setImageUrl : function (image) {
        this.imageUrl = image;
        
        if ((!this.disabled || Ext.isEmpty(this.disabledImageUrl, false)) && 
            (!this.pressed || Ext.isEmpty(this.pressedImageUrl, false))) {
            this.imgEl.dom.src = image;
        } else {
            new Image().src = image;
        }
    },
    
    setDisabledImageUrl : function (image) {
        this.disabledImageUrl = image;
        
        if (this.disabled) {
            this.imgEl.dom.src = image;
        } else {
            new Image().src = image;
        }
    },
    
    setOverImageUrl : function (image) {
        this.overImageUrl = image;
        
        if ((!this.disabled || Ext.isEmpty(this.disabledImageUrl, false)) &&
            this.monitoringMouseOver &&
            (!this.pressed || Ext.isEmpty(this.pressedImageUrl, false))) {
            this.imgEl.dom.src = image;
        } else {
            new Image().src = image;
        }
    },
    
    setPressedImageUrl : function (image) {
        this.pressedImageUrl = image;
        
        if ((!this.disabled || Ext.isEmpty(this.disabledImageUrl, false)) && this.pressed) {
            this.imgEl.dom.src = image;
        } else {
            new Image().src = image;
        }
    },
    
    setAlign : function (align) {
        this.align = align;
        
        if (this.rendered) {
            this.imgEl.dom.setAttribute("align", this.align);
        }
    },

    setAltText : function (altText) {
        this.altText = altText;
        
        if (this.rendered) {
            this.imgEl.dom.setAttribute("altText", this.altText);
        }
    }
});

Ext.reg("imagebutton", Coolite.Ext.ImageButton);

// @source core/buttons/LinkButton.js

Coolite.Ext.LinkButton = Ext.extend(Ext.Button, {
    buttonSelector : "a:first",
    cls            : "",
    iconAlign      : "left",

    valueElement : function () {
        var textEl = document.createElement("a");
        
        textEl.style.verticalAlign = "middle";
        textEl.id = Ext.id();
        
        if (!Ext.isEmpty(this.cls, false)) {
            textEl.className = this.cls;
        }

        textEl.setAttribute("href", "#");

        if (this.disabled || this.pressed) {
            textEl.setAttribute("disabled", "1");
            textEl.removeAttribute("href");

            if (this.pressed && this.allowDepress !== false) {
                textEl.style.cursor = "pointer";
            }
        }

        if (this.tabIndex !== undefined) {
            textEl.tabIndex = this.tabIndex;
        }
        
        if (this.tooltip) {
            if (typeof this.tooltip == "object") {
                Ext.QuickTips.register(Ext.apply({
                    target : textEl.id
                }, this.tooltip));
            } else {
                textEl[this.tooltipType] = this.tooltip;
            }
        }

        textEl.innerHTML = this.text;
        
        var txt = Ext.get(textEl);

        if (this.menu) {
            this.menu.on("show", this.onMenuShow, this);
            this.menu.on("hide", this.onMenuHide, this);
        }

        if (this.repeat) {
            var repeater = new Ext.util.ClickRepeater(txt,
                typeof this.repeat == "object" ? this.repeat : {}
            );
            repeater.on("click", this.onClick, this);
        }

        txt.on(this.clickEvent, this.onClick, this);

        this.textEl = textEl;
        return this.textEl;
    },

    // private
    onMenuShow : function (e) {
        this.ignoreNextClick = 0;
        this.fireEvent("menushow", this, this.menu);
    },
    
    // private
    onMenuHide : function (e) {
        this.ignoreNextClick = this.restoreClick.defer(250, this);
        this.fireEvent("menuhide", this, this.menu);
    },

    toggle : function (state) {
        state = state === undefined ? !this.pressed : state;
        if (state != this.pressed) {
            if (state) {
                this.setDisabled(true);
                this.disabled = false;
                this.pressed = true;
                
                if (this.allowDepress !== false) {
                    this.textEl.style.cursor = "pointer";
                    this.el.dom.style.cursor = "pointer";
                }
                this.fireEvent("toggle", this, true);
            } else {
                this.setDisabled(false);
                this.pressed = false;
                this.fireEvent("toggle", this, false);
            }
            
            if (this.toggleHandler) {
                this.toggleHandler.call(this.scope || this, this, state);
            }
        }
    },

    onRender : function (ct, position) {
        if (!this.el) {
            var el = document.createElement("span");
            el.id = this.getId();

            var img = document.createElement("img");
            img.src = Ext.BLANK_IMAGE_URL;
            img.className = "x-label-icon " + (this.iconCls || "");

            if (Ext.isEmpty(this.iconCls)) {
                img.style.display = "none";
            }

            if (this.iconAlign == "left") {
                el.appendChild(img);
            }

            el.appendChild(this.valueElement());

            if (this.iconAlign == "right") {
                el.appendChild(img);
            }

            this.el = el;
            Ext.BoxComponent.superclass.onRender.call(this, ct, position);
        }

        if (this.pressed && this.allowDepress !== false) {
            this.setDisabled(true);
            this.disabled = false;
            this.el.dom.style.cursor = "pointer";
        }

        Ext.ButtonToggleMgr.register(this);
    },
    
    setText : function (t, encode) {
        this.text = t;
        
        if (this.rendered) {
            this.textEl.innerHTML = encode !== false ? Ext.util.Format.htmlEncode(t) : t;
        }
        
        return this;
    },
    
    setIconClass : function (cls) {
        var oldCls = this.iconCls;
        
        this.iconCls = cls;
        
        if (this.rendered) {
            var img = this.el.child("img.x-label-icon");
            img.replaceClass(oldCls, this.iconCls);
            img.dom.style.display = (cls === "") ? "none" : "inline";
        }
    },
    
    setDisabled : function (disabled) {
        Coolite.Ext.LinkButton.superclass.setDisabled.apply(this, arguments);
        
        if (disabled) {
            this.textEl.setAttribute("disabled", "1");
            this.textEl.removeAttribute("href");
        } else {
            this.textEl.removeAttribute("disabled");
            this.textEl.setAttribute("href", "#");
        }
    }
});

Ext.reg("linkbutton", Coolite.Ext.LinkButton);

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

// @source core/form/BasicForm.js

Ext.form.BasicForm.override({
    getValues : function (asString) {
        var isForm = !Ext.isEmpty(this.el.dom.elements),
            fs = Ext.lib.Ajax.serializeForm(isForm ? this.el.dom : this.el.up("form").dom, isForm ? undefined : this.el);
        
        if (asString === true) {
            return fs;
        }
        
        return Ext.urlDecode(fs);
    }
});

// @source core/form/FormPanel.js

Ext.form.FormPanel.override({
    initComponent : function () {
        this.form = this.createForm();

        this.bodyCfg = {
            tag    : "form",
            cls    : this.baseCls + "-body",
            method : this.method || "POST",
            id     : this.formId || Ext.id()
        };
        
        if (this.fileUpload) {
            this.bodyCfg.enctype = "multipart/form-data";
        }

        if (this.isInForm) {
            this.bodyCfg.tag = "div";
        }

        Ext.FormPanel.superclass.initComponent.call(this);

        this.initItems();

        this.addEvents(
            
            "clientvalidation"
        );

        this.relayEvents(this.form, ["beforeaction", "actionfailed", "actioncomplete"]);
    },
    
    /// TODO: override default functionality to check if each item 
    /// has a .isValid function before calling. 
    bindHandler : function () {
        var valid = true;
        
        this.form.items.each(function (f) {
            /// TODO: OLD 
            //if (!f.isValid(true)) {
            
            /// TODO: NEW
            if (f.isValid && !f.isValid(true)) {
                valid = false;
                return false;
            }
        });
        
        if (this.buttons) {
            for (var i = 0, len = this.buttons.length; i < len; i++) {
                var btn = this.buttons[i];
                
                if (btn.formBind === true && btn.disabled === valid) {
                    btn.setDisabled(!valid);
                }
            }
        }
        this.fireEvent("clientvalidation", this, valid);
    },
	
	isValid : function () {
        return this.getForm().isValid();
    },
    
    validate : function () {
        return this.getForm().isValid();
    },
    
    isDirty : function () {
        return this.getForm().isDirty();
    },
    
    getName : function () {
        return this.id || '';
    },
    
    clearInvalid : function () {
        return this.getForm().clearInvalid();
    },
    
    markInvalid : function (msg) {
        return this.getForm().markInvalid(msg);
    },
    
    getValue : function () {
        return this.getForm().getValues();
    },
    
    setValue : function (value) {
        return this.getForm().setValues(value);
    },
    
    reset : function () {
        return this.getForm().reset();
    }
});

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

// @source core/form/ComboBox.js

Ext.form.ComboBox.prototype.initComponent = Ext.form.ComboBox.prototype.initComponent.createSequence(function () {
    this.initMerge();    
    
    if (!Ext.isEmpty(this.initSelectedIndex) && this.store) {
        this.setInitValueByIndex(this.initSelectedIndex);
    } else if (!Ext.isEmpty(this.value) && this.store) {
        this.setInitValue(this.value);
    }   
    
});

Ext.form.ComboBox.prototype.onRender = Ext.form.ComboBox.prototype.onRender.createSequence(function (el) {
    this.getEl().dom.setAttribute("name", this.uniqueName || this.id);
    this.getSelectedIndexField().render(this.el.parent() || this.el);
    
    this.on("focus", function (el) {
        this.oldValue = this.getValue();        
        var t = this.getEl().dom.value.trim();        
        this.oldText = (t === this.emptyText) ? "" : t;
    });
});

Ext.form.ComboBox.prototype.clearValue = Ext.form.ComboBox.prototype.clearValue.createSequence(function () {
    this.oldValue = null;   
    this.oldText = null;
});

Ext.form.ComboBox.override({
    alwaysMergeItems: true,
    forceSelection: true,

    initMerge : function () {
        if (this.mergeItems) {
            if (this.store.getCount() > 0) {
                this.doMerge();
            }

            if (this.store.getCount() === 0 || this.alwaysMergeItems) {
                this.store.on("load", this.doMerge, this, { single: !this.alwaysMergeItems });
            }
        }
    },

    doMerge : function () {
        for (var mi = this.mergeItems.getCount() - 1; mi > -1; mi--) {
            var f = this.store.recordType.prototype.fields, dv = [];

            for (var i = 0; i < f.length; i++) {
                dv[f.items[i].name] = f.items[i].defaultValue;
            }

            if (!Ext.isEmpty(this.displayField, false)) {
                dv[this.displayField] = this.mergeItems.getAt(mi).data.text;
            }

            if (!Ext.isEmpty(this.valueField, false) && this.displayField != this.valueField) {
                dv[this.valueField] = this.mergeItems.getAt(mi).data.value;
            }

            this.store.insert(0, new this.store.recordType(dv));
        }
    },

    addRecord : function (values) {
        this.store.clearFilter(false);
        
        var rowIndex = this.store.data.length,
            record = this.insertRecord(rowIndex, values);

        return { index: rowIndex, record: record };
    },

    addItem : function (text, value) {
        this.store.clearFilter(false);
        var rowIndex = this.store.data.length,
            record = this.insertItem(rowIndex, text, value);

        return { index: rowIndex, record: record };
    },

    insertRecord : function (rowIndex, values) {
        this.store.clearFilter(false);
        values = values || {};

        var f = this.store.recordType.prototype.fields, dv = {};

        for (var i = 0; i < f.length; i++) {
            dv[f.items[i].name] = f.items[i].defaultValue;
        }

        var record = new this.store.recordType(dv, values[this.store.metaId()]);

        this.store.insert(rowIndex, record);

        for (var v in values) {
            record.set(v, values[v]);
        }

        if (!Ext.isEmpty(this.store.metaId())) {
            record.set(this.store.metaId(), record.id);
        }

        return record;
    },

    insertItem : function (rowIndex, text, value) {
        this.store.clearFilter(false);
        
        var f = this.store.recordType.prototype.fields, dv = {};

        for (var i = 0; i < f.length; i++) {
            dv[f.items[i].name] = f.items[i].defaultValue;
        }

        if (!Ext.isEmpty(this.displayField, false)) {
            dv[this.displayField] = text;
        }

        if (!Ext.isEmpty(this.valueField, false) && this.displayField != this.valueField) {
            dv[this.valueField] = value;
        }

        var record = new this.store.recordType(dv);

        this.store.insert(rowIndex, record);

        return record;
    },

    removeByField : function (field, value) {
        var index = this.store.find(field, value);

        if (index < 0) {
            return;
        }

        this.store.remove(this.store.getAt(index));
    },

    removeByIndex : function (index) {
        if (index < 0 || index >= this.store.getCount()) {
            return;
        }

        this.store.remove(this.store.getAt(index));
    },

    removeByValue : function (value) {
        this.removeByField(this.valueField, value);
    },

    removeByText : function (text) {
        this.removeByField(this.displayField, text);
    },

    getSelectedIndexField : function () {
        if (!this.selectedIndexField) {
            this.selectedIndexField = new Ext.form.Hidden({ id: this.id + "_SelIndex", name: this.id + "_SelIndex" });
        }

        return this.selectedIndexField;
    },

    getText : function () {
        return this.el.getValue();
    },

    getSelectedItem : function () {
        return { text: this.getText(), value: this.getValue() };
    },

    initSelect : false,

    setValueAndFireSelect : function (v) {
        this.setValue(v);

        var r = this.findRecord(this.valueField, v);

        if (!Ext.isEmpty(r)) {
            var index = this.store.indexOf(r);

            this.getSelectedIndexField().setValue(this.getSelectedIndex());
            this.initSelect = true;
            this.fireEvent("select", this, r, index);
            this.initSelect = false;
        }
    },

    findRecordByText : function (prop, text) {
        var record;

        if (this.store.getCount() > 0) {
            this.store.each(function (r) {
                if (r.data[prop] == text) {
                    record = r;
                    return false;
                }
            });
        }
        return record;
    },

    origFindRecord : Ext.form.ComboBox.prototype.findRecord,

    findRecord : function (prop, value) {
        if (this.store.snapshot && this.store.snapshot.getCount() > 0) {
            var record;

            if (this.store.snapshot.getCount() > 0) {
                this.store.snapshot.each(function (r) {
                    if (r.data[prop] == value) {
                        record = r;
                        return false;
                    }
                });
            }
            
            return record;
        }

        return this.origFindRecord(prop, value);
    },

    indexOfEx : function (record) {
        if (this.store.snapshot && this.store.snapshot.getCount() > 0) {
            return this.store.snapshot.indexOf(record);
        }

        return this.store.data.indexOf(record);
    },

    getSelectedIndex : function () {
        var r = this.findRecord(this.forceSelection ? this.valueField : this.displayField, this.getValue());

        return (!Ext.isEmpty(r)) ? this.indexOfEx(r) : -1;
    },    

    setInitValue : function (value) {
        if (this.store.getCount() > 0) {
            this.setLoadedValue(value);
        } else {
            this.setValue(value);
            this.store.on("load", this.setLoadedValue.createDelegate(this, [value]), this, { single: true });
        }
    },

    setLoadedValue : function (value) {
        this[this.fireSelectOnLoad ? "setValueAndFireSelect" : "setValue"](value);
        this.clearInvalid();
    },
    
    onSelect : function (record, index) {
        if (this.fireEvent("beforeselect", this, record, index) !== false) {            
            this.setValue(record.data[this.valueField || this.displayField]);            
            this.collapse();
            this.getSelectedIndexField().setValue(this.getSelectedIndex());
            this.fireEvent("select", this, record, index);
            this.oldValue = this.getValue();
            
            var t = this.getEl().dom.value.trim();
            
            this.oldText = (t === this.emptyText) ? "" : t;
        }
    },

    triggerBlur : function () {
        this.mimicing = false;
        Ext.getDoc().un("mousewheel", this.mimicBlur, this);
        Ext.getDoc().un("mousedown", this.mimicBlur, this);
        
        if (this.monitorTab && this.el) {
            this.el.un("keydown", this.checkTab, this);
        }
        
        this.beforeBlur();
        
        if (this.wrap) {
            this.wrap.removeClass("x-trigger-wrap-focus");
        }

        var t = this.getEl().dom.value.trim(), v = this.getValue();

        if (this.oldValue !== v || (t !== this.oldText && t !== this.emptyText)) {
            if (!Ext.isEmpty(this.selValue) && this.selText != t && this.selValue == this.getValue()) {
                this.hiddenField.value = "";
            }

            var val = this.el.dom.value,
                r = this.findRecordByText(this.displayField, val);

            if (!Ext.isEmpty(r)) {
                this.onSelect(r, this.store.indexOf(r));
            } else {
                if (this.forceSelection) {
                    if (Ext.isEmpty(this.findRecord(this.valueField, this.oldValue))) {
                        this.clearValue();
                    } else {
                        this.setValue(this.oldValue);
                    }
                } else {
                    this.setValue(val);
                }
            }

            this.getSelectedIndexField().setValue(this.getSelectedIndex());
        }

        Ext.form.TriggerField.superclass.onBlur.call(this);
    },

    onFocus : function () {
        Ext.form.TriggerField.superclass.onFocus.call(this);
        
        if (!this.mimicing) {
            this.wrap.addClass("x-trigger-wrap-focus");
            this.mimicing = true;
            Ext.getDoc().on("mousewheel", this.mimicBlur, this, { delay: 10 });
            Ext.getDoc().on("mousedown", this.mimicBlur, this, { delay: 10 });
            
            if (this.monitorTab) {
                this.el.on("keydown", this.checkTab, this);
            }
        }
    },
    
    selectByIndex : function (index, fireSelect) {
        if (index >= 0) {
            this[this.fireSelect ? "setValueAndFireSelect" : "setValue"](this.store.getAt(index).get(this.valueField || this.displayField));
        }
    },
    
    setInitValueByIndex : function (index) {
        if (this.store.getCount() > 0) {
            this.setLoadedIndex(index);
        } else {
            this.store.on("load", this.setLoadedIndex.createDelegate(this, [index]), this, { single : true });
        }
    },

    setLoadedIndex : function (index) {
        this.selectByIndex(index, this.fireSelectOnLoad);
        this.clearInvalid();
    },

    doForce : Ext.emptyFn
});

// @source core/form/DateField.js

Date.prototype.extadd = Date.prototype.add;


Ext.DatePicker.prototype.initComponent = Ext.DatePicker.prototype.initComponent.createInterceptor(function () {
    if (!this.msadd) {
        Date.prototype.msadd = Date.prototype.add;
        
        Date.prototype.add = function () {
            return this[typeof arguments[0] === "string" ? "extadd" : "msadd"].apply(this, arguments);
        };
    }
});

Ext.form.DateField.override({
    onTriggerClick : function () {
        if (this.disabled) {
            return;
        }
        
        if (Ext.isEmpty(this.menu)) {
            this.menu = new Ext.menu.DateMenu();
        }

        if (this.menu.isVisible()) {
            this.menu.hide();
            return;
        }

        Ext.apply(this.menu.picker, {
            minDate           : this.minValue,
            maxDate           : this.maxValue,
            disabledDatesRE   : this.disabledDatesRE,
            disabledDatesText : this.disabledDatesText,
            disabledDays      : this.disabledDays,
            disabledDaysText  : this.disabledDaysText,
            format            : this.format,
            showToday         : this.showToday,
            minText           : String.format(this.minText, this.formatDate(this.minValue)),
            maxText           : String.format(this.maxText, this.formatDate(this.maxValue))
        });

        if (this.cancelText) {
            Ext.apply(this.menu.picker, { cancelText : this.cancelText });
        }
        
        if (this.dayNames) {
            Ext.apply(this.menu.picker, { dayNames : this.dayNames });
        }
        
        if (this.monthNames) {
            Ext.apply(this.menu.picker, { monthNames : this.monthNames });
        }
        
        if (this.monthYearText) {
            Ext.apply(this.menu.picker, { monthYearText : this.monthYearText });
        }
        
        if (this.nextText) {
            Ext.apply(this.menu.picker, { nextText : this.nextText });
        }
        
        if (this.okText) {
            Ext.apply(this.menu.picker, { okText : this.okText });
        }
        
        if (this.prevText) {
            Ext.apply(this.menu.picker, { prevText : this.prevText });
        }
        
        if (this.startDay) {
            Ext.apply(this.menu.picker, { startDay : this.startDay });
        }
        
        if (this.todayText) {
            Ext.apply(this.menu.picker, { todayText : this.todayText });
        }
        
        if (this.todayTip) {
            Ext.apply(this.menu.picker, { todayTip : this.todayTip });
        }

        this.menu.on(Ext.apply({}, this.menuListeners, {
            scope : this
        }));
        
        this.menu.picker.setValue(this.getValue() || new Date());
        this.menu.show(this.el, "tl-bl?");
    }
});

// @source core/form/FileUploadField.js

Ext.form.FileUploadField = Ext.extend(Ext.form.TextField, {
    buttonText   : "Browse...",
    buttonOnly   : false,
    buttonOffset : 3,
    // private
    readOnly     : true,
    autoSize     : Ext.emptyFn,

    // private
    initComponent : function () {
        Ext.form.FileUploadField.superclass.initComponent.call(this);

        this.addEvents("fileselected");
    },

    // private
    onRender : function (ct, position) {
        Ext.form.FileUploadField.superclass.onRender.call(this, ct, position);

        this.wrap = this.el.wrap({ cls : "x-form-field-wrap x-form-file-wrap" });
        this.el.addClass("x-form-file-text");
        this.el.dom.removeAttribute("name");

        this.createFileInput();

        var btnCfg = Ext.applyIf(this.buttonCfg || {}, {
            text    : this.buttonText,
            disabled : this.disabled,
            iconCls : this.iconCls
        });
        
        this.button = new Ext.Button(Ext.apply(btnCfg, {
            renderTo : this.wrap,
            cls      : "x-form-file-btn" + (btnCfg.iconCls ? (btnCfg.text ? " x-btn-text-icon" : " x-btn-icon") : "")
        }));

        if (this.buttonOnly) {
            this.el.hide();
            this.wrap.setWidth(this.button.getEl().getWidth());
        }
    },

    createFileInput : function () {
        if (this.fileInput) {
            this.fileInput.remove();
        }

        this.fileInput = this.wrap.createChild({
            id   : this.getFileInputId(),
            name : this.name || this.getFileInputId(),
            cls  : "x-form-file",
            tag  : "input",
            type : "file",
            size : 1
        });

        this.fileInput.on("change", function () {
            var v = this.fileInput.dom.value;
            this.setValue(v);
            this.fireEvent("fileselected", this, v);
        }, this);
        
        if (this.disabled) {
            this.fileInput.dom.disabled = true;
        }
    },

    // private
    getFileInputId : function () {
        return this.id + "-file";
    },

    // private
    onResize : function (w, h) {
        Ext.form.FileUploadField.superclass.onResize.call(this, w, h);

        this.wrap.setWidth(w);

        if (!this.buttonOnly) {
            w = this.wrap.getWidth() - this.button.getEl().getWidth() - this.buttonOffset;
            this.el.setWidth(w);
        }
    },

    // private
    preFocus : Ext.emptyFn,

    // private
    getResizeEl : function () {
        return this.wrap;
    },

    // private
    getPositionEl : function () {
        return this.wrap;
    },

    // private
    alignErrorIcon : function () {
        this.errorIcon.alignTo(this.wrap, "tl-tr", [2, 0]);
    },

    reset : function () {
        Ext.form.FileUploadField.superclass.reset.call(this);
        this.createFileInput();
    },
    
    setDisabled : function (disabled) {
        Ext.form.FileUploadField.superclass.setDisabled.call(this, disabled);
        this.button.setDisabled(disabled);
        
        if (this.fileInput) {
            this.fileInput.dom.disabled = disabled;
        }
    }
});

Ext.reg("fileuploadfield", Ext.form.FileUploadField);

// @source core/form/Hidden.js

Ext.form.Hidden.override({
    setValue : function (v) {
        var temp = this.rendered ? this.el.dom.value : this.value;
        
        this.value = v;
        
        if (this.rendered) {
            this.el.dom.value = (v === null || v === undefined ? "" : v);
            this.validate();
        }
        
        if (v != temp) {
            this.fireEvent("change");
        }
    }
});

// @source core/form/HtmlEditor.js

Ext.form.HtmlEditor.prototype.initComponent = Ext.form.HtmlEditor.prototype.initComponent.createSequence(function () {
    this.originalFixKeys = this.fixKeys;
    
    if (this.readOnly === true) {
        this.setReadOnly(this.readOnly);
    }
    
    this.on("render", function () {
        this.disableToolbar(this.readOnly);  
    }, this);
});

Ext.form.HtmlEditor.prototype.onFirstFocus = Ext.form.HtmlEditor.prototype.onFirstFocus.createInterceptor(function () {
    if (this.readOnly === true) {
        this.activated = false;
        return false;
    }
});

Ext.form.HtmlEditor.override({
    escapeValue : true,
    readOnly    : false,
    
    disableToolbar : function (disable) {
        if (this.tb && disable === true) {
            var roMask = this.tb.el.parent().mask();
            
            roMask.dom.style.filter     = "alpha(opacity=0);";
            roMask.dom.style.opacity    = "0.0";
            roMask.dom.style.background = "white";
            
            var select = this.tb.el.select("select.x-font-select");
            
            if (!Ext.isEmpty(select) && select.getCount() > 0) {
                select.show();
            }
            
            this.tb.items.each(function (item) {
                item.disable();
            });
        } else {
            if (this.tb) {
                this.tb.el.parent().unmask();
                
                this.tb.items.each(function (item) {
                    item.enable();
                });
            }
        }
    },
    
    setReadOnly : function (readOnly) {
        this.readOnly = readOnly;
        
        if (this.rendered) {
            this.el.dom.setAttribute("readOnly", readOnly);
            this.el.dom.readOnly = readOnly;     
            
            if (readOnly) {               
                this.doc.designMode = Ext.isGecko ? "off" : "Off";         
                this.initFrame();               
            } else {
                this.monitorTask = Ext.TaskMgr.start({
                    run      : this.checkDesignMode,
                    scope    : this,
                    interval : 100
                });
                
                try {
                    this.doc.designMode = Ext.isGecko ? "on" : "On";
                } catch (e) { }
            }     
            
            if (this.tb) {
                this.disableToolbar(readOnly);                
            }              
        } else {
            this.autoMonitorDesignMode = !readOnly;
        }   
        
        this.fixKeys = readOnly ? Ext.emptyFn : this.originalFixKeys; 
    },
    
    initFrame : function () {        
        if (this.monitorTask) {
            Ext.TaskMgr.stop(this.monitorTask);
        }
        this.win = this.getWin();
        
        this.doc = this.getDoc();
        this.doc.open();
        this.doc.write(this.getDocMarkup());
        this.doc.close();

        var task = {
            interval : 10,
            duration : 10000,
            scope    : this,
            run      : function () {
                if (this.doc.body || this.doc.readyState == "complete") {
                    Ext.TaskMgr.stop(task);
                    
                    if (!this.readOnly) {
                        this.doc.designMode = Ext.isGecko ? "on" : "On";
                    }
                    this.initEditor.defer(10, this);
                }
            }
        };
        Ext.TaskMgr.start(task);
    },
    
    syncValue : function () {
        if (this.initialized) {
            var bd = this.getEditorBody(),
                html = bd.innerHTML;
                
            if (Ext.isWebKit) {
                var bs = bd.getAttribute("style"),
                    m = bs.match(/text-align:(.*?);/i);

                if (m && m[1]) {
                    html = '<div style="' + m[0] + '">' + html + "</div>";
                }
            }

            html = this.cleanHtml(html);
            
            if (this.fireEvent("beforesync", this, html) !== false) {
                this.el.dom.value = this.escapeValue ? escape(html) : html;
                this.fireEvent("sync", this, html);
            }
        }
    },

    setValue : function (v) {
        Ext.form.HtmlEditor.superclass.setValue.call(this, (this.escapeValue && this.rendered) ? escape(v) : v);
        this.pushValue();
    },

    getValue : function () {
        this.syncValue();
        
        if (!this.rendered) {
            return this.value;
        }
        
        var v = this.el.getValue();
        
        if (v === this.emptyText || v === undefined) {
            v = "";
        }
        
        return this.escapeValue ? unescape(v) : v;
    },

    toggleSourceEdit : function (sourceEditMode) {
        if (sourceEditMode === undefined) {
            sourceEditMode = !this.sourceEditMode;
        }
        
        this.sourceEditMode = sourceEditMode === true;
        
        var btn = this.tb.items.get("sourceedit");
        
        if (btn.pressed !== this.sourceEditMode) {
            btn.toggle(this.sourceEditMode);
            return;
        }
        
        if (this.sourceEditMode) {
            this.tb.items.each(function (item) {
                if (item.itemId != "sourceedit") {
                    item.disable();
                }
            });
            
            this.syncValue();
            
            if (this.escapeValue) {
                this.el.dom.value = unescape(this.el.dom.value);
            }
            
            this.iframe.className = "x-hidden";
            this.el.removeClass("x-hidden");
            this.el.dom.removeAttribute("tabIndex");
            this.el.focus();
        } else {
            if (this.initialized) {
                this.tb.items.each(function (item) {
                    item.enable();
                });
            }
            
            this.pushValue();
            
            if (this.escapeValue) {
                this.el.dom.value = escape(this.el.dom.value);
            }
            
            this.iframe.className = "";
            this.el.addClass("x-hidden");
            this.el.dom.setAttribute("tabIndex", -1);
            this.deferFocus();
        }
        
        var lastSize = this.lastSize;
        
        if (lastSize) {
            delete this.lastSize;
            this.setSize(lastSize);
        }
        
        this.fireEvent("editmodechange", this, this.sourceEditMode);
    },

    pushValue : function () {
        if (this.initialized) {
            var v = this.escapeValue ? unescape(this.el.dom.value) : this.el.dom.value;
            
            if (!this.activated && v.length < 1) {
                v = "&nbsp;";
            }
            
            if (this.fireEvent("beforepush", this, v) !== false) {
                this.getEditorBody().innerHTML = v;
                this.fireEvent("push", this, v);
            }
        }
    }
});

// @source core/form/Hyperlink.js

Coolite.Ext.HyperLink = Ext.extend(Ext.form.Label, {
    cls : "",
    url : "#",

    valueElement : function () {
        var textEl = document.createElement("a");
        
        textEl.style.verticalAlign = "middle";
        
        if (!Ext.isEmpty(this.cls, false)) {
            textEl.className = this.cls;
        }

        textEl.setAttribute("href", this.url);

        if (this.disabled) {
            textEl.setAttribute("disabled", "1");
            textEl.removeAttribute("href");
        }

        if (!Ext.isEmpty(this.target, false)) {
            textEl.setAttribute("target", this.target);
        }

        if (this.imageUrl) {
            textEl.innerHTML = '<img src="' + this.imageUrl + '" />';
        } else {
            textEl.innerHTML = this.text ? Ext.util.Format.htmlEncode(this.text) : (this.html || "");
        }
        
        this.textEl = textEl;
        return this.textEl;
    },

    setDisabled : function (disabled) {
        Coolite.Ext.HyperLink.superclass.setDisabled.apply(this, arguments);
        
        if (disabled) {
            this.textEl.setAttribute("disabled", "1");
            this.textEl.removeAttribute("href");
        } else {
            this.textEl.removeAttribute("disabled");
            this.textEl.setAttribute("href", this.url);
        }
    },

    setImageUrl : function (imageUrl) {
        this.imageUrl = imageUrl;
        this.textEl.innerHTML = '<img style="border:0px;" src="' + this.imageUrl + '" />';
    },

    setUrl : function (url) {
        this.url = url;
        this.textEl.setAttribute("href", this.url);
    },

    setTarget : function (target) {
        this.target = target;
        this.textEl.setAttribute("target", this.target);
    }
});

Ext.reg("hyperlink", Coolite.Ext.HyperLink);

// @source core/form/Image.js

Coolite.Ext.Image = Ext.extend(Ext.form.Label, {
    cls : "",
    
    onRender : function (ct, position) {
        if (!this.el) {
            this.el = document.createElement("img");
            this.el.id = this.getId();
            this.el.src = this.imageUrl;
            this.el.style.border = "none";

            if (this.altText) {
                this.el.setAttribute("alt", this.altText);
            }

            if (this.align && this.align !== "notset") {
                this.el.setAttribute("align", this.align);
            }

            if (!Ext.isEmpty(this.cls, false)) {
                this.el.className = this.cls;
            }
        }
        Coolite.Ext.Image.superclass.onRender.call(this, ct, position);
    },

    setImageUrl : function (imageUrl) {
        this.imageUrl = imageUrl;
        
        if (this.rendered) {
            this.el.dom.removeAttribute("width");
            this.el.dom.removeAttribute("height");
            this.el.dom.src = this.imageUrl;
        }
    },

    setAlign : function (align) {
        this.align = align;
        
        if (this.rendered) {
            this.el.dom.setAttribute("align", this.align);
        }
    },

    setAltText : function (altText) {
        this.altText = altText;
        
        if (this.rendered) {
            this.el.dom.setAttribute("altText", this.altText);
        }
    }
});

Ext.reg("image", Coolite.Ext.Image);

// @source core/form/Label.js

Ext.form.Label.override({
    iconAlign   : "left",
    isFormField : true,

    // for correct FormPanel reset
    reset       : Ext.emptyFn,
	getName     : Ext.emptyFn,
    validate    : function () {
        return true;
    },
    isValid     : function () {
        return true;
    },

    valueElement : function () {
        var textEl = document.createElement("span");
        
        textEl.className = "x-label-value";
        textEl.innerHTML = this.text ? Ext.util.Format.htmlEncode(this.text) : (this.html || "");
        this.textEl = textEl;
        
        if (this.editor) {
            if (Ext.isEmpty(this.editor.field)) {
                this.editor.field = {xtype : "textfield"};                
            }
            
            this.editor.target = textEl;
            this.editor = new Ext.Editor({}, this.editor);
        }

        return textEl;
    },

    onRender : function (ct, position) {
        if (!this.el) {
            this.el = document.createElement(this.forId ? "label" : "span");
            this.el.className = "x-label";
            this.el.id = this.getId();

            var img = document.createElement("img");
            img.src = Ext.BLANK_IMAGE_URL;
            img.className = "x-label-icon " + (this.iconCls || "");

            if (Ext.isEmpty(this.iconCls)) {
                img.style.display = "none";
            }

            if (this.iconAlign == "left") {
                this.el.appendChild(img);
            }

            this.el.appendChild(this.valueElement());

            if (this.iconAlign == "right") {
                this.el.appendChild(img);
            }

            if (this.forId) {
                this.el.setAttribute("htmlFor", this.forId);
            }

            if (ct.hasClass("x-form-element")) {
                ct.setStyle("padding-top", "3px");
            }
        }
        Ext.form.Label.superclass.onRender.call(this, ct, position);
    },

    getText : function (encode) {
        return this.rendered ? encode === true ? Ext.util.Format.htmlEncode(this.textEl.innerHTML) : this.textEl.innerHTML : this.text;
    },

    setText : function (t, encode) {
        this.text = t;
        
        if (this.rendered) {
            var x = encode !== false ? Ext.util.Format.htmlEncode(t) : t;
            this.textEl.innerHTML = (Ext.isEmpty(t) && !Ext.isEmpty(this.emptyText)) ? this.emptyText : !Ext.isEmpty(this.format) ? String.format(this.format, x) : x;
        }
        return this;
    },

    setIconClass : function (cls) {
        var oldCls = this.iconCls;
        this.iconCls = cls;
        
        if (this.rendered) {
            var img = this.el.child("img.x-label-icon");
            img.replaceClass(oldCls, this.iconCls);
            img.dom.style.display = (cls === "") ? "none" : "inline";
        }
    }
});

// @source core/form/MultiField.js

Coolite.Ext.MultiField = Ext.extend(Ext.form.Field, {
    defaultAutoCreate : { cls : "x-hide-display" },
    
    initValue  : Ext.emptyFn,
    setValue   : Ext.emptyFn,
    getValue   : Ext.emptyFn,
    onRender   : function (ct, position) {
        Coolite.Ext.MultiField.superclass.onRender.call(this, ct, position);
        
        if (this.ownerCt) {
            this.ownerCt.bubble(function (c) {
                if (c.form) {
                    this.form = c.form;
                    return false;
                }
            }, this);
        }

        this.fields = this.fields || [];
        
        if (!Ext.isArray(this.fields)) {
            this.fields = [this.fields];
        }
        
        if (this.fields.length > 0) {
            this.wrap = this.el.wrap();
            
            var fields = [];
            
            for (var i = 0; i < this.fields.length; i++) {
                var fieldCt = this.wrap.createChild({ cls : "x-field-multi" }),
                    field = new Ext.ComponentMgr.create(this.fields[i]);
                    
                field.render(fieldCt);
                fields.push(field);
                
                if (this.form && field.isFormField) {
                    this.form.items.add(field);
                }
            }
            
            this.fields = fields;
        }
    }
});

Ext.reg("coolitemultifield", Coolite.Ext.MultiField);

// @source core/form/TextField.js

Ext.override(Ext.form.TextField, {
    truncate    : true,
    
    afterRender : function () {
        Ext.form.TextField.superclass.afterRender.call(this);
        
        if (this.maxLength !== Number.MAX_VALUE && this.truncate === true) {
            this.el.dom.setAttribute("maxlength", this.maxLength);
        }
    }
});

// @source core/form/TextArea.js

Ext.override(Ext.form.TextArea, {
    initComponent : function () {
        Ext.form.TextArea.superclass.initComponent.call(this);
        
        if (this.maxLength !== Number.MAX_VALUE && this.truncate === true) {
            this.on("invalid", function () {
                if (this.getValue().length > this.maxLength) {
                    this.setValue(this.getValue().substr(0, this.maxLength));
                }
            });
        }
    }
});

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

// @source core/form/NumberField.js

Ext.form.NumberField.prototype.setValue = Ext.form.NumberField.prototype.setValue.createSequence(function (v) {
    if (this.trimTrailedZeros === false) {
        var value = this.getValue();
        
        if (!Ext.isEmpty(value, false)) {
            this.setRawValue(value.toFixed(this.decimalPrecision));
        }
    }
});

// @source core/menu/Menu.js

Ext.override(Ext.menu.Menu, {
    lastTargetIn : function (cmp) {
        return Ext.fly(cmp.getEl ? cmp.getEl() : cmp).contains(this.trg);
    },

    createEl : function () {
        var frm = document.body;
        
        
        if (document.forms.length == 1) {
            frm = document.forms[0];
        }        
        
        return new Ext.Layer({
            cls       : "x-menu",
            shadow    : this.shadow,
            shim      : this.shim || true,
            constrain : false,
            parentEl  : this.parentEl || frm,
            zindex    : 15000
        });
    },
        
    autoWidth : function () {
        var el = this.el, 
            ul = this.ul, 
            w = this.width, 
            m = this.minWidth,
            t;
            
        if (!el) {
            return;
        }
        
        if (w) {
            el.setWidth(w);
        } else if (Ext.isIE && !Ext.isIE8) {
            el.setWidth(this.minWidth);
            t = el.dom.offsetWidth; // force recalc
            el.setWidth(ul.getWidth() + el.getFrameWidth("lr"));
        } else if (m && m > (el.getWidth() + el.getFrameWidth("lr"))) {
            el.setWidth(m);
        }
    }
});

// @source core/menu/CheckItem.js

Ext.menu.CheckItem.prototype.onRender = Ext.menu.CheckItem.prototype.onRender.createSequence(function (el) {
    this.getCheckedField().render(this.el.parent() || this.el);
});

Ext.menu.CheckItem.override({
    getCheckedField : function () {
        if (!this.checkedField) {
            this.checkedField = new Ext.form.Hidden({ id : this.id + "_Checked", name : this.id + "_Checked" });
        }
        
        return this.checkedField;
    }
});

// @source core/menu/ColorItem.js

Coolite.Ext.ColorItem = function (config) {
    Coolite.Ext.ColorItem.superclass.constructor.call(this, new Ext.ColorPalette(config.palette), config);
    this.palette = this.component;
    this.relayEvents(this.palette, ["select"]);

    if (this.selectHandler) {
        this.on("select", this.selectHandler, this.scope);
    }
};

Ext.extend(Coolite.Ext.ColorItem, Ext.menu.Adapter);

// @source core/menu/ColorMenu.js

Coolite.Ext.ColorMenu = function (config) {
    Coolite.Ext.ColorMenu.superclass.constructor.call(this, config);
    this.plain = true;
    var ci = new Coolite.Ext.ColorItem(config);
    this.add(ci);
    this.palette = ci.palette;
};

Ext.extend(Coolite.Ext.ColorMenu, Ext.menu.Menu);

// @source core/menu/ComboMenuItem.js

Coolite.Ext.ComboMenuItem = function (config) {
    Coolite.Ext.ComboMenuItem.superclass.constructor.call(this, new Ext.form.ComboBox(config.combobox), config);
    this.combo = this.component;
    this.addEvents("select");
    
    this.combo.on("render", function (combo) {
        combo.getEl().swallowEvent("click");
        
        if (combo.list) {
            combo.list.applyStyles("z-index:99999");
            combo.list.on("mousedown", function (e) {
                Ext.lib.Event.stopPropagation(e);
            });
        }
    });
};

Ext.extend(Coolite.Ext.ComboMenuItem, Ext.menu.Adapter, {
    hideOnClick : false,
    
    onSelect    : function (combo, record) {
        this.fireEvent("select", this, record);
        Coolite.Ext.ComboMenuItem.superclass.handleClick.call(this);
    },
    
    onRender : function (container) {
        Coolite.Ext.ComboMenuItem.superclass.onRender.call(this, container);

        if (Ext.isIE && this.combo.list) {
            this.combo.list.shadow = false;
        }

        this.el.swallowEvent(["keydown", "keypress"]);
        
        Ext.each(["keydown", "keypress"], function (eventName) {
            this.el.on(eventName, function (e) {
                if (e.isNavKeyPress()) {
                    e.stopPropagation();
                }
            }, this);
        }, this);

        if (Ext.isGecko) {
            container.setOverflow("auto");
            var containerSize = container.getSize();
            this.combo.wrap.setStyle("position", "fixed");
            container.setSize(containerSize);
        }
    }
});

// @source core/menu/DateItem.js

Coolite.Ext.DateItem = function (config) {
    Coolite.Ext.DateItem.superclass.constructor.call(this, new Ext.DatePicker(config.picker || {}), config);
    this.picker = this.component;
    this.addEvents("select");

    this.picker.on("render", function (picker) {
        picker.getEl().swallowEvent("click");
        picker.container.addClass("x-menu-date-item");
    });

    this.picker.on("select", this.onSelect, this);
};

Ext.extend(Coolite.Ext.DateItem, Ext.menu.Adapter, {
    // private
    onSelect : function (picker, date) {
        this.fireEvent("select", this, date, picker);
        Coolite.Ext.DateItem.superclass.handleClick.call(this);
    }
});

// @source core/menu/DateMenu.js

Coolite.Ext.DateMenu = function (config) {
    Coolite.Ext.DateMenu.superclass.constructor.call(this, config);
    this.plain = true;

    var ae = config.ajaxEvents,
        listeners = config.listeners,
        di;
        
    config.ajaxEvents = undefined;
    config.listeners = undefined;

    di = new Coolite.Ext.DateItem(config);

    config.ajaxEvents = ae;
    config.listeners = listeners;

    this.add(di);
    this.picker = di.picker;
    this.relayEvents(di, ["select"]);

    this.on("beforeshow", function () {
        if (this.picker) {
            this.picker.hideMonthPicker(true);
        }
    }, this);
};

Ext.extend(Coolite.Ext.DateMenu, Ext.menu.Menu, {
    cls : "x-date-menu",

    // private
    beforeDestroy : function () {
        this.picker.destroy();
    }
});

// @source core/menu/DatFieldMenuItem.js

Coolite.Ext.DateFieldMenuItem = function (config) {
    Coolite.Ext.DateFieldMenuItem.superclass.constructor.call(this, new Ext.form.DateField(config.dateField), config);
    this.dateField = this.component;
    
    this.dateField.menu = new Ext.menu.DateMenu({
        allowOtherMenus : true
    });

    this.dateField.on("render", function (dateField) {
        dateField.getEl().swallowEvent("click");
    });
};

Ext.extend(Coolite.Ext.DateFieldMenuItem, Ext.menu.Adapter, {
    hideOnClick : false,
    canActivate : false,
    
    onRender    : function (container) {
        Coolite.Ext.DateFieldMenuItem.superclass.onRender.call(this, container);

        this.el.swallowEvent(["keydown", "keypress"]);
        
        Ext.each(["keydown", "keypress"], function (eventName) {
            this.el.on(eventName, function (e) {
                if (e.isNavKeyPress()) {
                    e.stopPropagation();
                }
            }, this);
        }, this);

        if (Ext.isGecko) {
            container.setOverflow("auto");
            var containerSize = container.getSize();
            this.dateField.wrap.setStyle("position", "fixed");
            container.setSize(containerSize);
        }
    }
});

// @source core/menu/EditMenuItem.js

Coolite.Ext.EditMenuItem = function (config) {
    Coolite.Ext.EditMenuItem.superclass.constructor.call(this, new Ext.form.TextField(config.textbox), config);
    this.textbox = this.component;
    this.addEvents("select");
    
    this.textbox.on("render", function (textbox) {
        textbox.getEl().swallowEvent("click");
    });
};

Ext.extend(Coolite.Ext.EditMenuItem, Ext.menu.Adapter, {
    onRender : function (container) {
        Coolite.Ext.EditMenuItem.superclass.onRender.call(this, container);

        this.el.swallowEvent(["keydown", "keypress"]);
        
        Ext.each(["keydown", "keypress"], function (eventName) {
            this.el.on(eventName, function (e) {
                if (e.isNavKeyPress()) {
                    e.stopPropagation();
                }
            }, this);
        }, this);

        if (Ext.isGecko) {
            this.el.setOverflow("auto");
            var containerSize = container.getSize();
            this.textbox.getEl().setStyle("position", "fixed");
            container.setSize(containerSize);
        }
    }
});

// @source core/menu/ElementMenuItem.js

Coolite.Ext.ElementMenuItem = function (cfg) {
    this.target = cfg.target;
    Coolite.Ext.ElementMenuItem.superclass.constructor.call(this, cfg);
};

Ext.extend(Coolite.Ext.ElementMenuItem, Ext.menu.BaseItem, {
    hideOnClick   : false,
    itemCls       : "x-menu-item",
    shift         : true,
    targetElement : "element",

    getComponent : function () {
        if (Ext.isEmpty(this.baseEl.id)) {
            return null;
        }
        
        var cmp = Ext.getCmp(this.baseEl.id);
        
        if (Ext.isEmpty(cmp)) {
            return null;
        }
        
        return cmp;
    },

    // private
    onRender : function (container) {
        if (this.target.getEl) {
            this.el = this.target.getEl();
        } else {
            this.el = Ext.get(this.target);
        }
        
        var cmp = Ext.getCmp(this.el.id);       
        
        this.parentMenu.on("show", function () {
            if (!Ext.isEmpty(cmp)) {
                if (cmp.doLayout) {
                    cmp.doLayout();
                }

                if (cmp.syncSize) {
                    cmp.syncSize();
                }
            }
        });

        if (Ext.isIE) {
            this.parentMenu.shadow = false;
            this.parentMenu.el.shadow = false;

            if (!Ext.isEmpty(cmp)) {
                cmp.shadow = false;
                cmp.el.shadow = false;
            }
        }

        if (this.shift) {
            this.el.applyStyles({ "margin-left": "23px" });
        }

        this.el.swallowEvent(["keydown", "keypress"]);
        
        Ext.each(["keydown", "keypress"], function (eventName) {
            this.el.on(eventName, function (e) {
                if (e.isNavKeyPress()) {
                    e.stopPropagation();
                }
            }, this);
        }, this);

        if (Ext.isGecko) {
            container.removeClass("x-menu-list-item");
            container.setStyle({ 
                width  : "", 
                height : "" 
            });
            
            if (this.shift) {
                this.el.applyStyles({ "margin-left": "24px" });
            }
        }
        
        this.baseEl = this.el;
        
        if (this.targetElement === "wrap" && !Ext.isEmpty(cmp)) {            
            this.el = cmp.wrap;
        }

        Coolite.Ext.ElementMenuItem.superclass.onRender.apply(this, arguments);
    },

    activate : function () {
        if (this.disabled) {
            return false;
        }

        var cmp = this.getComponent();
        
        if (Ext.isEmpty(cmp)) {
            return false;
        }

        this.cmp.focus();
        this.fireEvent("activate", this);
        
        return true;
    },

    // private
    deactivate : function () {
        this.fireEvent("deactivate", this);
    },

    // private
    disable : function () {
        var cmp = this.getComponent();
        
        if (Ext.isEmpty(cmp)) {
            return;
        }
        
        this.cmp.disable();
        
        Coolite.Ext.ElementMenuItem.superclass.disable.call(this);
    },

    // private
    enable : function () {
        var cmp = this.getComponent();
        
        if (Ext.isEmpty(cmp)) {
            return;
        }
        
        this.cmp.enable();
        Coolite.Ext.ElementMenuItem.superclass.enable.call(this);
    }
});


// @source core/menu/HtmlElement.js

Ext.Toolbar.HtmlElement = function (config) {
    Ext.Toolbar.HtmlElement.superclass.constructor.call(this, config.target);
};

Ext.extend(Ext.Toolbar.HtmlElement, Ext.Toolbar.Item, {});

Ext.reg("coolitetbhtml", Ext.Toolbar.HtmlElement);

// @source core/menu/MenuPanel.js

Coolite.Ext.MenuPanel = function (config) {
    Coolite.Ext.MenuPanel.superclass.constructor.call(this, config);
    this.menu.on("itemclick", this.setSelection, this);
};

Ext.extend(Coolite.Ext.MenuPanel, Ext.Panel, {
    saveSelection : true,
    selectedIndex : -1,
    fitHeight     : true,

    initComponent : function () {
        Coolite.Ext.MenuPanel.superclass.initComponent.call(this);

        if (this.selectedIndex > -1) {
            this.menu.items.get(this.selectedIndex).ctCls = "x-menu-item-active";
            this.getSelIndexField().setValue(this.selectedIndex);
        }

        this.menu.on("mouseout", this.onMenuMouseOut, this);
    },

    onMenuMouseOut : function (menu, e, t) {        
        if (!this.saveSelection) {
            return;
        }
        
        var index = this.menu.items.indexOf(t),
            selIndex = this.getSelIndexField().getValue();
            
        if (selIndex.length > 0 && index == selIndex) {
            t.container.addClass("x-menu-item-active");
        }
    },

    setSelectedIndex : function (index) {
        this.setSelection(this.menu.items.get(index));
    },

    getSelIndexField : function () {
        if (!this.selIndexField) {
            this.selIndexField = new Ext.form.Hidden({ 
                id   : this.id + "_SelIndex", 
                name : this.id + "_SelIndex" 
            });
        }
        
        return this.selIndexField;
    },

    setSelection : function (item, e) {
        if (this.saveSelection) {
            this.menu.items.each(function (item) {
                item.container.removeClass("x-menu-item-active");
            }, this.menu);

            item.container.addClass("x-menu-item-active");
        }

        this.getSelIndexField().setValue(this.menu.items.indexOf(item));
    },

    afterRender : function () {
        Coolite.Ext.MenuPanel.superclass.afterRender.call(this);
        
        var lay = this.menu.getEl();
        
        if (Ext.isIE) {
            lay.shadow = false;
        }

        this.body.appendChild(lay);
        lay.clearPositioning("auto");
        
        if (this.fitHeight) {
            lay.setSize("auto", "100%");
        } else {
            lay.setWidth("auto");
        }
        
        lay.applyStyles({ border : "0px" });
        lay.show();
        this.getSelIndexField().render(this.el.parent() || this.el);
    }
});

Ext.reg("coolitemenupanel", Coolite.Ext.MenuPanel);

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

// @source core/toolbar/ToolbarItem.js

// HACK: monkey-patch Toolbar.Item .getEl() to return a typeof Element
Ext.Toolbar.Item.prototype.getEl = function () {
    return Ext.get(this.el);
};

// @source core/toolbar/ToolbarSpacer.js

Coolite.Ext.ToolbarSpacer = function (config) {
    Coolite.Ext.ToolbarSpacer.superclass.constructor.call(this);
    config = config || {};
    this.width = config.width;

    this.render = function (td) {
        Coolite.Ext.ToolbarSpacer.superclass.render.call(this, td);
        if (!Ext.isEmpty(this.width)) {
            Ext.fly(this.el).removeClass("ytb-spacer").setWidth(this.width);
        }
    };
};

Ext.extend(Coolite.Ext.ToolbarSpacer, Ext.Toolbar.Spacer);

Ext.reg("coolitetbspacer", Coolite.Ext.ToolbarSpacer);

// @source core/toolbar/ToolbarTextItem.js

Ext.Toolbar.TextItem = function (t) {
    var s = document.createElement("span");
    
    s.className = "ytb-text";
    s.innerHTML = t.text ? t.text : t;
    Ext.apply(this, t || {});
    Ext.Toolbar.TextItem.superclass.constructor.call(this, s);
};

Ext.extend(Ext.Toolbar.TextItem, Ext.Toolbar.Item, {
    enable  : Ext.emptyFn,
    disable : Ext.emptyFn,
    focus   : Ext.emptyFn,
    
    setText : function (text) {
        this.el.innerHTML = text;
    },
    
    getText : function () {
        return this.el.innerHTML;
    }
});

Ext.reg("tbtext", Ext.Toolbar.TextItem);

// @source core/tree/TreePanel.js

Coolite.Ext.TreePanel = function (config) {
    Coolite.Ext.TreePanel.superclass.constructor.call(this, config);
};

Ext.extend(Coolite.Ext.TreePanel, Ext.tree.TreePanel, {
    initComponent : function () {
        Coolite.Ext.TreePanel.superclass.initComponent.call(this);
        this.initChildren(this.nodes);
    },

    initChildren : function (nodes) {
        if (!Ext.isEmpty(nodes) && nodes.length > 0) {
            var root = nodes[0],
                rootNode = this.createNode(root);
                
            this.setRootNode(rootNode);

            if (root.children) {
                this.setChildren(root, rootNode);
            }
        }
    },

    setChildren : function (parent, node) {
        for (var i = 0; i < parent.children.length; i++) {

            var child = parent.children[i],
                childNode = this.createNode(child);

            node.appendChild(childNode);

            if (child.children) {
                this.setChildren(child, childNode);
            }
        }
    },

    createNode : function (config) {
        var type = config.nodeType || "node";
        
        if (type == "node") {
            return new Ext.tree.TreeNode(config);
        }

        return new Ext.tree.AsyncTreeNode(config);
    }
});

Ext.reg("coolitetreepanel", Coolite.Ext.TreePanel);

// @source core/tree/TreeNode.js

Ext.override(Ext.tree.TreeNode, {
    removeChildren : function () {
        while (this.childNodes.length > 0) {
            this.removeChild(this.childNodes[0]);
        }
    }
});

// @source core/tree/TreeNodeUI.js

Ext.override(Ext.tree.TreeNodeUI, {
    setIconClass : function (cls) {
        if (this.iconNode) {
            Ext.fly(this.iconNode).replaceClass(this.node.attributes.cls, cls);
        }
        
        this.node.attributes.cls = cls;
    }
});

// @source core/tree/AsyncTreeNode.js

Ext.tree.AsyncTreeNode.override({
    loadNodes : function (nodes) {
        this.beginUpdate();

        for (var i = 0, len = nodes.length; i < len; i++) {
            var n = this.getOwnerTree().getLoader().createNode(nodes[i]);

            if (!Ext.isEmpty(n)) {
                this.appendChild(n);
            }
        }

        this.endUpdate();
        this.loadComplete();
    }
});

// @source core/tree/TreeLoader.js

Ext.tree.TreeLoader.override({
    requestData : function (node, callback) {
        if (this.fireEvent("beforeload", this, node, callback) !== false) {
            this.transId = Ext.Ajax.request({
                method   : this.requestMethod,
                url      : this.dataUrl || this.url,
                success  : this.handleResponse,
                failure  : this.handleFailure,
                scope    : this,
                timeout  : this.timeout || 30000,
                argument : { callback : callback, node : node },
                params   : this.getParams(node)
            });
        } else {
            if (typeof callback == "function") {
                callback();
            }
        }
    },
    createNode : function (attr) {
        if (this.baseAttrs) {
            Ext.applyIf(attr, this.baseAttrs);
        }
        
        if (this.applyLoader !== false) {
            attr.loader = this;
        }
        
        if (typeof attr.uiProvider == "string") {
            attr.uiProvider = this.uiProviders[attr.uiProvider] || eval(attr.uiProvider);
        }

        var node;
        
        if (attr.nodeType) {
            node = new Ext.tree.TreePanel.nodeTypes[attr.nodeType](attr);
        } else {
            node = attr.leaf ?
                        new Ext.tree.TreeNode(attr) :
                        new Ext.tree.AsyncTreeNode(attr);
        }

        if (this.preloadChildren) {
            this.doPreload(node);
        }

        return node;
    }
});

// @source core/tree/WebServiceTreeLoader.js

Coolite.Ext.WebServiceTreeLoader = Ext.extend(Ext.tree.TreeLoader, {
    // private override
    processResponse : function (response, node, callback) {
        var xmlData = response.responseXML,
            root = xmlData.documentElement || xmlData,
            json = Ext.DomQuery.selectValue("json", root, "");

        try {
            var o = eval("(" + json + ")");
            
            node.beginUpdate();
            
            for (var i = 0, len = o.length; i < len; i++) {
                var n = this.createNode(o[i]);
                if (n) {
                    node.appendChild(n);
                }
            }
            
            node.endUpdate();
            
            if (typeof callback == "function") {
                callback(this, node);
            }
        } catch (e) {
            this.handleFailure(response);
        }
    }
});

// @source core/tree/PageTreeLoader.js

Coolite.Ext.PageTreeLoader = Ext.extend(Ext.tree.TreeLoader, {
    load : function (node, callback) {
        if (this.clearOnLoad) {
            while (node.firstChild) {
                node.removeChild(node.firstChild);
            }
        }
        
        if (this.doPreload(node)) {
            if (typeof callback == "function") {
                callback();
            }
        } else {
            this.requestData(node, callback);
        }
    },

    requestData : function (node, callback) {
        if (this.fireEvent("beforeload", this, node, callback) !== false) {
            var config = {};

            Ext.apply(config, {
                control       : node.getOwnerTree(),
                eventType     : "postback",
                action        : "nodeload",
                userSuccess   : this.handleSuccess,
                userFailure   : this.handleFailure,
                argument      : { callback : callback, node : node },
                extraParams   : this.getParams(node),
                method        : this.method,
                timeout       : this.timeout || 30000,
                isUpload      : this.isUpload,
                viewStateMode : this.viewStateMode,
                type          : this.type,
                url           : this.url,
                formProxyArg  : this.formProxyArg,
                eventMask     : this.eventMask
            });
            
            Coolite.AjaxEvent.request(config);

        } else {
            if (typeof callback == "function") {
                callback();
            }
        }
    },

    handleFailure : function (response, result, context, type, action, extraParams) {
        var loader = context.getLoader(),
            a;
            
        loader.transId = false;
        
        a = response.argument;
        
        loader.fireEvent("loadexception", loader, a.node, response, result.errorMessage || response.statusText);
        
        if (typeof a.callback == "function") {
            a.callback(loader, a.node);
        }
    },

    handleSuccess : function (response, result, context, type, action, extraParams) {
        var loader = context.getLoader(),
            serviceResponse = result.serviceResponse || {},
            a;

        loader.transId = false;
        
        a = response.argument;
        
        loader.processResponse(response, serviceResponse.Data || [], a.node, a.callback);
        loader.fireEvent("load", loader, a.node, response);
    },

    getParams : function (node) {
        var buf = {}, bp = this.baseParams;
        
        for (var key in bp) {
            if (typeof bp[key] != "function") {
                buf[key] = bp[key];
            }
        }
        
        buf.node = node.id;
        return buf;
    },

    processResponse : function (response, data, node, callback) {
        try {
            var o = data;
            node.beginUpdate();
            
            for (var i = 0, len = o.length; i < len; i++) {
                var n = this.createNode(o[i]);
                if (n) {
                    node.appendChild(n);
                }
            }
            
            node.endUpdate();
            
            if (typeof callback == "function") {
                callback(this, node);
            }
        } catch (e) {
            this.handleFailure(response);
        }
    }
});

// @source core/Element.js

// IE7 fix for Accordion, appears in 2.3.0, do not require for ExtJS 3.x
if (Ext.isIE7 || Ext.isIE6) {    
    Ext.override(Ext.layout.Accordion, {
        getHeight : function (el) {
            var h = Math.max(el.dom.offsetHeight, el.dom.clientHeight) || 0;
            h = el.dom.offsetHeight || 0;
            
            return h < 0 ? 0 : h;
        },
        
        setItemSize : function (item, size) {
            if (this.fill && item) {
                var items = this.container.items.items,
                    hh = 0;
                
                for (var i = 0, len = items.length; i < len; i++) {
                    var p = items[i];
                    
                    if (p != item) {
                        hh += (p.getSize().height - this.getHeight(p.bwrap));
                    }
                }
                
                size.height -= hh;
                item.setSize(size);
            }
        }
    });
}

// @source core/Viewport.js


Coolite.Ext.Viewport = Ext.extend(Ext.Container, {
    initComponent : function () {
        Coolite.Ext.Viewport.superclass.initComponent.call(this);
        var html = document.getElementsByTagName("html")[0];
        html.className += " x-viewport";
        html.style.height = "100%";
        this.el = Ext.get(this.renderTo || document.forms[0]);
        this.el.setHeight = this.el.setWidth = this.el.setSize = Ext.emptyFn;
        this.el.dom.scroll = "no";
        this.allowDomMove = false;
        this.autoWidth = this.autoHeight = true;
        Ext.EventManager.onWindowResize(this.fireResize, this);
        this.renderTo = this.el;
        
        Ext.getBody().applyStyles({
            overflow : "hidden",
            margin   : "0",
            padding  : "0",
            border   : "0px none",
            height   : "100%"
        });
        
        this.el.applyStyles({ height : "100%", width : "100%" });
    },

    fireResize : function (w, h) {
        this.fireEvent("resize", this, w, h, w, h);
    }
});

Ext.reg("cooliteviewport", Coolite.Ext.Viewport);

// @source core/Window.js

Ext.Window.override({
    showModal : function () {
        this.initMask();
        this.modal = true;
        Ext.getBody().addClass("x-body-masked");
        this.mask.setSize(Ext.lib.Dom.getViewWidth(true), Ext.lib.Dom.getViewHeight(true));
        this.mask.show();
    },
    
    hideModal : function () {
        this.initMask();
        this.modal = false;
        this.mask.hide();
        Ext.getBody().removeClass("x-body-masked");
    },
    
    initMask : function () {
        if (!this.mask) {
            this.mask = this.container.createChild({ cls : "ext-el-mask" }, this.el.dom);
            this.mask.enableDisplayMode("block");
            this.mask.hide();
            this.mask.on('click', this.focus, this);
        }
    },
    
    isModal : function () {
        return this.modal || false;
    },
    
    toggleModal : function () {
        var show = this.modal = !this.isModal();
        this[show ? "showModal" : "hideModal"]();
    }
});


// @source core/TabPanel.js

Ext.TabPanel.prototype.initComponent = Ext.TabPanel.prototype.initComponent.createSequence(function () {
    this.addEvents("beforetabclose", "beforetabhide", "tabclose");
    
    this.on("render", function () {
        this.getActiveTabField().render(this.el.parent() || this.el);
    }, this);
});

Ext.TabPanel.override({
    getActiveTabField : function () {
        if (!this.activeTabField) {
            this.activeTabField = new Ext.form.Hidden({ 
                id    : this.id + "_ActiveTab", 
                name  : this.id + "_ActiveTab", 
                value : this.id + ":" + (this.activeTab || 0)
            });
        }

        return this.activeTabField;
    },

    onStripMouseDown : function (e) {
        if (e.button !== 0) {
            return;
        }
        
        e.preventDefault();
        
        var t = this.findTargets(e);
        
        if (t.close) {
            this.closeTab(t.item);
            return;
        }
        
        if (t.item && t.item != this.activeTab) {
            this.setActiveTab(t.item);
        }
    },

    closeTab : function (tab, closeAction) {
        if (typeof tab == "string") {
            tab = this.getItem(tab);
        } else if (typeof tab == "number") {
            tab = this.items.get(tab);
        }

        if (Ext.isEmpty(tab)) {
            return;
        }

        var eventName = tab.closeAction || closeAction || "close",
            destroy = eventName == "close";

        if (this.fireEvent("beforetab" + eventName, tab) === false) {
            return;
        }

        if (tab.fireEvent("before" + eventName, tab) === false) {
            return;
        }

        if (destroy) {
            tab.fireEvent("close", tab);
        }
        
        this.remove(tab, destroy);
        
        this.hideTabStripItem(tab);
        
        tab.addClass("x-hide-display");
        
        this.fireEvent("tabclose", tab);
        
        if (!destroy) {
            tab.fireEvent("close", tab);
        }
    },

    addTab : function (tab, index, activate) {
        var config = {};

        if (!Ext.isEmpty(index)) {
            if (typeof index == "object") {
                config = index;
            } else if (typeof index == "number") {
                config.index = index;
            } else {
                config.activate = index;
            }
        }

        if (!Ext.isEmpty(activate)) {
            config.activate = activate;
        }

        if (this.items.getCount() === 0) {
            this.activeTab = null;
        }

        if (!Ext.isEmpty(config.index) && config.index >= 0) {
            tab = this.insert(config.index, tab);
        } else {
            tab = this.add(tab);
        }

        if (config.activate !== false) {
            this.setActiveTab(tab);
        }
    }
});

// @source core/ColorPalette.js

Ext.override(Ext.ColorPalette, {
    silentSelect : function (color) {
        color = color.replace("#", "");
        
        if (color != this.value || this.allowReselect) {
            var el = this.el;
            
            if (this.value) {
                el.child("a.color-" + this.value).removeClass("x-color-palette-sel");
            }
            
            if (!Ext.isEmpty(color, false)) {
                el.child("a.color-" + color).addClass("x-color-palette-sel");
            } else {
                color = null;
            }
            
            this.value = color;
        }
    },
	
	getColorField : function () {
        if (!this.colorField) {
            this.colorField = new Ext.form.Hidden({ id : this.id + "_Color", name : this.id + "_Color" });
        }
        
        return this.colorField;
    }
});

Ext.ColorPalette.prototype.onRender = Ext.ColorPalette.prototype.onRender.createSequence(function (el) {
    this.getColorField().render(this.el.parent() || this.el);
});

// @source core/DatePicker.js

Ext.DatePicker.prototype.initComponent = Ext.DatePicker.prototype.initComponent.createSequence(function () {
    var fn = function () { 
        this.getInputField().setValue(this.getValue().dateFormat("Y-m-d\\Th:i:s")); 
    };
    
    this.on("render", fn, this);
    this.on("select", fn, this);
});

Ext.DatePicker.prototype.onRender = Ext.DatePicker.prototype.onRender.createSequence(function (el) {
    this.getInputField().render(this.el.parent() || this.el);
});

Ext.DatePicker.override({
    getInputField : function () {
        if (!this.inputField) {
            this.inputField = new Ext.form.Hidden({ id : this.id + "_Input", name : this.id + "_Input" });
        }
        
        return this.inputField;
    }
});

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

// @source core/Slider.js

Ext.Slider.prototype.onRender = Ext.Slider.prototype.onRender.createSequence(function (el) {
    this.getValueField().render(this.el.parent() || this.el);
});

Ext.Slider.override({
    getValueField : function () {
        if (!this.valueField) {
            this.valueField = new Ext.form.Hidden({ id : this.id + "_Value", name : this.id + "_Value" });
        }
        
        return this.valueField;
    }
});

// @source core/utils/History.js

Ext.History.init = Ext.History.init.createInterceptor(function (onReady, scope) {
    if (this.listeners) {
        this.on(this.listeners);
        delete this.listeners;
    }
});

// @source core/utils/Notification.js

Coolite.Ext.Notification = function () {
    var notifications = [];
    
    Ext.util.CSS.createStyleSheet(".x-notification-auto-hide .x-tool-close{display: none !important}", "Coolite.Ext.Notification");

    return {
        show : function (config) {
            config = Ext.applyIf(config || {}, {
                width        : 200,
                height       : 100,
                autoHide     : true,
                plain        : false,
                resizable    : false,
                draggable    : false,
                bodyStyle    : "padding:3px;text-align:center",
                alignToCfg   : { 
                    el       : document, 
                    position : "br-br", 
                    offset   : [-20, -20] 
                },
                showMode     : "grid", 
                closeVisible : false,
                bringToFront : false,
                pinEvent     : "click",
                hideDelay    : 2500,
                shadow       : false,
                showPin      : false,
                pinned       : false,
                showFx       : { 
                    fxName : "slideIn", 
                    args   : [
                        "b", 
                        { 
                            duration : 1
                        }
                    ] 
                },
                hideFx       : { 
                    fxName : "ghost", 
                    args   : [
                        "b", 
                        { 
                            duration : 1
                        }
                    ] 
                },

                
                focus        : Ext.emptyFn,

                stopHiding   : function () {
                    this.removeClass("x-notification-auto-hide");
                    this.pinned = true;
                    
                    if (this.autoHide) {
                        this.hideTask.cancel();
                    }
                },
                
                isStandardAlign : function () {
                    return this.alignToCfg.el == document && this.alignToCfg.position == "br-br";
                },

                getStatndardAlign : function () {
                    var w = [];
                    
                    for (var i = 0; i < notifications.length; i++) {
                        var window = notifications[i];
                        
                        if (window.isStandardAlign()) {
                            w.push(window);
                        }
                    }

                    return w;
                },

                getOffset : function () {                        
                    var offset = [], predefinedOffset = this.alignToCfg.offset || [-20, -20];
                    //need clone
                    offset.push(predefinedOffset[0]);
                    offset.push(predefinedOffset[1]);
                    
                    if (this.showMode == "grid" && this.isStandardAlign()) {
                        var saw = this.getStatndardAlign(),
                            height = this.getSize().height - offset[1],
                            width = this.getSize().width - offset[0],
                            yPos = Ext.fly(this.alignToCfg.el).getViewSize().height - height,
                            xPos = Ext.fly(this.alignToCfg.el).getViewSize().width - width,
                            found = false,
                            isIntersect = function (tBox, box) {                                
                                tBox.x2 = tBox.x + tBox.width;
                                tBox.y2 = tBox.y + tBox.height;
                                
                                box.x2 = box.x + box.width;
                                box.y2 = box.y + box.height;
                                
                                if ((tBox.x2 - box.x) <= 0 || (box.x2 - tBox.x) <= 0) {
                                    return false;
                                }

                                if ((tBox.y2 - box.y) <= 0 || (box.y2 - tBox.y) <= 0) {
                                    return false;
                                }
                                
                                return true;
                            };
                        
                        while (xPos >= 0 && !found) {
                            while (yPos >= 0 && !found) {
                                var intersect = false;
                                for (var i = 0; i < saw.length; i++) {
                                    var window = saw[i];
                                    
                                    if (isIntersect({ 
                                        x      : xPos, 
                                        y      : yPos, 
                                        width  : width, 
                                        height : height 
                                    }, window.getBox())) {                                            
                                        intersect = true;
                                        break;
                                    }
                                }
                                
                                found = !intersect;
                                
                                if (!found) {                                    
                                    yPos -= height;
                                }
                            }
                            
                            if (!found) {  
                                yPos = Ext.fly(this.alignToCfg.el).getViewSize().height - height;
                                xPos -= width;
                            }
                        }                            

                        if (found) {
                            offset[0] = offset[0] + ((xPos + width) - Ext.fly(this.alignToCfg.el).getViewSize().width);
                            offset[1] = offset[1] + ((yPos + height) - Ext.fly(this.alignToCfg.el).getViewSize().height);
                        }
                    }

                    return offset;
                },
                animShow : function () {
                    var offset = this.getOffset();
                    notifications.push(this);
                    this.alignOffset = offset;
                    this.el.alignTo(this.alignToCfg.el || document, this.alignToCfg.position || "br-br", offset);
                    
                    if (Ext.isArray(this.showFx.args) && this.showFx.args.length > 0) {
                        this.showFx.args[this.showFx.args.length - 1] = Ext.apply(this.showFx.args[this.showFx.args.length - 1], { callback : this.afterShow, scope : this });
                    } else {
                        this.showFx.args = [{ callback : this.afterShow, scope : this}];
                    }
                    
                    this.el[this.showFx.fxName].apply(this.el, this.showFx.args);
                },
                animHide : function () {
                    if (Ext.isArray(this.hideFx.args) && this.hideFx.args.length > 0) {
                        this.hideFx.args[this.hideFx.args.length - 1] = Ext.apply(this.hideFx.args[this.hideFx.args.length - 1], { callback : this.destroy, scope : this });
                    } else {
                        this.showFx.args = [{ callback : this.destroy, scope : this}];
                    }
                    
                    this.el[this.hideFx.fxName].apply(this.el, this.hideFx.args);
                }
            });

            config.cls = "x-notification" + (config.autoHide ? " x-notification-auto-hide" : "");

            var w = new Ext.Window(config),
                mOver = function (e, t) {
                    if (!this.pinned) {
                        this.hideTask.cancel();
                        this.delayed = true;
                    }
                },
                mOut = function (e, t) {
                    //if (!this.pinned && !e.within(this.body, true) && !e.within(this.header, true)) {
                    if (!this.pinned) {
                        this.hideTask.delay(this.hideDelay);
                        this.delayed = false;
                    }
                };

            w.on("render", function () {
                if (this.autoHide) {
                    this.body.on("mouseover", mOver, this);
                    this.body.on("mouseout", mOut, this);
                    this.header.on("mouseover", mOver, this);
                    this.header.on("mouseout", mOut, this);
                }
            }, w);

            w.afterRender = w.afterRender.createSequence(function () {
                if (this.showPin) {
                    this.pin = function (e, tool) {
                        tool.hide();
                        this.tools.pin.show();
                        this.hideTask.cancel();
                        this.pinned = true;
                    };

                    this.unpin = function (e, tool) {
                        tool.hide();
                        this.tools.unpin.show();
                        this.hide();
                        this.pinned = false;
                    };

                    this.addTool({
                        id      : "unpin",
                        handler : this.pin,
                        hidden  : this.pinned,
                        scope   : this
                    });

                    this.addTool({
                        id      : "pin",
                        handler : this.unpin,
                        hidden  : !this.pinned,
                        scope   : this
                    });
                }
            });

            w.toFront = function (e) {
                var aw = Ext.WindowMgr.getActive();
                
                this.manager.bringToFront(this);
                
                if (!Ext.isEmpty(aw) && aw !== this && !this.bringToFront) {
                    aw.manager.bringToFront(aw);
                    aw.manager.bringToFront.defer(10, aw.manager, [aw]);
                }
                
                return this;
            };

            w.focus = Ext.emptyFn;

            w.afterShow = w.afterShow.createSequence(function () {
                if (this.pinEvent !== "none") {
                    this.body.on(this.pinEvent, this.stopHiding, this);
                    this.on(this.pinEvent, this.stopHiding, this);
                }
                
                if (this.autoHide && !this.delayed && !this.pinned) {
                    this.hideTask.delay(this.hideDelay);
                }
            });

            w.on("beforedestroy", function () {
                for (var i = 0; i < notifications.length; i++) {
                    if (notifications[i].id == this.id) {
                        notifications.remove(this);
                        break;
                    }
                }

                if (this.contentEl) {
                    var ce = Ext.fly(this.contentEl), el = Ext.getBody().dom;
                    
                    ce.addClass("x-hidden");
                    if (document.forms.length > 0) {
                        el = document.forms[0];
                    }
                    el.appendChild(ce.dom);
                }
                
                if (this.initialConfig.id) {
                    window[this.initialConfig.id] = undefined;
                }
            }, w);

            if (config.autoHide) {
                w.hideTask = new Ext.util.DelayedTask(w.hide, w);
            }

            if (config.closeVisible) {
                for (var i = notifications.length - 1; i >= 0; i--) {
                    notifications[i].destroy();
                }
            }

            w.show(config.alignToCfg.el || document);
            return w;
        }
    };
}();

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

// @source core/dd/DragSource.js

Ext.dd.DragSource.override({
    getDropTarget : function (id) {
        var dd = null;
        
        for (var i in Ext.dd.DragDropMgr.ids) {
            if (Ext.dd.DragDropMgr.ids[i][id]) {
                dd = Ext.dd.DragDropMgr.ids[i][id];
                
                if (dd.isNotifyTarget) {
                    return dd;
                }
            }
        }
        return dd;
    },
    
    onDragEnter : function (e, id) {
        var target = this.getDropTarget(id, true);
        
        this.cachedTarget = target;
        
        if (this.beforeDragEnter(target, e, id) !== false) {
            if (target.isNotifyTarget) {
                var status = target.notifyEnter(this, e, this.dragData);
                this.proxy.setStatus(status);
            } else {
                this.proxy.setStatus(this.dropAllowed);
            }
            
            if (this.afterDragEnter) {
                this.afterDragEnter(target, e, id);
            }
        }
    }
});

// @source core/init/End.js

var buf = [];

if (!Ext.isIE6) {
    if (Ext.isIE) {
        buf.push(".x-btn button{width:100%;}");
    }
    
    buf.push(".x-form-radio-group .x-panel-body,.x-form-check-group .x-panel-body{background-color:transparent;} .x-form-cb-label-nowrap{white-space:nowrap;} .x-label-icon{width:16px;height:16px; margin-left:3px; margin-right:3px; vertical-align:middle;border:0px !important;} .x-label-value{vertical-align:middle;}");
}

if (Ext.isIE8) {
    buf.push(".ext-ie8 .x-form-text{margin: 0px 0px;}");
}    

if (Ext.isIE7) {
    buf.push(".ext-ie7 .x-form-text, .ext-ie7 .x-form-file {height:18px;line-height:18px;margin: 0px 0px;vertical-align:middle;}");    
}

if (Ext.isIE6) {
    buf.push(".ext-ie6 .x-form-text, .ext-ie6 .x-form-file {height:18px;line-height:18px;margin: 0px 0px;vertical-align:middle;}");
}

buf.push(".x-tree-node .x-tree-node-inline-icon{background:transparent;height:16px !important;} .ext-ie .x-small-editor .x-form-trigger{top:-1px;} .ext-ie .x-small-editor .x-form-text{top: 0px;} .x-field-note { clear: both; font-size: 12px; color: gray;} .x-field-multi { float: left; padding-right: 3px; position: relative;} .x-inline-toolbar{padding:0px !important; border:0px !important; background: none !important;}");

Ext.util.CSS.createStyleSheet(buf.join(""));

Coolite.Ext.setTheme = function (url) {
    Ext.util.CSS.swapStyleSheet("ext-theme", url);
};

if (typeof Sys !== "undefined") { 
    Sys.Application.notifyScriptLoaded();
}
