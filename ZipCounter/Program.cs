namespace ZipCounter
{
    using System;
    using System.IO;
    using System.Net.Http;

    static class Program
    {
        static readonly HttpClient client = new HttpClient();

        // TODO move download
        static async Task Downloader(String url)
        {
            try
            {
                using HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                Console.WriteLine("YES");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("UHHHHHHHHH OHHHHHHH" + e);
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
                    // TODO add to a list of tasks, await after loop
                    while (S != null)
                    {
                        Console.WriteLine(S);
                        downloadTasks.Add(Downloader(S));
                        S = SR.ReadLine();
                    }
                    await Task.WhenAll(downloadTasks);
                }
            }
            else { Console.WriteLine("UH OH!"); }
        }

        static async Task Main()
        {
            await ParseFile(Console.ReadLine());
            // await ParseFile("/home/KOXXSX/Downloads/list");
        }
    }
}
