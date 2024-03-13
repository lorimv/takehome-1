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
            Dictionary<String, int> result = CsvParser.GetZips();
            foreach (KeyValuePair<String, int> kvp in result)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
        }
    }
}
