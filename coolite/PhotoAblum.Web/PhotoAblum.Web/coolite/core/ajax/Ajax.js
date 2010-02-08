
// @source core/ajax/Ajax.js

Ext.apply(Ext.lib.Ajax, {
    serializeForm : function (form, parent) {
        if (typeof form == "string") {
            form = (document.getElementById(form) || document.forms[form]);
        }

        var el, name, val, disabled, data = [], hasSubmit = false;
        
        hasSubmit = form.ignoreAllSubmitFields || false;
        
        for (var i = 0; i < form.elements.length; i++) {
            el = form.elements[i];
            disabled = form.elements[i].disabled;
            name = form.elements[i].name;
            val = form.elements[i].value;

            if (!Ext.isEmpty(parent) && Ext.isEmpty(Ext.fly(form.elements[i]).parent("#" + parent.id))) {
                continue;
            }

            if (name) {
                switch (el.type) {
                case "select-one":
                case "select-multiple":
                    for (var j = 0; j < el.options.length; j++) {
                        if (el.options[j].selected) {
                            if (Ext.isIE) {
                                data.push(encodeURIComponent(name));
                                data.push("=");
                                data.push(encodeURIComponent(el.options[j].attributes.value.specified ? el.options[j].value : el.options[j].text));
                                data.push("&");
                                //data += encodeURIComponent(name) + "=" + encodeURIComponent(el.options[j].attributes.value.specified ? el.options[j].value : el.options[j].text) + "&";
                            } else {
                                data.push(encodeURIComponent(name));
                                data.push("=");
                                data.push(encodeURIComponent(el.options[j].hasAttribute("value") ? el.options[j].value : el.options[j].text));
                                data.push("&");
                                //data += encodeURIComponent(name) + "=" + encodeURIComponent(el.options[j].hasAttribute("value") ? el.options[j].value : el.options[j].text) + "&";
                            }
                        }
                    }
                    break;
                case "radio":
                case "checkbox":
                    if (el.checked) {
                        data.push(encodeURIComponent(name));
                        data.push("=");
                        data.push(encodeURIComponent(val));
                        data.push("&");
                        //data += encodeURIComponent(name) + "=" + encodeURIComponent(val) + "&";
                    }
                    break;
                case "file":
                case undefined:
                case "reset":
                case "button":
                    break;
                case "submit":
                    if (hasSubmit === false) {
                        data.push(encodeURIComponent(name));
                        data.push("=");
                        data.push(encodeURIComponent(val));
                        data.push("&");
                        //data += encodeURIComponent(name) + "=" + encodeURIComponent(val) + "&";
                        hasSubmit = true;
                    }
                    break;
                default:
                    data.push(encodeURIComponent(name));
                    data.push("=");
                    data.push(encodeURIComponent(val));
                    data.push("&");
                    //data += encodeURIComponent(name) + "=" + encodeURIComponent(val) + "&";
                    break;
                }
            }
        }
        
        data = data.join("");
        data = data.substr(0, data.length - 1);
        return data;
    }
});