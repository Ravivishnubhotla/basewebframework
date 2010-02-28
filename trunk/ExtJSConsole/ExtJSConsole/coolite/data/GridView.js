
// @source data/GridView.js

Ext.grid.GridView.prototype.initEvents = Ext.grid.GridView.prototype.initEvents.createSequence(function () {
    this.addEvents("afterRender");
});

Ext.grid.GridView.prototype.afterRender = Ext.grid.GridView.prototype.afterRender.createSequence(function () {
    this.fireEvent("afterRender", this);
});

Ext.grid.GridView.override({
    getCell : function (row, col) {
        var tds = this.getRow(row).getElementsByTagName("td"),
            ind = -1;
            
        if (tds) {
            for (var i = 0; i < tds.length; i++) {
                if (Ext.fly(tds[i]).hasClass("x-grid3-col x-grid3-cell")) {
                    ind++;
                    
                    if (ind == col) {
                        return tds[i];
                    }
                }
            }
        }
        return tds;
    },
    
    refreshRow : function (record) {
        var ds = this.ds, index;
        
        if (typeof record == "number") {
            index = record;
            record = ds.getAt(index);
            
            if (!record) {
                return;
            }
        } else {
            index = ds.indexOf(record);
            
            if (index < 0) {
                return;
            }
        }
        
        var cls = [];
        this.insertRows(ds, index, index, true);
        this.getRow(index).rowIndex = index;
        this.onRemove(ds, record, index + 1, true);
        this.fireEvent("rowupdated", this, index, record);
    }
});