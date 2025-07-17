using System;

namespace Book_Library
{
    public partial class Books : System.Web.UI.Page
    {
        private long SelectedISBN
        {
            get { return ViewState["ISBN"] == null ? 0L : (long)ViewState["ISBN"]; }
            set { ViewState["ISBN"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindGrid();
        }

        private void BindGrid()
        {
            gvBooks.DataSource = Dal.BookList();
            gvBooks.DataBind();
        }

        protected void gvBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedISBN = Convert.ToInt64(gvBooks.SelectedDataKey.Value);
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookDetails.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (SelectedISBN != 0)
                Response.Redirect("BookDetails.aspx?isbn=" + SelectedISBN);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedISBN != 0)
            {
                Dal.BookDelete(SelectedISBN);
                BindGrid();
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }
    }
}
