/// <reference name="Ext.Net.Build.Ext.Net.extjs.adapter.ext.ext-base.js" assembly="Ext.Net" />
/// <reference name="Ext.Net.Build.Ext.Net.extjs.adapter.ext.ext-base-debug.js" assembly="Ext.Net" />
/// <reference name="Ext.Net.Build.Ext.Net.extjs.ext-all-debug.js" assembly="Ext.Net" />
/// <reference name="Ext.Net.Build.Ext.Net.extjs.ext-all.js" assembly="Ext.Net" />

var swfu; //全局变量

//获取初始化设置项
function getSettings() {
    return settings = {//此处所有的配置项在SWF说明文档中有，详见本项目中SWFUpload Document.html
        upload_url: "FileUpload.ashx",
        flash_url: "swfupload/swfupload.swf",
        flash9_url: "swfupload/swfupload_fp9.swf",

        file_post_name: "Filedata",
        use_query_string: false,
        requeue_on_error: false,
        http_success: [201, 202],
        assume_success_timeout: 0,
        file_types: "*.*",
        file_types_description: "所有文件",
        file_size_limit: "10 GB",
        file_upload_limit: 0,
        file_queue_limit: 0,

        debug: false,

        //Added in v2.2.0 This boolean setting indicates whether a random value should be added to the Flash 
        //URL in an attempt to prevent the browser from caching the SWF movie. This works around a bug in some IE-engine based browsers.
        //Note: The algorithm for adding the random number to the URL is dumb and cannot handle URLs that already have some parameters.
        prevent_swf_caching: true,
        //A boolean value that indicates whether SWFUpload should attempt to convert relative URLs used by the Flash Player to absolute URLs. 
        //If set to true SWFUpload will not modify any URLs. The default value is false.
        preserve_relative_urls: false,


        //按钮部分
        button_placeholder_id: btnUploadButtonID, //上传按钮所占用的区域
        button_image_url: "/images/XPButtonNoText_61x22.png", //上传按钮图片效果
        button_width: 77, //上传按钮宽
        button_height: 21, //上传按钮高
        button_text: "添加附件",
        button_text_left_padding: 10,
        button_text_top_padding: 1,
        button_action: SWFUpload.BUTTON_ACTION.SELECT_FILES,
        button_disabled: false,
        button_cursor: SWFUpload.CURSOR.HAND,
        button_window_mode: SWFUpload.WINDOW_MODE.TRANSPARENT,

        //以下是SWFUpload的事件，详见说明文档
        swfupload_preload_handler: swfupload_preload_function,
        swfupload_load_failed_handler: swfupload_load_failed_function,
        file_queue_error_handler: file_queue_error_function,
        file_dialog_complete_handler: file_dialog_complete_function,
        upload_progress_handler: upload_progress_function,
        upload_error_handler: upload_error_function,
        upload_success_handler: upload_success_function,
        upload_complete_handler: upload_complete_function,

        swfupload_loaded_handler: swfupload_loaded_function,
        mouse_click_handler: mouse_click_function,
        mouse_over_handler: mouse_over_function,
        mouse_out_handler: mouse_out_function,
        file_dialog_start_handler: file_dialog_start_function,
        file_queued_handler: file_queued_function,
        upload_start_handler: upload_start_function,
        debug_handler: debug_function
    };
}

function InitSwf() {
    if (swfu) {//初次需要销毁，不这么做会有BUG，忘了是什么，可以试试看
        swfu.destroy();
    }
    swfu = new SWFUpload(getSettings()); //初始化SWFUpload对象
}