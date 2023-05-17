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
                    { "Categorie01", new List<string> { $"xPrs = new GBA_XTPRSGEG(processor.Process(processor.repo.GetGBA_TPRSGEG(rsysPrs)).Single())", $"xNam = new GBA_XTNAMREG(processor.Process(processor.repo.GetGBA_TNAMREG(xPrs.RsysNam)).Single())" } },
                    { "Categorie02", new List<string> { $"xOu1 = new GBA_XTOU1AKT(processor.Process(processor.repo.GetGBA_TOU1AKT(rsysPrs)).Single())", $"xNam = new GBA_XTNAMREG(processor.Process(processor.repo.GetGBA_TNAMREG(rsysPrs)).Single())" } },
                    { "Categorie03", new List<string> { $"xOu2 = new GBA_XTOU2AKT(processor.Process(processor.repo.GetGBA_TOU2AKT(rsysPrs)).Single())", $"xNam = new GBA_XTNAMREG(processor.Process(processor.repo.GetGBA_TNAMREG(rsysPrs)).Single())" } },
                    { "Categorie04", new List<string> { $"xNatAkt = processor.Process(processor.repo.GetGBA_TNATAKT(rsysPrs)).OrderByDescending(n => n.DGLD).ThenByDescending(n => n.DOPN)" } },
                    { "Categorieen04", new List<string> { $"processor.Process(processor.repo.GetGBA_TNATAKT(rsysPrs)).OrderByDescending(n => n.DGLD).ThenByDescending(n => n.DOPN)", "GBA_XTNATAKT"} },
                    { "Categorieen05", new List<string> { $"processor.Process(QMagazijn.GetTHUWAKT(rsysprs)).OrderByDescending(huw => huw.DGLD).ThenByDescending(huw => huw.DOPN).ThenBy(huw => huw.RVLG_HW)", "GBA_XTHUWAKT" } },
                    { "Categorie06", new List<string> { $"xOvlAkt = new GBA_XTOVLAKT(processor.Process(processor.repo.GetGBA_TOVLAKT(rsysPrs)).Single())" } },
                    { "Categorie07", new List<string> { $"xOvlAkt = new GBA_XTOVLAKT(processor.Process(processor.repo.GetGBA_TOVLAKT(rsysPrs)).Single())" } }
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

        public string WriteMeerdereKerenActueel()
        {
            StringBuilder sb = new StringBuilder();

            // hier genereren van dit:
            /*
            public class Categorieen04 : CategorieBase
            {
                public IList<Categorie04> Categorieen = new List<Categorie04>();

                /// <summary>
                /// Constructor Categorieen04 
                /// </summary>
                public Categorieen04(long rsysPrs)
                {
                    var natAktList = processor.Process(processor.repo.GetGBA_TNATAKT(rsysPrs)).OrderByDescending(n => n.DGLD)
                        .ThenByDescending(n => n.DOPN);

                    foreach (var natAkt in natAktList)
                    {
                        var _categorie04 = new Categorie04(new GBA_XTNATAKT(natAkt));
                        this.Categorieen.Add(_categorie04);
                    }
                }
            }
            */
            if (!categorieen.ContainsKey($"Categorieen{Nummer}"))
                return string.Empty;
            
            //var action = categorieen[$"Categorieen{this.Nummer}"].Single();

            sb.Append($"\t/// <summary>\r\n");
            sb.Append($"\t/// Representeert een lijst van Categorie{Nummer}-instanties ({Naam})\r\n");
            sb.Append($"\t/// </summary>\r\n");
            sb.Append($"\t[ExcludeFromCodeCoverage]\r\n");
            sb.Append($"\tpublic class Categorieen{Nummer} : CategorieBase\r\n");
            sb.Append($"\t{{\r\n");
            sb.Append($"\t\tpublic IList<Categorie{Nummer}> Categorieen = new List<Categorie{Nummer}>();\r\n");
            sb.Append($"\r\n");
            sb.Append($"\t\tpublic Categorieen{Nummer}(long rsysPrs)\r\n");
            sb.Append($"\t\t{{\r\n");
            sb.Append($"\t\t\tvar xList = {(categorieen[$"Categorieen{this.Nummer}"].First())};\r\n");
            sb.Append($"\t\t\tforeach (var x in xList)\r\n");
            sb.Append($"\t\t\t{{\r\n");
            sb.Append($"\t\t\t\tvar categorie{Nummer} = new Categorie{Nummer}(new {(categorieen[$"Categorieen{this.Nummer}"].Last())}(x));\r\n");
            sb.Append($"\t\t\t\tthis.Categorieen.Add(categorie{Nummer});\r\n");
            sb.Append($"\t\t\t}}\r\n");
            sb.Append($"\t\t}}\r\n");
            sb.Append($"\t}}\r\n");

            return sb.ToString();
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
            sb.Append($"\t\tpublic IList<Categorie{Convert.ToInt32(Nummer) + 50}> Historie {{ get; set; }}\r\n\r\n");
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
                sb.Append($"\t\t/// Constructor Categorie{Nummer} \r\n");
                sb.Append($"\t\t/// </summary>\r\n");
                sb.Append(this.IsMeerdereKerenActueel ? $"\t\tpublic Categorie{this.Nummer}(params ITransferable[] transferables)\r\n" : $"\t\tpublic Categorie{this.Nummer}(long rsysPrs)\r\n");
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
                sb.Append($"\r\n");

                foreach (var groep in this.Groepsopsomming.Where(g => g.Nummer != "84"))
                    sb.Append($"\t\t\tgroep{groep.Nummer} = (Groep{groep.Nummer})groepen.SingleOrDefault(g => g is Groep{groep.Nummer});\r\n");

                sb.Append($"\t\t}}\r\n");
                return sb.ToString();
            }
            else { return string.Empty; }
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
