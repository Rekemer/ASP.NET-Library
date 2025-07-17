using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Book_Library
{
    public static class Dal
    {
        private static string Conn
            => ConfigurationManager.ConnectionStrings["LibraryConn"].ConnectionString;

        public static DataTable BookList()
        {
            using (var cn = new SqlConnection(Conn))
            {
                using (var cmd = new SqlCommand("usp_Book_List", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static DataRow BookGet(long isbn)
        {
            using (var cn = new SqlConnection(Conn))
            {
                using (var cmd = new SqlCommand("usp_Book_Get", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ISBN", isbn);

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt.Rows.Count == 1 ? dt.Rows[0] : null;
                    }
                }
            }
        }

        public static void BookInsert(long isbn, string title, string author,
                                      DateTime pubDate, decimal price, bool publish)
        {
            using (var cn = new SqlConnection(Conn))
            {
                using (var cmd = new SqlCommand("usp_Book_Insert", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ISBN", isbn);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Author", author);
                    cmd.Parameters.AddWithValue("@PublishDate", pubDate);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Publish", publish);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void BookUpdate(long isbn, string title, string author,
                                      DateTime pubDate, decimal price, bool publish)
        {
            using (var cn = new SqlConnection(Conn))
            {
                using (var cmd = new SqlCommand("usp_Book_Update", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ISBN", isbn);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Author", author);
                    cmd.Parameters.AddWithValue("@PublishDate", pubDate);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Publish", publish);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void BookDelete(long isbn)
        {
            using (var cn = new SqlConnection(Conn))
            {
                using (var cmd = new SqlCommand("usp_Book_Delete", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ISBN", isbn);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
