
// @source data/NumericPagingToolbar.js

Ext.ux.NumericPagingToolbar = function () {
    Ext.ux.NumericPagingToolbar.superclass.constructor.apply(this, arguments);
};

Ext.extend(Ext.ux.NumericPagingToolbar, Ext.PagingToolbar, {
    onRender : function (el, position) {
        Ext.PagingToolbar.prototype.onRender.apply(this, arguments);
        this.preceding = [];
        
        for (var i = 0; i < 3; i++) {
            this.preceding[i] = this.insertButton(i + 4, {
                handler : this.onPageNumberClick,
                scope   : this
            });
            
            this.preceding[i].el.setVisibilityMode(Ext.Element.DISPLAY);
            
            this.preceding[i].el.child(".x-btn-text").setStyle({
                "font-weight" : "bold",
                "color"       : "#083772"
            });
        }
        
        this.following = [];
        
        for (var j = 0; j < 3; j++) {
            this.following[j] = this.insertButton(j + 8, {
                handler : this.onPageNumberClick,
                scope   : this
            });
            
            this.following[j].el.setVisibilityMode(Ext.Element.DISPLAY);
            
            this.following[j].el.child(".x-btn-text").setStyle({
                "font-weight" : "bold",
                "color"       : "#083772"
            });
        }
    },

    onPageNumberClick : function (b, e) {
        var pageNum = parseInt(b.el.child(".x-btn-text").dom.innerHTML, 10),
            d = this.getPageData();
            
        if (!isNaN(pageNum) && (pageNum > 0) && (pageNum <= d.pages)) {
            this.field.dom.value = pageNum;
            pageNum--;
            this.store.load({ params : { start : pageNum * this.pageSize, limit : this.pageSize} });
        }
    },

    updateInfo : function () {
        Ext.PagingToolbar.prototype.updateInfo.apply(this, arguments);
        
        var d = this.getPageData(),
            p = d.activePage - 3;
            
        for (var i = 0; i < 3; i++, p++) {
            if (p < 1) {
                this.preceding[i].el.hide();
            } else {
                this.preceding[i].el.show();
                this.preceding[i].el.child(".x-btn-text").dom.innerHTML = p;
            }
        }
        
        p = d.activePage + 1;
        
        for (var j = 0; j < 3; j++, p++) {
            if (p > d.pages) {
                this.following[j].el.hide();
            } else {
                this.following[j].el.show();
                this.following[j].el.child(".x-btn-text").dom.innerHTML = p;
            }
        }
    }
});

Ext.reg("numpaging", Ext.ux.NumericPagingToolbar);