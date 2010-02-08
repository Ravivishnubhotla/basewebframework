/*
 * Ext JS Library 2.1
 * Copyright(c) 2006-2008, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */

// Very simple plugin for adding a close context menu to tabs

Ext.ux.plugins.TabCloseMenu = Ext.extend(Ext.TabPanel, {
    constructor : function (config) {
        Ext.apply(this, config, {
            closeTabText: "Close Tab", 
            closeOtherTabsText: "Close Other Tabs",
            closeTabIconCls: "",
            closeOtherTabsIconCls: ""
        });
    },
    
    init : function (tp) {
        var tabs = tp, menu, ctxItem;
        tabs.on("contextmenu", function (ts, item, e) {
            var self = this;
                
            if (Ext.isEmpty(menu)) { // create context menu on first right click
                menu = new Ext.menu.Menu({
                    listeners: {
                        show: function (el) {
                            el.items.items[0].setText(String.format(self.closeTabText, ctxItem.title));
                        }
                    },
                    items: [{
                        id     : tabs.id + "-close",
                        text   : this.closeTabText,
                        iconCls: this.closeTabIconCls,
                        handler: function () {
                            tabs.closeTab ? tabs.closeTab(ctxItem) : tabs.remove(ctxItem);
                        }
                    }, {
                        id     : tabs.id + "-close-others",
                        text   : this.closeOtherTabsText,
                        iconCls: this.closeOtherTabsIconCls,
                        handler: function () {
                            tabs.items.each(function (item) {
                                if (item.closable && item != ctxItem) {
                                    tabs.closeTab ? tabs.closeTab(item) : tabs.remove(item);
                                }
                            });
                        }
                    }]
                });
            }
            
            ctxItem = item;
            
            var items = menu.items, 
                disableOthers = true;
            
            items.get(tabs.id + "-close").setDisabled(!item.closable);
            
            tabs.items.each(function () {
                if (this != item && this.closable) {
                    disableOthers = false;
                    return false;
                }
            });
            
            items.get(tabs.id + "-close-others").setDisabled(disableOthers);
            menu.showAt(e.getPoint());
        }, this);
    }
});

if(typeof Sys!=="undefined"){Sys.Application.notifyScriptLoaded();}