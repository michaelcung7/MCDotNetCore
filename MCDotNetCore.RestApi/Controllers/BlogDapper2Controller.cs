using Dapper;
using MCDotNetCore.RestApi.Models;
using MCDotNetCore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace MCDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapper2Controller : ControllerBase
    {
        private readonly DapperService _dapperService = new DapperService(ConnectionString.sqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlog()
        {
            string query = "select * from tbl_blog";
            var lst = _dapperService.Query<BlogModel>(query); 
            return Ok(lst);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @" INSERT INTO [dbo].[tbl_blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
             VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
           // using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Saving Success" : "Saving Failed";

            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            var item = FindById(id);

            if (item is null)
            {
                return NotFound("Item not Fund");

            }
            blog.BlogId = id;
            string query = @"UPDATE [dbo].[tbl_blog]
             SET [BlogTitle] = @BlogTitle
            ,[BlogAuthor] = @BlogAuthor
             ,[BlogContent] = @BlogContent
             WHERE BlogId = @BlogId";
        //    using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            int result = _dapperService.Execute(query, blog);
            if (item is null)
            {
                return NotFound("Item not Fund");

            }
            string message = result > 0 ? "Update Success" : "Update Failed";
            return Ok(message);
        }

        [HttpGet("{id}")]
        public IActionResult GetblogById(int id)
        {
            var item = FindById(id);

            if (item is null)
            {
                return NotFound("Item not Fund");

            }

            return Ok(item);
        }


        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            var item = FindById(id);

            if (item is null)
            {
                return NotFound("Item not Fund");
            }

            blog.BlogId = id;
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
                return NotFound("No Data To Update");
            }
            conditions = conditions.Substring(0, conditions.Length - 2);
            string query = $@"UPDATE [dbo].[tbl_blog]
             SET {conditions}
             WHERE BlogId = @BlogId";
          //  using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Update Success" : "Update Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = FindById(id);

            if (item is null)
            {
                return NotFound("Item not Fund");

            }
            string query = @"delete from tbl_blog where BlogId=@BlogId";
           // using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            int result = _dapperService.Execute(query, new BlogModel { BlogId = id });

            string message = result > 0 ? "Delete Success" : "Delete Failed";
            return Ok(message);

        }

        private BlogModel? FindById(int id)
        {
            string query = "select * from tbl_blog where BlogId = @BlogId";
            BlogModel item = _dapperService.FindById<BlogModel>(query, new BlogModel { BlogId = id });
            return item;
        }
    }
}
