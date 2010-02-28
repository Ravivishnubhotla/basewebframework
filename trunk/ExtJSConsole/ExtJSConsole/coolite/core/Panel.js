
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
            /*LOCALIZE*/
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
            /*LOCALIZE*/
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
            /*LOCALIZE*/
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