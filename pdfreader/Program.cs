using System;
using System.Collections.Generic;
using System.IO;
using VHD_Director;
using RaadplegenPLSourceGenerator;

namespace pdfreader
{

    public enum Type
    {
        Numeriek,
        Alfanumeriek
    }


    public class Elements
    {
        public static IDictionary<string, Element> AllElements = new Dictionary<string, Element>();
    }


    public static class Program
    {
        public static void Main(string[] args)
        {
            //LogischOntwerpReader loreader = new LogischOntwerpReader("/Users/peteruilenberg/Downloads/LOGBA3_12.pdf");
            var dir = Environment.CurrentDirectory;
            Console.WriteLine("Generating content from LogischOntwerpBRP4.2.pdf...");
            RaadplegenPLSourceGenerator.LogischOntwerpReader reader = new RaadplegenPLSourceGenerator.LogischOntwerpReader("../../LogischOntwerp/LO/Current/LogischOntwerpBRP4.2.pdf");
            //LogischOntwerpReader lndtabReader = new LogischOntwerpReader("../../LogischOntwerp/Tabel32.pdf");
            //My7Zip.CompressFileLZMA("../../LogischOntwerp/Categorieen/Categorieen.cs", "../../LogischOntwerp/Categorieen/blabla.7z");
            Console.WriteLine("Zipping..");
            My7Zip.CreateZipFolder("../../LogischOntwerp", "../../LogischOntwerp.zip");
            Console.WriteLine("Done!");
 

        }
    }
}
