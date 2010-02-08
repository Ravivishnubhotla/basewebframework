
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