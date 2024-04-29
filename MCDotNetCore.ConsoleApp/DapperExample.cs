using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MCDotNetCore.ConsoleApp
{
    internal class DapperExample
    {
        public void Run()
        {
            Read();
            Edit(1);
            //Create("New Blog", "Author 1", "Content 1");
            // Update(1, "Blog 1", "Author 1", "Content 1");
            //Delete(2);

         }
        private void Read()
        {
           using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            List<BlogDTO> lst = db.Query<BlogDTO>("select * from tbl_blog").ToList();

            foreach(BlogDTO item in lst)
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
            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogDTO>("select * from tbl_blog where BlogId = @BlogId", new BlogDTO { BlogId = id }).FirstOrDefault();

            if(item is null)
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
            string query = @" INSERT INTO [dbo].[tbl_blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
             VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
           int result = db.Execute(query, item);

            string message = result > 0 ? "Saving Success" : "Saving Failed";
            Console.WriteLine(message);


        }

        private void Update(int id, string title, string author, string content)
        {
            var item = new BlogDTO
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content

            };
            string query = @"UPDATE [dbo].[tbl_blog]
             SET [BlogTitle] = @BlogTitle
            ,[BlogAuthor] = @BlogAuthor
             ,[BlogContent] = @BlogContent
             WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Update Success" : "Update Failed";
            Console.WriteLine(message);


        }

        private void Delete(int id)
        {
            var item = new BlogDTO
            {
                BlogId = id
            };
            string query = @"select * from tbl_blog where BlogId=@BlogId";
            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Delete Success" : "Delete Failed";
            Console.WriteLine(message);
        }
    }
}
