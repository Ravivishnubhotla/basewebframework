
// @source data/CommandColumn.js

Coolite.Ext.CommandColumn = function (config) {
    Ext.apply(this, config);
    
    if (!this.id) {
        this.id = Ext.id();
    }

    Coolite.Ext.CommandColumn.superclass.constructor.call(this); 
};

Ext.extend(Coolite.Ext.CommandColumn, Ext.util.Observable, {
    dataIndex    : "",
    header       : "",
    menuDisabled : true,
    sortable     : false,
    autoWidth    : false,

    init : function (grid) {
        this.grid = grid;
        
        var view = this.grid.getView(),
            func;
        
        view.rowSelectorDepth = 100;

        if (this.commands) {
            func = function () {
                this.insertToolbars();
                view.on("refresh", this.insertToolbars, this);
                view.on("beforerefresh", this.removeToolbars, this);
            };
            
            if (this.grid.rendered) {
                func.call(this);
            } else {
                view.on("afterRender", func, this);
            }

            view.on("beforerowremoved", this.removeToolbar, this);
            view.on("rowsinserted", this.insertToolbar, this);
            view.on("rowupdated", this.rowUpdated, this);
        }

        if (view.groupTextTpl && this.groupCommands) {
            func = function () {
                this.insertGroupToolbars();
                view.on("refresh", this.insertGroupToolbars, this);
                view.on("beforerefresh", this.removeGroupToolbars, this);
            };
            
            if (view.groupTextTpl && this.groupCommands) {
                view.groupTextTpl = '<div class="standart-view-group">' + view.groupTextTpl + '</div>';
            }

            if (this.grid.rendered) {
                func.call(this);
            } else {
                view.on("afterRender", func, this);
            }
        }
    },

    renderer : function (value, meta, record, row, col, store) {
        meta.css = "row-cmd-cell";
        return "";
    },

    insertToolbar : function (view, firstRow, lastRow) {
        this.insertToolbars(firstRow, lastRow + 1);
    },

    rowUpdated : function (view, firstRow, record) {
        this.insertToolbars(firstRow, firstRow + 1);
    },

    select : function () {
        var classSelector = "x-grid3-td-" + this.id + ".row-cmd-cell";
        return this.grid.getEl().query("td." + classSelector);
    },

    selectGroups : function () {
        return this.grid.getEl().query("div.x-grid-group div.x-grid-group-hd");
    },

    removeGroupToolbars : function () {
        var groupCmd = this.selectGroups();

        for (var i = 0; i < groupCmd.length; i++) {
            var div = Ext.fly(groupCmd[i]).first("div"),
                el = div.last();
                
            if (!Ext.isEmpty(el)) {
                var cmp = Ext.getCmp(el.id);
                
                Ext.Element.uncache(cmp);
                cmp.destroy();
            }
        }
    },

    insertGroupToolbars : function () {
        var groupCmd = this.selectGroups(),
            i;

        if (this.groupCommands) {
            for (i = 0; i < groupCmd.length; i++) {
                var toolbar = new Ext.Toolbar({
                        items : this.groupCommands
                    }),
                    div = Ext.fly(groupCmd[i]).first("div");
                    
                div.addClass("row-cmd-cell-ct");
                toolbar.render(div);

                var group = this.grid.view.findGroup(div),
                    groupId = group ? group.id.replace(/ext-gen[0-9]+-gp-/, "") : null,
                    records = this.getRecords(groupId);
                    
                if (this.prepareGroupToolbar && this.prepareGroupToolbar(this.grid, toolbar, groupId, records) === false) {
                    Ext.Element.uncache(toolbar);
                    toolbar.destroy();
                    continue;
                }

                toolbar.grid = this.grid;
                toolbar.groupId = groupId;

                toolbar.items.each(function (button) {
                    if (button.on) {
                        button.toolbar = toolbar;
                        button.column = this;

                        if (button.standOut) {
                            button.on("mouseout", function () { 
                                this.getEl().addClass("x-btn-over"); 
                            }, button);
                        }

                        if (!Ext.isEmpty(button.command, false)) {
                            button.on("click", function () {
                                this.toolbar.grid.fireEvent("groupcommand", this.command, this.toolbar.groupId, this.column.getRecords.apply(this.column, [this.toolbar.groupId]));
                            }, button);
                        }

                        if (button.menu) {
                            this.initGroupMenu(button.menu, toolbar);
                        }
                    }
                }, this);
            }
        }
    },

    initGroupMenu : function (menu, toolbar) {
        menu.items.each(function (item) {
            if (item.on) {
                item.toolbar = toolbar;
                item.column = this;

                if (!Ext.isEmpty(item.command, false)) {
                    item.on("click", function () {
                        this.toolbar.grid.fireEvent("groupcommand", this.command, this.toolbar.groupId, this.column.getRecords.apply(this.column, [this.toolbar.groupId]));
                    }, item);
                }

                if (item.menu) {
                    this.initGroupMenu(item.menu, toolbar);
                }
            }
        }, this);
    },

    getRecords : function (groupId) {
        if (groupId) {
            var re = new RegExp(RegExp.escape(groupId)),
                records = this.grid.store.queryBy(function (r) {
                    return r._groupId.match(re);
                });
                
            return records ? records.items : [];
        }
    },

    getAllGroupToolbars : function () {
        var groups = this.selectGroups(),
            toolbars = [],
            i;

        for (i = 0; i < groups.length; i++) {
            var div = Ext.fly(groups[i]).first("div"),
                el = div.last();
                
            if (!Ext.isEmpty(el)) {
                var cmp = Ext.getCmp(el.id);
                toolbars.push(cmp);
            }
        }

        return toolbars;
    },

    getGroupToolbar : function (groupId) {
        var groups = this.selectGroups(),
            i;

        for (i = 0; i < groups.length; i++) {
            var div = Ext.fly(groups[i]).first("div"),
                _group = this.grid.view.findGroup(div),
                _groupId = _group ? _group.id.replace(/ext-gen[0-9]+-gp-/, "") : null;

            if (_groupId == groupId) {
                var el = div.last();
                
                if (!Ext.isEmpty(el)) {
                    var cmp = Ext.getCmp(el.id);
                    return cmp;
                }
            }
        }

        return undefined;
    },

    insertToolbars : function (start, end) {
        var tdCmd = this.select(),
            width = 0;

        if (Ext.isEmpty(start) || Ext.isEmpty(end)) {
            start = 0;
            end = tdCmd.length;
        }

        if (this.commands) {
            for (var i = start; i < end; i++) {
                var toolbar = new Ext.Toolbar({
                        items : this.commands
                    }),
                    div = Ext.fly(tdCmd[i]).first("div");

                div.dom.innerHTML = "";
                div.addClass("row-cmd-cell-ct");

                toolbar.render(div);

                var record = this.grid.store.getAt(i);
                
                if (this.prepareToolbar && this.prepareToolbar(this.grid, toolbar, i, record) === false) {
                    Ext.Element.uncache(toolbar);
                    toolbar.destroy();
                    continue;
                }

                toolbar.grid = this.grid;
                toolbar.rowIndex = i;
                toolbar.record = record;

                toolbar.items.each(function (button) {
                    if (button.on) {
                        button.toolbar = toolbar;

                        if (button.standOut) {
                            button.on("mouseout", function () { 
                                this.getEl().addClass("x-btn-over"); 
                            }, button);
                        }

                        if (!Ext.isEmpty(button.command, false)) {
                            button.on("click", function () {
                                this.toolbar.grid.fireEvent("command", this.command, this.toolbar.record, this.toolbar.rowIndex);
                            }, button);
                        }

                        if (button.menu) {
                            this.initMenu(button.menu, toolbar);
                        }
                    }
                }, this);

                if (this.autoWidth) {
                    var tbTable = toolbar.getEl().first("table"),
                        tbWidth = tbTable.getComputedWidth();
                        
                    width = tbWidth > width ? tbWidth : width;
                }
            }

            if (this.autoWidth && width > 0) {
                var cm = this.grid.getColumnModel();
                cm.setColumnWidth(cm.getIndexById(this.id), width + 4);
                this.grid.view.autoExpand();
            }
        }
    },

    initMenu : function (menu, toolbar) {
        menu.items.each(function (item) {
            if (item.on) {
                item.toolbar = toolbar;

                if (!Ext.isEmpty(item.command, false)) {
                    item.on("click", function () {
                        this.toolbar.grid.fireEvent("command", this.command, this.toolbar.record, this.toolbar.rowIndex);
                    }, item);
                }

                if (item.menu) {
                    this.initMenu(item.menu, toolbar);
                }
            }
        }, this);
    },

    removeToolbar : function (view, rowIndex) {
        var tdCmd = this.select(),
            div = Ext.fly(tdCmd[rowIndex]).first("div"),
            el = div.first();
            
        if (!Ext.isEmpty(el)) {
            var cmp = Ext.getCmp(el.id);
            Ext.Element.uncache(cmp);
            cmp.destroy();
        }
    },

    removeToolbars : function () {
        var tdCmd = this.select();

        for (var i = 0; i < tdCmd.length; i++) {
            var div = Ext.fly(tdCmd[i]).first("div"),
                el = div.first();
                
            if (!Ext.isEmpty(el)) {
                var cmp = Ext.getCmp(el.id);
                Ext.Element.uncache(cmp);
                cmp.destroy();
            }
        }
    },

    getToolbar : function (rowIndex) {
        var tdCmd = this.select(),
            div = Ext.fly(tdCmd[rowIndex]).first("div"),
            el = div.first();
            
        if (!Ext.isEmpty(el)) {
            var cmp = Ext.getCmp(el.id);
            return cmp;
        }

        return undefined;
    },

    getAllToolbars : function () {
        var tdCmd = this.select(),
            toolbars = [];

        for (var i = 0; i < tdCmd.length; i++) {
            var div = Ext.fly(tdCmd[i]).first("div"),
                el = div.first();
                
            if (!Ext.isEmpty(el)) {
                var cmp = Ext.getCmp(el.id);
                toolbars.push(cmp);
            }
        }

        return toolbars;
    },
    
    destroy : function () {
        var view = this.grid.getView();
        view.un("refresh", this.insertToolbars, this);
        view.un("beforerefresh", this.removeToolbars, this);
        view.un("beforerowremoved", this.removeToolbar, this);
        view.un("rowsinserted", this.insertToolbar, this);
        view.un("rowupdated", this.rowUpdated, this);
		view.un("refresh", this.insertGroupToolbars, this);
        view.un("beforerefresh", this.removeGroupToolbars, this);
    }
});