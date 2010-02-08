
// @source core/form/Image.js

Coolite.Ext.Image = Ext.extend(Ext.form.Label, {
    cls : "",
    
    onRender : function (ct, position) {
        if (!this.el) {
            this.el = document.createElement("img");
            this.el.id = this.getId();
            this.el.src = this.imageUrl;
            this.el.style.border = "none";

            if (this.altText) {
                this.el.setAttribute("alt", this.altText);
            }

            if (this.align && this.align !== "notset") {
                this.el.setAttribute("align", this.align);
            }

            if (!Ext.isEmpty(this.cls, false)) {
                this.el.className = this.cls;
            }
        }
        Coolite.Ext.Image.superclass.onRender.call(this, ct, position);
    },

    setImageUrl : function (imageUrl) {
        this.imageUrl = imageUrl;
        
        if (this.rendered) {
            this.el.dom.removeAttribute("width");
            this.el.dom.removeAttribute("height");
            this.el.dom.src = this.imageUrl;
        }
    },

    setAlign : function (align) {
        this.align = align;
        
        if (this.rendered) {
            this.el.dom.setAttribute("align", this.align);
        }
    },

    setAltText : function (altText) {
        this.altText = altText;
        
        if (this.rendered) {
            this.el.dom.setAttribute("altText", this.altText);
        }
    }
});

Ext.reg("image", Coolite.Ext.Image);