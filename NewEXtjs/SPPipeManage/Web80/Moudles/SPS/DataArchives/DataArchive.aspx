<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="DataArchive.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.DataArchives.DataArchive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:FormPanel ID="FormPanel1" runat="server"  Frame="true" Title="归档操作">
                        <Body>
                            <ext:FormLayout ID="FormLayout1" runat="server">
                                <ext:Anchor>
                                    <ext:MultiField ID="MultiField1" runat="server" FieldLabel="数据库空间占用">
                                        <Fields>
                                            <ext:ProgressBar ID="Progress1" runat="server" Width="200" Text="10.00MB 10%" Value="0.1">
                                            </ext:ProgressBar>
                                        </Fields>
                                    </ext:MultiField>
                                </ext:Anchor>
                                <ext:Anchor>
                                    <ext:MultiField ID="MultiField2" runat="server" FieldLabel="归档数据">
                                        <Fields>
                                            <ext:Label ID="lblStart" runat="server" Text="开始时间："  />
                                            <ext:DateField ID="dfStart" runat="server" />
                                            <ext:Label ID="Label4" runat="server" Text="结束时间："  />
                                            <ext:DateField ID="dfEnd" runat="server" />
                                            <ext:Button ID="btnArchive" runat="server" Text="开始归档操作" />
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
