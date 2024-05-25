using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDotNetCore.ConsoleAppWithRefit
{
    public class RefitExample
    {
        private readonly IBlogApi _service = RestService.For<IBlogApi>("https://localhost:71100");
        public async  Task RunAsync()
        {
            await ReadAsync();
            //await EditAsync(1);
            //await CreateAsync("title", "author", "content");
            //await UpdateAsync(2, "title", "author", "content");
            //await DeleteAsync(8);
        }

        private async Task ReadAsync()
        {
            var lst = await _service.GetBlog();

            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine("==========================>");
            }

        }

        private async Task EditAsync(int id)
        {
            try
            {
                var item = await _service.GetBlogById(id);

                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine(item.BlogTitle);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
            
        }

        private async Task CreateAsync(string title, string author, string content)
        {
            BlogModel blog = new BlogModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var message = await _service.CreateBlog(blog);

            Console.WriteLine(message);
           
        }

        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var message = await _service.UpdateBlog(id, blog);

            Console.WriteLine(message);

        }

        private async Task DeleteAsync(int id)
        {
            var message = await _service.DeleteBlog(id);

            Console.WriteLine(message);

        }
    }
}
