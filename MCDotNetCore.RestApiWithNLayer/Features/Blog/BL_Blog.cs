namespace MCDotNetCore.RestApiWithNLayer.Features.Blog
{
    public class BL_Blog
    {
        private readonly DA_Blog da_Blog;

        public BL_Blog()
        {
            da_Blog = new DA_Blog();
        }

        public List<BlogModel> GetBlogs()
        {
            List<BlogModel> lst = da_Blog.GetBlogs();
            return lst;
        }

        public BlogModel GetBlogById(int id)
        {
            return da_Blog.GetBlogByID(id);
        }

        public int CreateBlog(BlogModel requestModel)
        {
            return da_Blog.CreateBlog(requestModel);
        }

        public int UpdateBlog(int id, BlogModel requestModel)
        {
            return da_Blog.UpdateBlog(id, requestModel);
        }

        public int PatchBlog(int id, BlogModel requestModel)
        {
            return da_Blog.PatchBlog(id, requestModel);
        }

        public int DeleteBlog(int id)
        {
            return da_Blog.DeleteBlog(id);
        }

    }
}
