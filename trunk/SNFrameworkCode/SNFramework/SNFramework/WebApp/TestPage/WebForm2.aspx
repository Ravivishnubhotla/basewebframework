<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="WebForm2.aspx.cs" Inherits="Legendigital.Common.WebApp.TestPage.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder1" runat="server" Mode="ScriptFiles">
    </ext:ResourcePlaceHolder>
    <script type="text/javascript">
        Ext.override(Ext.form.Field, 
            { markDirty: function () {
                if (this.isDirty() && this.originalValue != this.getValue()) {
                    if (!this.dirtyIcon) {
                        var elp = this.el.parent('.x-form-element');
                        this.dirtyIcon = elp.createChild({ cls: 'x-grid3-dirty-cell' });
                        if (Ext.isIE) { this.dirtyIcon.position("absolute", 0, -5, 0); }
                        else { this.dirtyIcon.position("absolute", 0, 0, 0); }
                        this.dirtyIcon.setSize(5, 5);
                    }
                    this.alignDirtyIcon();
                    this.dirtyIcon.show();
                    this.on('resize', this.alignDirtyIcon, this);
                }
                else { if (this.dirtyIcon) { this.dirtyIcon.hide(); } } 
            },
            initEvents: Ext.form.Field.prototype.initEvents.createSequence(function () {
                this.el.on("change", this.markDirty, this);
                this.on("change", this.markDirty, this);
            }),
            alignDirtyIcon: function () { this.dirtyIcon.alignTo(this.el, 'tl', [0, 0]); } 
        });
        Ext.override(Ext.form.BasicForm, 
            { clearDirty: function () { this.callFieldMethod("markDirty"); } });     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <ext:FormPanel ID="FormPanel1" runat="server" Width="400" Height="300" Title="Form">
        <Items>
            <ext:TextField ID="TextField1" runat="server" />
            <ext:TextField ID="TextField2" runat="server" />
            <ext:TextField ID="TextField3" runat="server" />
            <ext:Checkbox ID="Checkbox1" runat="server" />
            <ext:ComboBox ID="ComboBox1" runat="server">
                <Items>
                    <ext:ListItem Text="Item 1" />
                    <ext:ListItem Text="Item 2" />
                </Items>
            </ext:ComboBox>
        </Items>
    </ext:FormPanel>
</asp:Content>
