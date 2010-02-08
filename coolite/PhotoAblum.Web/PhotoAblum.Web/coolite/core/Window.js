
// @source core/Window.js

Ext.Window.override({
    showModal : function () {
        this.initMask();
        this.modal = true;
        Ext.getBody().addClass("x-body-masked");
        this.mask.setSize(Ext.lib.Dom.getViewWidth(true), Ext.lib.Dom.getViewHeight(true));
        this.mask.show();
    },
    
    hideModal : function () {
        this.initMask();
        this.modal = false;
        this.mask.hide();
        Ext.getBody().removeClass("x-body-masked");
    },
    
    initMask : function () {
        if (!this.mask) {
            this.mask = this.container.createChild({ cls : "ext-el-mask" }, this.el.dom);
            this.mask.enableDisplayMode("block");
            this.mask.hide();
            this.mask.on('click', this.focus, this);
        }
    },
    
    isModal : function () {
        return this.modal || false;
    },
    
    toggleModal : function () {
        var show = this.modal = !this.isModal();
        this[show ? "showModal" : "hideModal"]();
    }
});
