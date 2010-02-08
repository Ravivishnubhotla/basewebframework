
// @source core/form/Hyperlink.js

Coolite.Ext.HyperLink = Ext.extend(Ext.form.Label, {
    cls : "",
    url : "#",

    valueElement : function () {
        var textEl = document.createElement("a");
        
        textEl.style.verticalAlign = "middle";
        
        if (!Ext.isEmpty(this.cls, false)) {
            textEl.className = this.cls;
        }

        textEl.setAttribute("href", this.url);

        if (this.disabled) {
            textEl.setAttribute("disabled", "1");
            textEl.removeAttribute("href");
        }

        if (!Ext.isEmpty(this.target, false)) {
            textEl.setAttribute("target", this.target);
        }

        if (this.imageUrl) {
            textEl.innerHTML = '<img src="' + this.imageUrl + '" />';
        } else {
            textEl.innerHTML = this.text ? Ext.util.Format.htmlEncode(this.text) : (this.html || "");
        }
        
        this.textEl = textEl;
        return this.textEl;
    },

    setDisabled : function (disabled) {
        Coolite.Ext.HyperLink.superclass.setDisabled.apply(this, arguments);
        
        if (disabled) {
            this.textEl.setAttribute("disabled", "1");
            this.textEl.removeAttribute("href");
        } else {
            this.textEl.removeAttribute("disabled");
            this.textEl.setAttribute("href", this.url);
        }
    },

    setImageUrl : function (imageUrl) {
        this.imageUrl = imageUrl;
        this.textEl.innerHTML = '<img style="border:0px;" src="' + this.imageUrl + '" />';
    },

    setUrl : function (url) {
        this.url = url;
        this.textEl.setAttribute("href", this.url);
    },

    setTarget : function (target) {
        this.target = target;
        this.textEl.setAttribute("target", this.target);
    }
});

Ext.reg("hyperlink", Coolite.Ext.HyperLink);