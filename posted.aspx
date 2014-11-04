<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeFile="posted.aspx.cs" Inherits="ajaxPostDemo.posted" %>

<h2>Previous Posts:</h2><br />
<asp:Repeater ID="rptrPosts" runat="server">
<HeaderTemplate>
<table border="1">
<tr><th>Id</th><th>Name</th><th>Inquiry</th><th>Email</th><th>Timestamp</th></tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td><%# Eval("Id") %></td>
<td><%# Eval("Name") %></td>
<td><%# Eval("Inquiry") %></td>
<td><%# Eval("Email") %></td>
<td><%# Eval("Timestamp") %></td>
</tr>
</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
</asp:Repeater>

