
// @source data/CheckboxSelectionModel.js

Ext.override(Ext.grid.CheckboxSelectionModel, {
    allowDeselect : true,
    onMouseDown   : function (e, t) {
        /* 
            If you want make selections only by checking the checker box,
            add "&& t.className == 'x-grid3-row-checker'" to next if statement
           
            If you want to make selection only with Ctrl key pressed, add
            "&& e.ctrlKey" to next if statement
        */
        if (e.button === 0 && (!this.checkOnly || (this.checkOnly && t.className == "x-grid3-row-checker")) && t.className != "x-grid3-row-expander" && !Ext.fly(t).hasClass("x-grid3-td-expander")) { 
            e.stopEvent();
            
            var row = e.getTarget(".x-grid3-row");
            
            if (row) {
                var index = row.rowIndex;
                
                if (this.isSelected(index)) {
                    if (!this.grid.enableDragDrop) {
                        if (this.allowDeselect === false) {
                            return;
                        }
                        
                        this.deselectRow(index);
                    } else {
                        this.deselectingFlag = true;
                    }
                } else {
                    if (this.grid.enableDragDrop) {
                        this.deselectingFlag = false;
                    }
                    
                    this.selectRow(index, true);
                }
            }
        }
    },
    
    handleMouseDown : Ext.emptyFn,

    uncheckHeader : function () {
        var view = this.grid.getView(),
            t = Ext.fly(view.innerHd).child(".x-grid3-hd-checker"),
            isChecked = t.hasClass("x-grid3-hd-checker-on");
            
        if (isChecked) {
            t.removeClass("x-grid3-hd-checker-on");
        }
    },

    toggleHeader : function () {
        var view = this.grid.getView(),
            t = Ext.fly(view.innerHd).child(".x-grid3-hd-checker"),
            isChecked = t.hasClass("x-grid3-hd-checker-on");
            
        if (isChecked) {
            t.removeClass("x-grid3-hd-checker-on");
        } else {
            t.addClass("x-grid3-hd-checker-on");
        }
    },

    checkHeader : function () {
        var view = this.grid.getView(),
            t = Ext.fly(view.innerHd).child(".x-grid3-hd-checker"),
            isChecked = t.hasClass("x-grid3-hd-checker-on");
            
        if (!isChecked) {
            t.addClass("x-grid3-hd-checker-on");
        }
    }
});

Ext.grid.CheckboxSelectionModel.prototype.initEvents = Ext.grid.CheckboxSelectionModel.prototype.initEvents.createSequence(function () {
    this.grid.on("rowclick", function (grid, rowIndex, e) {
        if (this.deselectingFlag && this.grid.enableDragDrop) {
            this.deselectingFlag = false;
            this.deselectRow(rowIndex);
        }
    }, this);
    
    this.on("rowdeselect", function () {
        this.uncheckHeader();
    });
    
    this.on("rowselect", function () {
        if (this.grid.store.getCount() === this.getSelections().length) {
            this.checkHeader();
        }
    });
});