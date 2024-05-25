

using MCDotNetCore.ConsoleAppWithRefit;

try
{
    RefitExample refitExample = new RefitExample();
    refitExample.RunAsync();

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());      
}

