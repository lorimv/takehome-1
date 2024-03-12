namespace ZipCounter
{
    using System;
    using System.IO;

    static class Program
    {
        // find out why this throws a null type warning
        static void ParseFile(String filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader SR = new StreamReader(filePath))
                {
                    String S = SR.ReadLine();
                    while (S != null)
                    {
                        Console.WriteLine(S);
                        S = SR.ReadLine();
                    }
                }
            }
            else { Console.WriteLine("UH OH!"); }
        }

        static void Main()
        {
            Console.WriteLine("main;");
            Console.WriteLine("hi");
            ParseFile("/home/XXXXXXXXXX/Downloads/list");
        }
    }
}
