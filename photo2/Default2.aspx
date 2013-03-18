<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         Id:<asp:TextBox ID="idtextbox" runat="server"></asp:TextBox>
         <br />
         Description:
         <asp:TextBox ID="desctextbox" runat="server"></asp:TextBox>
         <br />
         Image:
         <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="submitbtn" runat="server" Text="Save to db" OnClick="submitbtn_Click" />
            <br />
            __________________________________________________________<br />
         <br />
         How image by id:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Show" 
             onclick="Button1_Click" />
            <br />
         Description:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
         <asp:Image ID="Image1" runat="server" />
    </div>
    </form>
</body>
</html>
