using System.Text;

namespace pdfreader
{
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net.Mime;
    using System.Security.Policy;

    /// <summary>
    /// Landelijke Tabel
    /// </summary>
    public class Tabel
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
            /// Numeriek / Alfanumeriek
            /// </summary>
            public string Type { get; set; }

            public string Lengte { get; set; }

            public System.Type DotNetType
            {
                [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1503:CurlyBracketsMustNotBeOmitted", Justification = "Reviewed. Suppression is OK here.")]
                get
                {
                    if (this.Type == "Alfanumeriek")
                        return typeof(string);
                    var v = Convert.ToInt32(this.Lengte);
                    return v <= 4 ? typeof(short) : v <= 9 ? typeof(int) : typeof(long);
                }
            }


            /// <summary>
            /// 
            /// </summary>
            public Element()
            {

            }

            public Element(string nummer, string naam, string type, string lengte) 
                : this()
            {
                this.Nummer = nummer.Replace(".", string.Empty);
                this.Naam = naam;
                this.Type = type;
                this.Lengte = lengte;
            }

            public string Write()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"\t\t/// <summary>\r\n");
                sb.Append($"\t\t/// Representeert Element{this.Nummer}\r\n");
                sb.Append($"\t\t/// {this.Naam}\r\n");
                sb.Append($"\t\t/// </summary>\r\n");
                sb.Append($"\t\t[JsonProperty(\"Element{this.Nummer}\")]\r\n");
                sb.Append($"\t\tpublic Element{this.Nummer} element{this.Nummer} {{ get; set; }}\r\n\r\n");

                return sb.ToString();
            }

            public string WriteElement()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"\t/// <summary>\r\n");
                sb.Append($"\t/// Representeert Element{this.Nummer} ({this.Naam})\r\n");
                sb.Append($"\t/// </summary>\r\n");
                sb.Append($"\t[ExcludeFromCodeCoverage]\r\n");
                //sb.Append($"\tpublic partial class Element{this.Nummer} : Element<{(this.Type == "Numeriek" ? "int" : "string")}>\r\n");
                sb.Append($"\tpublic partial class Element{this.Nummer} : Element<{(this.Nummer == "9210" ? "string" : this.DotNetType.Name)}>\r\n");  // uitzondering voor 92.10 
                sb.Append($"\t{{\r\n{this.GetConstructor()}\t}}\r\n");

                return sb.ToString();
            }

            private string GetConstructor()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"\t\tpublic Element{this.Nummer}({(this.Nummer == "9210" ? "string" : this.DotNetType.Name)} val)\r\n");
                sb.Append($"\t\t{{\r\n");
                sb.Append($"\t\t\tthis.element = new ElementNummer(\"{this.Nummer}\", \"{this.Naam}\");\r\n");

                string _elementwaarde = $"\t\t\tthis.waarde = new ElementWaarde<{(this.Nummer == "9210" ? "string" : this.DotNetType.Name)}> {{ Waarde = val }};\r\n";
                sb.Append(_elementwaarde);

                sb.Append($"\t\t}}\r\n");

                return sb.ToString();
            }
        }



        /// <summary>
        /// Nummer van de Landelijke Tabel
        /// </summary>
        public string Nummer { get; set; }

        /// <summary>
        /// Naam van de Landelijke Tabel
        /// </summary>
        public string Naam { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string  Toelichting { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string[] Tabelregelelementen { get; set; }

        public IList<Element> ElementOpsomming { get; set; }

        public Tabel(string nummer, string naam, string toelichting, string tabelregelelementen)
        {
            this.Nummer = nummer.Substring(0,nummer.IndexOf('\n')).Trim();
            this.Naam = naam.Substring(0, naam.IndexOf('\n')).Trim();
            this.Toelichting = toelichting.Substring(0, toelichting.LastIndexOf('\n')).Replace('\n', ' ').Trim();
            
            this.Tabelregelelementen = tabelregelelementen.Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries).Where(s => Char.IsDigit(s.Trim()[0]) && s.Trim()[2] == '.' ).ToArray();
            
            var tabelregelelementtypes = tabelregelelementen.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Where(s => !char.IsDigit(s.Trim()[0])).ToArray().Where(t => t.Trim().StartsWith("Numeriek")||t.Trim().StartsWith("Alfanumeriek")).ToArray();
            
            this.ElementOpsomming = new List<Element>();

            for (int i = 0; i < this.Tabelregelelementen.Length; i++)
            {
                // bepaal dotNETType!
                var v = tabelregelelementtypes[i].Trim();
                var type = v.Substring(0, tabelregelelementtypes[i].Trim().IndexOf(' '));
                var posities = v.IndexOf("positie");
                var len = v.Substring(v.IndexOf(' '), posities - v.IndexOf(' ')).Trim();
                if (len.Contains("-"))
                {
                    len = len.Substring(len.IndexOf('-') + 1);
                }

                this.ElementOpsomming.Add(
                    new Element(
                        Tabelregelelementen[i].Trim().Substring(0, "00.00".Length).Trim(),
                        Tabelregelelementen[i].Trim().Substring("00.00 ".Length).Trim(),
                        type:type,
                        //tabelregelelementtypes[i].Trim().Substring(0, tabelregelelementtypes[i].Trim().IndexOf(' '))
                        lengte:len
                        ));
            }
        }

        public string Write()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"\t///<summary>\r\n");
            sb.Append($"\t///Representeert een tabelregel uit Landelijke Tabel{this.Nummer}({this.Naam})\r\n");
            sb.Append($"\t///</summary>\r\n");
            sb.Append("\t[ExcludeFromCodeCoverage]\r\n");
            sb.Append($"\tpublic sealed partial class Tabelregel{Nummer}\r\n");
            sb.Append($"\t{{\r\n{this.GetElementen()}\r\n");
            sb.Append($"\t{this.WriteLtRegelConstructor()}\r\n");
            sb.Append($"\t}}\r\n");
            var tmp = sb.ToString();

            return tmp;
        }

        private string WriteLtRegelConstructor()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"\t\t/// <summary>\r\n");
            sb.Append($"\t\t/// Constructor\r\n");
            sb.Append($"\t\t/// </summary>\r\n");
            sb.Append($"\t\tpublic Tabelregel{this.Nummer}(string rgl)\r\n");
            sb.Append($"\t\t{{\r\n");
            sb.Append($"\t\t\tstring[] columns = rgl.Split(new char[] {{ \'•\' }}, StringSplitOptions.None);\r\n");
            for (int i = 0; i < this.ElementOpsomming.Count; i++)
            {
                var _element = this.ElementOpsomming[i];
                var assignment = _element.Nummer == "9210" ? $"columns[{i}]" : _element.Type == "Numeriek" ? $"System.Convert.To{_element.DotNetType.Name}(columns[{i}])" : $"columns[{i}]";
                sb.Append(
                    $"\t\t\telement{this.ElementOpsomming[i].Nummer} = new Element{this.ElementOpsomming[i].Nummer}({assignment});\r\n");
            }
            sb.Append($"\t\t}}\r\n");

            return sb.ToString();
        }

        public string WriteTabel()
        {
            // Tabel33 wordt anders behandeld!
            var tabelregel =
                $"var tabelregel = new Tabelregel{this.Nummer}(rgl.Replace($\"\\\",\\\"\", \"•\").Replace($\"\\\"\", string.Empty).Replace($\"\\r\", string.Empty).Replace($\"\\n\", string.Empty));";
            
            StringBuilder sb = new StringBuilder();
            sb.Append($"\t/// <summary>\r\n");
            sb.Append($"\t/// Representeert Landelijke Tabel{this.Nummer}, {this.Naam}\r\n");
            sb.Append($"\t/// {this.Toelichting}\r\n");
            sb.Append($"\t/// </summary>\r\n");
            sb.Append("\t[ExcludeFromCodeCoverage]\r\n");
            sb.Append($"\tpublic sealed partial class Tabel{this.Nummer}\r\n");
            sb.Append($"\t{{\r\n");
            var typename = this.Nummer == "33" ? "string" : this.ElementOpsomming.First().DotNetType.Name;
            //sb.Append($"\t\tprivate static IDictionary<{this.ElementOpsomming.First().DotNetType.Name}, Tabelregel{this.Nummer}> Tabelregels {{ get; set; }}\r\n\r\n");
            sb.Append($"\t\tprivate static IDictionary<{typename}, Tabelregel{this.Nummer}> Tabelregels {{ get; set; }}\r\n\r\n");
            sb.Append($"\t\tprivate static readonly Lazy<Tabel{this.Nummer}> lazy = new Lazy<Tabel{this.Nummer}>( () => new Tabel{this.Nummer}() );\r\n\r\n");
            sb.Append($"\t\tpublic static Tabel{this.Nummer} Instance => lazy.Value;\r\n\r\n");
            //sb.Append($"\t\tprivate Tabel{this.Nummer}()\r\n\t\t{{\r\n\t\t\tTabelregels = new Dictionary<{this.ElementOpsomming.First().DotNetType.Name}, Tabelregel{this.Nummer}>();\r\n\t\t\tforeach (var rgl in System.IO.File.ReadLines(@\"csv\\Tabel{this.Nummer}.csv\"))\r\n\t\t\t{{\r\n\t\t\t\t{tabelregel}\r\n\t\t\t\tTabelregels.Add(tabelregel.element{this.ElementOpsomming.First().Nummer}.Waarde, tabelregel);\r\n\t\t\t}}\r\n\t\t}}\r\n\r\n");
            sb.Append($"\t\tprivate Tabel{this.Nummer}()\r\n\t\t{{\r\n\t\t\tTabelregels = new Dictionary<{typename}, Tabelregel{this.Nummer}>();\r\n\t\t\tforeach (var rgl in System.IO.File.ReadLines(@\"csv\\Tabel{this.Nummer}.csv\"))\r\n\t\t\t{{\r\n\t\t\t\t{tabelregel}\r\n\t\t\t\tTabelregels.Add(tabelregel.element{this.ElementOpsomming.First().Nummer}.Waarde, tabelregel);\r\n\t\t\t}}\r\n\t\t}}\r\n\r\n");
            //sb.Append($"\t\tpublic string Omschrijving({this.ElementOpsomming.First().DotNetType.Name} code)\r\n\t\t{{\r\n\t\t\tif (code == null)\r\n\t\t\t\treturn null;\r\n\t\t\tif (Tabelregels.ContainsKey(code))\r\n\t\t\t\treturn Tabelregels[code].Omschrijving;\r\n\t\t\tthrow new TabelregelNotFoundException($\"code {{code}} niet aangetroffen in Tabel{this.Nummer}\");\r\n\t\t}}\r\n\r\n"); // Nullable '?' verwijderd
            sb.Append($"\t\tpublic string Omschrijving({typename} code)\r\n\t\t{{\r\n\t\t\tif (Tabelregels.ContainsKey(code))\r\n\t\t\t\treturn Tabelregels[code].Omschrijving;\r\n\t\t\t{(this.Nummer == "33" ? $"return string.Empty;\r\n" : $"throw new TabelregelNotFoundException($\"code {{code}} niet aangetroffen in Tabel{this.Nummer}\");\r\n" )}\t\t}}\r\n\r\n"); // Nullable '?' verwijderd
            if (this.Nummer == "33")
                sb.Append($"\t\tpublic string Omschrijving(short code) => Omschrijving(code.ToString(\"D4\"));\r\n");
            sb.Append($"\t}}\r\n\r\n");

            return sb.ToString();
        }


        private string GetElementen()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Element element in ElementOpsomming)
                sb.Append(element.Write());


            sb.Append($"\t\t[JsonIgnore]\r\n");
            //sb.Append($"\t\tpublic {(this.ElementOpsomming[0].Type == "Numeriek" ? "int" : "string")} Code => element{this.ElementOpsomming[0].Nummer}.Waarde;\r\n\r\n");
            sb.Append($"\t\tpublic {(this.Nummer == "33" ? "string" : this.ElementOpsomming[0].DotNetType.Name)} Code => element{this.ElementOpsomming[0].Nummer}.Waarde;\r\n\r\n");
            sb.Append($"\t\t[JsonIgnore]\r\n");
            if (this.ElementOpsomming.Count > 1)
                sb.Append($"\t\tpublic string Omschrijving => element{this.ElementOpsomming[1].Nummer}.Waarde;\r\n");
            else
                sb.Append($"\t\tpublic string Omschrijving => element{this.ElementOpsomming[0].Nummer}.Waarde;\r\n");

            return sb.ToString();
        }
    }
}