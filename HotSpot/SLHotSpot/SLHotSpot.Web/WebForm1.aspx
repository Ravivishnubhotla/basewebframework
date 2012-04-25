﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SLHotSpot.Web.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" type="text/css" href="Scripts/EasyUI/themes/gray/easyui.css" />
    <link rel="stylesheet" type="text/css" href="Scripts/EasyUI/themes/icon.css" />
     <script type="text/javascript" src="Scripts/JQuery/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="Scripts/EasyUI/jquery.easyui.min.js"></script>
 	<script>
 	    $(function () {
 	        $('#test').datagrid({
 	            title: 'My DataGrid',
 	            iconCls: 'icon-save',
 	            width: 700,
 	            height: 350,
 	            nowrap: false,
 	            striped: true,
 	            collapsible: true,
 	            url: 'datagrid_data.json',
 	            sortName: 'code',
 	            sortOrder: 'desc',
 	            remoteSort: false,
 	            idField: 'code',
 	            frozenColumns: [[
	                { field: 'ck', checkbox: true },
	                { title: 'code', field: 'code', width: 80, sortable: true }
				]],
 	            columns: [[
			        { title: 'Base Information', colspan: 3 },
					{ field: 'opt', title: 'Operation', width: 100, align: 'center', rowspan: 2,
					    formatter: function (value, rec) {
					        return '<span style="color:red">Edit Delete</span>';
					    }
					}
				], [
					{ field: 'name', title: 'Name', width: 120 },
					{ field: 'addr', title: 'Address', width: 220, rowspan: 2, sortable: true,
					    sorter: function (a, b) {
					        return (a > b ? 1 : -1);
					    }
					},
					{ field: 'col4', title: 'Col41', width: 150, rowspan: 2 }
				]],
 	            pagination: true,
 	            rownumbers: true,
 	            toolbar: [{
 	                id: 'btnadd',
 	                text: 'Add',
 	                iconCls: 'icon-add',
 	                handler: function () {
 	                    $('#btnsave').linkbutton('enable');
 	                    alert('add')
 	                }
 	            }, {
 	                id: 'btncut',
 	                text: 'Cut',
 	                iconCls: 'icon-cut',
 	                handler: function () {
 	                    $('#btnsave').linkbutton('enable');
 	                    alert('cut')
 	                }
 	            }, '-', {
 	                id: 'btnsave',
 	                text: 'Save',
 	                disabled: true,
 	                iconCls: 'icon-save',
 	                handler: function () {
 	                    $('#btnsave').linkbutton('disable');
 	                    alert('save')
 	                }
 	            }]
 	        });
 	        var p = $('#test').datagrid('getPager');
 	        $(p).pagination({
 	            onBeforeRefresh: function () {
 	                alert('before refresh');
 	            }
 	        });
 	    });
 	    function resize() {
 	        $('#test').datagrid('resize', {
 	            width: 700,
 	            height: 400
 	        });
 	    }
 	    function getSelected() {
 	        var selected = $('#test').datagrid('getSelected');
 	        if (selected) {
 	            alert(selected.code + ":" + selected.name + ":" + selected.addr + ":" + selected.col4);
 	        }
 	    }
 	    function getSelections() {
 	        var ids = [];
 	        var rows = $('#test').datagrid('getSelections');
 	        for (var i = 0; i < rows.length; i++) {
 	            ids.push(rows[i].code);
 	        }
 	        alert(ids.join(':'));
 	    }
 	    function clearSelections() {
 	        $('#test').datagrid('clearSelections');
 	    }
 	    function selectRow() {
 	        $('#test').datagrid('selectRow', 2);
 	    }
 	    function selectRecord() {
 	        $('#test').datagrid('selectRecord', '002');
 	    }
 	    function unselectRow() {
 	        $('#test').datagrid('unselectRow', 2);
 	    }
 	    function mergeCells() {
 	        $('#test').datagrid('mergeCells', {
 	            index: 2,
 	            field: 'addr',
 	            rowspan: 2,
 	            colspan: 2
 	        });
 	    }
	</script>
</head>
<body>
    <form id="form1" runat="server">
 
    </form>
    
	<h2>Complex DataGrid</h2>
	<div class="demo-info">
		<div class="demo-tip icon-tip"></div>
		<div>Click the button to do actions with datagrid.</div>
	</div>
	
	<div style="margin:10px 0;">
		<a href="#" onclick="getSelected()">GetSelected</a>
		<a href="#" onclick="getSelections()">GetSelections</a>
		<a href="#" onclick="selectRow()">SelectRow</a>
		<a href="#" onclick="selectRecord()">SelectRecord</a>
		<a href="#" onclick="unselectRow()">UnselectRow</a>
		<a href="#" onclick="clearSelections()">ClearSelections</a>
		<a href="#" onclick="resize()">Resize</a>
		<a href="#" onclick="mergeCells()">MergeCells</a>
	</div>
	
	<table id="test"></table>
</body>
</html>
