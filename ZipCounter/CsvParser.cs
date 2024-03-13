namespace ZipCounter;
using Microsoft.VisualBasic.FileIO;

static class CsvParser
{
    static Dictionary<String, int> zips = new Dictionary<string, int>();

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

                while (!parser.EndOfData)
                {
                    // TODO filter out "ZipCode" str
                    row = parser.ReadFields();
                    if (zips.ContainsKey(row[8])) // error when async? (threw System.InvalidOperationException)
                    {
                        zips[row[8]]++;
                    }
                    else
                    {
                        zips.Add(row[8], 1);
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

    public static Dictionary<String, int> GetZips()
    {
        return zips;
    }
}
