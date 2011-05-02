﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemUserListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.UserManage.SystemUserListPage" %>

<%@ Register Src="UCSystemUserAdd.ascx" TagName="UCSystemUserAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemUserEdit.ascx" TagName="UCSystemUserEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSystemUserChangePwd.ascx" TagName="UCSystemUserChangePwd" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <script type="text/javascript">
        var rooturl = '<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
        }

        
        
        var FormatLocked = function(value) {
            if (value)
                return '<%= this.GetLocalResourceObject("msgLocked") %>';
            else
                return '<%= this.GetLocalResourceObject("msgNormal") %>';
        }

        function processcmd(cmd, id) {

            alert(cmd);
            alert(id);
        }


        var RefreshData = function(btn) {
            <%= this.storeSystemUser.ClientID %>.reload();
        };
        

        function showAddForm() {
            Ext.net.DirectMethods.UCSystemUserAdd.Show(
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg, RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                    }
                                                                });

        }

        function processcmd(cmd, id) {
            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSystemUserEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") 
            {
                Ext.MessageBox.confirm('<%= GetGlobalResourceObject("GlobalResource","msgWarning").ToString() %>','<%= GetGlobalResourceObject("GlobalResource","msgDeleteWarning").ToString() %>',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpSuccessful").ToString() %>', '<%= GetGlobalResourceObject("GlobalResource","msgDeleteSuccessful").ToString() %>',RefreshData);             
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                }
                                                            );
                    }
                    );
            }
            if (cmd == "btnLock"||cmd == "btnUnlock") 
            {
                            Ext.net.DirectMethods.LockUser
                            (
                                                                id.id,
                                                                {
                                                                    failure: function(msg) 
                                                                    {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                                    },
                                                                    success: function(result) 
                                                                    { 
                                                                       <%= this.storeSystemUser.ClientID %>.reload();            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                }
                            );
            }
            if (cmd == "cmdChangePassword") 
            {
                            Ext.net.DirectMethods.UCSystemUserChangePwd.Show
                            (
                                                                id.id,
                                                                {
                                                                    failure: function(msg) 
                                                                    {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                                    },
                                                                    success: function(result) 
                                                                    { 
                                                                       //Ext.Msg.alert('Operation Successful', 'Delete successfulSystem User!',RefreshData);            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                }
                            );
            }
            if (cmd == "cmdApplyRole") 
            {
                            Ext.net.DirectMethods.UCSystemUserAssignedRole.Show
                            (
                                                                id.id,
                                                                {
                                                                    failure: function(msg) 
                                                                    {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                                    },
                                                                    success: function(result) 
                                                                    { 
                                                                       //Ext.Msg.alert('Operation Successful', 'Delete successfulSystem User!',RefreshData);            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                }
                            );
            }
        }



                var IntailLockedOut=function(grid, toolbar, rowIndex, record)
        {
      
            if(record.data.IsLockedOut)
            {
             toolbar.items.items[0].menu.items.items[4].hide();
             toolbar.items.items[0].menu.items.items[5].show();
            }
            
            else{
             toolbar.items.items[0].menu.items.items[4].show();
             toolbar.items.items[0].menu.items.items[5].hide();
        
            }
               
        }


    </script>
    <ext:Store ID="storeSystemUser" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSystemUser_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Reader>
            <ext:JsonReader IDProperty="UserID">
                <Fields>
                    <ext:RecordField Name="UserID" Type="int" />
                    <ext:RecordField Name="UserLoginID" />
                    <ext:RecordField Name="UserName" />
                    <ext:RecordField Name="UserEmail" />
                    <ext:RecordField Name="UserPassword" />
                    <ext:RecordField Name="UserStatus" />
                    <ext:RecordField Name="UserCreateDate" Type="Date" />
                    <ext:RecordField Name="UserType" />
                    <ext:RecordField Name="PasswordFormat" Type="int" />
                    <ext:RecordField Name="Comments" />
                    <ext:RecordField Name="IsApproved" Type="Boolean" />
                    <ext:RecordField Name="IsLockedOut" Type="Boolean" />
                    <ext:RecordField Name="LastActivityDate" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemUserAdd ID="UCSystemUserAdd1" runat="server" />
    <uc2:UCSystemUserEdit ID="UCSystemUserEdit1" runat="server" />
    <uc3:UCSystemUserChangePwd ID="UCSystemUserChangePwd1" runat="server" />
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSystemUser" runat="server" StoreID="storeSystemUser"
                StripeRows="true" Title="<%$ Resources:msgGridTitle %>" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>" Icon="Add">
                                <Listeners>
                                    <Click Handler="showAddForm();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="<%$ Resources : GlobalResource, msgRefresh  %>" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSystemUser}.reload();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <View>
                    <ext:GridView ForceFit="true" ID="GridView1">
                        <GetRowClass Handler="" FormatHandler="False"></GetRowClass>
                    </ext:GridView>
                </View>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:RowNumbererColumn>
                        </ext:RowNumbererColumn>
                        <ext:Column ColumnID="colUserLoginID" DataIndex="UserLoginID" Header="<%$ Resources:msgcolUserLoginID %>" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colUserName" DataIndex="UserName" Header="<%$ Resources:msgcolUserName %>" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colUserEmail" DataIndex="UserEmail" Header="<%$ Resources:msgcolUserEmail %>" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colUserStatus" DataIndex="UserStatus" Header="<%$ Resources:msgcolUserStatus %>" Sortable="true"
                            Width="35">
                        </ext:Column>
                        <ext:Column ColumnID="colUserCreateDate" DataIndex="UserCreateDate" Header="<%$ Resources:msgcolUserCreateDate %>"
                            Sortable="true" Width="60">
                            <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y')" />
                        </ext:Column>
                        <ext:Column ColumnID="colIsApproved" DataIndex="IsApproved" Header="<%$ Resources:msgcolIsApproved %>" Sortable="true"
                            Width="35">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colIsLockedOut" DataIndex="IsLockedOut" Header="<%$ Resources:msgcolIsLockedOut %>" Sortable="true"
                            Width="35">
                            <Renderer Fn="FormatLocked" />
                        </ext:Column>
                        <ext:CommandColumn ColumnID="colManage" Header="<%$ Resources : GlobalResource, msgManage  %>" Width="50"
                            DataIndex="IsLockedOut">
                            <Commands>
                                <ext:SplitCommand Text="<%$ Resources : GlobalResource, msgAction  %>" >
                                    <Menu>
                                        <Items>
                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="<%$ Resources : GlobalResource, msgEdit  %>">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="<%$ Resources : GlobalResource, msgDelete  %>">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="Key" CommandName="cmdChangePassword" Text="<%$ Resources:msgChangePassword %>">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="Application" CommandName="cmdApplyRole" Text="<%$ Resources:msgAssignedPassword %>"
                                                Hidden="true">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="Lock" CommandName="btnLock" Text="<%$ Resources:msgLock %>">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="LockOpen" CommandName="btnUnlock" Text="<%$ Resources:msgunLock %>">
                                            </ext:MenuCommand>
                                        </Items>
                                    </Menu>
                                </ext:SplitCommand>
                            </Commands>
                            <PrepareToolbar Fn="IntailLockedOut" />
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemUser"
                        DisplayInfo="true" DisplayMsg="<%$ Resources : GlobalResource, msgPageInfo  %>" EmptyMsg="<%$ Resources : GlobalResource, msgNoRecordInfo  %>"  />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
