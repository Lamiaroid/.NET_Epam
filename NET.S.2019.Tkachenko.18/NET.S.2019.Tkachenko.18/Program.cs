using System;

namespace NET.S._2019.Tkachenko._18
{
    class Program
    {
        static void Main(string[] args)
        {
            UrlDataExporter ude = new UrlDataExporter();
            ude.ExportData(System.IO.Directory.GetCurrentDirectory() + "\\TestDoc.txt");

            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}