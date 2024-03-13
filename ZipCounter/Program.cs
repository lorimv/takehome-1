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
            IDictionary<String, int> result = CsvParser.GetZips();
            foreach (KeyValuePair<String, int> kvp in result)
            {
                // Okay there is definitely some crazy race condition or smth
                // because changing this WriteLine affects whether a
                // System.InvalidOperationException occurs within ReadCsv()
                Console.WriteLine("Zip: {0}, People: {1}", kvp.Key, kvp.Value);
            }
            // ReadCsv tests:
            // using FileStream stream = File.Open(Console.ReadLine(), FileMode.Open);
            // CsvParser.ReadCsv(stream);
        }
    }
}
