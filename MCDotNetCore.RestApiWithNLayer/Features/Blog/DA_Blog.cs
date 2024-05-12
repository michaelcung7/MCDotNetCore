using MCDotNetCore.RestApiWithNLayer.DB;
using Microsoft.AspNetCore.Mvc;

namespace MCDotNetCore.RestApiWithNLayer.Features.Blog
{
    public class DA_Blog
    {
        private readonly AppDBContext _context;

        public DA_Blog()
        {
            _context = new AppDBContext();
        }

        public List<BlogModel> GetBlogs()
        {
            var lst = _context.Blogs.ToList();
            return lst;
        }

        public BlogModel GetBlogByID(int id)
        {
            var blog = _context.Blogs.FirstOrDefault(x =>  x.BlogId == id);
            return blog;
        }

        public int CreateBlog(BlogModel requestModel)
        {
             _context.Blogs.Add(requestModel);
            int result = _context.SaveChanges();
            return result;

        }

        public int UpdateBlog(int id, BlogModel requestModel)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            item.BlogTitle = requestModel.BlogTitle;
            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogContent = requestModel.BlogContent;

            int result = _context.SaveChanges();
            return result;
        }

        public int PatchBlog(int id, BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null) return 0;

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }

            int result = _context.SaveChanges();
            return result;

        }

        public int DeleteBlog(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            _context.Blogs.Remove(item);
            int result = _context.SaveChanges();
            return result;
        }
    }
}
