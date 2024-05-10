using MCDotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace MCDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNetController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlog()
        {
            SqlConnection connection = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString );
            connection.Open();
            string query = "select * from tbl_blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
          //  List< BlogModel> lst = new List<BlogModel>();

            //foreach (DataRow dr in dt.Rows)
           // {
              //  BlogModel blog = new BlogModel();
              //  blog.BlogId = Convert.ToInt32(dr["BlogId"]);
               // blog.BlogTitle = Convert.ToString(dr["BlogTitle"]);
               // blog.BlogAuthor = Convert.ToString(dr["BlogAuthor"]);
               // blog.BlogContent = Convert.ToString(dr["BlogContent"]);
               // lst.Add(blog);
           // }
            List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
            {
             BlogId = Convert.ToInt32(dr["BlogId"]),
             BlogTitle = Convert.ToString(dr["BlogTitle"]),
             BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
             BlogContent = Convert.ToString(dr["BlogContent"])
           }).ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogById(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = "select * from tbl_blog where BlogId=@BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found");
                return NotFound("No Data Found");
            }


            DataRow dr = dt.Rows[0];
            var item = new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            };
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @" INSERT INTO [dbo].[tbl_blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
             VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Saving Success" : "Saving Failed";
            Console.WriteLine(message);
            return Ok(message);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"UPDATE [dbo].[tbl_blog]
             SET [BlogTitle] = @BlogTitle
            ,[BlogAuthor] = @BlogAuthor
             ,[BlogContent] = @BlogContent
             WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Update Success" : "Update Failed";
            return Ok(message);
        }


        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent, ";
            }
            if(conditions.Length == 0)
            {
                return NotFound("No data to update");
            }
            conditions = conditions.Substring(0, conditions.Length - 2);
            string query = $@"UPDATE [dbo].[tbl_blog]
             SET {conditions}
             WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            }
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Update Success" : "Update Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"delete from Tbl_Blog where BlogId=@BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Deleted Successful" : "Deleted Failed";
            return Ok(message);
        }

        private DataTable? findById(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = "select * from tbl_blog where BlogId=@BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            return dt;

        }
    }
}
