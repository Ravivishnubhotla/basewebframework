
// @source core/tree/TreeNodeUI.js

Ext.override(Ext.tree.TreeNodeUI, {
    setIconClass : function (cls) {
        if (this.iconNode) {
            Ext.fly(this.iconNode).replaceClass(this.node.attributes.cls, cls);
        }
        
        this.node.attributes.cls = cls;
    }
});