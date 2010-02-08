
// @source data/RowSelectionModel.js

Ext.grid.RowSelectionModel.prototype.handleMouseDown = Ext.grid.RowSelectionModel.prototype.handleMouseDown.createInterceptor(function (g, rowIndex, e) {
    if (e.button !== 0 || this.isLocked()) {
        return;
    }
    
    if (!e.shiftKey && !e.ctrlKey && this.getCount() > 1) { 
        this.clearSelections(); 
        this.selectRow(rowIndex, false); 
    }
});