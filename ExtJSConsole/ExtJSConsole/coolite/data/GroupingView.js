
// @source data/GroupingView.js

Ext.grid.GroupingView.override({
    onRemove : function (ds, record, index, isUpdate) {
        Ext.grid.GroupingView.superclass.onRemove.apply(this, arguments);
        
        var g = document.getElementById(Ext.util.Format.htmlDecode(record._groupId));
        
        if (g && g.childNodes[1].childNodes.length < 1) {
            Ext.removeNode(g);
        }
        
        this.applyEmptyText();
    }
});