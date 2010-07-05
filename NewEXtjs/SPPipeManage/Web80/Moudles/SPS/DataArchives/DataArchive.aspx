﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="DataArchive.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.DataArchives.DataArchive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:FormPanel ID="FormPanel1" runat="server" Frame="true" Title="归档操作">
                        <Body>
                            <ext:FormLayout ID="FormLayout1" runat="server">
                                <ext:Anchor>
                                    <ext:MultiField ID="MultiField1" runat="server" FieldLabel="数据库空间占用">
                                        <Fields>
                                            <ext:ProgressBar ID="prgData" runat="server" Width="300" Text="10.00MB 10%" Value="0.1">
                                            </ext:ProgressBar>
                                        </Fields>
                                    </ext:MultiField>
                                </ext:Anchor>
                                <ext:Anchor>
                                    <ext:MultiField ID="MultiField2" runat="server" FieldLabel="归档数据">
                                        <Fields>
                                            <ext:Label ID="lblStart" runat="server" Text="开始时间：" />
                                            <ext:DateField ID="dfStart" runat="server" />
                                            <ext:Label ID="Label4" runat="server" Text="结束时间：" />
                                            <ext:DateField ID="dfEnd" runat="server" />
                                            <ext:Button ID="btnArchive" runat="server" Text="开始归档操作">
                                                <AjaxEvents>
                                                    <Click OnEvent="StartLongAction"  Success="Ext.MessageBox.alert('操作成功', '成功的归档了数据.',callback);function callback(id) {};">
                                                        <EventMask ShowMask="true" Msg="处理中..." />
                                                        <Confirmation ConfirmRequest="true" Message="确认进行数据归档操作？" Title="确认操作" />
                                                    </Click>
                                                </AjaxEvents>
                                            </ext:Button>
                                        </Fields>
                                    </ext:MultiField>
                                </ext:Anchor>
                            </ext:FormLayout>
                        </Body>
                    </ext:FormPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>