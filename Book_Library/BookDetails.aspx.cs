using System;

namespace Book_Library
{
    public partial class BookDetails : System.Web.UI.Page
    {
        private long ISBN
        {
            get
            {
                long v = 0;
                return long.TryParse(Request.QueryString["isbn"], out v) ? v : 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && ISBN != 0)
            {
                var row = DataBaseService.BookGet(ISBN);
                if (row != null)
                {
                    textISBN.Text = row["ISBN"].ToString();
                    textISBN.Enabled = false;
                    textTitle.Text = row["Title"].ToString();
                    labelHeader.Text = textTitle.Text;   
                    textAuthor.Text = row["Author"].ToString();
                    textPublishDate.Text = Convert.ToDateTime(row["PublishDate"]).ToString("yyyy-MM-dd");
                    textPrice.Text = Convert.ToDecimal(row["Price"]).ToString("0.00");
                    checkPublish.Checked = Convert.ToBoolean(row["Publish"]);
                }
            }
        }

        protected void Save(object sender, EventArgs e)
        {
            long isbn = long.Parse(textISBN.Text);
            string title = textTitle.Text.Trim();
            string author = textAuthor.Text.Trim();
            DateTime pubDate = DateTime.Parse(textPublishDate.Text);
            decimal price = decimal.Parse(textPrice.Text);
            bool publish = checkPublish.Checked;

            if (ISBN == 0)
                DataBaseService.BookInsert(isbn, title, author, pubDate, price, publish);
            else
                DataBaseService.BookUpdate(isbn, title, author, pubDate, price, publish);

            Response.Redirect("Books.aspx");
        }

        protected void Cancel(object sender, EventArgs e)
        {
            Response.Redirect("Books.aspx");
        }
    }
}
