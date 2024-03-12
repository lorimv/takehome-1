namespace ZipCounter
{
    using System;
    using System.IO;
    using System.Net.Http;

    static class Program
    {
        static readonly HttpClient client = new HttpClient();

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

        // find out why this throws a null type warning
        static async Task ParseFile(String filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader SR = new StreamReader(filePath))
                {
                    String S = SR.ReadLine();
                    while (S != null)
                    {
                        Console.WriteLine(S);
                        Console.WriteLine("Bouta go to Main");
                        //await Downloader(S);
                        await Task.Delay(400);
                        while (true) {Console.Write(".");}
                        S = SR.ReadLine();
                    }
                }
            }
            else { Console.WriteLine("UH OH!"); }
        }

        static async Task Main()
        {
            Console.WriteLine("main;");
            Console.WriteLine("hi");
            Task parsed =  ParseFile("/home/X/Downloads/list");
            Console.WriteLine("Gone 2 main");
            await Task.Delay(900);
            Console.WriteLine("Waited N Main");
            await parsed;

        }
    }
}
