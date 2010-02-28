
// @source core/buttons/CycleButton.js

Ext.override(Ext.CycleButton, {
    initComponent : function () {
        this.addEvents("change");

        if (this.changeHandler) {
            this.on("change", this.changeHandler, this.scope || this);
            delete this.changeHandler;
        }

        this.itemCount = this.menu.items.length;

        this.menu.cls = "x-cycle-menu";
        
        var checked, item;
        
        for (var i = 0, len = this.itemCount; i < len; i++) {
            item = this.menu.items.itemAt(i);

            item.group = item.group || this.id;

            item.itemIndex = i;
            item.on("checkchange", this.checkHandler, this);
            item.scope = this;
            item.setChecked(item.checked || false, true);

            if (item.checked) {
                checked = item;
            }
        }
        this.setActiveItem(checked, true);
        Ext.CycleButton.superclass.initComponent.call(this);

        this.on("click", this.toggleSelected, this);
    }
});