<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Legendigital.Common.WebApp.TestPage.WebForm3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
    </ext:ResourceManager>
<ext:FormPanel 
            ID="Panel2" 
            runat="server"
            Title="Simple Form with FieldSets"
            PaddingSummary="5px 5px 0"
            Width="350"
            Frame="true"
            ButtonAlign="Center" MonitorValid="true" >
            <Items>
                <ext:FieldSet 
                    runat="server"
                    CheckboxToggle="true"
                    Title="User Information"
                    AutoHeight="true"
                    Collapsed="false"
                    LabelWidth="75"
                    Layout="Form">
                    <Items>
                        <ext:TextField runat="server" FieldLabel="First Name" AllowBlank="false" AnchorHorizontal="100%" />
                        <ext:TextField runat="server" FieldLabel="Last Name" AllowBlank="false" AnchorHorizontal="100%" />
                        <ext:TextField runat="server" FieldLabel="Company" AnchorHorizontal="100%" />
                        <ext:TextField runat="server" FieldLabel="Email" AnchorHorizontal="100%" />
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet
                    runat="server"
                    CheckboxToggle="true"
                    Title="Phone Number"
                    AutoHeight="true"
                    LabelWidth="75"
                    Layout="Form">
                    <Items>
                        <ext:TextField runat="server" FieldLabel="Home" Text="(888) 555-1212" AnchorHorizontal="100%" />
                        <ext:TextField runat="server" FieldLabel="Business" AnchorHorizontal="100%" />
                        <ext:TextField runat="server" FieldLabel="Mobile" AnchorHorizontal="100%" />
                        <ext:TextField runat="server" FieldLabel="Fax" AnchorHorizontal="100%" />
                    </Items>
                </ext:FieldSet>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Save" />
                <ext:Button runat="server" Text="Cancel" />
            </Buttons>
        </ext:FormPanel>



                <ext:MultiCombo ID="MultiCombo2" runat="server" SelectionMode="Selection" Width="260">
            <Items>
                <ext:ListItem Text="Item 1" Value="1" />
                <ext:ListItem Text="Item 2" Value="2" />
                <ext:ListItem Text="Item 3" Value="3" />
                <ext:ListItem Text="Item 4" Value="4" />
                <ext:ListItem Text="Item 5" Value="5" />
                                <ext:ListItem Text="Item 1" Value="1" />
                <ext:ListItem Text="Item 2" Value="2" />
                <ext:ListItem Text="Item 3" Value="3" />
                <ext:ListItem Text="Item 4" Value="4" />
                <ext:ListItem Text="Item 5" Value="5" />
                                <ext:ListItem Text="Item 1" Value="1" />
                <ext:ListItem Text="Item 2" Value="2" />
                <ext:ListItem Text="Item 3" Value="3" />
                <ext:ListItem Text="Item 4" Value="4" />
                <ext:ListItem Text="Item 5" Value="5" />
                                <ext:ListItem Text="Item 1" Value="1" />
                <ext:ListItem Text="Item 2" Value="2" />
                <ext:ListItem Text="Item 3" Value="3" />
                <ext:ListItem Text="Item 4" Value="4" />
                <ext:ListItem Text="Item 5" Value="5" />
                                <ext:ListItem Text="Item 1" Value="1" />
                <ext:ListItem Text="Item 2" Value="2" />
                <ext:ListItem Text="Item 3" Value="3" />
                <ext:ListItem Text="Item 4" Value="4" />
                <ext:ListItem Text="Item 5" Value="5" />
                                <ext:ListItem Text="Item 1" Value="1" />
                <ext:ListItem Text="Item 2" Value="2" />
                <ext:ListItem Text="Item 3" Value="3" />
                <ext:ListItem Text="Item 4" Value="4" />
                <ext:ListItem Text="Item 5" Value="5" />
            </Items>
            
            <SelectedItems>
 
            </SelectedItems>
        </ext:MultiCombo>
    </form>
</body>
</html>
