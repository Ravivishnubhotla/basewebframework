<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPAdvertisementEdit.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Ads.UCSPAdvertisementEdit" %>
<ext:Window ID="winSPAdvertisementEdit" runat="server" Icon="ApplicationEdit" Title="编辑广告"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPAdvertisementEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" AutoScroll="true"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
						<ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtCode" runat="server" FieldLabel="编码" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtImageUrl" runat="server" FieldLabel="图片地址" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtAdPrice" runat="server" FieldLabel="价格" AllowBlank="True"  AnchorHorizontal="95%" />
              
                <ext:ComboBox ID="cmbAdType" Editable="false" runat="server" FieldLabel="广告类型"
                    DisplayField="Value" ValueField="Key" StoreID="storeDictionaryAdType"
                    AllowBlank="false" SelectedIndex="0" AnchorHorizontal="95%">
                </ext:ComboBox>
                <ext:ComboBox ID="cmbAccountType" Editable="false" runat="server" FieldLabel="结算类型"
                    DisplayField="Value" ValueField="Key" StoreID="storeDictionaryAcountType" AllowBlank="false"
                    SelectedIndex="0" AnchorHorizontal="95%">
                </ext:ComboBox>

					
						<ext:TextArea ID="txtAdText" runat="server" FieldLabel="广告文本" AllowBlank="True"  AnchorHorizontal="95%"/>
                   
					
						<ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True"  AnchorHorizontal="95%"/>
                   
					              
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSPAdvertisement" runat="server" Text="编辑" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPAdvertisementEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPAdvertisement_Click" Success="Ext.MessageBox.alert('Operation successful', 'Update a record success',callback);function callback(id) {#{formPanelSPAdvertisementEdit}.getForm().reset();#{storeSPAdvertisement}.reload(); };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPAdvertisement" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPAdvertisementEdit}.getForm().reset();#{winSPAdvertisementEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
        <Listeners>
        <BeforeShow Handler="#{storeDictionaryAdType}.reload();#{storeDictionaryAcountType}.reload();"></BeforeShow>
    </Listeners>
</ext:Window>