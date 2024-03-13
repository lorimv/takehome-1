namespace ZipCounter;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Concurrent;

static class CsvParser
{
    static ConcurrentDictionary<String, int> zips = new ConcurrentDictionary<string, int>();

    public static void ReadCsv(Stream stream)
    {
        // TODO add id arg? or make the whole class Csv and give it an id var
        try
        {
            using (TextFieldParser parser = new TextFieldParser(stream))
            {
                Console.WriteLine("reading csv...");
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                string[] row;

                if (!parser.EndOfData) { parser.ReadFields(); }
                while (!parser.EndOfData)
                {
                    row = parser.ReadFields()!;
                    if (row.Length > 8) // error when async? (threw System.InvalidOperationException)
                    {
                        zips.AddOrUpdate(row[8], 1, (k, v) => v++);
                    }
                }
                Console.WriteLine("read complete.");
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Stream cannot be read: " + e);
        }
    }

    public static ConcurrentDictionary<String, int> GetZips()
    {
        return zips;
    }
}
