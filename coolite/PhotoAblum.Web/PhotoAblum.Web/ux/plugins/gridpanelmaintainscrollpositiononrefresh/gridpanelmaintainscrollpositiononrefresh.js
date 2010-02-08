Ext.ux.plugins.GridPanelMaintainScrollPositionOnRefresh = Ext.extend(Ext.util.Observable, {
    init: function (grid) {
        grid.on("render", function () {
            this.view.onLoad = Ext.emptyFn;
            
            this.view.on("beforerefresh", function (v) {
               v.scrollTop = v.scroller.dom.scrollTop;
               v.scrollHeight = v.scroller.dom.scrollHeight;
               
               v.scrollLeft = v.scroller.dom.scrollLeft;
               v.scrollWidth = v.scroller.dom.scrollWidth;
            });
            
            this.view.on("refresh", function (v) {
               v.scroller.dom.scrollTop = v.scrollTop + 
                (v.scrollTop == 0 ? 0 : v.scroller.dom.scrollHeight - v.scrollHeight);
                
               v.scroller.dom.scrollLeft = v.scrollLeft + 
                (v.scrollLeft == 0 ? 0 : v.scroller.dom.scrollWidth - v.scrollWidth);
            }, this.view, { delay:10 });
        });            
    }
});

if(typeof Sys!=="undefined"){Sys.Application.notifyScriptLoaded();}