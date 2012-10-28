<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPAdPackEdit.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Ads.UCSPAdPackEdit" %>
<ext:Window ID="winSPAdPackEdit" runat="server" Icon="ApplicationEdit" Title="编辑广告包"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPAdPackEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" AutoScroll="true"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
 
			
						<ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtCode" runat="server" FieldLabel="编码" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSPAdPack" runat="server" Text="编辑" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPAdPackEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPAdPack_Click" Success="Ext.MessageBox.alert('Operation successful', 'Update a record success',callback);function callback(id) {#{formPanelSPAdPackEdit}.getForm().reset();#{storeSPAdPack}.reload(); };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPAdPack" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPAdPackEdit}.getForm().reset();#{winSPAdPackEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>


