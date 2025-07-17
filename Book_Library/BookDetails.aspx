<%@ Page Language="C#" MasterPageFile="~/Site1.master"
         AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs"
         Inherits="Book_Library.BookDetails" Title="Book Details" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2 style="margin-bottom:2px;">
        <asp:Label ID="labelHeader" runat="server" />
    </h2>
    <hr style="border:1px solid #808080; margin-bottom:12px;" />

    <table>
        <tr>
            <td style="width:120px;">ISBN:</td>
            <td><asp:TextBox ID="textISBN" runat="server" CssClass="input" /></td>
        </tr>
        <tr>
            <td>Title:</td>
            <td><asp:TextBox ID="textTitle" runat="server" Width="250" /></td>
        </tr>
        <tr>
            <td>Author:</td>
            <td><asp:TextBox ID="textAuthor" runat="server" Width="250" /></td>
        </tr>
        <tr>
            <td>Publish&nbsp;Date:</td>
            <td><asp:TextBox ID="textPublishDate" runat="server" /></td>
        </tr>
        <tr>
            <td>Price:</td>
            <td><asp:TextBox ID="textPrice" runat="server" /></td>
        </tr>
        <tr>
            <td>Publish?</td>
            <td><asp:CheckBox ID="checkPublish" runat="server" /></td>
        </tr>
    </table>

    <asp:Button ID="buttonSave"   runat="server" Text="Save"
                OnClick="Save"   CssClass="button" />
    <asp:Button ID="buttonCancel" runat="server" Text="Cancel"
                OnClick="Cancel" CssClass="button" />

</asp:Content>
