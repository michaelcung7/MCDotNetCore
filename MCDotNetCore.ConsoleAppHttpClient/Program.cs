// See https://aka.ms/new-console-template for more information
using MCDotNetCore.ConsoleAppHttpClient;

Console.WriteLine("Hello, World!");


HttpClientExample example = new HttpClientExample();
example.RunAsync();

Console.ReadLine();