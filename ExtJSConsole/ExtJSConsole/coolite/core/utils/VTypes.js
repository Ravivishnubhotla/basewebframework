
// @source core/utils/VTypes.js

Ext.apply(Ext.form.VTypes, {
    daterange : function (val, field) {
        var date = field.parseDate(val),
            dispUpd = function (picker) {
                var ad = picker.activeDate;
                
                if (ad) {
                    picker.activeDate = null;
                    picker.update(ad);
                }
            };

        if (field.startDateField) {
            var sd = Ext.getCmp(field.startDateField);
            
            sd.maxValue = date;
            
            if (sd.menu && sd.menu.picker) {
                sd.menu.picker.maxDate = date;
                dispUpd(sd.menu.picker);
            }
        } else if (field.endDateField) {
            var ed = Ext.getCmp(field.endDateField);
            
            ed.minValue = date;
            
            if (ed.menu && ed.menu.picker) {
                ed.menu.picker.minDate = date;
                dispUpd(ed.menu.picker);
            }
        }
        return true;
    }
});