namespace ZipCounter
{
    using System;
    using System.IO;
    using System.Net.Http;

    static class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Please enter your filepath:");
            // possible null
            await UriHandler.ParseFile(Console.ReadLine());
            Console.WriteLine(CsvParser.GetZips());
        }
    }
}
