
// @source core/toolbar/ToolbarTextItem.js

Ext.Toolbar.TextItem = function (t) {
    var s = document.createElement("span");
    
    s.className = "ytb-text";
    s.innerHTML = t.text ? t.text : t;
    Ext.apply(this, t || {});
    Ext.Toolbar.TextItem.superclass.constructor.call(this, s);
};

Ext.extend(Ext.Toolbar.TextItem, Ext.Toolbar.Item, {
    enable  : Ext.emptyFn,
    disable : Ext.emptyFn,
    focus   : Ext.emptyFn,
    
    setText : function (text) {
        this.el.innerHTML = text;
    },
    
    getText : function () {
        return this.el.innerHTML;
    }
});

Ext.reg("tbtext", Ext.Toolbar.TextItem);