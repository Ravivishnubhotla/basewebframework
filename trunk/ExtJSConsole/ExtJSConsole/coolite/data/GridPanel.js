
// @source data/GridPanel.js

Coolite.Ext.GridPanel = function (config) {
    this.selectedIds = {};
    this.memoryIDField = "id";

    //Ext.apply(this, config);
    this.addEvents("editcompleted", "command", "groupcommand");
    Coolite.Ext.GridPanel.superclass.constructor.call(this, config);
    this.initSelection();    
};

Ext.extend(Coolite.Ext.GridPanel, Ext.grid.EditorGridPanel, {
    clearEditorFilter : true,
    selectionSavingBuffer : 0,
    
    getFilterPlugin : function () {
        if (this.plugins && Ext.isArray(this.plugins)) {
            for (var i = 0; i < this.plugins.length; i++) {
                if (this.plugins[i].isGridFiltersPlugin) {
                    return this.plugins[i];
                }
            }
        } else {
            if (this.plugins && this.plugins.isGridFiltersPlugin) {
                return this.plugins;
            }
        }
    },

    doSelection : function () {
        var data = this.selModel.selectedData,
            silent = true;

        if (!Ext.isEmpty(this.fireSelectOnLoad)) {
            silent = !this.fireSelectOnLoad;
        }

        if (!Ext.isEmpty(data)) {
            if (silent) {
                this.suspendEvents();
                this.selModel.suspendEvents();
            }

            if (this.selModel.select) {
                if (!Ext.isEmpty(data.recordID) && !Ext.isEmpty(data.name)) {
                    var rowIndex = this.store.indexOfId(data.recordID),
                        colIndex = this.getColumnModel().findColumnIndex(data.name);

                    if (rowIndex > -1 && colIndex > -1) {
                        this.selModel.select(rowIndex, colIndex);
                    }
                } else if (!Ext.isEmpty(data.rowIndex) && !Ext.isEmpty(data.colIndex)) {
                    this.selModel.select(data.rowIndex, data.colIndex);
                }

                if (silent) {
                    this.updateCellSelection();
                }
            }
            else if (this.selModel.selectRow && data.length > 0) {
                var records = [],
                    record;

                for (var i = 0; i < data.length; i++) {
                    if (!Ext.isEmpty(data[i].recordID)) {
                        record = this.store.getById(data[i].recordID);

                        if (this.selectionMemory) {
                            var idx = data[i].rowIndex || -1;

                            if (!Ext.isEmpty(record)) {
                                idx = this.store.indexOfId(record.id);
                                idx = this.getAbsoluteIndex(idx);
                            }

                            this.onMemorySelectId(null, idx, data[i].recordID);
                        }
                    }
                    else if (!Ext.isEmpty(data[i].rowIndex)) {
                        record = this.store.getAt(data[i].rowIndex);

                        if (this.selectionMemory && !Ext.isEmpty(record)) {
                            this.onMemorySelectId(null, data[i].rowIndex, record.id);
                        }
                    }

                    if (!Ext.isEmpty(record)) {
                        records.push(record);
                    }
                }
                this.selModel.selectRecords(records);

                if (silent) {
                    this.updateSelectedRows();
                }
            }

            if (silent) {
                this.resumeEvents();
                this.selModel.resumeEvents();
            }
        }
    },

    updateSelectedRows : function () {
        var records = [];

        if (this.selectionMemory) {
            for (var id in this.selectedIds) {
                records.push({ RecordID: this.selectedIds[id].id, RowIndex: this.selectedIds[id].index });
            }
        } else {
            var selectedRecords = this.selModel.getSelections();

            for (var i = 0; i < selectedRecords.length; i++) {
                records.push({ RecordID: selectedRecords[i].id, RowIndex: this.store.indexOfId(selectedRecords[i].id) });
            }
        }

        this.hField.setValue(Ext.encode(records));
    },

    updateCellSelection : function (sm, selection) {
        if (selection === null) {
            this.hField.setValue("");
        }
    },

    cellSelect : function (sm, rowIndex, colIndex) {
        var r = this.store.getAt(rowIndex),
            selection = {
                record: r,
                cell: [rowIndex, colIndex]
            },
            name = this.getColumnModel().getDataIndex(selection.cell[1]),
            value = selection.record.get(name),
            id = selection.record.id || "";

        this.hField.setValue(Ext.encode({ RecordID: id, Name: name, SubmittedValue: value, RowIndex: selection.cell[0], ColIndex: selection.cell[1] }));
    },

    selectionMemory : true,
    
    //private
    removeOrphanColumnPlugins : function (column) {
        var p, 
            i = 0;
        
        while (i < this.plugins.length) {
            p = this.plugins[i];
            
            if (p.isColumnPlugin) {
                if (this.getColumnModel().config.indexOf(p) === -1) {
                    this.plugins.remove(p);
                   
                    if (p.destroy) {
                        p.destroy();
                    }
                } else {
                    i++;
                }
            } else {
                i++;
            }
        }
    },

    addColumnPlugins : function (plugins, init) {        
        if (Ext.isArray(plugins)) {
            for (var i = 0; i < plugins.length; i++) {
                
                this.plugins.push(plugins[i]);
                
                if (init && plugins[i].init) {
                    plugins[i].init(this);
                }
            }
        } else {            
            this.plugins.push(plugins);
            
            if (init && plugins.init) {
                plugins.init(this);
            }
        }
    },

    initColumnPlugins : function (plugins, init) {
        var cp = [],
            p;
            
        this.initGridPlugins();
        
        if (init) {
            this.removeOrphanColumnPlugins();
        }    
        
        for (var i = 0; i < plugins.length; i++) {
            p = this.getColumnModel().config[plugins[i]];
            p.isColumnPlugin = true;
            cp.push(p);
        }
        
        this.addColumnPlugins(cp, init);
    },
    
    initGridPlugins : function () {
        if (Ext.isEmpty(this.plugins)) {
            this.plugins = [];
        } else if (!Ext.isArray(this.plugins)) {
            this.plugins = [this.plugins];
        }
    },

    initComponent : function () {
        Coolite.Ext.GridPanel.superclass.initComponent.call(this);
        
        this.initGridPlugins();

        if (this.columnPlugins) {
            this.initColumnPlugins(this.columnPlugins, false);
        }

        var cm = this.getColumnModel();

        for (var j = 0; j < cm.config.length; j++) {
            var column = cm.config[j];
            
            if (column.commands) {
                this.addColumnPlugins([new Coolite.Ext.CellCommands()]);
                break;
            }
        }

        if (this.selectionMemory) {
            this.selModel.on("rowselect", this.onMemorySelect, this);
            this.selModel.on("rowdeselect", this.onMemoryDeselect, this);
            this.store.on("remove", this.onStoreRemove, this);
            this.getView().on("refresh", this.memoryReConfigure, this);
        }

        if (!this.record && this.store) {
            this.record = this.store.recordType;
        }

        if (this.disableSelection) {
            if (this.selModel.select) {
                this.selModel.select = Ext.emptyFn;
            } else if (this.selModel.selectRow) {
                this.selModel.selectRow = Ext.emptyFn;
            }
        }

        if (this.store) {
            if (this.store.getCount() > 0) {
                this.on("render", this.doSelection, this, { single: true, delay: 100 });
            } else {
                this.store.on("load", this.doSelection, this, { single: true, delay: 100 });
            }
        }

        if (this.getView().headerRows) {
            this.enableColumnMove = false;

            for (var rowIndex = 0; rowIndex < this.view.headerRows.length; rowIndex++) {
                var cols = this.view.headerRows[rowIndex].columns;

                for (var colIndex = 0; colIndex < cols.length; colIndex++) {
                    var col = cols[colIndex];

                    if (Ext.isEmpty(col.component)) {
                        continue;
                    }

                    if (Ext.isArray(col.component) && col.component.length > 0) {
                        col.component = col.component[0];
                    }

                    col.component = col.component.render ? col.component : Ext.ComponentMgr.create(col.component, "panel");
                }
            }
        }

        if (this.clearEditorFilter) {
            this.on("beforeedit", function (e) {
                var ed = this.getColumnModel().config[e.column].editor;
                
                if (!Ext.isEmpty(ed) && ed.field && ed.field.store && ed.field.store.clearFilter) {
                    ed.field.store.clearFilter();
                }
            }, this);
        }
    },

    /*Selection Memory*/

    clearMemory : function () {
        delete this.selModel.selectedData;
        this.selectedIds = {};
        this.hField.setValue("");
    },

    memoryReConfigure : function () {
        this.store.on("clear", this.onMemoryClear, this);
        this.store.on("datachanged", this.memoryRestoreState, this);
    },

    onMemorySelect : function (sm, idx, rec) {
        if (this.getSelectionModel().singleSelect) {
            this.clearMemory();
        }
		var id = this.getRecId(rec),
            absIndex = this.getAbsoluteIndex(idx);

        this.onMemorySelectId(sm, absIndex, id);
    },

    onMemorySelectId : function (sm, index, id) {
        var obj = { id: id, index: index };
        this.selectedIds[id] = obj;
    },

    getAbsoluteIndex : function (pageIndex) {
        var absIndex = pageIndex;

        if (!Ext.isEmpty(this.pbarID)) {
            if (!this.pbar) {
                this.pbar = Ext.getCmp(this.pbarID);
            }
            absIndex = ((this.pbar.getPageData().activePage - 1) * this.pbar.pageSize) + pageIndex;
        }

        return absIndex;
    },

    onMemoryDeselect : function (sm, idx, rec) {
        delete this.selectedIds[this.getRecId(rec)];
    },

    onStoreRemove : function (store, rec, idx) {
        this.onMemoryDeselect(null, idx, rec);
    },

    memoryRestoreState : function () {
        if (this.store !== null) {
            var i = 0,
                sel = [],
                all = true,
                silent = true;

            this.store.each(function (rec) {
                var id = this.getRecId(rec);

                if (!Ext.isEmpty(this.selectedIds[id])) {
                    sel.push(i);
                } else {
                    all = false;
                }

                ++i;
            }, this);

            if (!Ext.isEmpty(this.fireSelectOnLoad)) {
                silent = !this.fireSelectOnLoad;
            }

            if (sel.length > 0) {
                if (silent) {
                    this.suspendEvents();
                    this.selModel.suspendEvents();
                }

                this.selModel.selectRows(sel);

                if (silent) {
                    this.resumeEvents();
                    this.selModel.resumeEvents();
                }
            }

            if (this.selModel.checkHeader) {
                if (all) {
                    this.selModel.checkHeader();
                } else {
                    this.selModel.uncheckHeader();
                }
            }
        }
    },

    getRecId : function (rec) {
        var id = rec.get(this.memoryIDField);

        if (Ext.isEmpty(id)) {
            id = rec.id;
        }

        return id;
    },

    onMemoryClear : function () {
        this.selectedIds = {};
    },

    /*------------------------------*/

    getSelectionModelField : function () {
        if (!this.selectionModelField) {
            this.selectionModelField = new Ext.form.Hidden({ id: this.id + "_SM", name: this.id + "_SM" });
        }

        return this.selectionModelField;
    },

    initSelection : function () {
        this.hField = this.getSelectionModelField();

        if (this.selModel.select) {
            this.selModel.on("cellselect", this.cellSelect, this);
            this.selModel.on("selectionchange", this.updateCellSelection, this);
        } else if (this.selModel.selectRow) {
            this.selModel.on("selectionchange", this.updateSelectedRows, this, {buffer: this.selectionSavingBuffer});
            this.selModel.on("rowdeselect", this.updateSelectedRows, this, {buffer: this.selectionSavingBuffer});
            this.store.on("remove", this.updateSelectedRows, this, {buffer: this.selectionSavingBuffer});
        }
    },

    getKeyMap : function () {
        if (!this.keyMap) {
            this.keyMap = new Ext.KeyMap(this.view.el, this.keys);
        }

        return this.keyMap;
    },

    onRender : function (ct, position) {
        Coolite.Ext.GridPanel.superclass.onRender.call(this, ct, position);

        this.getSelectionModelField().render(this.el.parent() || this.el);

        if (this.menu instanceof Ext.menu.Menu) {
            this.on("contextmenu", this.showContextMenu);
            this.on("rowcontextmenu", this.onRowContextMenu);
        }

        this.relayEvents(this.selModel, ["rowselect", "rowdeselect"]);
        this.relayEvents(this.store, ["commitdone", "commitfailed"]);

        if (Ext.isEmpty(this.keyMap)) {
            this.keymap = new Ext.KeyMap(this.view.el, {
                key: [13, 35, 36],
                scope: this,
                fn: this.handleKeys
            });
        }

        if (this.view.headerRows) {
            this.on("resize", this.syncHeaders);
            this.on("columnresize", this.syncHeaders);
            this.colModel.on("hiddenchange", this.onHeaderRowHiddenChange, this);

            for (var rowIndex = 0; rowIndex < this.view.headerRows.length; rowIndex++) {
                var cols = this.view.headerRows[rowIndex].columns,
                    tr = this.view.mainHd.child("tr.x-grid3-hd-row-r" + rowIndex);

                for (var colIndex = 0; colIndex < cols.length; colIndex++) {
                    var col = cols[colIndex], div;
                    if (!Ext.isEmpty(col.component)) {
                        div = Ext.fly(tr.dom.cells[colIndex]).child("div.x-grid3-hd-inner");
                        col.component.render(div);
                    } else if (!Ext.isEmpty(col.target)) {
                        var cmp = Ext.getCmp(col.target.id || "");
                        div = Ext.fly(tr.dom.cells[colIndex]).child("div.x-grid3-hd-inner");

                        if (!Ext.isEmpty(cmp) && cmp.initTrigger) {
                            div.dom.appendChild(cmp.wrap.dom);
                        } else {
                            div.dom.appendChild(col.target.dom);
                        }
                    }
                }
            }
            this.syncHeaders.defer(100, this);
            
            var cm = this.getColumnModel();
            for (var i = 0; i < cm.columns.length; i++) {
                if (cm.isHidden(i)) {
                    this.onHeaderRowHiddenChange(cm, i, true);
                }                
            }
        }
    },

    onHeaderRowHiddenChange : function (cm, colIndex, hidden) {
        var display = hidden ? 'none' : '';

        for (var rowIndex = 0; rowIndex < this.view.headerRows.length; rowIndex++) {
            var cols = this.view.headerRows[rowIndex].columns,
                tr = this.view.mainHd.child("tr.x-grid3-hd-row-r" + rowIndex);

            Ext.fly(tr.dom.cells[colIndex]).dom.style.display = display;
        }
        this.syncHeaders.defer(100, this);
    },

    syncHeaders : function () {
        for (var rowIndex = 0; rowIndex < this.view.headerRows.length; rowIndex++) {
            var cols = this.view.headerRows[rowIndex].columns;

            for (var colIndex = 0; colIndex < cols.length; colIndex++) {
                var col = cols[colIndex],
                    cmp = undefined;

                if (!Ext.isEmpty(col.component)) {
                    cmp = col.component;
                } else if (!Ext.isEmpty(col.target)) {
                    cmp = Ext.getCmp(col.target.id || "");
                } else {
                    continue;
                }

                if (col.autoWidth !== false) {
                    var autoCorrection = Ext.isEmpty(col.correction) ? 3 : col.correction;

                    if (Ext.isIE && !Ext.isEmpty(cmp)) {
                        autoCorrection -= 1;
                    }

                    if (!Ext.isEmpty(cmp) && cmp.setSize) {
                        cmp.setSize(this.getColumnModel().getColumnWidth(colIndex) - autoCorrection);
                    } else {
                        col.target.setSize(this.getColumnModel().getColumnWidth(colIndex) - autoCorrection, col.target.getSize().height);
                    }
                }
            }
        }
    },

    onEditComplete : function (ed, value, startValue) {
        Coolite.Ext.GridPanel.superclass.onEditComplete.call(this, ed, value, startValue);

        ed.field.reset();

        if (!ed.record.dirty && ed.record.firstEdit) {
            this.store.remove(ed.record);
        }    

        delete ed.record.firstEdit;
        this.fireEvent("editcompleted", ed, value, startValue);
    },

    onRowContextMenu : function (grid, rowIndex, e) {
        e.stopEvent();

        if (!this.selModel.isSelected(rowIndex)) {
            this.selModel.selectRow(rowIndex);
            this.fireEvent("rowclick", this, rowIndex, e);
        }

        this.showContextMenu(e, rowIndex);
    },

    showContextMenu : function (e, rowIndex) {
        e.stopEvent();

        if (rowIndex === undefined) {
            this.selModel.clearSelections();
        }

        if (this.menu) {
            this.menu.showAt(e.getXY());
        }
    },

    handleKeys : function (key, e) {
        e.stopEvent();

        switch (key) {
        case 13:  // return key
            var rowIndex = this.selModel.last;
            var keyEvent = (e.shiftKey === true) ? "rowdblclick" : "rowclick";
            this.fireEvent(keyEvent, this, rowIndex, e);
            break;
        case 35:  // end key
            if (this.store.getCount() > 0) {
                this.selModel.selectLastRow();
                this.getView().focusRow(this.store.getCount() - 1);
            }
            break;
        case 36:  // home key
            if (this.store.getCount() > 0) {
                this.selModel.selectFirstRow();
                this.getView().focusRow(0);
            }
            break;
        }
    },

    reload : function (options) {
        this.store.reload(options);
    },

    isDirty : function () {
        if (this.store.modified.length > 0 || this.store.deleted.length > 0) {
            return true;
        }

        return false;
    },

    hasSelection : function () {
        return this.selModel.hasSelection();
    },

    addRecord : function (values) {
        this.store.clearFilter(false);
        
        var rowIndex = this.store.data.length;

        this.insertRecord(rowIndex, values);
        
        return rowIndex;
    },

    addRecordEx : function (values) {
        this.store.clearFilter(false);
        
        var rowIndex = this.store.data.length,
            record = this.insertRecord(rowIndex, values);

        return { index : rowIndex, record : record };
    },

    insertRecord : function (rowIndex, values) {
        if (arguments.length === 0) {
            this.insertRecord(0, {});
            this.getView().focusRow(0);
            this.startEditing(0, 0);
            return;
        }
        
        this.store.clearFilter(false);
        
        var f = this.record.prototype.fields,
            dv = {},
            i,
            v;
            
        values = values || {};
        
        for (i = 0; i < f.length; i++) {
            dv[f.items[i].name] = f.items[i].defaultValue;
        }

        var record = new this.record(dv, values[this.store.metaId()]);

        record.firstEdit = true;
        record.newRecord = true;
        this.stopEditing();
        this.store.insert(rowIndex, record);

        for (v in values) {
            record.set(v, values[v]);
        }

        if (!Ext.isEmpty(this.store.metaId())) {
            record.set(this.store.metaId(), record.id);
        }

        return record;
    },

    deleteRecord : function (record) {
        this.store.remove(record);
    },

    deleteSelected : function () {
        var s = this.selModel.getSelections(),
            i;

        for (i = 0, len = s.length; i < len; i++) {
            this.deleteRecord(s[i]);
        }
    },

    load : function (options) {
        this.store.load(options);
    },

    save : function (options) {
        if (options && options.visibleOnly) {
            options.grid = this;
        }
        
        this.stopEditing(false);

        this.store.save(options);
    },

    clear : function () {
        this.store.removeAll();
    },

    saveMask : false,

    initEvents : function () {
        Coolite.Ext.GridPanel.superclass.initEvents.call(this);

        if (this.saveMask) {
            this.saveMask = new Coolite.Ext.SaveMask(this.bwrap,
                    Ext.apply({ writeStore: this.store }, this.saveMask));
        }
    },

    reconfigure : function (store, colModel) {
        Coolite.Ext.GridPanel.superclass.reconfigure.call(this, store, colModel);

        if (this.saveMask) {
            this.saveMask.destroy();
            this.saveMask = new Coolite.Ext.SaveMask(this.bwrap,
                    Ext.apply({ writeStore: store }, this.initialConfig.saveMask));
        }
    },

    onDestroy : function () {
        if (this.rendered) {
            if (this.saveMask) {
                this.saveMask.destroy();
            }
        }

        Coolite.Ext.GridPanel.superclass.onDestroy.call(this);
    },

    insertColumn : function (index, newCol) {
        var c = this.getColumnModel().config;

        if (index >= 0) {
            c.splice(index, 0, newCol);
        }

        Ext.apply(c, { events: this.getColumnModel().events, ajaxEvents: this.getColumnModel().ajaxEvents });

        this.reconfigure(this.store, new Ext.grid.ColumnModel(c));
    },

    addColumn : function (newCol) {
        var c = this.getColumnModel().config;

        c.push(newCol);

        Ext.apply(c, { events: this.getColumnModel().events, ajaxEvents: this.getColumnModel().ajaxEvents });

        this.reconfigure(this.store, new Ext.grid.ColumnModel(c));
    },

    removeColumn : function (index) {
        var c = this.getColumnModel().config;

        if (index >= 0) {
            c.splice(index, 1);
        }

        Ext.apply(c, { events: this.getColumnModel().events, ajaxEvents: this.getColumnModel().ajaxEvents });

        var cm = new Ext.grid.ColumnModel(c);

        this.reconfigure(this.store, cm);
    },

    reconfigureColumns : function (cfg) {
        var oldCM = this.getColumnModel(),
            specialCols = ["checker", "expander"],
            i;

        Ext.apply(cfg, { events: oldCM.events, ajaxEvents: oldCM.ajaxEvents });

        for (i = 0; i < specialCols.length; i++) {
            var specCol = oldCM.getColumnById(specialCols[i]);

            if (!Ext.isEmpty(specCol)) {
                var index = oldCM.getIndexById(specialCols[i]);

                if (index !== 0 && index >= cfg.length) {
                    index = cfg.length - 1;
                }

                cfg.splice(index, 0, specCol);
            }
        }

        this.reconfigure(this.store, new Ext.grid.ColumnModel(cfg));
    },

    getRowsValues : function (selectedOnly, visibleOnly, dirtyOnly, currentPageOnly) {
        this.stopEditing(false);
        
        if (Ext.isEmpty(selectedOnly)) {
            selectedOnly = true;
        }

        var records = (selectedOnly ? this.selModel.getSelections() : currentPageOnly ? this.store.getRange() : this.store.getAllRange()) || [],
            record,
            values = [],
            i;
            
        if (this.selectionMemory && selectedOnly && !currentPageOnly && this.store.isPagingStore()) {
            records = [];
            for (var id in this.selectedIds) {                
                record = this.store.getById(this.selectedIds[id].id);
                if (!Ext.isEmpty(record)) {
                    records.push(record);
                }
            }
        }

        for (i = 0; i < records.length; i++) {
            var obj = {}, dataR;
            if (this.store.metaId()) {
                obj[this.store.metaId()] = records[i].id;
            }

            dataR = Ext.apply(obj, records[i].data);
            dataR = this.store.prepareRecord(dataR, records[i], { visibleOnly: visibleOnly, grid: this, dirtyOnly: dirtyOnly });

            if (!Ext.isEmptyObj(dataR)) {
                values.push(dataR);
            }
        }

        return values;
    },
    
    submitData : function (selectedOnly, visibleOnly, dirtyOnly, currentPageOnly) {
        this.store.submitData(this.getRowsValues(selectedOnly || false, visibleOnly, dirtyOnly, currentPageOnly));
    },
    
    stopEditing : function (cancel) {
        Coolite.Ext.GridPanel.superclass.stopEditing.call(this, cancel);
        var ae = this.activeEditor;
        
        if (ae) {
            ae.field.reset();
        }
    }
});

Ext.reg("coolitegrid", Coolite.Ext.GridPanel);