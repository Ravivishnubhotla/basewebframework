<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ExtJSConsole.Moudle.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ScriptManager ID="ScriptManager1" runat="server" />
    <ext:Menu ID="menu1" runat="server">
        <Items>
            <ext:MenuItem Text="Add Sub">
            </ext:MenuItem>
            <ext:MenuItem Text="Edit">
            </ext:MenuItem>
            <ext:MenuItem Text="Delete">
            </ext:MenuItem>
            <ext:MenuItem Text="Sort Sub">
            </ext:MenuItem>
        </Items>
    </ext:Menu>
    <br />
    <ext:TreePanel ID="TreePanel1" runat="server" Height="300" ContextMenuID="menu1" Title="Title">
        <Root>
            <ext:TreeNode Text="11111" Icon="Folder" Expanded="true" Checked=False>
                <Nodes>
                    <ext:TreeNode Text="2222" Icon="FolderEdit" Expanded="true" Checked=False>
                        <Nodes>
                            <ext:TreeNode Text="3333" Icon="FolderEdit" Checked=False>
                            </ext:TreeNode>
                            <ext:TreeNode Text="3333" Icon="FolderEdit" Checked=False>
                            </ext:TreeNode>
                            <ext:TreeNode Text="3333" Icon="FolderEdit" Checked=False>
                            </ext:TreeNode>
                        </Nodes>
                    </ext:TreeNode>
                    <ext:TreeNode Text="2222" Icon="FolderEdit" Checked=False>
                    </ext:TreeNode>
                    <ext:TreeNode Text="2222" Icon="FolderEdit" Checked=False>
                    </ext:TreeNode>
                    <ext:TreeNode Text="2222" Icon="FolderEdit" Checked=False>
                    </ext:TreeNode>
                </Nodes>
            </ext:TreeNode>
        </Root>
    </ext:TreePanel>
    </form>
</body>
</html>
