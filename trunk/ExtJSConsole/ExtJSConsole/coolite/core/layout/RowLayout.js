
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