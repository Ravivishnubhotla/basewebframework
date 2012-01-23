<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPSDataManage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Data.SPSDataManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server" Layout="Fit">
        <Items>
            <ext:TabPanel ID="TabPanel1" runat="server" ActiveTabIndex="0" Title="系统数据管理" Frame="True">
                <Items>
                    <ext:FormPanel ID="fpnl1" runat="server" Title="日报表数据生成" Frame="True" AutoScroll="true">
                        <Items>
                            <ext:CompositeField ID="cmReportDataRange" runat="server" LabelWidth="350" FieldLabel="生成报表日期段">
                                <Items>
                                    <ext:DateField ID="dfStart" runat="server" AllowBlank="False" />
                                    <ext:DateField ID="dfEnd" runat="server"  AllowBlank="False" />
                                    <ext:Button ID="btnGeneReport" runat="server" Text="生成">
                                        <DirectEvents>
                                            <Click Before="if(!#{fpnl1}.getForm().isValid()) return false;"
                                                OnEvent="btnGeneReportl_Click" Success="Ext.MessageBox.alert('操作成功', '生成报表成功!',callback);function callback(id) {#{fpnl1}.getForm().reset(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                                                <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>
                            </ext:CompositeField>
                        </Items>
                    </ext:FormPanel>
                    <ext:FormPanel ID="fpnl2" runat="server" Title="补发数据导入" AutoScroll="true">
                    </ext:FormPanel>
                    <ext:FormPanel ID="fpnl3" runat="server" Title="号码批量查询" AutoScroll="true">
                    </ext:FormPanel>
                    <ext:FormPanel ID="fpnl4" runat="server" Title="LinkID比对" AutoScroll="true">
                    </ext:FormPanel>
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
