
// @source core/tree/AsyncTreeNode.js

Ext.tree.AsyncTreeNode.override({
    loadNodes : function (nodes) {
        this.beginUpdate();

        for (var i = 0, len = nodes.length; i < len; i++) {
            var n = this.getOwnerTree().getLoader().createNode(nodes[i]);

            if (!Ext.isEmpty(n)) {
                this.appendChild(n);
            }
        }

        this.endUpdate();
        this.loadComplete();
    }
});