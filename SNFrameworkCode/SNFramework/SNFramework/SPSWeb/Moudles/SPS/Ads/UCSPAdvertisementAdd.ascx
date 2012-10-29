<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPAdvertisementAdd.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Ads.UCSPAdvertisementAdd" %>
<ext:Window ID="winSPAdvertisementAdd" runat="server" Icon="ApplicationAdd" Title="添加广告"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPAdvertisementAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100" AutoScroll="true"
            Layout="Form">
            <Items>

                <ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True" AnchorHorizontal="95%" />


                <ext:TextField ID="txtCode" runat="server" FieldLabel="编码" AllowBlank="True" AnchorHorizontal="95%" />


                <ext:TextField ID="txtImageUrl" runat="server" FieldLabel="图片地址" AllowBlank="True" AnchorHorizontal="95%" />


                <ext:TextField ID="txtAdPrice" runat="server" FieldLabel="价格" AllowBlank="True" AnchorHorizontal="95%" />

                <ext:ComboBox ID="cmbAdType" Editable="false" runat="server" FieldLabel="广告类型"
                    DisplayField="Value" ValueField="Key" StoreID="storeDictionaryAdType"
                    AllowBlank="false" SelectedIndex="0" AnchorHorizontal="95%">
                </ext:ComboBox>
                <ext:ComboBox ID="cmbAccountType" Editable="false" runat="server" FieldLabel="结算类型"
                    DisplayField="Value" ValueField="Key" StoreID="storeDictionaryAcountType" AllowBlank="false"
                    SelectedIndex="0" AnchorHorizontal="95%">
                </ext:ComboBox>




                <ext:TextArea ID="txtAdText" runat="server" FieldLabel="广告文本" AllowBlank="True" AnchorHorizontal="95%" />


                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True" AnchorHorizontal="95%" />



            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPAdvertisement" runat="server" Text="添加" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPAdvertisementAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPAdvertisement_Click"
                    Success="Ext.MessageBox.alert('操作成功', 'Add a record success' ,callback);function callback(id) {#{formPanelSPAdvertisementAdd}.getForm().reset();#{storeSPAdvertisement}.reload(); };
"
                    Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPAdvertisement" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPAdvertisementAdd}.getForm().reset();#{winSPAdvertisementAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{storeDictionaryAdType}.reload();#{storeDictionaryAcountType}.reload();"></BeforeShow>
    </Listeners>
</ext:Window>
