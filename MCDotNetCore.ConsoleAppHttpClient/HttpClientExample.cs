using Newtonsoft.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace MCDotNetCore.ConsoleAppHttpClient
{
    internal class HttpClientExample
    {
        private readonly HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7266") };
        private readonly string _blogEndpoint = "api/blog";
        public async Task RunAsync()
        {
            await ReadAsync();
           // await EditAsync(12);
            //await CreateAsync("title", "author", "content");
           // await UpdateAsync(12,"title", "author", "content");

        }

        private async Task ReadAsync()
        {
            

            var response = await _client.GetAsync(_blogEndpoint);

            if (response.IsSuccessStatusCode)
            {
                string jsonstr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonstr);
                List<BlogDTO> lst = JsonConvert.DeserializeObject<List<BlogDTO>>(jsonstr)!;
                foreach (var blog in lst)
                {
                    Console.WriteLine($"Title => {blog.BlogTitle}");
                    Console.Write($"Author =>{blog.BlogAuthor}");
                    Console.WriteLine($"Content =>{blog.BlogContent}");
                }
            }

        }

        private async Task EditAsync(int id)
        {
            var response = await _client.GetAsync($"{_blogEndpoint}/{id}");

            if (response.IsSuccessStatusCode)
            {
                string jsonstr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonstr);
                BlogDTO blog = JsonConvert.DeserializeObject<BlogDTO>(jsonstr)!;
               
                    Console.WriteLine($"Title => {blog.BlogTitle}");
                    Console.Write($"Author =>{blog.BlogAuthor}");
                    Console.WriteLine($"Content =>{blog.BlogContent}");  
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message); 
            }

        }

        private async Task CreateAsync(string title, string author, string content)
        {
            BlogDTO blogDTO = new BlogDTO()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content

            }; //C# object
            string blogJson = JsonConvert.SerializeObject(blogDTO);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PostAsync(_blogEndpoint, httpContent);

            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task UpdateAsync(int id,string title, string author, string content)
        {
            BlogDTO blogDTO = new BlogDTO()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content

            }; //C# object
            string blogJson = JsonConvert.SerializeObject(blogDTO);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PostAsync($"{_blogEndpoint}/{id}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"{_blogEndpoint}/{id}");

            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }

        }


    }
}
