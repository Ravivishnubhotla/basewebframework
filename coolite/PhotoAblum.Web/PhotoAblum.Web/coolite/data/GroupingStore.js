
// @source data/GroupingStore.js

Ext.override(Ext.data.GroupingStore, {
    applySort : function () {
        Ext.data.GroupingStore.superclass.applySort.call(this);
        
        if (!this.groupOnSort && !this.remoteGroup) {
            var gs = this.getGroupState();
            
            if (gs && gs != (Ext.isEmpty(this.sortInfo) ? "" : this.sortInfo.field)) {
                this.sortData(this.groupField);
            }
        }
    }
});