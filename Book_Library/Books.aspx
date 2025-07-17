<%@ Page Language="C#"
         MasterPageFile="~/Site1.master"
         AutoEventWireup="true"
         CodeBehind="Books.aspx.cs"
         Inherits="Book_Library.Books"
         Title="Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Books</h2>

    <asp:GridView ID="gvBooks" runat="server"
        AutoGenerateColumns="False"
        CssClass="table"
        DataKeyNames="ISBN"
        OnSelectedIndexChanged="gvBooks_SelectedIndexChanged">
        <Columns>
          
            <asp:CommandField ShowSelectButton="True" SelectText="Select" />
            <asp:BoundField DataField="ISBN" HeaderText="ISBN" ReadOnly="True" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Author" HeaderText="Author" />
            <asp:BoundField DataField="PublishDate" HeaderText="PublishDate" DataFormatString="{0:d}" />
            <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
            <asp:CheckBoxField DataField="Publish" HeaderText="Publish" />
        </Columns>
    </asp:GridView>

    <asp:Button ID="btnAdd"    runat="server" Text="Add"    OnClick="btnAdd_Click"  CssClass="btn" />
    <asp:Button ID="btnEdit"   runat="server" Text="Edit"   OnClick="btnEdit_Click" CssClass="btn" Enabled="false" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn" Enabled="false" />
</asp:Content>

