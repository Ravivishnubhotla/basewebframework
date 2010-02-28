
// @source core/form/ComboBox.js

Ext.form.ComboBox.prototype.initComponent = Ext.form.ComboBox.prototype.initComponent.createSequence(function () {
    this.initMerge();    
    
    if (!Ext.isEmpty(this.initSelectedIndex) && this.store) {
        this.setInitValueByIndex(this.initSelectedIndex);
    } else if (!Ext.isEmpty(this.value) && this.store) {
        this.setInitValue(this.value);
    }   
    
});

Ext.form.ComboBox.prototype.onRender = Ext.form.ComboBox.prototype.onRender.createSequence(function (el) {
    this.getEl().dom.setAttribute("name", this.uniqueName || this.id);
    this.getSelectedIndexField().render(this.el.parent() || this.el);
    
    this.on("focus", function (el) {
        this.oldValue = this.getValue();        
        var t = this.getEl().dom.value.trim();        
        this.oldText = (t === this.emptyText) ? "" : t;
    });
});

Ext.form.ComboBox.prototype.clearValue = Ext.form.ComboBox.prototype.clearValue.createSequence(function () {
    this.oldValue = null;   
    this.oldText = null;
});

Ext.form.ComboBox.override({
    alwaysMergeItems: true,
    forceSelection: true,

    initMerge : function () {
        if (this.mergeItems) {
            if (this.store.getCount() > 0) {
                this.doMerge();
            }

            if (this.store.getCount() === 0 || this.alwaysMergeItems) {
                this.store.on("load", this.doMerge, this, { single: !this.alwaysMergeItems });
            }
        }
    },

    doMerge : function () {
        for (var mi = this.mergeItems.getCount() - 1; mi > -1; mi--) {
            var f = this.store.recordType.prototype.fields, dv = [];

            for (var i = 0; i < f.length; i++) {
                dv[f.items[i].name] = f.items[i].defaultValue;
            }

            if (!Ext.isEmpty(this.displayField, false)) {
                dv[this.displayField] = this.mergeItems.getAt(mi).data.text;
            }

            if (!Ext.isEmpty(this.valueField, false) && this.displayField != this.valueField) {
                dv[this.valueField] = this.mergeItems.getAt(mi).data.value;
            }

            this.store.insert(0, new this.store.recordType(dv));
        }
    },

    addRecord : function (values) {
        this.store.clearFilter(false);
        
        var rowIndex = this.store.data.length,
            record = this.insertRecord(rowIndex, values);

        return { index: rowIndex, record: record };
    },

    addItem : function (text, value) {
        this.store.clearFilter(false);
        var rowIndex = this.store.data.length,
            record = this.insertItem(rowIndex, text, value);

        return { index: rowIndex, record: record };
    },

    insertRecord : function (rowIndex, values) {
        this.store.clearFilter(false);
        values = values || {};

        var f = this.store.recordType.prototype.fields, dv = {};

        for (var i = 0; i < f.length; i++) {
            dv[f.items[i].name] = f.items[i].defaultValue;
        }

        var record = new this.store.recordType(dv, values[this.store.metaId()]);

        this.store.insert(rowIndex, record);

        for (var v in values) {
            record.set(v, values[v]);
        }

        if (!Ext.isEmpty(this.store.metaId())) {
            record.set(this.store.metaId(), record.id);
        }

        return record;
    },

    insertItem : function (rowIndex, text, value) {
        this.store.clearFilter(false);
        
        var f = this.store.recordType.prototype.fields, dv = {};

        for (var i = 0; i < f.length; i++) {
            dv[f.items[i].name] = f.items[i].defaultValue;
        }

        if (!Ext.isEmpty(this.displayField, false)) {
            dv[this.displayField] = text;
        }

        if (!Ext.isEmpty(this.valueField, false) && this.displayField != this.valueField) {
            dv[this.valueField] = value;
        }

        var record = new this.store.recordType(dv);

        this.store.insert(rowIndex, record);

        return record;
    },

    removeByField : function (field, value) {
        var index = this.store.find(field, value);

        if (index < 0) {
            return;
        }

        this.store.remove(this.store.getAt(index));
    },

    removeByIndex : function (index) {
        if (index < 0 || index >= this.store.getCount()) {
            return;
        }

        this.store.remove(this.store.getAt(index));
    },

    removeByValue : function (value) {
        this.removeByField(this.valueField, value);
    },

    removeByText : function (text) {
        this.removeByField(this.displayField, text);
    },

    getSelectedIndexField : function () {
        if (!this.selectedIndexField) {
            this.selectedIndexField = new Ext.form.Hidden({ id: this.id + "_SelIndex", name: this.id + "_SelIndex" });
        }

        return this.selectedIndexField;
    },

    getText : function () {
        return this.el.getValue();
    },

    getSelectedItem : function () {
        return { text: this.getText(), value: this.getValue() };
    },

    initSelect : false,

    setValueAndFireSelect : function (v) {
        this.setValue(v);

        var r = this.findRecord(this.valueField, v);

        if (!Ext.isEmpty(r)) {
            var index = this.store.indexOf(r);

            this.getSelectedIndexField().setValue(this.getSelectedIndex());
            this.initSelect = true;
            this.fireEvent("select", this, r, index);
            this.initSelect = false;
        }
    },

    findRecordByText : function (prop, text) {
        var record;

        if (this.store.getCount() > 0) {
            this.store.each(function (r) {
                if (r.data[prop] == text) {
                    record = r;
                    return false;
                }
            });
        }
        return record;
    },

    origFindRecord : Ext.form.ComboBox.prototype.findRecord,

    findRecord : function (prop, value) {
        if (this.store.snapshot && this.store.snapshot.getCount() > 0) {
            var record;

            if (this.store.snapshot.getCount() > 0) {
                this.store.snapshot.each(function (r) {
                    if (r.data[prop] == value) {
                        record = r;
                        return false;
                    }
                });
            }
            
            return record;
        }

        return this.origFindRecord(prop, value);
    },

    indexOfEx : function (record) {
        if (this.store.snapshot && this.store.snapshot.getCount() > 0) {
            return this.store.snapshot.indexOf(record);
        }

        return this.store.data.indexOf(record);
    },

    getSelectedIndex : function () {
        var r = this.findRecord(this.forceSelection ? this.valueField : this.displayField, this.getValue());

        return (!Ext.isEmpty(r)) ? this.indexOfEx(r) : -1;
    },    

    setInitValue : function (value) {
        if (this.store.getCount() > 0) {
            this.setLoadedValue(value);
        } else {
            this.setValue(value);
            this.store.on("load", this.setLoadedValue.createDelegate(this, [value]), this, { single: true });
        }
    },

    setLoadedValue : function (value) {
        this[this.fireSelectOnLoad ? "setValueAndFireSelect" : "setValue"](value);
        this.clearInvalid();
    },
    
    onSelect : function (record, index) {
        if (this.fireEvent("beforeselect", this, record, index) !== false) {            
            this.setValue(record.data[this.valueField || this.displayField]);            
            this.collapse();
            this.getSelectedIndexField().setValue(this.getSelectedIndex());
            this.fireEvent("select", this, record, index);
            this.oldValue = this.getValue();
            
            var t = this.getEl().dom.value.trim();
            
            this.oldText = (t === this.emptyText) ? "" : t;
        }
    },

    triggerBlur : function () {
        this.mimicing = false;
        Ext.getDoc().un("mousewheel", this.mimicBlur, this);
        Ext.getDoc().un("mousedown", this.mimicBlur, this);
        
        if (this.monitorTab && this.el) {
            this.el.un("keydown", this.checkTab, this);
        }
        
        this.beforeBlur();
        
        if (this.wrap) {
            this.wrap.removeClass("x-trigger-wrap-focus");
        }

        var t = this.getEl().dom.value.trim(), v = this.getValue();

        if (this.oldValue !== v || (t !== this.oldText && t !== this.emptyText)) {
            if (!Ext.isEmpty(this.selValue) && this.selText != t && this.selValue == this.getValue()) {
                this.hiddenField.value = "";
            }

            var val = this.el.dom.value,
                r = this.findRecordByText(this.displayField, val);

            if (!Ext.isEmpty(r)) {
                this.onSelect(r, this.store.indexOf(r));
            } else {
                if (this.forceSelection) {
                    if (Ext.isEmpty(this.findRecord(this.valueField, this.oldValue))) {
                        this.clearValue();
                    } else {
                        this.setValue(this.oldValue);
                    }
                } else {
                    this.setValue(val);
                }
            }

            this.getSelectedIndexField().setValue(this.getSelectedIndex());
        }

        Ext.form.TriggerField.superclass.onBlur.call(this);
    },

    onFocus : function () {
        Ext.form.TriggerField.superclass.onFocus.call(this);
        
        if (!this.mimicing) {
            this.wrap.addClass("x-trigger-wrap-focus");
            this.mimicing = true;
            Ext.getDoc().on("mousewheel", this.mimicBlur, this, { delay: 10 });
            Ext.getDoc().on("mousedown", this.mimicBlur, this, { delay: 10 });
            
            if (this.monitorTab) {
                this.el.on("keydown", this.checkTab, this);
            }
        }
    },
    
    selectByIndex : function (index, fireSelect) {
        if (index >= 0) {
            this[this.fireSelect ? "setValueAndFireSelect" : "setValue"](this.store.getAt(index).get(this.valueField || this.displayField));
        }
    },
    
    setInitValueByIndex : function (index) {
        if (this.store.getCount() > 0) {
            this.setLoadedIndex(index);
        } else {
            this.store.on("load", this.setLoadedIndex.createDelegate(this, [index]), this, { single : true });
        }
    },

    setLoadedIndex : function (index) {
        this.selectByIndex(index, this.fireSelectOnLoad);
        this.clearInvalid();
    },

    doForce : Ext.emptyFn
});