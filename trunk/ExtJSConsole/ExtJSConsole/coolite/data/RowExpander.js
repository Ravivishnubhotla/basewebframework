
// @source data/RowExpander.js

Ext.grid.RowExpander = function (config) {
    Ext.apply(this, config);

    this.addEvents({
        beforeexpand   : true,
        expand         : true,
        beforecollapse : true,
        collapse       : true
    });

    Ext.grid.RowExpander.superclass.constructor.call(this);

    if (this.tpl) {
        if (typeof this.tpl == "string") {
            this.tpl = new Ext.Template(this.tpl);
        }
    
        this.tpl.compile();
    }

    this.state = {};
    this.bodyContent = {};
    this.renderer = this.renderer.createDelegate(this);
};

Ext.extend(Ext.grid.RowExpander, Ext.util.Observable, {
    header        : "",
    width         : 20,
    sortable      : false,
    fixed         : true,
    menuDisabled  : true,
    dataIndex     : "",
    id            : "expander",
    lazyRender    : true,
    enableCaching : true,
    collapsed     : true,

    getRowClass   : function (record, rowIndex, p, ds) {
        p.cols = p.cols - 1;
        
        var content = this.bodyContent[record.id];
        
        if (!content && !this.lazyRender) {
            content = this.getBodyContent(record, rowIndex);
        }
        
        if (content) {
            p.body = content;
        }

        if (this.state[record.id] === undefined) {
            if (this.collapsed === false) {
                this.state[record.id] = true;
                
                if (this.tpl && this.lazyRender) {
                    p.body = this.getBodyContent(record, rowIndex);
                }         
                
                return "x-grid3-row-expanded";
            }
            return "x-grid3-row-collapsed";
        }

        return this.state[record.id] ? "x-grid3-row-expanded" : "x-grid3-row-collapsed";
    },

    init : function (grid) {
        this.grid = grid;

        var view = grid.getView();
        
        view.getRowClass = this.getRowClass.createDelegate(this);

        view.enableRowBody = true;

        grid.on("render", function () {
                view.mainBody.on("mousedown", this.onMouseDown, this);
            }, this);
    },

    getBodyContent : function (record, index) {
        if (!this.enableCaching) {
            return this.tpl.apply(record.data);
        }
        
        var content = this.bodyContent[record.id];
        
        if (!content) {
            content = this.tpl.apply(record.data);
            this.bodyContent[record.id] = content;
        }
        
        return content;
    },

    onMouseDown : function (e, t) {
        if (t.className == "x-grid3-row-expander") {
            e.stopEvent();
            var row = e.getTarget(".x-grid3-row");
            this.toggleRow(row);
        }
    },
    
    prepare : function (record) { },

    renderer : function (v, p, record) {
        p.cellAttr = 'rowspan="2"';
        return '<div class="' + (this.prepare(record) !== false ? "x-grid3-row-expander" : "") + '">&#160;</div>';
    },

    beforeExpand : function (record, body, rowIndex) {
        if (this.fireEvent("beforeexpand", this, record, body, rowIndex) !== false) {
            if (this.tpl && this.lazyRender) {
                body.innerHTML = this.getBodyContent(record, rowIndex);
            }
            
            return true;
        } else {
            return false;
        }
    },

    toggleRow : function (row) {
        if (typeof row == "number") {
            row = this.grid.view.getRow(row);
        }
        this[Ext.fly(row).hasClass("x-grid3-row-collapsed") ? "expandRow" : "collapseRow"](row);
    },

    expandRow : function (row) {
        if (typeof row == "number") {
            row = this.grid.view.getRow(row);
        }
        
        var record = this.grid.store.getAt(row.rowIndex),
            body = Ext.DomQuery.selectNode("tr div.x-grid3-row-body", row);
            
        if (this.beforeExpand(record, body, row.rowIndex)) {
            this.state[record.id] = true;
            Ext.fly(row).replaceClass("x-grid3-row-collapsed", "x-grid3-row-expanded");
            this.fireEvent("expand", this, record, body, row.rowIndex);
        }
    },

    collapseRow : function (row) {
        if (typeof row == "number") {
            row = this.grid.view.getRow(row);
        }
        
        var record = this.grid.store.getAt(row.rowIndex),
            body = Ext.fly(row).child("tr:nth(1) div.x-grid3-row-body", true);
            
        if (this.fireEvent("beforecollapse", this, record, body, row.rowIndex) !== false) {
            this.state[record.id] = false;
            Ext.fly(row).replaceClass("x-grid3-row-expanded", "x-grid3-row-collapsed");
            this.fireEvent("collapse", this, record, body, row.rowIndex);
        }
    }
});