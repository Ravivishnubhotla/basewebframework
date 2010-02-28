
// @source data/RowNumberer.js

Ext.override(Ext.grid.RowNumberer, {
    renderer : function (v, p, record, rowIndex) {
        if (this.rowspan) {
            p.cellAttr = 'rowspan="' + this.rowspan + '"';
        }

        var so = record.store.lastOptions,
            sop = so ? so.params : null;
            
        return ((sop && sop.start) ? sop.start : 0) + rowIndex + 1;
    }
});