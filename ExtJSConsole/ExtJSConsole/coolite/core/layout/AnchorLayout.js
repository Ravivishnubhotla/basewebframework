
// @source core/layout/AnchorLayout.js

/**
* @class Coolite.Ext.AnchorLayout
* @extends Ext.layout.AnchorLayout
* This layout adds the ability for x/y positioning using the standard x and y component config options.
*/
Coolite.Ext.AnchorLayout = Ext.extend(Ext.layout.AnchorLayout, {
    monitorResize     : true,
    
    getAnchorViewSize : function (ct, target) {
        return ((target.dom == Ext.getBody().dom) || (target.dom == document.forms[0])) ?
                   target.getViewSize() : target.getStyleSize();
    }
});

Ext.reg("cooliteanchor", Coolite.Ext.AnchorLayout);

Ext.Container.LAYOUTS.cooliteanchor = Coolite.Ext.AnchorLayout;