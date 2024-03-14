namespace ZipCounter;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Concurrent;

static class CsvParser
{
    static ConcurrentDictionary<String, int> zips = new ConcurrentDictionary<string, int>();

    public static void ReadCsv(Stream stream)
    {
        // TODO add id arg? or make the class a Csv object with an id var
        try
        {
            using (TextFieldParser parser = new TextFieldParser(stream))
            {
                Console.WriteLine("reading csv...");
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                string[] row;

                // skip headers (assume ZipCode is always index 8)
                if (!parser.EndOfData) { parser.ReadFields(); }

                while (!parser.EndOfData)
                {
                    row = parser.ReadFields()!; // 99.9% sure this cannot be null
                    if (row.Length > 8) // TODO i think leading 0's are cut?
                    {
                        // add zip & set occurrences to 1, or increment occurrences
                        zips.AddOrUpdate(row[8].PadLeft(5, '0'), 1, (k, v) => v + 1);
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
