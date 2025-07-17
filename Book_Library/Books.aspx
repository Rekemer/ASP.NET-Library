<%@ Page Language="C#"
         MasterPageFile="~/Site1.master"
         AutoEventWireup="true"
         CodeBehind="Books.aspx.cs"
         Inherits="Book_Library.Books"
         Title="Books" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Books</h2>
    <asp:SqlDataSource ID="booksDataSource" runat="server"
        ConnectionString="<%$ ConnectionStrings:LibraryConn %>"
        SelectCommand="Book_List"
        SelectCommandType="StoredProcedure" />

    <asp:GridView ID="booksGridView" runat="server"
        DataSourceID="booksDataSource"
        AutoGenerateColumns="False"
        DataKeyNames="ISBN"
        Width ="100%"
        HeaderStyle-BackColor="#0066CC"
        HeaderStyle-ForeColor="White"
        HeaderStyle-Font-Bold="true"
        HeaderStyle-HorizontalAlign="Left"
        RowStyle-Padding="3"
        AlternatingRowStyle-BackColor="#F8F8F8"
        OnSelectedIndexChanged="Selected"
      >

        <Columns>
            <asp:CommandField ShowSelectButton="True" SelectText="Select" />
            <asp:BoundField DataField="ISBN"         HeaderText="ISBN"         ReadOnly="True" />
            <asp:BoundField DataField="Title"        HeaderText="Title" />
            <asp:BoundField DataField="Author"       HeaderText="Author" />
            <asp:BoundField DataField="PublishDate"  HeaderText="Publish Date" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="Price"        HeaderText="Price"        DataFormatString="{0:N2}" HtmlEncode="False" />
            <asp:CheckBoxField DataField="Publish"   HeaderText="Publish" />
        </Columns>
    </asp:GridView>

    <asp:Button ID="buttonAdd"    runat="server" Text="Add"    CssClass="button"
                OnClick="Add"  />
    <asp:Button ID="buttonEdit"   runat="server" Text="Edit"   CssClass="button"
                OnClick="Edit" Enabled="false" />
    <asp:Button ID="buttonDelete" runat="server" Text="Delete" CssClass="button"
                OnClick="Delete" Enabled="false" />

</asp:Content>
