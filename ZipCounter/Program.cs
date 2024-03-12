namespace ZipCounter
{
    using System;
    using System.IO;
    using System.Net.Http;

    static class Program
    {
        static readonly HttpClient client = new HttpClient();

        // TODO move download functions to separate class
        static async Task Downloader(String url)
        {
            try
            {
                // TODO replace response code with an actual download
                using HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Connected.");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Connection error: " + e);
            }
        }

        // null type warning, bc SR.ReadLine will assign null to S?
        static async Task ParseFile(String filePath)
        {
            if (File.Exists(filePath))
            {
                List<Task> downloadTasks = new List<Task>();
                using (StreamReader SR = new StreamReader(filePath))
                {
                    String S = SR.ReadLine();
                    while (S != null)
                    {
                        Console.WriteLine(S);
                        downloadTasks.Add(Downloader(S));
                        S = SR.ReadLine();
                    }
                    await Task.WhenAll(downloadTasks);
                }
            }
            else { Console.WriteLine("File not found!"); }
        }

        static async Task Main()
        {
            Console.WriteLine("Please enter your filepath:");
            await ParseFile(Console.ReadLine());
            // await ParseFile("/home/XXXXXXXXX/Downloads/list");
        }
    }
}
