
// @source core/Element.js

// IE7 fix for Accordion, appears in 2.3.0, do not require for ExtJS 3.x
if (Ext.isIE7 || Ext.isIE6) {    
    Ext.override(Ext.layout.Accordion, {
        getHeight : function (el) {
            var h = Math.max(el.dom.offsetHeight, el.dom.clientHeight) || 0;
            h = el.dom.offsetHeight || 0;
            
            return h < 0 ? 0 : h;
        },
        
        setItemSize : function (item, size) {
            if (this.fill && item) {
                var items = this.container.items.items,
                    hh = 0;
                
                for (var i = 0, len = items.length; i < len; i++) {
                    var p = items[i];
                    
                    if (p != item) {
                        hh += (p.getSize().height - this.getHeight(p.bwrap));
                    }
                }
                
                size.height -= hh;
                item.setSize(size);
            }
        }
    });
}