
// @source core/BoxComponent.js

Ext.BoxComponent.override({
    getWidth  : function () {
        return this.getSize().width;
    },
    
    getHeight : function () {
        return this.getSize().height;
    }
});