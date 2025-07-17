<%@ Page Language="C#" MasterPageFile="~/Site1.master"
         AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs"
         Inherits="Book_Library.BookDetails" Title="Book Details" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><asp:Label ID="lblHeader" runat="server" /></h2>

    <table>
        <tr><td>ISBN:</td><td><asp:TextBox ID="txtISBN" runat="server" CssClass="input" /></td></tr>
        <tr><td>Title:</td><td><asp:TextBox ID="txtTitle" runat="server" Width="250" /></td></tr>
        <tr><td>Author:</td><td><asp:TextBox ID="txtAuthor" runat="server" Width="250" /></td></tr>
        <tr><td>Publish&nbsp;Date:</td><td><asp:TextBox ID="txtPublishDate" runat="server" /></td></tr>
        <tr><td>Price:</td><td><asp:TextBox ID="txtPrice" runat="server" /></td></tr>
        <tr><td>Publish?</td><td><asp:CheckBox ID="chkPublish" runat="server" /></td></tr>
    </table>

    <asp:Button ID="btnSave"   runat="server" Text="Save"   OnClick="btnSave_Click" CssClass="btn" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn" />
</asp:Content>
