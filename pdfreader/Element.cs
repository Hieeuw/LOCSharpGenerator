using System;
using System.Text;

namespace pdfreader
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Zelfstandige weergave van een Element
    /// </summary>
    public class Element
    {

        public static IList<string> DomeinBlackList = new List<string> { "6410", "7310", "8010" };

        public static IList<string> DomeinPreList = new List<string> { "6110", "7010", "8710" };

        public string Nummer { get; set; }

        public string Naam { get; set; }

        public string Toelichting { get; set; }

        public string Lengte { get; set; }

        public Type Type { get; set; }

        public string LandelijkeTabel { get; set; }

        public bool IsDatum { get; set; }

        public System.Type DotNetType
        {
            [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1503:CurlyBracketsMustNotBeOmitted", Justification = "Reviewed. Suppression is OK here.")]
            get
            {
                if (this.Type == Type.Alfanumeriek)
                    return typeof(string);
                var v = Convert.ToInt32(this.Lengte);
                return v <= 4 ? typeof(short) : v <= 9 ? typeof(int) : typeof(long);
            }
        }

        /// <summary>
        /// Toegestane waarden en bijbehorende omschrijvingen
        /// </summary>
        public IDictionary<string, string> Domein = new Dictionary<string, string>();

        public Element(string elementnummer, string elementnaam, string toelichting, string lengte, string type, string landelijkeTabel, string mogelijkeWaarden)
        {
            Nummer = elementnummer.Substring(0, 5).Replace(".", string.Empty);  // geen scheidingspunt
            Naam = elementnaam.Substring(0, elementnaam.IndexOf('\n')).TrimEnd();
            Toelichting = toelichting.Replace("\n", "\r\n");
            Toelichting = Toelichting.Substring(0, Toelichting.LastIndexOf("\r\n")).TrimEnd().Replace("\r\n", string.Empty);
            Lengte = lengte.Substring(0, lengte.IndexOf('\n')).TrimEnd();
            if (Lengte.Contains('-')) Lengte = Lengte.Substring(Lengte.IndexOf('-') + 1);
            Type = (Type)Enum.Parse(typeof(Type), type.Substring(0, type.IndexOf('\n')));
            LandelijkeTabel = landelijkeTabel;


            if (mogelijkeWaarden.Contains("jjjjmmdd") && this.Lengte == "8")
                IsDatum = true;
            else
            {
                // Elementen op de 'blacklist' krijgen geen Domein!
                if (!DomeinBlackList.Contains(this.Nummer))
                {
                    List<string> lijstVanMogelijkeWaarden;
                    if (DomeinPreList.Contains(this.Nummer))
                    {
                        // Element op de PreList? Dan eerst dit!
                        mogelijkeWaarden = mogelijkeWaarden.Replace("\n", " ");
                        lijstVanMogelijkeWaarden = mogelijkeWaarden
                            .Split(new char[] { ')' }, StringSplitOptions.RemoveEmptyEntries)
                            .Where(s => s.Trim() != string.Empty).Select(
                                s =>
                                    {
                                        s += ')';
                                        return s.Trim();
                                    }).ToList();
                    }
                    else
                    {
                        lijstVanMogelijkeWaarden = mogelijkeWaarden.Split('\n').Where(s => Regex.IsMatch(s, @"\(([^\)]){1,}\)"))
                            .Where(s => s.Trim().EndsWith(")")).ToList();
                    }
                    if (lijstVanMogelijkeWaarden.Any())
                    {
                        for (var i = 0; i < lijstVanMogelijkeWaarden.Count(); i++)
                        {
                            var code = Regex.Match(lijstVanMogelijkeWaarden[i], @"[^(]{1,}");
                            var omschrijving = Regex.Match(lijstVanMogelijkeWaarden[i], @"\((={0,})([\s]{0,})[^)]{1,}");
                            this.Domein.Add(
                                new string(code.Value.Where(char.IsLetterOrDigit).ToArray()),
                                /*this.Source = Regex.Replace(source, @"\s+", " "); // remove all insignificant white-space*/
                                Regex.Replace(new string(omschrijving.Value.Substring(1).Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-' || c == '/' || c == '(' || c == ')').ToArray()).Trim(), @"\s+", " ")
                            );
                        }
                    }
                }

                //List<string> l = new List<string> { "0410", "1010", "6110", "6410", "7010", "8710" };
                //if (l.Contains(Nummer))
                //{
                //    string kopiemogelijkeWaarden;
                //    kopiemogelijkeWaarden = mogelijkeWaarden.Replace("\n", " ");
                //    var split = kopiemogelijkeWaarden.Split(new char[] { ')' }, StringSplitOptions.RemoveEmptyEntries)
                //        .ToList();

                //    var list = split.Where(s => s.Trim() != string.Empty).Select(s => { s += ')'; return s.Trim(); }).ToList();

                //}
                //var mw = mogelijkeWaarden.Split('\n').Where(s => Regex.IsMatch(s, @"\(([^\)]){1,}\)"))
                //    .Where(s => s.Trim().EndsWith(")")).ToList();
                //if (mw.Any())
                //{
                //    for (int i = 0; i < mw.Count(); i++)
                //    {
                //        var code = Regex.Match(mw[i], @"[^(]{1,}");
                //        var omschrijving = Regex.Match(mw[i], @"\((={0,})([\s]{0,})[^)]{1,}");
                //        this.Domein.Add(
                //            new string(code.Value.Where(char.IsLetterOrDigit).ToArray()),
                //            new string(omschrijving.Value.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray()).Trim());
                //    }
                //}
            }

            Elements.AllElements.Add(this.Nummer, this);
        }

        public string ElementType => DotNetType.Name;



        public string ElementLength => /*Lengte.IndexOf('-') > -1 ? "null" : Lengte.Substring(Lengte.IndexOf("-") + 1)*/ this.Lengte;

        public string Write()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"\t/// <summary>\r\n");
            sb.Append($"\t/// Representeert Element{this.Nummer} ({this.Naam})\r\n");
            sb.Append($"\t/// {this.Toelichting}\r\n");
            sb.Append($"\t/// </summary>\r\n");
            sb.Append($"\t[ExcludeFromCodeCoverage]\r\n");
            sb.Append($"\tpublic partial class Element{Nummer} : Element<{ElementType}>\r\n"); // Nullable '?' verwijderd
            sb.Append($"\t{{\r\n");
            if (this.Domein.Any())
            {
                var d = $"\t\tprivate static IDictionary<{this.ElementType}, string> Domein = new Dictionary<{this.ElementType}, string>{{ # }};\r\n\r\n";

                foreach (var kv in this.Domein)
                {
                    var key = this.ElementType == "String" ? $"\"{kv.Key}\"" : $"{kv.Key}";
                    d = d.Replace("#", $"{{ {key}, \"{kv.Value}\" }}, #");
                }
                sb.Append(d.Replace(", #", string.Empty));
            }
            sb.Append($"{this.GetConstructor()}\t}}\r\n\r\n");

            return sb.ToString();


        }

        public string GetConstructor()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"\t\tpublic Element{Nummer}({ElementType} val)\r\n");    // Nullable '?' verwijderd
            sb.Append($"\t\t{{\r\n");
            sb.Append($"\t\t\tthis.element = new ElementNummer(\"{this.Nummer}\", \"{this.Naam}\"/*,len: {this.ElementLength}*/);\r\n");

            string _elementwaarde = $"\t\t\tthis.waarde = new ElementWaarde<{ElementType}> {{ Waarde = val @tab }};\r\n"; // Nullable '?' verwijderd
            _elementwaarde = _elementwaarde.Replace("@tab", this.LandelijkeTabel != null ? $", Omschrijving = Tabel{LandelijkeTabel}.Instance.Omschrijving(val)" : this.Domein.Any() ? $", Omschrijving = Domein[val]" : this.IsDatum ? $", Omschrijving = DatumFormatter.Format(val/*, \"dd-mm-jjjj\"*/)" : null);
            sb.Append(_elementwaarde);

            sb.Append($"\t\t}}\r\n");

            return sb.ToString();
        }
    }
}
