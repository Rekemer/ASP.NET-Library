using System;

namespace Book_Library
{
    public partial class BookDetails : System.Web.UI.Page
    {
        private long ISBN
        {
            get
            {
                long v;
                return long.TryParse(Request.QueryString["isbn"], out v) ? v : 0L;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && ISBN != 0)
            {
                var row = Dal.BookGet(ISBN);
                if (row != null)
                {
                    txtISBN.Text = row["ISBN"].ToString();
                    txtISBN.Enabled = false;
                    txtTitle.Text = row["Title"].ToString();
                    txtAuthor.Text = row["Author"].ToString();
                    txtPublishDate.Text = Convert.ToDateTime(row["PublishDate"]).ToString("yyyy-MM-dd");
                    txtPrice.Text = Convert.ToDecimal(row["Price"]).ToString("0.00");
                    chkPublish.Checked = Convert.ToBoolean(row["Publish"]);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            long isbn = long.Parse(txtISBN.Text);
            string title = txtTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();
            DateTime pubDate = DateTime.Parse(txtPublishDate.Text);
            decimal price = decimal.Parse(txtPrice.Text);
            bool publish = chkPublish.Checked;

            if (ISBN == 0)
                Dal.BookInsert(isbn, title, author, pubDate, price, publish);
            else
                Dal.BookUpdate(isbn, title, author, pubDate, price, publish);

            Response.Redirect("Books.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Books.aspx");
        }
    }
}
