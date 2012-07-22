<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientEdit.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.Clients.UCSPClientEdit" %>
<ext:Store ID="storeSPChannelGroup" runat="server" AutoLoad="true" OnRefreshData="storeSPChannelGroup_Refresh">
    <Reader>
        <ext:JsonReader>
            <Fields>
                <ext:RecordField Name="Id" Type="Int" />
                <ext:RecordField Name="Name" />
                <ext:RecordField Name="DefaultInterceptRate" Type="Int" />
            </Fields>
        </ext:JsonReader>
    </Reader>
    <Listeners>
        <Load Handler="if (GetGroupID()!='') {#{cmbClientGroupID}.setValue(GetGroupID());} #{formPanelSPClientEdit}.setDisabled(false);ShowInterceptSetting();" />
    </Listeners>
</ext:Store>
<script type="text/javascript">
    function GetGroupID() {
        var hidClientGroupID = <%=  hidClientGroupID.ClientID %>;
        if(hidClientGroupID==null)
            return '';
        return hidClientGroupID.getValue();
    }

    function checkChange() {
        var rgdCustomIntercept = <%= rgdCustomIntercept.ClientID %>;
        var numCustomerIntercept = <%= numCustomerIntercept.ClientID %>;
        if(rgdCustomIntercept.getValue()) {
            numCustomerIntercept.setDisabled(false);
        } else {
            numCustomerIntercept.setDisabled(true);
        }
    }

    function setIntercept(data) {
        //alert(interceptvalue);
        setBoxLable(<%= lblDefaultClientIntercept.ClientID %>, data);
    }

    function setBoxLable(radioID,data) {
        //alert(radioID);
        radioID.setText('下家“' + data.Name + '”默认扣率(' + data.DefaultInterceptRate.toString() + ')');
        //document.getElementById(Ext.getCmp(radioID).container.up('div.x-form-item').id).childNodes[1].childNodes[0].childNodes[1].innerHTML = text;
    }

    function ShowInterceptSetting() {
        var cmbClientGroupID = <%= cmbClientGroupID.ClientID %>;
        cmbClientGroupID.getValue();
        var formPanel1 = <%= formPanel1.ClientID %>;
        if(cmbClientGroupID.getValue()!=GetGroupID()) {
            formPanel1.show(); 
        } else {
            formPanel1.hide();
        }
    }

</script>
<ext:Window ID="winSPClientEdit" runat="server" Icon="ApplicationEdit" Title="编辑下家"
    ConstrainHeader="true" Width="600" Height="390" AutoShow="false" Maximizable="true"
    Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPClientEdit" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPClient" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidId" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidUserID" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtAlias" runat="server" FieldLabel="下家显示名" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbClientGroupID" runat="server" FieldLabel="下家组" AllowBlank="True"
                                    StoreID="storeSPChannelGroup" TypeAhead="true" Mode="Local" Editable="True" ForceSelection="True"
                                    TriggerAction="All" DisplayField="Name" ValueField="Id" EmptyText="请选择下家组">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();setIntercept(record.data);ShowInterceptSetting();checkChange();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();ShowInterceptSetting(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:FormPanel ID="formPanel1" runat="server" Frame="true" Hidden="True" Header="false">
                                    <Body>
                                        <ext:FormLayout ID="FormLayout1" runat="server" LabelSeparator=":" LabelWidth="100">
                                            <Anchors>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:MultiField FieldLabel="选择扣率" runat="server">
                                                        <Fields>
                                                            <ext:Radio ID="rgdDefaultChannelIntercept" GroupName="rgIntercept" Checked="true" runat="server">
                                                                <Listeners>
                                                                    <Check Handler="checkChange();"></Check>
                                                                </Listeners>
                                                            </ext:Radio>
                                                            <ext:Label ID="lblDefaultChannelIntercept" runat="server" Text="通道默认扣率">
                                                            </ext:Label>
                                                        </Fields>
                                                    </ext:MultiField>
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:MultiField ID="MultiField1" FieldLabel="" runat="server">
                                                        <Fields>
                                                            <ext:Radio ID="rgdDefaultClientIntercept" runat="server" GroupName="rgIntercept"
                                                                >
                                                                <Listeners>
                                                                    <Check Handler="checkChange();"></Check>
                                                                </Listeners>
                                                            </ext:Radio>
                                                            <ext:Label ID="lblDefaultClientIntercept" runat="server" Text="下家默认扣率">
                                                            </ext:Label>
                                                        </Fields>
                                                    </ext:MultiField>
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:MultiField ID="MultiField2" FieldLabel="" runat="server">
                                                        <Fields>
                                                            <ext:Radio ID="rgdCustomIntercept" runat="server" GroupName="rgIntercept">
                                                                <Listeners>
                                                                    <Check Handler="checkChange();"></Check>
                                                                </Listeners>
                                                            </ext:Radio>
                                                            <ext:Label ID="Label2" runat="server" Text="自定义扣率">
                                                            </ext:Label>
                                                        </Fields>
                                                    </ext:MultiField>
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:NumberField ID="numCustomerIntercept" FieldLabel="自定义扣率" runat="server" AllowDecimals="true"
                                                        DecimalPrecision="0" Text="15" Disabled="True">
                                                    </ext:NumberField>
                                                </ext:Anchor>
                                            </Anchors>
                                        </ext:FormLayout>
                                    </Body>
                                </ext:FormPanel>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="numPrice" FieldLabel="通道价格" runat="server" AllowDecimals="true"
                                    DecimalPrecision="2">
                                </ext:NumberField>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidClientGroupID" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPClient" runat="server" Text="编辑" Icon="ApplicationEdit">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPClientEdit}.getForm().isValid()) return false;" OnEvent="btnSaveSPClient_Click"
                    Success="#{formPanelSPClientEdit}.getForm().reset();Ext.MessageBox.alert('操作成功', '成功的编辑了下家。',callback);function callback(id) { #{storeSPClient}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClient" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPClientEdit}.hide();#{formPanelSPClientEdit}.getForm().reset();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <Show Handler="#{formPanelSPClientEdit}.setDisabled(true);#{storeSPChannelGroup}.reload();" />
        <BeforeClose Handler="#{formPanelSPClientEdit}.getForm().reset();"></BeforeClose>
    </Listeners>
</ext:Window>
