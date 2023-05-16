using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace pdfreader
{
    using Org.BouncyCastle.Bcpg.OpenPgp;

    /// <summary>
    /// 
    /// </summary>
    public class Categorie
    {
        /// <summary>
        /// 
        /// </summary>
        public class Groep
        {
            /// <summary>
            /// 
            /// </summary>
            public string Naam;

            /// <summary>
            /// 
            /// </summary>
            public string Nummer;

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public string Write()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("\t\t/// <summary>\r\n");
                sb.Append($"\t\t/// Representeert Groep {Nummer} ({Naam})\r\n");
                sb.Append("\t\t/// </summary>\r\n");
                sb.Append($"\t\t[JsonProperty(\"{Naam}\")]\r\n");
                //sb.Append($"\t\t[ExcludeFromCodeCoverage]\r\n");
                sb.Append($"\t\tpublic Groep{Nummer} groep{Nummer} {{ get; set; }}\r\n\r\n");

                return sb.ToString();

            }
        }


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
        public string Toelichting { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<Groep> Groepsopsomming { get; set; }

        public bool IsMeerdereKerenActueel { get; set; }

        public bool HeeftHistorie { get; set; }

        private static IDictionary<string, IList<string>> categorieen =
            new Dictionary<string, IList<string>>
            {
                    { "Categorie01", new List<string> { $"xprs = new GBA_XTPRSGEG(processor.Process(processor.repo.GetGBA_TPRSREG(rsysprs)))", $"xnam = new GBA_XTNAMREG(processor.Process(processor.repo.GetGBA_TNAMREG(xprs.RsysNam)).Single())", $"xins = new GBA_XTINSREG(processor.Process(processor.repo.GetGBA_TINSREG(xprs.prs.RSYS_PRS)).Single())" } },
                    { "Categorie02", new List<string> { $"xou1 = new GBA_XTOU1AKT(processor.Process(processor.repo.GetGBA_TOU1AKT(rsysprs)).Single())", $"xnam = new GBA_XTNAMREG(processor.Process(processor.repo.GetGBA_TNAMREG(xou1.ou1.RSYS_NAM)).Single())", $"xprs = new GBA_XTPRSGEG(processor.Process(processor.repo.GetGBA_TPRSGEGBYRSYSNAM(ou1.RSYS_NAM)).Where(p => p.IREG == \"A\").SingleOrDefault())", } },
                    { "Categorie04", new List<string> { $"xnatakt = processor.Process(processor.repo.GetGBA_TNATAKT(rsysprs)).OrderByDescending(n => n.DGLD).ThenByDescending(n => n.DOPN)" } }
            };



        public Categorie(string nummer, string naam, string toelichting, string groepen, string aantalmalenactueel)
        {
            IsMeerdereKerenActueel = aantalmalenactueel.Contains("n");
            var _nummer = nummer.Substring(0, nummer.IndexOf(" "));
            if (_nummer.Contains("/"))
                HeeftHistorie = true;

            Groepsopsomming = new List<Groep>();
            Toelichting = toelichting.Trim();

            Naam = naam.Substring(0, naam.IndexOf(' '));
            Nummer = nummer.Substring(0, 2);

            string grpnum = string.Empty;
            string grpnaam = string.Empty;

            char[] _groepen = groepen.ToCharArray();
            for (int i = 0; i < _groepen.Length; i++)
            {
                char c = _groepen[i];
                if (char.IsDigit(c))
                    grpnum += c;
                if (char.IsLetter(c) || char.IsPunctuation(c))
                    grpnaam += c;

                if (char.IsWhiteSpace(c) && c != '\n')
                {
                    if (!(grpnaam == string.Empty))
                    {
                        if (i < _groepen.Length - 1)
                        {
                            if (!char.IsControl(_groepen[i + 1]))
                                grpnaam += c;
                        }
                    }
                }

                if (char.IsControl(c))
                {
                    Groepsopsomming.Add(new Groep { Naam = grpnaam, Nummer = grpnum });
                    grpnum = string.Empty;
                    grpnaam = string.Empty;
                }


            }
        }

        private string GetGroepen()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Groep grp in Groepsopsomming.Where(g => g.Nummer != "84"))
                sb.Append(grp.Write());
            return sb.ToString();
        }




        public string Write()
        {
            StringBuilder sb = new StringBuilder();

            //  schrijf header
            sb.Append($"\t/// <summary>\r\n");
            sb.Append($"\t/// Representeert Categorie{Nummer}/{Convert.ToInt32(Nummer) + 50} ({Naam})\r\n");
            sb.Append($"\t/// </summary>\r\n");
            sb.Append($"\t[ExcludeFromCodeCoverage]\r\n");
            sb.Append($"\tpublic abstract class Categorie{Nummer}Base : CategorieBase\r\n");
            sb.Append($"\t{{\r\n{this.GetGroepen()}\r\n\t}}\r\n");

            var tmp = sb.ToString();
            return tmp.Replace(tmp.Substring(tmp.LastIndexOf($"}}\r\n\r\n\r\n\t}}\r\n")), $"}}\r\n\t}}\r\n\r\n");
        }

        public string WriteHeeftHist()
        {
            StringBuilder sb = new StringBuilder();

            //  schrijf header
            sb.Append($"\t/// <summary>\r\n");
            sb.Append($"\t/// Representeert Categorie{Nummer} ({Naam})\r\n");
            sb.Append($"\t/// </summary>\r\n");
            sb.Append($"\t[ExcludeFromCodeCoverage]\r\n");
            sb.Append($"\tpublic class Categorie{Nummer} : Categorie{Nummer}Base, IHistorie\r\n");
            sb.Append($"\t{{\r\n");
            sb.Append($"\t\tpublic IList<Categorie{Convert.ToInt32(Nummer) + 50}> Historie {{ get; set; }}\r\n");
            sb.Append($"{_Constructor()}");
            sb.Append($"\t}}\r\n\r\n");
            return sb.ToString();
        }
        
        public string _Constructor()
        {
            if (categorieen.ContainsKey($"Categorie{this.Nummer}"))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"\t\t/// <summary>\r\n");
                sb.Append($"\t\t/// Constructor\r\n");
                sb.Append($"\t\t/// </summary>\r\n");
                sb.Append(this.IsMeerdereKerenActueel ? $"\t\tpublic Categorie{this.Nummer}(params ITransferable[] transferables)\r\n" : $"\t\tpublic Categorie{this.Nummer}(long rsysprs)\r\n");
                sb.Append($"\t\t{{\r\n");

                string s = $"\t\t\tvar groepen = new List<Groep>();";
                if (this.IsMeerdereKerenActueel == false)
                {
                    foreach (var table in categorieen[$"Categorie{this.Nummer}"])
                    {
                        sb.Append($"\t\t\tvar {table};\r\n");
                        s = s.Replace(";", $".Concat({table.Substring(0, table.IndexOf(" ="))}.Groepen);");
                    }

                    sb.Append($"{s}\r\n");
                }
                else
                {
                    sb.Append($"\t\t\t/*transferables are provided IN ORDER by class Categorieën{this.Nummer}!*/\r\n");
                    sb.Append($"{s}\r\n");

                    sb.Append($"\t\t\tfor (int i=0; i<transferables.Length; i++)\r\n\t\t\t{{\r\n\t\t\t\tgroepen = (List<Groep>)groepen.Concat(transferables[i].Groepen);\r\n\t\t\t}}\r\n");
                }

                foreach (var groep in this.Groepsopsomming.Where(g => g.Nummer != "84"))
                    sb.Append($"\t\t\tthis.groep{groep.Nummer} = (Groep{groep.Nummer})groepen.Where(g => g.GetType() == typeof(Groep{groep.Nummer})).SingleOrDefault();\r\n");

                sb.Append($"\t\t}}\r\n");
                return sb.ToString();
            }
            else {return string.Empty;}
        }

        public string WriteZonderHist()
        {
            StringBuilder sb = new StringBuilder();

            //  schrijf header
            sb.Append($"\t/// <summary>\r\n");
            sb.Append($"\t/// Representeert Categorie{Nummer} ({Naam})\r\n");
            sb.Append($"\t/// </summary>\r\n");
            sb.Append($"\t[ExcludeFromCodeCoverage]\r\n");
            sb.Append($"\tpublic class Categorie{Nummer} : Categorie{Nummer}Base\r\n");
            sb.Append($"\t{{\r\n\t}}\r\n\r\n");

            return sb.ToString();
        }

        public string WriteHistCategorieen()
        {
            StringBuilder sb = new StringBuilder();

            //  schrijf header
            sb.Append($"\t/// <summary>\r\n");
            sb.Append($"\t/// Representeert Categorie{Convert.ToInt32(Nummer) + 50} (Historie {Naam})\r\n");
            sb.Append($"\t/// </summary>\r\n");
            sb.Append($"\t[ExcludeFromCodeCoverage]\r\n");
            sb.Append($"\tpublic abstract class Categorie{Convert.ToInt32(Nummer) + 50} : Categorie{Nummer}Base\r\n\t{{\r\n");
            sb.Append($"\t\t/// <summary>\r\n");
            sb.Append($"\t\t/// Representeert Groep 84 (Onjuist)\r\n");
            sb.Append($"\t\t/// </summary>\r\n");
            sb.Append($"\t\t[JsonProperty(\"Onjuist\")]\r\n");

            sb.Append($"\t\tpublic Groep84 groep84 {{ get; set; }}\r\n\t}}\r\n\r\n");
            return sb.ToString();
        }
    }
}
