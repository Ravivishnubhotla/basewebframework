
// @source core/tree/TreeNode.js

Ext.override(Ext.tree.TreeNode, {
    removeChildren : function () {
        while (this.childNodes.length > 0) {
            this.removeChild(this.childNodes[0]);
        }
    }
});