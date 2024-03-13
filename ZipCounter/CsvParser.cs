namespace ZipCounter;
using Microsoft.VisualBasic.FileIO;

static class CsvParser
{
    // we'll have a static dict or something to count zip codes
    static int zips = 0;

    public static void ReadCsv(Stream stream)
    {
        using (TextFieldParser parser = new TextFieldParser(stream))
        {
            Console.WriteLine("reading csv...");
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {
                // TODO add counting logic
                parser.ReadFields();
            }
        }
    }

    public static int GetZips()
    {
        return zips;
    }
}
