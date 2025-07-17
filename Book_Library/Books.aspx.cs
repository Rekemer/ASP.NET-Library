using System;

namespace Book_Library
{
    public partial class Books : System.Web.UI.Page
    {
        private long SelectedISBN
        {
            get { return ViewState["ISBN"] == null ? 0 : (long)ViewState["ISBN"]; }
            set { ViewState["ISBN"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindGrid();
        }

        private void BindGrid()
        {
            booksGridView.DataBind();
        }

        protected void Selected(object sender, EventArgs e)
        {
            SelectedISBN = Convert.ToInt64(booksGridView.SelectedDataKey.Value);
            buttonEdit.Enabled = true;
            buttonDelete.Enabled = true;
        }

        protected void Add(object sender, EventArgs e)
        {
            Response.Redirect("BookDetails.aspx");
        }

        protected void Edit(object sender, EventArgs e)
        {
            if (SelectedISBN != 0)
                Response.Redirect("BookDetails.aspx?isbn=" + SelectedISBN);
        }

        protected void Delete(object sender, EventArgs e)
        {
            if (SelectedISBN != 0)
            {
                DataBaseService.BookDelete(SelectedISBN);
                BindGrid();
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;
            }
        }
    }
}
