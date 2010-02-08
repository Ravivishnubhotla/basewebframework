
// @source core/layout/ColumnLayout.js

/**
* @class Coolite.Ext.ColumnLayout
* @extends Ext.layout.ColumnLayout
* This is the layout style of choice for creating structural layouts in a multi-column format where the width of each column can be specified as a percentage or fixed width, but the height is allowed to vary based on the content. 
*/
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