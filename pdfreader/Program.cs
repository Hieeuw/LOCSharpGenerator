using System;
using System.Collections.Generic;
using System.IO;
using VHD_Director;
using RaadplegenPLSourceGenerator;

namespace pdfreader
{
    using System.Linq;
    using System.Text.RegularExpressions;

    using Org.BouncyCastle.Asn1;

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
        
        //public static string ELEMENT(Match m)
        //{
        //    var s = m.Value;
        //    var _equals = s.IndexOf("= ");
        //    var _open = s.IndexOf('(');

        //    s = s.Substring(0, _equals + 2) + s.Substring(_open + 1) + " == null ? default : " + s.Substring(_equals + 2) + ".Value";
        //    Console.WriteLine($"org {m.Value} of nieuw {s}?");
        //    if (Console.ReadKey().Key == ConsoleKey.N)
        //        return s;
        //    else return m.Value;
        //}

        public static void Main(string[] args)
        {

            //string s = File.ReadAllText(
            //    @"C:\git\repos\BZ\BZ.Pkg.RaadplegenPL\ResourceLayer.Brp\DataModel\Transferables\GBA_XTHUWAKT.cs");
            //var matchcollection = Regex.Matches(s, @"element\d{4} = new Element\d{4}([^\)]{1,})\)").Cast<Match>();
            //s = Regex.Replace(s, @"element\d{4} = new Element\d{4}([^\)]{1,})", new MatchEvaluator(ELEMENT));

            //File.WriteAllText(@"C:\git\repos\BZ\BZ.Pkg.RaadplegenPL\ResourceLayer.Brp\DataModel\Transferables\GBA_XTHUWAKT.cs", s);
            //return;

            var dir = Environment.CurrentDirectory;
            Console.WriteLine("Generating content from LogischOntwerpBRP4.2.pdf...");
            RaadplegenPLSourceGenerator.LogischOntwerpReader reader = new RaadplegenPLSourceGenerator.LogischOntwerpReader("../../LogischOntwerp/LO/Current/LogischOntwerpBRP4.2.pdf");
            Console.WriteLine("Zipping..");
            My7Zip.CreateZipFolder("../../LogischOntwerp", "../../LogischOntwerp.zip");
            Console.WriteLine("Done!");


        }
    }
}
