<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="SLC_Classview_CSharp.header" %>
<div id="headerBars">
    <div id="left" class="headerLabel" style="float: left; clear:both">
        Hello, <asp:Label ID="userFullName" runat="server" Text="" Font-Bold="true"></asp:Label>
    </div>
    <div id="right" class="headerLabel" style="float: right;">
        Roles: <asp:Label ID="userRoles" runat="server" Text="" Font-Bold="true"></asp:Label>
    </div>
</div>