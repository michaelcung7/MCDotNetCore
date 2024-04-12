// See https://aka.ms/new-console-template for more information
using MCDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

AdoDotnetExample adoDotNetExample = new AdoDotnetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("title","author","content");
//adoDotNetExample.Update(1,"title", "author", "content");
//adoDotNetExample.Delete(5);
adoDotNetExample.Edit(6);
Console.ReadKey();
