
// @source data/PropertyGrid.js

Coolite.Ext.PropertyGrid = function () {
    Coolite.Ext.PropertyGrid.superclass.constructor.call(this);	
	this.addEvents("beforesave", "save", "saveexception");
};

Coolite.Ext.PropertyGrid = Ext.extend(Ext.grid.PropertyGrid, {
    editable : true,
    
    getDataField : function () {
        if (!this.dataField) {
            this.dataField = new Ext.form.Hidden({ id : this.id + "_Data", name : this.id + "_Data" });
        }
        
        return this.dataField;
    },

    initComponent : function () {
        Coolite.Ext.PropertyGrid.superclass.initComponent.call(this);
        
        if (!this.editable) {
            this.on("beforeedit", function (e) {
                return false;
            });
        }
    },

    onRender : function () {
        Coolite.Ext.PropertyGrid.superclass.onRender.apply(this, arguments);
        this.getDataField().render(this.el.parent() || this.el);
    },

    callbackHandler : function (response, result, context, type, action, extraParams) {
        try {
            var responseObj = result.serviceResponse;
            result = { success : responseObj.Success, msg : responseObj.Msg || null };
        } catch (e) {
            context.fireEvent("saveexception", context, response, e);
            return;
        }

        if (result.success === false) {
            context.fireEvent("saveexception", context, response, { message : result.msg });
            return;
        }

        context.fireEvent("save", context, response);
    },

    callbackErrorHandler : function (response, result, context, type, action, extraParams) {
        context.fireEvent("saveexception", context, response, { message : result.errorMessage || response.statusText });
    },

    save : function () {
        var options = { params : {} };
        
        if (this.fireEvent("beforesave", this, options) !== false) {
            var config = {}, 
                ac = this.ajaxEventConfig;
                
            ac.userSuccess = this.callbackHandler;
            ac.userFailure = this.callbackErrorHandler;
            ac.extraParams = options.params;
            ac.enforceFailureWarning = !this.hasListener("saveexception");

            Ext.apply(config, ac, { control : this, eventType : "postback", action : "update", serviceParams : Ext.encode(this.getSource()) });
            Coolite.AjaxEvent.request(config);
        }
    }
});

Ext.reg("coolitepropertygrid", Coolite.Ext.PropertyGrid);