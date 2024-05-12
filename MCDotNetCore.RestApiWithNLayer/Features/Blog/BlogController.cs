using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCDotNetCore.RestApiWithNLayer.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BL_Blog bl_Blog;

        public BlogController()
        {
            bl_Blog = new BL_Blog();
        }

        [HttpGet]
        public IActionResult GetBlog()
        {
            var lst = bl_Blog.GetBlogs();
            return Ok(lst);

        }

        [HttpGet("{id}")]
        public IActionResult GetBlogById(int id)
        {
            var item = bl_Blog.GetBlogById(id);

            if (item is null)
            {
                return NotFound("Item Not Found");

            }
            return Ok(item);

        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel requestModel)
        {
            int result = bl_Blog.CreateBlog(requestModel);

            string message = result > 0 ? "Saving Success" : "Saving Failed";
            return Ok(message);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel requestModel)
        {
            var item = bl_Blog.GetBlogById(id);

            if (item is null)
            {
                return NotFound("Item Not Found");

            }
            int result = bl_Blog.UpdateBlog(id, requestModel);

            string message = result > 0 ? "Update Success" : "Update Failed";
            return Ok(message);

        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel requestBlog)
        {
            var item = bl_Blog.GetBlogById(id);

            if (item is null)
            {
                return NotFound("Item Not Found");

            }
            int result = bl_Blog.PatchBlog(id, requestBlog);

            string message = result > 0 ? "Update Success" : "Update Failed";
            return Ok(message);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = bl_Blog.GetBlogById(id);

            if (item is null)
            {
                return NotFound("Item Not Found");

            }
            int result = bl_Blog.DeleteBlog(id);

            string message = result > 0 ? "Delete Success" : "Delete Failed";
            return Ok(message);


        }
    }
}
