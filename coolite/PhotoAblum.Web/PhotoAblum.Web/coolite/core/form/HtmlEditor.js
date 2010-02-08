
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