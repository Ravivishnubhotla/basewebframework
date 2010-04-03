<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemLogEdit.ascx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.LogManage.UCSystemLogEdit" %>
<ext:Window ID="winSystemLogEdit" runat="server" Icon="ApplicationEdit" Title="编辑SystemLog"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemLogEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidLogID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
						<ext:TextField ID="txtLogLevel" runat="server" FieldLabel="LogLevel" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtLogType" runat="server" FieldLabel="LogType" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtLogDate" runat="server" FieldLabel="LogDate" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtLogSource" runat="server" FieldLabel="LogSource" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtLogUser" runat="server" FieldLabel="LogUser" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtLogDescrption" runat="server" FieldLabel="LogDescrption" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtLogRequestInfo" runat="server" FieldLabel="LogRequestInfo" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtLogRelateMoudleID" runat="server" FieldLabel="LogRelateMoudleID" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtLogRelateMoudleDataID" runat="server" FieldLabel="LogRelateMoudleDataID" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtLogRelateUserID" runat="server" FieldLabel="LogRelateUserID" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtLogRelateDateTime" runat="server" FieldLabel="LogRelateDateTime" AllowBlank="True"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemLog" runat="server" Text="编辑" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemLogEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemLog_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了SystemLog。',callback);function callback(id) {#{formPanelSystemLogEdit}.getForm().reset();#{storeSystemLog}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemLog" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemLogEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>



