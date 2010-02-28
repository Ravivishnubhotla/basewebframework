
// @source data/PagingToolbar.js

Coolite.Ext.initRefreshPagingToolbar = function (grid) {
    var refresh = function (bBar) {
        for (i = 0; i < bBar.items.items.length; ++i) {
            var item = bBar.items.items[i];
            
            if (item.iconCls == "x-tbar-loading" && item.tooltip == bBar.refreshText) {
                item.setHandler(function () {
                    
                    if (grid.getStore().proxy.refreshData) {
                        grid.getStore().proxy.refreshData(null, grid.getStore());
                    }
                    
                    if (grid.getStore().proxy.isUrl) {
                        item.initialConfig.handler();
                    }
                });
                return true;
            }
        }
        return false;
    };

    var bar,
        bBar = grid.getBottomToolbar();
    
    if (bBar && bBar.changePage) {
        bar = bBar;
    } else {
        bar = grid.getTopToolbar();
    }

    if (bar.rendered) {
        refresh(bar);
    } else {
        bar.on("render", refresh.createDelegate(this, [bar], false));
    }
};

Ext.PagingToolbar.prototype.onRender = Ext.PagingToolbar.prototype.onRender.createSequence(function (el) {
    this.getActivePageField().render(this.el.parent() || this.el);
});

Ext.PagingToolbar.override({
    getActivePageField : function () {
        if (!this.activePageField) {
            this.activePageField = new Ext.form.Hidden({ id : this.id + "_ActivePage", name : this.id + "_ActivePage" });
        }
        
        return this.activePageField;
    }
});