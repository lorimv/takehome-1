namespace ZipCounter;

static class UriHandler
{
    static readonly HttpClient client = new HttpClient();

    // null type warning, bc SR.ReadLine will assign null to S?
    public static async Task ParseFile(String filePath)
    {
        if (File.Exists(filePath))
        {
            List<Task> csvStreams = new List<Task>();
            using (StreamReader SR = new StreamReader(filePath))
            {
                String uri = SR.ReadLine();
                while (uri != null)
                {
                    Console.WriteLine(uri);
                    csvStreams.Add(FetchCsv(uri));
                    uri = SR.ReadLine();
                }
                await Task.WhenAll(csvStreams);
            }
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }

    static async Task FetchCsv(String uri)
    {
        try
        {
            using HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Connected.");
            using (var stream = await client.GetStreamAsync(uri))
            {
                // call a function to parse the stream
                // (demo fn)
                CsvParser.ReadCsv(stream);
                // using var SR = new StreamReader(stream);
                // Console.WriteLine(SR.ReadLine());
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("Connection error: " + e);
        }
    }
}
