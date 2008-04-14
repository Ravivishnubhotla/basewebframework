<%@ Page Language="C#" MasterPageFile="~/MasterPage/PageTemplate.Master" AutoEventWireup="true"  Theme="Standard" 
    Codebehind="ListPage.aspx.cs" Inherits="BaseWebManager.Module.FrameWork.SystemApplicationManage.LogEventView.ListPage"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:TextBox ID="txtT1" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ddd">
                <ItemTemplate>
                    <asp:TextBox ID="txtT2" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ddddd">
                <ItemTemplate>
                    <asp:TextBox ID="txtT3" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="wwwww">
                <ItemTemplate>
                    <asp:TextBox ID="txtT4" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        &nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <PowerAspWebUI:GridViewAddRowExtender ID="GridViewAddRowExtender1" runat="server"
            TargetGridViewID="GridView1">
        </PowerAspWebUI:GridViewAddRowExtender>
    
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
