<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiraToCode.aspx.cs" Inherits="ChatGPT_Demo.JiraToCode" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="I am developer. I write code."></asp:Label><br/>
            <asp:TextBox ID="txtInput" runat="server" TextMode="MultiLine" Height="304px" Width="551px" Text="feed me your code"></asp:TextBox><br/>
            <br/>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /> &nbsp; 
            <asp:Button ID="btnSample" runat="server" Text="Sample" OnClick="btnSample_Click" /><br/>
            <br/>
            <asp:CheckBox ID="CheckBoxRefine" Text="Code Refine" runat="server" Checked="True" /><br/>
            <br/>
            <asp:Panel ID="PanelRefine" runat="server">
                <asp:Label ID="Label2" runat="server" Text="Code Refine"></asp:Label><br/>
                <asp:TextBox ID="txtOutputRefine" runat="server" TextMode="MultiLine" Height="304px" Width="1000px" Enabled="False" BackColor="lightgreen"></asp:TextBox><br/>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
