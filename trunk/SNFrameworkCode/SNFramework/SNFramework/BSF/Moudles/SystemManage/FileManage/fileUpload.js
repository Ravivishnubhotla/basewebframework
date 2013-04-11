/// <reference name="Ext.Net.Build.Ext.Net.extjs.adapter.ext.ext-base.js" assembly="Ext.Net" />
/// <reference name="Ext.Net.Build.Ext.Net.extjs.adapter.ext.ext-base-debug.js" assembly="Ext.Net" />
/// <reference name="Ext.Net.Build.Ext.Net.extjs.ext-all-debug.js" assembly="Ext.Net" />
/// <reference name="Ext.Net.Build.Ext.Net.extjs.ext-all.js" assembly="Ext.Net" />

//删除动作
function gpFlilesDelete(cmd, record, rowIndex) {
    if (cmd === 'delete') {
        storeFiles.remove(record);//移除record
    }
}
//Store中移除了数据
function storeFilesRemoveEvent(store, record, rowIndex) {
    var recordCount = store.getCount();
    if (recordCount < 1) {
        gpFiles.hide();
    }
    //调用后端Direct方法删除文件
    Ext.net.DirectMethods.DeleteFile(record.data.FilePath, record.data.FileName);
}
//Store中添加了数据
function storeFilesAddEvent(store, record, rowIndex) {
    gpFiles.show();
}

//换算文件大小
function renderSize(value, p, record) {
    if (null == value || value == '') {
        return "0 Bytes";
    }
    var unitArr = new Array("Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB");
    var index = 0;

    var srcsize = parseFloat(value);
    var quotient = srcsize;
    while (quotient > 1024) {
        index += 1;
        quotient = quotient / 1024;
    }
    return roundFun(quotient, 2) + " " + unitArr[index];
}

/*
四舍五入保留小数位数
numberRound 被处理的数
roundDigit  保留几位小数位
*/
function roundFun(numberRound, roundDigit) {
    if (numberRound >= 0) {
        var tempNumber = parseInt((numberRound * Math.pow(10, roundDigit) + 0.5)) / Math.pow(10, roundDigit);
        return tempNumber;
    } else {
        numberRound1 = -numberRound
        var tempNumber = parseInt((numberRound1 * Math.pow(10, roundDigit) + 0.5)) / Math.pow(10, roundDigit);
        return -tempNumber;
    }
}