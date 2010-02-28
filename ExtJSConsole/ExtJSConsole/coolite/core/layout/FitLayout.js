
// @source core/layout/FitLayout.js

/**
* @class Coolite.Ext.FitLayout
* @extends Ext.layout.FitLayout
* This is a base class for layouts that contain a single items that automatically expands to fill the layout's contentContainer. This class is intended to be extended or created via the layout:'fit' Ext.Container.layout config, and should generally not need to be created directly via the new keyword. FitLayout does not have any direct config options (other than inherited ones). To fit a panel to a contentContainer using FitLayout, simply set layout:'fit' on the contentContainer and add a single panel to it. If the contentContainer has multiple panels, only the first one will be displayed.
*/
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