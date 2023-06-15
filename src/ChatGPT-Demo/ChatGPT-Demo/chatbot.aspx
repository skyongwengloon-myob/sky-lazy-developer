<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chatbot.aspx.cs" Inherits="ChatGPT_Demo.Chatbot" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Chatbot demo"></asp:Label><br/><br/>
            <asp:TextBox ID="txtInput" runat="server" TextMode="MultiLine" Height="304px" Width="551px" Text="say hello"></asp:TextBox><br/><br/>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /><br/><br/>
            <asp:Button ID="btnChat" runat="server" Text="Chat" OnClick="btnChat_Click" /><br/><br/>
            <asp:TextBox ID="txtOutput" runat="server" TextMode="MultiLine" Height="304px" Width="551px" Enabled="False"></asp:TextBox><br/><br/>

        </div>
    </form>
</body>
</html>
