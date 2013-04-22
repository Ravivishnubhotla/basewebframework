<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPCodeLimitSetting.aspx.cs" Inherits="SPSWeb.Moudles.SPS.Codes.SPCodeLimitSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="CheckAllAddUI();"></DocumentReady>
        </Listeners>
    </ext:ResourceManagerProxy>
    <ext:Store ID="storeAreaCountList" runat="server" AutoLoad="true" OnRefreshData="storeAreaCountList_Refresh">
        <Reader>
            <ext:JsonReader>
                <Fields>
                    <ext:RecordField Name="AreaName" />
                    <ext:RecordField Name="LimitCount" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <style type="text/css">
        .cellClass
        {
            padding: 5px;
        }
    </style>
    <script type="text/javascript">
        function CheckDayTimeLimit() {
            var chkIsDayTimeLimit = <%= chkIsDayTimeLimit.ClientID %>;
            var tfDayTimeLimitRangeStart = <%= tfDayTimeLimitRangeStart.ClientID %>;
            var dfDayTimeLimitRangeEnd = <%= dfDayTimeLimitRangeEnd.ClientID %>;
            var tfDayTimeLimitRangeEnd = <%= tfDayTimeLimitRangeEnd.ClientID %>;
            //alert(chkIsDayTimeLimit.getValue());
            if (chkIsDayTimeLimit.getValue()) {
                //alert(chkIsDayTimeLimit.getValue());
                tfDayTimeLimitRangeStart.show();
                dfDayTimeLimitRangeEnd.show();
                tfDayTimeLimitRangeEnd.show();
            } else {
                tfDayTimeLimitRangeStart.hide();
                dfDayTimeLimitRangeEnd.hide();
                tfDayTimeLimitRangeEnd.hide();
            }
        }
        function CheckDayMonthTotalLimit() {
            var chkDayMonthTotalLimit = <%= chkDayMonthTotalLimit.ClientID %>;
            var nfPhoneLimitDayCount = <%= nfPhoneLimitDayCount.ClientID %>;
            var dfPhoneLimitDayCount = <%= dfPhoneLimitDayCount.ClientID %>;
            var nfPhoneLimitMonthCount = <%= nfPhoneLimitMonthCount.ClientID %>;
            //alert(chkLimitProvince.getValue());
            if (chkDayMonthTotalLimit.getValue()) {
                nfPhoneLimitDayCount.show();
                dfPhoneLimitDayCount.show();
                nfPhoneLimitMonthCount.show();
            } else {
                nfPhoneLimitDayCount.hide();
                dfPhoneLimitDayCount.hide();
                nfPhoneLimitMonthCount.hide();
            }
        }
        function CheckDayTotalLimit() {
            var chkDayTotalLimit = <%= chkDayTotalLimit.ClientID %>;
        var nfDayTotalLimit = <%= nfDayTotalLimit.ClientID %>;
        //alert(chkLimitProvince.getValue());
        if (chkDayTotalLimit.getValue()) {
            nfDayTotalLimit.show();
        } else {
            nfDayTotalLimit.hide();
        }
        }
        
        function setAreaCountList() {
            var grdAreaCountList = <%= grdAreaCountList.ClientID %>;
            
                        var hidAreaCountList = <%= hidAreaCountList.ClientID %>;

                        hidAreaCountList.setValue(Ext.encode(grdAreaCountList.getRowsValues(false)));
            
                        //            alert(grdAreaCountList.getRowsValues(false));
                        //            alert(Ext.encode(grdAreaCountList.getRowsValues(false)));
                    }
    function CheckAllAddUI() {
        CheckDayTimeLimit();
        CheckDayMonthTotalLimit();
        CheckDayTotalLimit();
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:FormPanel ID="pnlCode" runat="server" Title="指令设置" Frame="true" PaddingSummary="0"
                ButtonAlign="Center" Layout="Form" AutoScroll="True">
                <Items>
                    <ext:CompositeField ID="cfIsDayTimeLimit" runat="server" FieldLabel="时段限制" AnchorHorizontal="95%">
                        <Items>
                            <ext:Checkbox ID="chkIsDayTimeLimit" runat="server">
                                <Listeners>
                                    <Check Handler="CheckDayTimeLimit();"></Check>
                                </Listeners>
                            </ext:Checkbox>
                            <ext:TimeField ID="tfDayTimeLimitRangeStart" runat="server" MinTime="0:00" Increment="30"
                                Format="H:mm" Width="60" />
                            <ext:DisplayField ID="dfDayTimeLimitRangeEnd" runat="server" Text="-" />
                            <ext:TimeField ID="tfDayTimeLimitRangeEnd" runat="server" MinTime="0:00" Increment="30"
                                Format="H:mm" Width="60" />
                        </Items>
                    </ext:CompositeField>
                    <ext:CompositeField ID="cfDayMonthTotalLimit" runat="server" FieldLabel="号码日月限量"
                        AnchorHorizontal="100%">
                        <Items>
                            <ext:Checkbox ID="chkDayMonthTotalLimit" runat="server">
                                <Listeners>
                                    <Check Handler="CheckDayMonthTotalLimit();"></Check>
                                </Listeners>
                            </ext:Checkbox>
                            <ext:NumberField ID="nfPhoneLimitDayCount" runat="server" Width="60" />
                            <ext:DisplayField ID="dfPhoneLimitDayCount" runat="server" Text="/" />
                            <ext:NumberField ID="nfPhoneLimitMonthCount" runat="server" Width="60" />
                        </Items>
                    </ext:CompositeField>
                    <ext:CompositeField ID="cfDayTotalLimit" runat="server" FieldLabel="日总限量" AnchorHorizontal="100%">
                        <Items>
                            <ext:Checkbox ID="chkDayTotalLimit" runat="server">
                                <Listeners>
                                    <Check Handler="CheckDayTotalLimit();"></Check>
                                </Listeners>
                            </ext:Checkbox>
                            <ext:NumberField ID="nfDayTotalLimit" runat="server" Width="60" />
                        </Items>
                    </ext:CompositeField>
                    <ext:Hidden ID="hidAreaCountList" runat="server" />
                    <ext:FieldSet ID="fsLimitProvince" runat="server" CheckboxToggle="true" Collapsed="True"
                        Title="省份日总限量分配" AutoHeight="true" LabelWidth="75" Layout="Form">
                        <Items>
                            <ext:GridPanel FieldLabel="省份日总限量分布" ID="grdAreaCountList" runat="server" StoreID="storeAreaCountList"
                                StripeRows="true" Header="False" Height="180" Frame="True">
                                <View>
                                    <ext:GridView ForceFit="true" ID="GridView1">
                                        <GetRowClass Handler="" FormatHandler="False"></GetRowClass>
                                    </ext:GridView>
                                </View>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn>
                                        </ext:RowNumbererColumn>
                                        <ext:Column ColumnID="colAreaName" DataIndex="AreaName" Header="省份" Sortable="true">
                                        </ext:Column>
                                        <ext:Column ColumnID="colLimitCount" DataIndex="LimitCount" Header="限量" Sortable="true">
                                            <Editor>
                                                <ext:NumberField ID="NumberField3" runat="server">
                                                </ext:NumberField>
                                            </Editor>
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <LoadMask ShowMask="true" />
                            </ext:GridPanel>
                        </Items>
                    </ext:FieldSet>
                </Items>
                <Buttons>
                    <ext:Button ID="btnSaveSPCode" runat="server" Text="编辑" Icon="ApplicationEdit">
                        <DirectEvents>
                            <Click Before="setAreaCountList();if(!#{pnlCode}.getForm().isValid()) return false;" OnEvent="btnSaveSPCodeLimitSetting_Click"
                                Success="#{pnlCode}.getForm().reset();parent.ShowMessage('操作成功','更新指令限量设置成功！',1);parent.reloadCodes();parent.CloseCodeLimitSetting();"
                                Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                                <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnCancelSPCode" runat="server" Text="取消" Icon="Cancel">
                        <Listeners>
                            <Click Handler="#{pnlCode}.getForm().reset();parent.CloseCodeEdit();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
