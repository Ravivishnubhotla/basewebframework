
// @source core/init/End.js

var buf = [];

if (!Ext.isIE6) {
    if (Ext.isIE) {
        buf.push(".x-btn button{width:100%;}");
    }
    
    buf.push(".x-form-radio-group .x-panel-body,.x-form-check-group .x-panel-body{background-color:transparent;} .x-form-cb-label-nowrap{white-space:nowrap;} .x-label-icon{width:16px;height:16px; margin-left:3px; margin-right:3px; vertical-align:middle;border:0px !important;} .x-label-value{vertical-align:middle;}");
}

if (Ext.isIE8) {
    buf.push(".ext-ie8 .x-form-text{margin: 0px 0px;}");
}    

if (Ext.isIE7) {
    buf.push(".ext-ie7 .x-form-text, .ext-ie7 .x-form-file {height:18px;line-height:18px;margin: 0px 0px;vertical-align:middle;}");    
}

if (Ext.isIE6) {
    buf.push(".ext-ie6 .x-form-text, .ext-ie6 .x-form-file {height:18px;line-height:18px;margin: 0px 0px;vertical-align:middle;}");
}

buf.push(".x-tree-node .x-tree-node-inline-icon{background:transparent;height:16px !important;} .ext-ie .x-small-editor .x-form-trigger{top:-1px;} .ext-ie .x-small-editor .x-form-text{top: 0px;} .x-field-note { clear: both; font-size: 12px; color: gray;} .x-field-multi { float: left; padding-right: 3px; position: relative;} .x-inline-toolbar{padding:0px !important; border:0px !important; background: none !important;}");

Ext.util.CSS.createStyleSheet(buf.join(""));

Coolite.Ext.setTheme = function (url) {
    Ext.util.CSS.swapStyleSheet("ext-theme", url);
};

if (typeof Sys !== "undefined") { 
    Sys.Application.notifyScriptLoaded();
}