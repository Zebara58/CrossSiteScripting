<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="master.aspx.cs" Inherits="CrossSiteScripting.master" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Product App</title>
</head>
<body>

    <p><a href ="ListComments.aspx">ListComments Link</a></p>
    <img id ="1" src="Images/flower.jpg" style="width:100px;height:100px;" />
    <div>
        <h2>All Products</h2>
        <ul id="products" />
    </div>
    <div>
        <h2>Search by ID</h2>
        <form runat="server">
        <asp:TextBox ID="prodId" runat="server" />
        <asp:Button OnClick="Button1_Click" ID="Button1" runat="server" Text="Search" />
        <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate><table width="100%"><tr><th>Name</th><th>City</th></tr></HeaderTemplate>
         <ItemTemplate>
            <tr><td><%#DataBinder.Eval(Container.DataItem, "theName")%></a></td>
            <td><%#DataBinder.Eval(Container.DataItem, "theCity")%></td></tr>
         </ItemTemplate>
         <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>
        </form>
    </div>

    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.0.3.min.js"></script>

    <asp:Label ID="lblDisplayErr" runat="server" Text="" CssClass="labelError" />
    <asp:Label ID="lblCookies" runat="server" Text="" CssClass="labelCookies" />
    <p id="2"></p>
    <p id="3"></p>
    <button type="button" onclick="Button2_Click()" id="Button2">Click me to copy text above!</button>
    <p>Select your language:

    <select><script>
    //This causes Javascript to be run after the page loads
    //DOM XSS attack here!
    document.write("<OPTION value=1>"+document.location.href.substring(document.location.href.indexOf("default=")+8)+"</OPTION>");

    document.write("<OPTION value=2>English</OPTION>");

    </script></select>
    </p>

</body>
</html>
