using MCDotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using MCDotNetCore.Shared;

namespace MCDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionString.sqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlog()
        {
            string query = "select * from tbl_blog";
            var lst = _adoDotNetService.Query<BlogModel>(query);
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogById(int id)
        {
            string query = "select * from tbl_blog where BlogId=@BlogId";
            var item = _adoDotNetService.FindById<BlogModel>(query, new AdoDotnetParameter("@BlogId", id));
            if(item is null)
            {
                return NotFound("No Data Found");
            }

            return Ok(item);
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

            int result = _adoDotNetService.Execute(query, new AdoDotnetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotnetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotnetParameter("@BlogContent", blog.BlogContent));

            string message = result > 0 ? "Saving Success" : "Saving Failed";
            return Ok(message);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            string query = @"UPDATE [dbo].[tbl_blog]
             SET [BlogTitle] = @BlogTitle
            ,[BlogAuthor] = @BlogAuthor
             ,[BlogContent] = @BlogContent
             WHERE BlogId = @BlogId";

            int result = _adoDotNetService.Execute(query, new AdoDotnetParameter("@BlogId", id),
                new AdoDotnetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotnetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotnetParameter("@BlogContent", blog.BlogContent));

            string message = result > 0 ? "Update Success" : "Update Failed";
            return Ok(message);
        }


        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            List<AdoDotnetParameter> parameters = new List<AdoDotnetParameter>();
           
            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle, ";
                parameters.Add(new AdoDotnetParameter("@BlogTitle", blog.BlogTitle));
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[BlogAuthor] = @BlogAuthor, ";
                parameters.Add(new AdoDotnetParameter("@BlogAuthor", blog.BlogAuthor));
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent, ";
                parameters.Add(new AdoDotnetParameter("@BlogContent", blog.BlogContent));
            }
            if(conditions.Length == 0)
            {
                return NotFound("No data to update");
            }
            conditions = conditions.Substring(0, conditions.Length - 2);
            string query = $@"UPDATE [dbo].[tbl_blog]
             SET {conditions}
             WHERE BlogId = @BlogId";
            parameters.Add(new AdoDotnetParameter("@BlogId", id));
            int result = _adoDotNetService.Execute(query, parameters.ToArray());

            string message = result > 0 ? "Update Success" : "Update Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = @"delete from Tbl_Blog where BlogId=@BlogId";
            int result = _adoDotNetService.Execute(query, new AdoDotnetParameter("@BlogId", id));

            string message = result > 0 ? "Deleted Successful" : "Deleted Failed";
            return Ok(message);
        }

    }
}
