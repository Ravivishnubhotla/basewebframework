
// @source core/tree/TreePanel.js

Coolite.Ext.TreePanel = function (config) {
    Coolite.Ext.TreePanel.superclass.constructor.call(this, config);
};

Ext.extend(Coolite.Ext.TreePanel, Ext.tree.TreePanel, {
    initComponent : function () {
        Coolite.Ext.TreePanel.superclass.initComponent.call(this);
        this.initChildren(this.nodes);
    },

    initChildren : function (nodes) {
        if (!Ext.isEmpty(nodes) && nodes.length > 0) {
            var root = nodes[0],
                rootNode = this.createNode(root);
                
            this.setRootNode(rootNode);

            if (root.children) {
                this.setChildren(root, rootNode);
            }
        }
    },

    setChildren : function (parent, node) {
        for (var i = 0; i < parent.children.length; i++) {

            var child = parent.children[i],
                childNode = this.createNode(child);

            node.appendChild(childNode);

            if (child.children) {
                this.setChildren(child, childNode);
            }
        }
    },

    createNode : function (config) {
        var type = config.nodeType || "node";
        
        if (type == "node") {
            return new Ext.tree.TreeNode(config);
        }

        return new Ext.tree.AsyncTreeNode(config);
    }
});

Ext.reg("coolitetreepanel", Coolite.Ext.TreePanel);