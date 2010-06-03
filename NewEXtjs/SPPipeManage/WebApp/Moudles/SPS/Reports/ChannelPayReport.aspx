<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ChannelPayReport.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Reports.ChannelPayReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server" Layout="Fit">
        <items>
<ext:GridPanel 
        ID="GridPanel1"
        runat="server" 
        StripeRows="true"
        Title="Sales By Region" 
  >
        <Store>
            <ext:Store ID="Store1" runat="server">
                <Reader>
                    <ext:ArrayReader />
                </Reader>
            </ext:Store>
        </Store>
        <SelectionModel>
            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
        </SelectionModel>
        <View>
            <ext:GridView ID="GridView1" runat="server" ForceFit="true" />
        </View>
    </ext:GridPanel>          

        </items>
    </ext:Viewport>
</asp:Content>
