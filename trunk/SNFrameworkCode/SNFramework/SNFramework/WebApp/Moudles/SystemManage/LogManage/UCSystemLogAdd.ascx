<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemLogAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.LogManage.UCSystemLogAdd" %>
<ext:Window ID="winSystemLogAdd" runat="server" Icon="ApplicationAdd" Title="New SystemLog"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemLogAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            Layout="Form">
            <Items>
			
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
        <ext:Button ID="btnSavelSystemLog" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemLogAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSystemLog_Click"
                    Success="Ext.MessageBox.alert('Operation successful', 'Success Added SystemLog。',callback);function callback(id) {#{formPanelSystemLogAdd}.getForm().reset();#{storeSystemLog}.reload(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemLog" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemLogAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>


