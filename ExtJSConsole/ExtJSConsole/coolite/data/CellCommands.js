
// @source data/CellCommands.js

Coolite.Ext.CellCommands = function (config) {
    Ext.apply(this, config);
    Coolite.Ext.CellCommands.superclass.constructor.call(this);    
};

Ext.extend(Coolite.Ext.CellCommands, Ext.util.Observable, {
    commandTemplate :
		'<div class="cell-imagecommands <tpl if="rightValue === true">cell-imagecommand-right-value</tpl>">' +
		  '<tpl if="rightAlign === true && rightValue === false"><div class="cell-imagecommand-value">{value}</div></tpl>' +
		  '<tpl for="commands">' +
		     '<div cmd="{command}" class="cell-imagecommand <tpl if="parent.rightAlign === false">left-cell-imagecommand</tpl> {cls} {iconCls} {hideCls}" ' +
		     'style="{style}" ext:qtip="{qtext}" ext:qtitle="{qtitle}">' +
		        '<tpl if="text"><span ext:qtip="{qtext}" ext:qtitle="{qtitle}">{text}</span></tpl>' +
		     '</div>' +
		  '</tpl>' +
		  '<tpl if="rightAlign === false || rightValue === true"><div class="cell-imagecommand-value">{value}</div></tpl>' +
		'</div>',

    getTemplate : function () {
        if (Ext.isEmpty(this.template)) {
            this.template = new Ext.XTemplate(this.commandTemplate);
        }

        return this.template;
    },

    init : function (grid) {
        this.grid = grid;

        var view = this.grid.getView();
        
        this.grid.afterRender = grid.afterRender.createSequence(function () {
            view.mainBody.on("click", this.onClick, this);
        }, this);

        var cm = this.grid.getColumnModel(),
            i;
        
        for (i = 0; i < cm.config.length; i++) {
            var column = cm.config[i];
            
            if (!column.expandRow) {
                column.userRenderer = cm.getRenderer(i);
                column.renderer = this.renderer.createDelegate(this);
            }
        }
    },

    renderer : function (value, meta, record, row, col, store) {
        var column = this.grid.getColumnModel().config[col];

        if (column.commands && column.commands.length > 0 && column.isCellCommand) {
            var rightAlign = column.rightCommandAlign === false ? false : true,
                preparedCommands = [],
                commands = column.commands;
                
            if (column.prepareCommands) {                
                commands = Coolite.Ext.clone(column.commands);
                column.prepareCommands(this.grid, commands, record, row, col, value);
            }    
                
            for (var i = rightAlign ? (commands.length - 1) : 0; rightAlign ? (i >= 0) : (i < commands.length); rightAlign ? i-- : i++) {
                var cmd = commands[i];
                
                cmd.tooltip = cmd.tooltip || {};
                
                var command = {
                    command  : cmd.command,
                    cls      : cmd.cls,
                    iconCls  : cmd.iconCls,
                    hidden   : cmd.hidden,
                    text     : cmd.text,
                    style    : cmd.style,
                    qtext    : cmd.tooltip.text,
                    qtitle   : cmd.tooltip.title,
                    hideMode : cmd.hideMode
                };

                if (column.prepareCommand) {
                    column.prepareCommand(this.grid, command, record, row, col, value);
                }

                if (command.hidden) {
                    command.hideCls = "x-hide-" + (command.hideMode || "display");
                }

                preparedCommands.push(command);
            }

            var userRendererValue = column.userRenderer(value, meta, record, row, col, store);

            return this.getTemplate().apply({
                commands   : preparedCommands,
                value      : userRendererValue,
                rightAlign : rightAlign,
                rightValue : column.align == "right"
            });
        } else {
            meta.css = meta.css || "";
            meta.css += " cell-no-imagecommand";
        }

        return column.userRenderer(value, meta, record, row, col, store);
    },

    onClick : function (e, target) {

        var view = this.grid.getView(),
            t = e.getTarget(".cell-imagecommand");

        if (t) {
            var cmd = Ext.fly(t).getAttributeNS("", "cmd");
            
            if (Ext.isEmpty(cmd, false)) {
                return;
            }
            
            var row = e.getTarget(".x-grid3-row");
            
            if (row === false) {
                return;
            }

            var col = view.findCellIndex(target.parentNode.parentNode),
                record = this.grid.store.getAt(row.rowIndex);

            this.grid.fireEvent("command", cmd, record, row.rowIndex, col);
        }
    }
});