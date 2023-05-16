using System;
using System.Collections.Generic;
using System.Text;

namespace pdfreader
{
    using System.Linq;

    /// <summary>
    /// Zelfstandige weergave van een Groep, Gegevenswoordenboek 1.6
    /// </summary>
    public class Groep
    {
        /// <summary>
        /// 
        /// </summary>
        public class Element
        {
            /// <summary>
            /// 
            /// </summary>
            public string Naam { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string Nummer { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public Element()
            {
            }

            public Element(string nummer, string naam)
            {
                this.Nummer = nummer;
                this.Naam = naam;
            }

            public string Write()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"\t\t/// <summary>\r\n");
                sb.Append($"\t\t/// Representeert Elementnummer{Nummer} ({Naam})\r\n");
                sb.Append($"\t\t/// </summary>\r\n");
                sb.Append($"\t\t[JsonProperty(\"{Naam}\")]\r\n");
                sb.Append($"\t\tpublic Element{Nummer} element{Nummer} {{ get; set; }}\r\n\r\n");

                return sb.ToString();
            }
        }

        /// <summary>
        /// Groepnummer
        /// </summary>
        public string Nummer { get; set; }

        /// <summary>
        /// Groepnaam
        /// </summary>
        public string Naam { get; set; }


        /// <summary>
        /// Toelichting
        /// </summary>
        public string Toelichting { get; set; }

        /// <summary>
        /// Elementopsomming
        /// </summary>
        public IList<Element> ElementOpsomming { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static IList<Groep> Groepen = new List<Groep>();


        public Groep(string groepnummer, string groepnaam, string toelichting, string elementen)
        {
            Nummer = groepnummer.Substring(0, 2);
            Naam = groepnaam.Substring(0, groepnaam.IndexOf(' '));
            Toelichting = toelichting.Trim().Replace("\n", "\r\n");
            ElementOpsomming = new List<Element>();


            elementen = elementen.Replace($"-\n", string.Empty);
            //  elementen = elementen.Replace(" \n", " ");
            var _elements = elementen.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var _element in _elements)
            {
                var trimmed = _element.Trim();
                var __element = new Element(trimmed.Substring(0, /*_element*/trimmed.IndexOf(' ')).Replace(".", string.Empty), trimmed.Substring(/*_element*/trimmed.IndexOf(' ')).Trim());
                this.ElementOpsomming.Add(
                new Element
                {
                    Nummer = trimmed.Substring(0, /*_element*/trimmed.IndexOf(' ')).Replace(".", string.Empty),
                    Naam = trimmed.Substring(/*_element*/trimmed.IndexOf(' ')).Trim()
                });
            }

            Groepen.Add(this);
        }

        private string GetElementen()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Element element in ElementOpsomming)
                sb.Append(element.Write());
            return sb.ToString();
        }

        public string Write()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"\t///<summary>\r\n");
            sb.Append($"\t///Representeert Groep{Nummer}({Naam})\r\n");
            sb.Append($"\t///{Toelichting.Replace("\r\n", " ")}\r\n");
            sb.Append($"\t///</summary>\r\n");
            sb.Append("\t[ExcludeFromCodeCoverage]\r\n");
            sb.Append($"\tpublic sealed partial class Groep{Nummer} : Groep\r\n");
            sb.Append($"\t{{\r\n{this.GetElementen()}\r\n");
            sb.Append($"\t}}\r\n");

            var tmp = sb.ToString();
            return tmp.Replace(tmp.Substring(tmp.LastIndexOf($"}}\r\n\r\n\r\n\t}}\r\n")), $"}}\r\n\t}}\r\n\r\n");
        }
    }
}
