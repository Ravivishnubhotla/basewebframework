/// <reference name="Ext.Net.Build.Ext.Net.extjs.adapter.ext.ext-base.js" assembly="Ext.Net" />
/// <reference name="Ext.Net.Build.Ext.Net.extjs.adapter.ext.ext-base-debug.js" assembly="Ext.Net" />
/// <reference name="Ext.Net.Build.Ext.Net.extjs.ext-all-debug.js" assembly="Ext.Net" />
/// <reference name="Ext.Net.Build.Ext.Net.extjs.ext-all.js" assembly="Ext.Net" />

function swfupload_preload_function() {
    if (!this.support.loading) {
        Ext.MessageBox.alert("温馨提示", "您的Flash版本过低(支持9.028及更高版本),<br/>请<a href='http://www.adobe.com' target='_blank'>点击此处</a>下载最新版Flash.");
        //alert("You need the Flash Player 9.028 or above to use SWFUpload.");
        return false;
    }
}
//加载失败
function swfupload_load_failed_function() {
    var t = this;
}
//加载后
function swfupload_loaded_function() {
    var t = this;
}

function mouse_click_function() {
    var t = this;
}
function mouse_over_function() {
    var t = this;
}
function mouse_out_function() {
    var t = this;
}
function file_dialog_start_function() {
    var t = this;
}
function file_queued_function(file) {
    var t = this;
}
//文件队列错
function file_queue_error_function(file, errorCode, message) {
    var t = this;
}
//文件上传完成
function file_dialog_complete_function(fileSelectedCount, numberOfFilesQueued, totalNumberOfFilesInTheQueued) {
    if (fileSelectedCount > 0) {
        swfu.startUpload();//如果队列中还有未上传文件，则继续，若没有，一次只能上传一个文件
    }
}
//开始上传
function upload_start_function(file) {
    pbar.show();
    btnCancelFileUpload.show();
}
//更新进度条
function upload_progress_function(file, completeBytes, totalBytes) {
    var percent = Math.ceil((completeBytes / totalBytes) * 100);
    pbar.updateProgress(percent / 100, file.name + ":" + percent + "%");
}
function upload_error_function(file, errorCode, message) {
    var t = this;
}
//上传成功
function upload_success_function(file, data, received) {
    if (received) {
        var TopicRecord = Ext.data.Record.create([
        { name: 'ID', type: 'string' },
        { name: 'FileName', type: 'string' },
        { name: 'FileSize', type: 'int' },
        { name: 'FileExtension', type: 'string' },
        { name: 'FileCreationDate', type: 'date' },
        { name: 'FileModificationDate', type: 'date' },
        { name: 'FilePath', type: 'string' },
        { name: 'FileIndex', type: 'int' },
        { name: 'FileId', tyep: 'int' }
        ]);
        var myNewRecord = new TopicRecord({
            ID: file.id,
            FileName: file.name,
            FileSize: file.size,
            FileExtension: file.type,
            FileCreationDate: file.creationdate,
            FileModificationDate: file.modificationdate,
            FilePath: data,
            FileIndex: file.index,
            FileId: file.index
        });
        storeFiles.add(myNewRecord);//向Store中添加一行数据
    }
}
//全部上传完成
function upload_complete_function(file) {
    btnCancelFileUpload.hide();
    pbar.reset();
    pbar.updateText("");
    pbar.hide();
    swfu.startUpload();
}
function debug_function() {
    var t = this;
}

function CancelFileUpload() {
    var s = swfu;
    swfu.cancelUpload();
}