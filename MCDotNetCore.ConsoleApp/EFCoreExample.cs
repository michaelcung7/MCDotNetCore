using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDotNetCore.ConsoleApp
{
    internal class EFCoreExample
    {
        private readonly AppDBContext db = new AppDBContext();
        public void Run()
        {
            //Read();
            Edit(1);
            //Create("New Blog", "Author 1", "Content 1");
            // Update(1, "Blog 1", "Author 1", "Content 1");
            //Delete(2);

        }

        private void Read()
        {
           
            var lst = db.Blogs.ToList();

            foreach (BlogDTO item in lst)
            {
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine("==========================>");
            }

        }

        private void Edit(int id)
        {
           var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                Console.WriteLine("No Record!");
                return;

            }

            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

        }

        private void Create(string title, string author, string content)
        {
            var item = new BlogDTO
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content

            };

            db.Blogs.Add(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Saving Success" : "Saving Failed";
            Console.WriteLine(message);


        }
        private void Update(int id, string title, string author, string content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                Console.WriteLine("No Record!");
                return;

            }
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;

            int result = db.SaveChanges();

            string message = result > 0 ? "Update Success" : "Update Failed";
            Console.WriteLine(message);


        }

        private void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                Console.WriteLine("No Record!");
                return;

            }
            db.Blogs.Remove(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Delete Success" : "Delete Failed";
            Console.WriteLine(message);


        }
    }
}
