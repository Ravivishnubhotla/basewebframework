
// @source core/ajax/AjaxEvent.js

Coolite.AjaxEvent = new Ext.data.Connection({
    autoAbort      : false,
    /*LOCALIZE*/
    confirmTitle   : "Confirmation",
    /*LOCALIZE*/
    confirmMessage : "Are you sure?",

    doFormUpload : function (o, ps, url) {
        var id = Ext.id(),
            frame = document.createElement("iframe"),
            form;
            
        frame.id = id;
        frame.name = id;
        frame.className = "x-hidden";
        
        if (Ext.isIE) {
            frame.src = Ext.SSL_SECURE_URL;
        }
        
        document.body.appendChild(frame);

        if (Ext.isIE) {
            document.frames[id].name = id;
        }

        form = Ext.getDom(o.form);
        form.target = id;
        form.method = "POST";
        form.enctype = form.encoding = "multipart/form-data";
        
        if (url) {
            form.action = url;
        }

        var hiddens, hd;
        
        if (ps) { // add dynamic params
            hiddens = [];
            ps = Ext.urlDecode(ps, false);
            
            for (var k in ps) {
                if (ps.hasOwnProperty(k)) {
                    hd = document.createElement("input");
                    hd.type = "hidden";
                    hd.name = k;
                    hd.value = ps[k];
                    form.appendChild(hd);
                    hiddens.push(hd);
                }
            }
        }

        var cb = function () {
            var r = {
                responseText : "",
                responseXML  : null
            };

            r.argument = o ? o.argument : null;

            try {
                var doc, firstChild;
                
                if (Ext.isIE) {
                    doc = frame.contentWindow.document;
                } else {
                    doc = (frame.contentDocument || window.frames[id].document);
                }
                
                if (doc && doc.body) {
                    if (/textarea/i.test((firstChild = doc.body.firstChild || {}).tagName)) {
                        r.responseText = firstChild.value;
                    } else if (doc.body.innerText) {
                        r.responseText = doc.body.innerText;
                    } else if (doc.body.textContent) {
                        r.responseText = doc.body.textContent;
                    } else {
                        r.responseText = doc.body.innerHTML;
                    }
                }
                
                if (doc && doc.XMLDocument) {
                    r.responseXML = doc.XMLDocument;
                } else {
                    r.responseXML = doc;
                }
            }
            catch (e) {
                // ignore
            }

            Ext.EventManager.removeListener(frame, "load", cb, this);

            this.fireEvent("requestcomplete", this, r, o);

            Ext.callback(o.success, o.scope, [r, o]);
            Ext.callback(o.callback, o.scope, [o, true, r]);

            setTimeout(function () { 
                Ext.removeNode(frame); 
                form.target = "";
            }, 100);
        };

        Ext.EventManager.on(frame, "load", cb, this);
        
        form.submit();

        if (hiddens) { // remove dynamic params
            for (var i = 0, len = hiddens.length; i < len; i++) {
                Ext.removeNode(hiddens[i]);
            }
        }        
    },

    confirmRequest : function (ajaxEventConfig) {
        ajaxEventConfig = ajaxEventConfig || {};
        if (ajaxEventConfig.confirmation && ajaxEventConfig.confirmation.confirmRequest) {
            if (ajaxEventConfig.confirmation.beforeConfirm && ajaxEventConfig.confirmation.beforeConfirm(ajaxEventConfig) === false) {
                Coolite.AjaxEvent.request(ajaxEventConfig);
                return;
            }
            
            Ext.Msg.confirm(
                ajaxEventConfig.confirmation.title || this.confirmTitle,
                ajaxEventConfig.confirmation.message || this.confirmMessage,
                this.confirmAnswer.createDelegate(this, [ajaxEventConfig], true),
                this);
        } else {
            Coolite.AjaxEvent.request(ajaxEventConfig);
        }
    },

    confirmAnswer : function (btn, text, buttonConfig, ajaxEventConfig) {
        if (btn == "yes") {
            Coolite.AjaxEvent.request(ajaxEventConfig);
        }
    },

    serializeForm : function (form) {
        return Ext.lib.Ajax.serializeForm(form);
    },
    
    setValue : function (form, name, value) {
        var input = null, pe;
        
        var els = Ext.fly(form).select("input[name=" + name + "]");
        
        if (els.getCount() > 0) {
            input = els.elements[0];
        } else {
            input = document.createElement("input");
            input.setAttribute("name", name);
            input.setAttribute("type", "hidden");
        }
        
        input.setAttribute("value", value);
        
        pe = input.parentElement ? input.parentElement : input.parentNode;
        
        if (Ext.isEmpty(pe)) {
            form.appendChild(input);
            //form[name] = input;
        }
    },
    
    delayedF : function (el, remove) {
        if (!Ext.isEmpty(el)) {
            el.unmask();
            
            if (remove === true) {
                el.remove();
            }
        }
    },
    
    showFailure : function (response, errorMsg) {
        var bodySize = Ext.getBody().getViewSize(),
            width = (bodySize.width < 500) ? bodySize.width - 50 : 500,
            height = (bodySize.height < 300) ? bodySize.height - 50 : 300,
            win;

        if (Ext.isEmpty(errorMsg)) {
            errorMsg = response.responseText;
        }

        win = new Ext.Window({ 
            modal       : true, 
            width       : width, 
            height      : height, 
            title       : "Request Failure", 
            layout      : "fit", 
            maximizable : true,
            listeners   : {
                "maximize": {
                    fn : function (el) {
                        var v = Ext.getBody().getViewSize();
                        el.setSize(v.width, v.height);
                    },
                    scope : this
                },

                "resize": {
                    fn : function (wnd) {
                        var editor = Ext.getCmp("__ErrorMessageEditor");
                        var sz = wnd.body.getViewSize();
                        editor.setSize(sz.width, sz.height - 42);
                    }
                }
            },
            items : new Ext.form.FormPanel({
                baseCls     : "x-plain",
                layout      : "absolute",
                defaultType : "label",
                items : [
                    {
                        x    : 5,
                        y    : 5,
                        html : '<div class="x-window-dlg"><div class="ext-mb-error" style="width:32px;height:32px"></div></div>'
                    }, 
                    {
                        x    : 42,
                        y    : 6,
                        html : "<b>Status code: </b>"
                    }, 
                    {
                        x    : 125,
                        y    : 6,
                        text : response.status
                    }, 
                    {
                        x    : 42,
                        y    : 25,
                        html : "<b>Status text: </b>"
                    }, 
                    {
                        x    : 125,
                        y    : 25,
                        text : response.statusText
                    }, 
                    {
                        x     : 0,
                        y     : 42,
                        id    : "__ErrorMessageEditor",
                        xtype : "htmleditor",
                        enableAlignments : false,
                        enableColors     : false,
                        enableFont       : false,
                        enableFontSize   : false,
                        enableFormat     : false,
                        enableLinks      : false,
                        enableLists      : false,
                        enableSourceEdit : false,
                        readOnly         : true,
                        value            : errorMsg
                    }
                ]
            })
        });
        win.show();
    },
        
    parseResponse : function (response) {
        var text = response.responseText,
            xmlTpl = "<?xml",
            result = {},
            exception = false;

        result.success = true;

        try {
            if (response.responseText.match(/^<\?xml/) == xmlTpl) {
                //xml parsing      
                var xmlData = response.responseXML,
                    root = xmlData.documentElement || xmlData,
                    q = Ext.DomQuery;

                if (root.nodeName == "AjaxResponse") {
                    //root = q.select("AjaxResponse", root);
                    //success
                    var sv = q.selectValue("Success", root, true),
                        pSuccess = sv !== false && sv !== "false",
                        pErrorMessage = q.selectValue("ErrorMessage", root, ""),
                        pScript = q.selectValue("Script", root, ""),
                        pViewState = q.selectValue("ViewState", root, ""),
                        pViewStateEncrypted = q.selectValue("ViewStateEncrypted", root, ""),
                        pEventValidation = q.selectValue("EventValidation", root, ""),
                        pServiceResponse = q.selectValue("ServiceResponse", root, ""),
                        pUserParamsResponse = q.selectValue("ExtraParamsResponse", root, ""),
                        pResult = q.selectValue("Result", root, "");

                    if (!Ext.isEmpty(pSuccess)) {
                        Ext.apply(result, { success : pSuccess });
                    }

                    if (!Ext.isEmpty(pErrorMessage)) {
                        Ext.apply(result, { errorMessage : pErrorMessage });
                    }

                    if (!Ext.isEmpty(pScript)) {
                        Ext.apply(result, { script : pScript });
                    }

                    if (!Ext.isEmpty(pViewState)) {
                        Ext.apply(result, { viewState : pViewState });
                    }

                    if (!Ext.isEmpty(pViewStateEncrypted)) {
                        Ext.apply(result, { viewStateEncrypted : pViewStateEncrypted });
                    }

                    if (!Ext.isEmpty(pEventValidation)) {
                        Ext.apply(result, { eventValidation : pEventValidation });
                    }

                    if (!Ext.isEmpty(pServiceResponse)) {
                        Ext.apply(result, { serviceResponse : eval("(" + pServiceResponse + ")") });
                    }

                    if (!Ext.isEmpty(pUserParamsResponse)) {
                        Ext.apply(result, { extraParamsResponse : eval("(" + pUserParamsResponse + ")") });
                    }

                    if (!Ext.isEmpty(pResult)) {
                        Ext.apply(result, { result : eval("(" + pResult + ")") });
                    }

                    return { result : result, exception : false };
                }
                else {
                    return { result : response.responseXML, exception : false }; // root.text || root.textContent;
                }
            }

            //json parsing
            result = eval("(" + text + ")");

        } catch (e) {
            result.success = false;
            exception = true;
            
            if (response.responseText.length === 0) {
                result.errorMessage = "NORESPONSE";
            } else {
                result.errorMessage = "BADRESPONSE: " + e.message;
                result.responseText = response.responseText;
            }

            response.statusText = result.errorMessage;
        }

        return { result : result, exception : exception };
    },

    listeners : {
        beforerequest : {
            fn : function (conn, options) {
                var o = options || {};
                
                o.eventType = o.eventType || "event";

                var isInstance = o.eventType == "public",
                    submitConfig = {},
                    forms;
                    
                o.extraParams = o.extraParams || {};
                
                switch (o.eventType) {
                case "event"    :
                case "custom"   : 
                case "proxy"    :
                case "postback" :
                case "public"   :
                    if (isInstance) {
                        o.action = o.name;
                    }

                    o.control = o.control || {};
                    o.type = o.type || "submit";
                    o.viewStateMode = o.viewStateMode || "default";
                    o.action = o.action || "Click";
                    o.headers = { "X-Coolite": "delta=true" };

                    if (o.type == "submit") {
                        o.form = Ext.get(o.formProxyArg);

                        if (!Ext.isEmpty(o.form) && !Ext.isEmpty(o.form.id)) {
                            var cmp = Ext.getCmp(o.form.id);
                            
                            if (!Ext.isEmpty(cmp) && cmp.getForm && cmp.startMonitoring) {
                                if (cmp.form && cmp.form.el.dom.elements) {
                                    o.form = cmp.form.el;
                                } else {
                                    o.form = undefined;
                                }
                            }
                        }

                        if (Ext.isEmpty(o.form) && !Ext.isEmpty(o.control.el)) {
                            if (Ext.isEmpty(o.control.isComposite) || o.control.isComposite === false) {
                                o.form = o.control.el.up("form");
                            } else {
                                o.form = Ext.get(o.control.elements[0]).up("form");
                            }
                        }
                    } else if (o.type == "load" && Ext.isEmpty(o.method)) {
                        o.method = "GET";
                    }

                    if (Ext.isEmpty(o.form) && Ext.isEmpty(o.url)) {
                        forms = Ext.select("form").elements;

                        if (forms.length > 0) {
                            if (o.type == "submit") {
                                o.form = (forms.length > 0) ? Ext.get(forms[0]) : undefined;
                            }
                            else {
                                o.url = (forms.length > 0) ? forms[0].action : Coolite.Ext.Url || window.location.href;
                            }
                        }
                    }

                    var argument = String.format("{0}|{1}|{2}", o.proxyId || o.control.proxyId || o.control.id || "-", o.eventType, o.action);

                    if (!Ext.isEmpty(o.form)) {
                        this.setValue(o.form.dom, "__EVENTTARGET", Coolite.ScriptManager);
                        this.setValue(o.form.dom, "__EVENTARGUMENT", argument);
                        Ext.getDom(o.form).ignoreAllSubmitFields = true;
                    } else {
                        o.url = o.url || Coolite.Ext.Url || window.location.href;
                        Ext.apply(submitConfig, { __EVENTTARGET : Coolite.ScriptManager, __EVENTARGUMENT : argument });
                    }

                    if (o.viewStateMode != "default") {
                        Ext.apply(submitConfig, { viewStateMode : o.viewStateMode });
                    }

                    if (o.before) {                        
                        if (o.before(o.control, o.eventType, o.action, o.extraParams) === false) {
                            return false;
                        }
                    }
                    
                    if (this.fireEvent("beforeajaxrequest", o.control, o.eventType, o.action, o.extraParams, o) === false) {
                        return false;
                    }

                    if (!Ext.isEmpty(o.extraParams) && !Ext.isEmptyObj(o.extraParams)) {
                        Ext.apply(submitConfig, { extraParams : o.extraParams });
                    }

                    if (!Ext.isEmpty(o.serviceParams)) {
                        Ext.apply(submitConfig, { serviceParams : o.serviceParams });
                    }

                    if (!Ext.isEmpty(submitConfig) && !Ext.isEmptyObj(submitConfig)) {
                        o.params = { submitAjaxEventConfig : Ext.encode({ config : submitConfig }) };
                    } else {
                        o.params = {};
                    }
                    
                    if (!Ext.isEmpty(o.form)) {
                        var enctype = Ext.getDom(o.form).getAttribute("enctype");
                        
                        if ((enctype && enctype.toLowerCase() == "multipart/form-data") || o.isUpload) {
                            Ext.apply(o.params, { "__CooliteAjaxEventMarker": "delta=true" });
                        }
                    }

                    if (o.cleanRequest) {
                        o.params = Ext.apply({}, o.extraParams || {});
                        
                        for (var key in o.params) {
                            var ov = o.params[key];
                            
                            if (typeof ov == "object") {
                                o.params[key] = Ext.encode(ov);
                            }
                        }
                        
                        if (o.json) {
                            o.jsonData = o.params;                        
                        }
                    }

                    if (!Ext.isEmpty(o.form)) {
                        o.form.dom.action = o.form.dom.action || o.form.action || o.url || Coolite.Ext.Url || window.location.href;
                    }

                    break;
                case "static":
                    o.headers = { "X-Coolite": "delta=true,staticmethod=true" };

                    if (Ext.isEmpty(o.form) && Ext.isEmpty(o.url)) {
                        forms = Ext.select("form").elements;
                        o.url = (forms.length == 1 && !Ext.isEmpty(forms[0].action)) ? forms[0].action : Coolite.Ext.Url || window.location.href;
                    }

                    if (o.before) {
                        if (o.before(o.control, o.eventType, o.action, o.extraParams) === false) {
                            return false;
                        }
                    }
                    
                    if (this.fireEvent("beforeajaxrequest", o.control, o.eventType, o.action, o.extraParams, o) === false) {
                        return false;
                    }

                    o.params = Ext.apply(o.extraParams, { "_methodName_": o.name });
                    break;
                }

                o.scope = this;

                //--Common part----------------------------------------------------------

                var el, em = o.eventMask || {};
                
                if ((em.showMask === true)) {
                    switch (em.target || "page") {
                    case "this":
                        if (o.control.getEl) {
                            el = o.control.getEl();
                        } else if (o.control.dom) {
                            el = o.control;
                        }
                        break;
                    case "parent":
                        if (o.control.getEl) {
                            el = o.control.getEl().parent();
                        } else if (o.control.parent) {
                            el = o.control.parent();
                        }
                        break;
                    case "page":
                        var theHeight = "100%";
                        
                        if (window.innerHeight) {
                            theHeight = window.innerHeight + "px";
                        } else if (document.documentElement && document.documentElement.clientHeight) {
                            theHeight = document.documentElement.clientHeight + "px";
                        } else if (document.body) {
                            theHeight = document.body.clientHeight + "px";
                        }

                        el = Ext.getBody().createChild({ style : "position:absolute;left:0;top:0;width:100%;height:" + theHeight + ";z-index:20000;background-color:Transparent;" });
                        
                        var scroll = Ext.getBody().getScroll();
                        el.setLeftTop(scroll.left, scroll.top);
                        break;
                    case "customtarget":
                        var trg = em.customTarget || "";
                        el = Coolite.Ext.getEl(trg);
                        
                        if (Ext.isEmpty(el)) {
                            el = trg.getEl ? trg.getEl() : null;
                        }
                        
                        break;
                    }

                    if (!Ext.isEmpty(el)) {
                        el.mask(em.msg || Ext.LoadMask.prototype.msg, em.msgCls || Ext.LoadMask.prototype.msgCls);
                        o.el = el;
                    }
                }

                var removeMask = function (o) {
                    if (o.el !== undefined && o.el !== null) {
                        var delay = 0,
                            em = o.eventMask || {},
                            task;
                            
                        if (em && em.minDelay) {
                            delay = em.minDelay;
                        }

                        var remove = (em.target || "page") == "page";
                        
                        task = new Ext.util.DelayedTask(function (o, remove) {
                                o.scope.delayedF(o.el, remove);
                            }, o.scope, [o, remove]).delay(delay);
                    }
                };

                var executeScript = function (o, result, response) {
                    var delay = 0,
                        em = o.eventMask || {};
                        
                    if (em.minDelay) {
                        delay = em.minDelay;
                    }

                    var task = new Ext.util.DelayedTask(
                        function (o, result, response) {
                            if (result.script && result.script.length > 0) {
                                eval(result.script);
                            }
                            
                            this.fireEvent("ajaxrequestcomplete", response, result, o.control, o.eventType, o.action, o.extraParams, o);

                            if (o.userSuccess) {
                                o.userSuccess(response, result, o.control, o.eventType, o.action, o.extraParams, o);
                            }
                        },
                        o.scope, [o, result, response]).delay(delay);
                };


                o.failure = function (response, options) {
                    var o = options;
                    removeMask(o);
                    
                    if (this.fireEvent("ajaxrequestexception", response, { "errorMessage": response.statusText }, o.control, o.eventType, o.action, o.extraParams, o) === false) {
                        o.cancelFailureWarning = true;
                    }
                    
                    if (o.userFailure && (Ext.isEmpty(o.enforceFailureWarning) || !o.enforceFailureWarning)) {
                        o.userFailure(response, { "errorMessage": response.statusText }, o.control, o.eventType, o.action, o.extraParams, o);
                    } else if (o.showWarningOnFailure !== false && !o.cancelFailureWarning) {
                        o.scope.showFailure(response, "");
                    }
                };

                o.success = function (response, options) {
                    var o = options;
                    
                    removeMask(o);

                    var parsedResponse = o.scope.parseResponse(response);

                    if (!Ext.isEmpty(parsedResponse.result.documentElement)) {
                        executeScript(o, parsedResponse.result, response);
                        return;
                    }
                    
                    var result = parsedResponse.result,
                        exception = parsedResponse.exception;

                    if (result.success === false) {
                        if (this.fireEvent("ajaxrequestexception", response, result, o.control, o.eventType, o.action, o.extraParams, o) === false) {
                            o.cancelFailureWarning = true;
                        }
                        
                        if (o.userFailure && (Ext.isEmpty(o.enforceFailureWarning) || !o.enforceFailureWarning)) {
                            o.userFailure(response, result, o.control, o.eventType, o.action, o.extraParams, o);
                        } else {
                            if (o.showWarningOnFailure !== false && !o.cancelFailureWarning) {
                                var errorMsg = "";
                                
                                if (!exception && result.errorMessage && result.errorMessage.length > 0) {
                                    errorMsg = result.errorMessage;
                                }
                                
                                o.scope.showFailure(response, errorMsg);
                            }
                        }

                        return;
                    }

                    if (!Ext.isEmpty(result.viewState) && o.form !== null) {
                        o.scope.setValue(o.form.dom, "__VIEWSTATE", result.viewState);
                        delete result.viewState;

                        if (!Ext.isEmpty(result.viewStateEncrypted) && o.form !== null) {
                            o.scope.setValue(o.form.dom, "__VIEWSTATEENCRYPTED", result.viewStateEncrypted);
                            delete result.viewStateEncrypted;
                        }

                        if (!Ext.isEmpty(result.eventValidation) && o.form !== null) {
                            o.scope.setValue(o.form.dom, "__EVENTVALIDATION", result.eventValidation);
                            delete result.eventValidation;
                        }
                    }

                    executeScript(o, result, response);
                };
            }
        }
    }
});

Coolite.AjaxEvent.addEvents("beforeajaxrequest", "ajaxrequestcomplete", "ajaxrequestexception");