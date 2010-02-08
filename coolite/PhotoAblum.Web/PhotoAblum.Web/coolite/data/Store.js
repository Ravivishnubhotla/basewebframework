
// @source data/Store.js

Ext.data.GroupingStore.prototype.clearGrouping = Ext.data.GroupingStore.prototype.clearGrouping.createInterceptor(function () {
    if (this.remoteGroup) {
        if (this.lastOptions && this.lastOptions.params) {
            delete this.lastOptions.params.groupBy;
        }
    }
});

Coolite.Ext.Store = function (config) {
    Ext.apply(this, config);

    this.deleted = [];
    
    this.addEvents(
        "beforesave",
        "save",
        "saveexception",
        "commitdone",
        "commitfailed");

    if (this.updateProxy) {
        this.relayEvents(this.updateProxy, ["saveexception"]);
    }

    if (!Ext.isEmpty(this.updateProxy)) {
        this.on("saveexception", function (ds, o, response, e) {
            if (this.showWarningOnFailure) {
                Coolite.AjaxEvent.showFailure(response, e.message);
            }
        }, this);
    }

    if (this.proxy && !this.proxy.refreshByUrl && !this.proxy.isDataProxy) {
        this.on("loadexception", function (ds, o, response, e) {
            if (this.showWarningOnFailure) {
                Coolite.AjaxEvent.showFailure(response, response.responseText);
            }
        }, this);
    }

    Coolite.Ext.Store.superclass.constructor.call(this);
};

Ext.extend(Coolite.Ext.Store, Ext.data.GroupingStore, {
    pruneModifiedRecords : true,
    warningOnDirty       : true,
    /*LOCALIZE*/
    dirtyWarningTitle    : "Uncommitted Changes",
    /*LOCALIZE*/
    dirtyWarningText     : "You have uncommitted changes.  Are you sure you want to reload data?",
    updateProxy          : null,

    // "none" - no refresh after saving
    // "always" - always refresh after saving
    // "auto" - auto refresh. If no new records then refresh doesn't perfom. If new records exists then refresh will be perfom for refresh id fields
    refreshAfterSave     : "Auto",
    useIdConfirmation    : false,
    showWarningOnFailure : true,
    
    metaId : function () {
        if (this.reader.isArrayReader) {
            var id = Ext.num(parseInt(this.reader.meta.id, 10), -1);
            
            if (id !== -1) {
                return this.reader.meta.fields[id].name;
            }
        }

        return this.reader.meta.id;
    },

    addRecord: function (values) {
        this.clearFilter(false);
        var rowIndex = this.data.length;
        var record = this.insertRecord(rowIndex, values);
        return { index: rowIndex, record: record };
    },

    addSortedRecord : function (values) {
        this.clearFilter(false);
        return this.insertRecord(0, values, true);
    },

    insertRecord : function (rowIndex, values, asSorted) {
        this.clearFilter(false);

        values = values || {};
        
        var f = this.recordType.prototype.fields, dv = {};

        for (var i = 0; i < f.length; i++) {
            dv[f.items[i].name] = f.items[i].defaultValue;
        }

        var record = new this.recordType(dv, values[this.metaId()]), v;
        record.newRecord = true;
        
        if (this.modified.indexOf(record) == -1) {
            this.modified.push(record);
        }

        if (!asSorted) {
            this.insert(rowIndex, record);

            for (v in values) {
                record.set(v, values[v]);
            }
        } else {
            for (v in values) {
                record.set(v, values[v]);
            }

            this.addSorted(record);
        }

        if (!Ext.isEmpty(this.metaId())) {
            record.set(this.metaId(), record.id);
        }

        return record;
    },

    addField : function (field, index) {
        if (typeof field == "string") {
            field = { name: field };
        }

        if (Ext.isEmpty(this.recordType)) {
            this.recordType = Ext.data.Record.create([]);
        }

        field = new Ext.data.Field(field);

        if (Ext.isEmpty(index)) {
            this.recordType.prototype.fields.replace(field);
        } else {
            this.recordType.prototype.fields.insert(index, field);
        }

        if (typeof field.defaultValue != "undefined") {
            this.each(function (r) {
                if (typeof r.data[field.name] == "undefined") {
                    r.data[field.name] = field.defaultValue;
                }
            });
        }
    },

    removeFields : function () {
        if (this.recordType) {
            this.recordType.prototype.fields.clear();
        }
        
        this.removeAll();
    },

    removeField : function (name) {
        this.recordType.prototype.fields.removeKey(name);

        this.each(function (r) {
            delete r.data[name];
            
            if (r.modified) {
                delete r.modified[name];
            }
        });
    },

    prepareRecord : function (data, record, options, isNew) {
        var newData = {};

        if (options.visibleOnly && options.grid) {
            var cm = options.grid.getColumnModel();

            for (var i in data) {
                var columnIndex = cm.findColumnIndex(i);
                
                if (columnIndex > -1 && !cm.isHidden(columnIndex)) {
                    newData[i] = data[i];
                }
            }

            data = newData;
        }

        if (options.dirtyOnly && !isNew) {
            for (var j in data) {
                if (record.isModified(j)) {
                    newData[j] = data[j];
                }
            }

            data = newData;
        }

        for (var k in data) {
            if (data[k] === "" && this.isSimpleField(k)) {
                data[k] = null;
            }
        }

        return data;
    },

    isSimpleField : function (name) {
        for (var i = 0; i < this.fields.getCount(); i++) {
            var field = this.fields.get(i);
            
            if (name === (field.mapping || field.name)) {
                return field.type === "int" || field.type === "float" || field.type === "boolean" || field.type === "date";
            }
        }

        return false;
    },

    getRecordsValues : function (options) {
        options = options || {};
        
        var records = (options.currentPageOnly ? this.getRange() : this.getAllRange()) || [],
            values = [],
            i;        

        for (i = 0; i < records.length; i++) {
            var obj = {}, dataR;
            
            if (this.metaId()) {
                obj[this.metaId()] = records[i].id;
            }

            dataR = Ext.apply(obj, records[i].data);
            dataR = this.prepareRecord(dataR, records[i], options);

            if (!Ext.isEmptyObj(dataR)) {
                values.push(dataR);
            }
        }

        return values;
    },

    refreshIds : function (newRecordsExists, deletedExists, dataAbsent) {
        switch (this.refreshAfterSave) {
        case "None":
            return;
        case "Always":
            if (dataAbsent) {
                this.reload();
            } else {
                this.reload(undefined, true);
            }
            break;
        case "Auto":
            if (newRecordsExists || deletedExists) {
                if (dataAbsent) {
                    this.reload();
                } else {
                    this.reload(undefined, true);
                }
            }
            break;
        }
    },

    reload : function (options, baseReload) {
        if (this.proxy.refreshByUrl && baseReload !== true) {
            var opts = options || {};
            opts.params = opts.params || {};            
            this.callbackReload(this.warningOnDirty, opts);
        } else {
            if (options && options.params && options.params.submitAjaxEventConfig) {
                delete options.params.submitAjaxEventConfig;
            }
            
            Coolite.Ext.Store.superclass.reload.call(this, options);
        }
    },

    load : function (options) {
        var loadData = function (store, options) {
            store.deleted = [];
            store.modified = [];
            
            return Coolite.Ext.Store.superclass.load.call(store, options);
        };

        if (this.warningOnDirty && this.isDirty() && !this.silentMode) {
            this.silentMode = false;
            Ext.MessageBox.confirm(
                this.dirtyWarningTitle,
                this.dirtyWarningText,
                function (btn, text) {
                    return (btn == "yes") ? loadData(this, options) : false;
                },
                this
            );
        } else {
            return loadData(this, options);
        }
    },

    save : function (options) {
        if (Ext.isEmpty(this.updateProxy)) {
            this.callbackSave(options);
            return;
        }

        options = options || {};

        if (this.fireEvent("beforesave", this, options) !== false) {
            var json = this.getChangedData(options);

            if (json.length > 0) {
                var p = Ext.apply(options.params || {}, { data: "{" + json + "}" });
                this.updateProxy.save(p, this.reader, this.recordsSaved, this, options);
            } else {
                this.fireEvent("commitdone", this, options);
            }
        }
    },

    getChangedData : function (options) {
        options = options || {};
        var json = "",
            d = this.deleted,
            m = this.modified;

        if (d.length > 0) {
            json += '"Deleted":[';

            var exists = false;

            for (var i = 0; i < d.length; i++) {
                var obj = {},
                    list = Ext.apply(obj, d[i].data);

                if (this.metaId() && Ext.isEmpty(list[this.metaId()], false)) {
                    list[this.metaId()] = d[i].id;
                }

                list = this.prepareRecord(list, d[i], options);

                if (!Ext.isEmptyObj(list)) {
                    json += Ext.util.JSON.encode(list) + ",";
                    exists = true;
                }
            }

            if (exists) {
                json = json.substring(0, json.length - 1) + "]";
            } else {
                json = "";
            }
        }

        var jsonUpdated = "",
            jsonCreated = "";

        for (var j = 0; j < m.length; j++) {

            var obj2 = {},
                list2 = Ext.apply(obj2, m[j].data);

            if (this.metaId() && Ext.isEmpty(list2[this.metaId()], false)) {
                list2[this.metaId()] = m[j].id;
            }

            if (m[j].newRecord && this.skipIdForNewRecords !== false && !this.useIdConfirmation) {
                list2[this.metaId()] = undefined;
            }

            list2 = this.prepareRecord(list2, m[j], options, m[j].newRecord);

            if (!Ext.isEmptyObj(list2)) {
                if (m[j].newRecord) {
                    jsonCreated += Ext.util.JSON.encode(list2) + ",";
                } else {
                    jsonUpdated += Ext.util.JSON.encode(list2) + ",";
                }
            }
        }

        if (jsonUpdated.length > 0) {
            jsonUpdated = jsonUpdated.substring(0, jsonUpdated.length - 1) + "]";
        }

        if (jsonCreated.length > 0) {
            jsonCreated = jsonCreated.substring(0, jsonCreated.length - 1) + "]";
        }

        if (jsonUpdated.length > 0) {
            if (json.length > 0) {
                json += ",";
            }

            json += '"Updated":[';
            json += jsonUpdated;
        }

        if (jsonCreated.length > 0) {
            if (json.length > 0) {
                json += ",";
            }

            json += '"Created":[';
            json += jsonCreated;
        }

        return json;
    },

    getByDataId : function (id) {
        if (!this.metaId()) {
            return undefined;
        }

        var m = this.modified, i;

        for (i = 0; i < m.length; i++) {
            if (m[i].data[this.metaId()] == id) {
                return m[i];
            }
        }

        return undefined;
    },

    recordsSaved : function (o, options, success) {
        if (!o || success === false) {
            if (success !== false) {
                this.fireEvent("save", this, options);
            }

            if (options.callback) {
                options.callback.call(options.scope || this, options, false);
            }

            return;
        }

        var serverSuccess = o.success,
            msg = o.msg;

        this.fireEvent("save", this, options);

        if (options.callback) {
            options.callback.call(options.scope || this, options, true);
        }

        var serviceResult = o.data || {},
            newRecordsExists = false,
            deletedExists = this.deleted.length > 0,
            m = this.modified,
            j;

        for (j = 0; j < m.length; j++) {
            if (m[j].newRecord) {
                newRecordsExists = true;
                break;
            }
        }

        if (!serverSuccess) {
            this.fireEvent("commitfailed", this, msg);

            if (this.showWarningOnFailure) {
                Coolite.AjaxEvent.showFailure({ status: "", statusText: "" }, msg);
            }

            return;
        }

        if (this.useIdConfirmation) {
            if (Ext.isEmpty(serviceResult.confirm)) {
                msg = "The confirmation list is absent";
                this.fireEvent("commitfailed", this, msg);

                if (this.showWarningOnFailure) {
                    Coolite.AjaxEvent.showFailure({ status: "", statusText: "" }, msg);
                }
                return;
            }

            var r = serviceResult.confirm,
                failCount = 0;

            for (var i = 0; i < r.length; i++) {
                if (r[i].s === false) {
                    failCount++;
                } else {
                    var record = this.getById(r[i].oldId) || this.getByDataId(r[i].oldId);

                    if (record) {
                        record.commit();
                        if (record.newRecord || false) {
                            delete record.newRecord;
                            var index = this.data.indexOf(record);
                            this.data.removeAt(index);
                            record.id = r[i].newId || r[i].oldId;
                            
                            if (this.metaId()) {
                                record.data[this.metaId()] = record.id;
                            }
                            
                            this.data.insert(index, record);
                        }
                    } else {
                        var d = this.deleted;

                        for (var i2 = 0; i2 < d.length; i2++) {
                            if (this.metaId() && d[i2].id == r[i].oldId) {
                                this.deleted.splice(i2, 1);
                                failCount--;
                                break;
                            }
                        }
                        failCount++;
                    }
                }
            }

            if (failCount > 0) {
                msg = "Some records have no success confirmation!";
                this.fireEvent("commitfailed", this, msg);

                if (this.showWarningOnFailure) {
                    Coolite.AjaxEvent.showFailure({ status: "", statusText: "" }, msg);
                }
                
                return;
            }

            this.modified = [];
            this.deleted = [];
        } else {
            this.commitChanges();
        }


        this.fireEvent("commitdone", this, options);

        var dataAbsent = true;

        if (serviceResult.data && serviceResult.data !== null && this.proxy.refreshData) {
            dataAbsent = false;
            this.proxy.refreshData(serviceResult.data);
            
            if (this.isPagingStore()) {
                this.loadData(serviceResult.data);
                this.load(this.lastOptions);
            }
        }

        this.refreshIds(newRecordsExists, deletedExists, dataAbsent);
    },

    isPagingStore : function () {
        return this.isPaging && this.applyPaging;
    },

    getDeletedRecords : function () {
        return this.deleted;
    },

    remove : function (record) {
        if (!record.newRecord) {
            this.deleted.push(record);
        }

        Coolite.Ext.Store.superclass.remove.call(this, record);
    },

    commitChanges : function () {
        Coolite.Ext.Store.superclass.commitChanges.call(this);
        this.deleted = [];
    },

    rejectChanges : function () {
        Coolite.Ext.Store.superclass.rejectChanges.call(this);

        var d = this.deleted.slice(0);

        this.deleted = [];
        this.add(d);

        for (var i = 0, len = d.length; i < len; i++) {
            d[i].reject();
        }
    },

    isDirty : function () {
        return (this.deleted.length > 0 || this.modified.length > 0) ? true : false;
    },

    prepareCallback : function (context, options) {
        options = options || {};
        options.params = options.params || {};

        if (context.fireEvent("beforesave", context, options) !== false) {
            var json = context.getChangedData(options);

            if (json.length > 0) {
                var p = { data: "{" + json + "}", extraParams: options.params };
                return p;
            } else {
                context.fireEvent("commitdone", context, options);
            }
        }
        return null;
    },

    callbackHandler : function (response, result, context, type, action, extraParams, o) {
        try {
            var responseObj = result.serviceResponse;

            result = { success: responseObj.Success, msg: responseObj.Msg, data: responseObj.Data };
        } catch (e) {
            context.fireEvent("saveexception", context, {}, response, e);

            if (context.showWarningOnFailure) {
                Coolite.AjaxEvent.showFailure(response, e.message);
            }
            return;
        }
        context.recordsSaved(result, {}, true);
    },

    silentMode : false,

    callbackRefreshHandler : function (response, result, context, type, action, extraParams, o) {
        var p = context.proxy;

        try {
            var responseObj = result.serviceResponse;
            result = { success: responseObj.Success, msg: responseObj.Msg || null, data: responseObj.Data || {} };
        } catch (e) {
            context.fireEvent("loadexception", context, {}, response, e);
            
            if (context.showWarningOnFailure) {
                Coolite.AjaxEvent.showFailure(response, e.message);
            }

            if (o && o.userCallback) {
                o.userCallback.call(o.userScope || this, [], o, false);
            }
            return;
        }

        if (result.success === false) {
            context.fireEvent("loadexception", context, {}, response, { message: result.msg });
            if (context.showWarningOnFailure) {
                Coolite.AjaxEvent.showFailure(response, result.msg);
            }

            if (o && o.userCallback) {
                o.userCallback.call(o.userScope || this, [], o, false);
            }

            return;
        }

        if (p.refreshData) {
            if (result.data.data && result.data.data !== null) {
                p.refreshData(result.data.data);
                if (context.isPagingStore()) {
                    context.loadData(result.data.data);
                }
            } else {
                p.refreshData({});
                if (context.isPagingStore()) {
                    context.loadData({});
                }
            }
        }

        if (o && o.userCallback) {
            o.callback = o.userCallback;
            o.userCallback = undefined;
            o.scope = o.userScope;
            o.userScope = undefined;
        }

        if (!context.isPagingStore()) {
            context.silentMode = true;
            context.reload(o, true);
            context.silentMode = false;
        }
    },

    callbackErrorHandler : function (response, result, context, type, action, extraParams) {
        context.fireEvent("saveexception", context, {}, response, { message: result.errorMessage || response.statusText });

        if (context.showWarningOnFailure) {
            Coolite.AjaxEvent.showFailure(response, response.responseText);
        }
    },

    callbackRefreshErrorHandler : function (response, result, context, type, action, extraParams, o) {
        context.fireEvent("loadexception", context, {}, response, { message: result.errorMessage || response.statusText });

        if (context.showWarningOnFailure) {
            Coolite.AjaxEvent.showFailure(response, response.responseText);
        }

        if (o && o.userCallback) {
            o.userCallback.call(o.userScope || this, [], o, false);
        }
    },

    callbackSave : function (options) {
        var requestObject = this.prepareCallback(this, options);

        if (requestObject !== null) {
            var config = {},
                ac = this.ajaxEventConfig;

            ac.userSuccess = this.callbackHandler;
            ac.userFailure = this.callbackErrorHandler;
            ac.extraParams = requestObject.extraParams;
            ac.enforceFailureWarning = !this.hasListener("saveexception");

            Ext.apply(config, ac, {
                control   : this,
                eventType : "postback",
                action    : "update",
                serviceParams : requestObject.data
            });
            
            Coolite.AjaxEvent.request(config);
        }
    },

    submitData : function (data, options) {
        if (Ext.isEmpty(data)) {
            data = this.getRecordsValues(options);
        }

        if (Ext.isEmpty(this.updateProxy)) {
            options = { params: {} };
            if (this.fireEvent("beforesave", this, options) !== false) {

                var config = {}, ac = this.ajaxEventConfig;

                ac.userSuccess = this.submitSuccess;
                ac.userFailure = this.submitFailure;
                ac.extraParams = options.params;
                ac.enforceFailureWarning = !this.hasListener("saveexception");

                Ext.apply(config, ac, {
                    control   : this,
                    eventType : "postback",
                    action    : "submit",
                    serviceParams : Ext.encode(data)
                });

                Coolite.AjaxEvent.request(config);
            }
        } else {
            options = { params: {} };

            if (this.fireEvent("beforesave", this, options) !== false) {
                var p = Ext.apply(options.params || {}, { data: Ext.encode(data) });
                this.updateProxy.save(p, this.reader, this.finishSubmit, this, options);
            }
        }
    },

    finishSubmit : function (o, options, success) {
        if (!o || success === false) {

            if (success !== false) {
                this.fireEvent("save", this, options);
            }

            return;
        }

        var serverSuccess = o.success,
            msg = o.msg;

        if (!serverSuccess) {
            context.fireEvent("saveexception", this, options, {}, { message: msg });

            if (context.showWarningOnFailure) {
                Coolite.AjaxEvent.showFailure({ status: 200, statusText: "OK" }, msg);
            }

            return;
        }

        this.fireEvent("save", this, options);
    },

    submitFailure : function (response, result, context, type, action, extraParams) {
        context.fireEvent("saveexception", context, {}, response, { message: result.errorMessage || response.statusText });

        if (context.showWarningOnFailure) {
            Coolite.AjaxEvent.showFailure(response, response.responseText);
        }
    },

    submitSuccess : function (response, result, context, type, action, extraParams) {
        try {
            var responseObj = result.serviceResponse;
            result = { success: responseObj.Success, msg: responseObj.Msg };
        } catch (e) {
            context.fireEvent("saveexception", context, {}, response, e);

            if (context.showWarningOnFailure) {
                Coolite.AjaxEvent.showFailure(response, e.message);
            }

            return;
        }

        if (!result.success) {
            context.fireEvent("saveexception", context, {}, response, { message: result.msg });

            if (context.showWarningOnFailure) {
                Coolite.AjaxEvent.showFailure(response, result.msg);
            }

            return;
        }

        context.fireEvent("save", context, {});
    },

    callbackReload : function (dirtyConfirm, reloadOptions) {
        var options = Ext.applyIf(reloadOptions || {}, this.lastOptions);
        options.params = options.params || {};

        var reload = function (store, options) {
            if (store.fireEvent("beforeload", store, options) !== false) {
                store.storeOptions(options);
                store.deleted = [];
                store.modified = [];
            
                var config = {},
                    ac = store.ajaxEventConfig;

                ac.userSuccess = store.callbackRefreshHandler;
                ac.userFailure = store.callbackRefreshErrorHandler;
                ac.extraParams = options.params;
                ac.enforceFailureWarning = !store.hasListener("loadexception");
                config.userCallback = options.callback;
                config.userScope = options.scope;

                Ext.apply(config, ac, { 
                    control   : store, 
                    eventType : "postback", 
                    action    : "refresh" 
                });
                
                Coolite.AjaxEvent.request(config);
            }
        };

        if (dirtyConfirm && this.isDirty()) {
            Ext.MessageBox.confirm(
                this.dirtyWarningTitle,
                this.dirtyWarningText, function (btn, text) {
                    if (btn == "yes") {
                        reload(this, options);
                    }
                }, this);
        } else {
            reload(this, options);
        }
    },
    
    getAllRange : function (start, end) {
        return this.getRange(start, end);
    }
});