<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CodeAnalysis.aspx.cs" Inherits="ChatGPT_Demo.CodeAnalysis" Async="true" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:Label ID="Label1" runat="server" Text="I am code master. I will review your code."></asp:Label><br/>
            <asp:TextBox ID="txtInput" runat="server" TextMode="MultiLine" Height="304px" Width="551px" Text="feed me your code"></asp:TextBox><br/>
            <br/>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /> &nbsp; 
            <asp:Button ID="btnSample" runat="server" Text="Sample" OnClick="btnSample_Click" /><br/>
            <br/>
            <asp:CheckBox ID="CheckBoxRefine" Text="Code Refine" runat="server" Checked="True" /><br/>
            <asp:CheckBox ID="CheckBoxUnitTest" Text="Code Unit Test" runat="server" Checked="True" /><br/>
            <asp:CheckBox ID="CheckBoxDocumentation" Text="Code Documentation" runat="server" Checked="True" /><br/>
            <br/>
            <asp:Label ID="lblRating" runat="server" Text="0%"></asp:Label><br/>
            <br/>
            <asp:Panel ID="PanelRefine" runat="server">
                <asp:Label ID="Label2" runat="server" Text="Code Refine"></asp:Label><br/>
                <asp:TextBox ID="txtOutputRefine" runat="server" TextMode="MultiLine" Height="304px" Width="1000px" Enabled="False" BackColor="lightgreen"></asp:TextBox><br/>
            </asp:Panel>
            <asp:Panel ID="PanelUnitTest" runat="server">
                <asp:Label ID="Label4" runat="server" Text="Code Unit Test"></asp:Label><br/>
                <asp:TextBox ID="txtOutputUnitTest" runat="server" TextMode="MultiLine" Height="304px" Width="1000px" Enabled="False" BackColor="lightyellow"></asp:TextBox><br/>
            </asp:Panel>
            <asp:Panel ID="PanelDocumentation" runat="server">
                <asp:Label ID="Label3" runat="server" Text="Code Documentation"></asp:Label><br/>
                <asp:TextBox ID="txtOutputDocumentation" runat="server" TextMode="MultiLine" Height="304px" Width="1000px" Enabled="False" BackColor="lightblue"></asp:TextBox><br/>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
