namespace MCDotNetCore.WinFormsApp
{
    public class BlogQuery
    {
        public static string CreateBlogQuery { get; } =
           @" INSERT INTO [dbo].[tbl_blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
             VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

    }
}
