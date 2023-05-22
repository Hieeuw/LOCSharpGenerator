﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

using pdfreader;
using pdfreader.pdfreader;

using Path = System.IO.Path;

namespace RaadplegenPLSourceGenerator
{

    public class LogischOntwerpReader
    {

        /// <summary>
        /// </summary>
        private class Versie
        {
            // Properties
            public static string Nummer => "4.2.0";

            public static string Naam => "Logisch Ontwerp BRP";

            public static string Datum => "1 januari 2023";
        }

        // Methods

        /// <summary>
        /// constructor
        /// </summary>
        public LogischOntwerpReader()
        {
            this.Categorieen = new List<Categorie>();
            this.Groepen = new List<Groep>();
            this.Elementen = new List<Element>();
            this.Tabellen = new List<Tabel>();
        }

        public LogischOntwerpReader(string file, string outputDir = @"../../LogischOntwerp")
            : this()
        {
            
            this.File = Path.GetFileName(file);
            this.OutputDir = outputDir;
            this.versie = new Versie();
            PdfReader reader = new PdfReader(file);
            int item = 1;
            while (true)
            {
                if (item > reader.NumberOfPages)
                {
                    break;
                }

                if (this.Pages.Contains(item))
                {
                    string s = PdfTextExtractor.GetTextFromPage(reader, item, new SimpleTextExtractionStrategy());
                    s = Encoding.UTF8.GetString(
                        Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                    this.Read(s);
                    if (item == ((IEnumerable<int>)this.Pages).Max())
                    {
                        break;
                    }
                }

                item++;
            }

            reader.Close();
            Console.WriteLine("Writing content...");
            this.WriteClassesToFiles();
            OutputDir = outputDir;
        }

        public void Read(string paginaInhoud)
        {
            if (paginaInhoud.Contains("Categorienummer"))
            {
                this.Categorieen.Add(new CategoriePagina(paginaInhoud).Read().Single<Categorie>());
            }
            else if (paginaInhoud.Contains("Groepnummer"))
            {
                this.Groepen.Add(new GroepPagina(paginaInhoud).Read().Single<Groep>());
            }
            else if (paginaInhoud.Contains("Elementnummer"))
            {
                this.Elementen.Add(new ElementPagina(paginaInhoud).Read());
            }
            else
            {
                this.Tabellen.Add(new TabelPagina(paginaInhoud).Read());
            }
        }

        public string WriteCategorieen()
        {
            StringBuilder builder = new StringBuilder();
            string[] textArray1 = new string[]
                                      {
                                          "//------------------------------------------------------------------------------\r\n// <auto-generated>\r\n//\x00a0\x00a0\x00a0 This code was generated from a template: ",
                                          Versie.Naam, " ", Versie.Nummer, " ", Versie.Datum,
                                          "\r\n//\r\n//\x00a0\x00a0\x00a0 Manual changes to this file may cause unexpected behavior in your application.\r\n//\x00a0\x00a0\x00a0 Manual changes to this file will be overwritten if the code is regenerated.\r\n// </auto-generated>\r\n//------------------------------------------------------------------------------\r\n"
                                      };
            builder.Append(string.Concat(textArray1));
            builder.Append("using System.Diagnostics.CodeAnalysis;\r\n");
            builder.Append("using Newtonsoft.Json;\r\n\r\n");
            builder.Append(
                "namespace Centric.PIV.Burgerzaken.RaadplegenPL.ResourceLayer.Brp.DomainModel.LogischOntwerp\r\n");
            builder.Append("{\r\n" + this._Categorieen + "}\r\n");
            return builder.ToString();
        }

        public string WriteCategorieenHeeftHist()
        {
            StringBuilder builder = new StringBuilder();
            string[] textArray1 = new string[]
                                      {
                                          "//------------------------------------------------------------------------------\r\n// <auto-generated>\r\n//\x00a0\x00a0\x00a0 This code was generated from a template: ",
                                          Versie.Naam, " ", Versie.Nummer, " ", Versie.Datum,
                                          "\r\n//\r\n//\x00a0\x00a0\x00a0 Manual changes to this file may cause unexpected behavior in your application.\r\n//\x00a0\x00a0\x00a0 Manual changes to this file will be overwritten if the code is regenerated.\r\n// </auto-generated>\r\n//------------------------------------------------------------------------------\r\n"
                                      };
            builder.Append(string.Concat(textArray1));
            builder.Append("using System.Collections.Generic;\r\n");
            builder.Append("using System.Diagnostics.CodeAnalysis;\r\n");
            builder.Append("using System.Linq;\r\n");
            builder.Append("using Centric.PIV.Burgerzaken.RaadplegenPL.ResourceLayer.Brp.DataModel.Transferables;\r\n");
            builder.Append("using Centric.PIV.Burgerzaken.RaadplegenPL.ResourceLayer.Brp.Interfaces;\r\n\r\n");
            builder.Append("namespace Centric.PIV.Burgerzaken.RaadplegenPL.ResourceLayer.Brp.DomainModel.LogischOntwerp\r\n");
            builder.Append("{\r\n" + this._CategorieenHist + "}\r\n");
            return builder.ToString();
        }

        public string WriteCategorieenZonderHist()
        {
            StringBuilder builder = new StringBuilder();
            string[] textArray1 = new string[]
                                      {
                                          "//------------------------------------------------------------------------------\r\n// <auto-generated>\r\n//\x00a0\x00a0\x00a0 This code was generated from a template: ",
                                          Versie.Naam, " ", Versie.Nummer, " ", Versie.Datum,
                                          "\r\n//\r\n//\x00a0\x00a0\x00a0 Manual changes to this file may cause unexpected behavior in your application.\r\n//\x00a0\x00a0\x00a0 Manual changes to this file will be overwritten if the code is regenerated.\r\n// </auto-generated>\r\n//------------------------------------------------------------------------------\r\n"
                                      };
            builder.Append(string.Concat(textArray1));
            builder.Append("using System.Diagnostics.CodeAnalysis;\r\n");
            builder.Append("using Newtonsoft.Json;\r\n\r\n");
            builder.Append(
                "namespace Centric.PIV.Burgerzaken.RaadplegenPL.ResourceLayer.Brp.DomainModel.LogischOntwerp\r\n");
            builder.Append("{\r\n" + this._CategorieenZonderHist + "}\r\n");
            return builder.ToString();
        }

        public void WriteClassesToFiles()
        {
            System.IO.File.WriteAllText(
                Path.Combine(this.OutputDir, "Categorieen", "Categorieen.cs"), this.WriteCategorieen()); // "../../LogischOntwerp/Categorieen/Categorieen.cs", this.WriteCategorieen());
            System.IO.File.WriteAllText(Path.Combine(this.OutputDir, "Groepen", "Groepen.cs"), this.WriteGroepen());
            System.IO.File.WriteAllText(Path.Combine(this.OutputDir, "Elementen", "Elementen.cs"), this.WriteElementen());
            System.IO.File.WriteAllText(Path.Combine(this.OutputDir, "Categorieen", "CategorieenZonderHist.cs"), this.WriteCategorieenZonderHist());
            System.IO.File.WriteAllText(Path.Combine(this.OutputDir, "Categorieen", "CategorieenMetHist.cs"), this.WriteCategorieenHeeftHist());
            System.IO.File.WriteAllText(Path.Combine(this.OutputDir, "Categorieen", "HistorischeCategorieen.cs"), this.WriteHistCategorieen());
            System.IO.File.WriteAllText(Path.Combine(this.OutputDir, "LandelijkeTabellen", "LandelijkeTabelRegels.cs"), this.WriteLTRegels());
            System.IO.File.WriteAllText(Path.Combine(this.OutputDir, "LandelijkeTabellen", "LandelijkeTabelRegelElementen.cs"), this.WriteLTElementen());
            System.IO.File.WriteAllText(Path.Combine(this.OutputDir, "LandelijkeTabellen", "LandelijkeTabellen.cs"), this.WriteLandelijkeTabellen());
        }

        public string WriteElementen()
        {
            StringBuilder builder = new StringBuilder();
            string[] textArray1 = new string[]
                                      {
                                          "//------------------------------------------------------------------------------\r\n// <auto-generated>\r\n//\x00a0\x00a0\x00a0 This code was generated from a template: ",
                                          Versie.Naam, " ", Versie.Nummer, " ", Versie.Datum,
                                          "\r\n//\r\n//\x00a0\x00a0\x00a0 Manual changes to this file may cause unexpected behavior in your application.\r\n//\x00a0\x00a0\x00a0 Manual changes to this file will be overwritten if the code is regenerated.\r\n// </auto-generated>\r\n//------------------------------------------------------------------------------\r\n"
                                      };
            builder.Append(string.Concat(textArray1));
            builder.Append("using System;\r\n");
            builder.Append("using System.Collections.Generic;\r\n");
            builder.Append("using System.Diagnostics.CodeAnalysis;\r\n");
            builder.Append("using Centric.PIV.Burgerzaken.RaadplegenPL.Common.Models;\r\n");
            builder.Append(
                "using Centric.PIV.Burgerzaken.RaadplegenPL.ResourceLayer.Brp.DomainModel.LogischOntwerp.LandelijkeTabellen;\r\n");
            builder.Append("using Newtonsoft.Json;\r\n\r\n");
            builder.Append(
                "namespace Centric.PIV.Burgerzaken.RaadplegenPL.ResourceLayer.Brp.DomainModel.LogischOntwerp\r\n");
            builder.Append("{\r\n" + this._Elementen + "}\r\n");
            string str = builder.ToString();
            return str.Replace(str.Substring(str.LastIndexOf("}\r\n\r\n}\r\n")), "}\r\n}\r\n");
        }

        public string WriteGroepen()
        {
            StringBuilder builder = new StringBuilder();
            string[] textArray1 = new string[]
                                      {
                                          "//------------------------------------------------------------------------------\r\n// <auto-generated>\r\n//\x00a0\x00a0\x00a0 This code was generated from a template: ",
                                          Versie.Naam, " ", Versie.Nummer, " ", Versie.Datum,
                                          "\r\n//\r\n//\x00a0\x00a0\x00a0 Manual changes to this file may cause unexpected behavior in your application.\r\n//\x00a0\x00a0\x00a0 Manual changes to this file will be overwritten if the code is regenerated.\r\n// </auto-generated>\r\n//------------------------------------------------------------------------------\r\n"
                                      };
            builder.Append(string.Concat(textArray1));
            builder.Append("using System.Diagnostics.CodeAnalysis;\r\n");
            builder.Append("using Newtonsoft.Json;\r\n\r\n");
            builder.Append(
                "namespace Centric.PIV.Burgerzaken.RaadplegenPL.ResourceLayer.Brp.DomainModel.LogischOntwerp\r\n");
            builder.Append("{\r\n" + this._Groepen + "\r\n}\r\n");
            return builder.ToString();
        }

        public string WriteHistCategorieen()
        {
            StringBuilder builder = new StringBuilder();
            string[] textArray1 = new string[]
                                      {
                                          "//------------------------------------------------------------------------------\r\n// <auto-generated>\r\n//\x00a0\x00a0\x00a0 This code was generated from a template: ",
                                          Versie.Naam, " ", Versie.Nummer, " ", Versie.Datum,
                                          "\r\n//\r\n//\x00a0\x00a0\x00a0 Manual changes to this file may cause unexpected behavior in your application.\r\n//\x00a0\x00a0\x00a0 Manual changes to this file will be overwritten if the code is regenerated.\r\n// </auto-generated>\r\n//------------------------------------------------------------------------------\r\n"
                                      };
            builder.Append(string.Concat(textArray1));
            builder.Append("using System.Diagnostics.CodeAnalysis;\r\n");
            builder.Append("using Newtonsoft.Json;\r\n\r\n");
            builder.Append(
                "namespace Centric.PIV.Burgerzaken.RaadplegenPL.ResourceLayer.Brp.DomainModel.LogischOntwerp\r\n");
            builder.Append("{\r\n" + this._HistCategorieen + "}\r\n");
            return builder.ToString();
        }

        public string WriteLandelijkeTabellen()
        {
            StringBuilder builder = new StringBuilder();
            string[] textArray1 = new string[]
                                      {
                                          "//------------------------------------------------------------------------------\r\n// <auto-generated>\r\n//\x00a0\x00a0\x00a0 This code was generated from a template: ",
                                          Versie.Naam, " ", Versie.Nummer, " ", Versie.Datum,
                                          "\r\n//\r\n//\x00a0\x00a0\x00a0 Manual changes to this file may cause unexpected behavior in your application.\r\n//\x00a0\x00a0\x00a0 Manual changes to this file will be overwritten if the code is regenerated.\r\n// </auto-generated>\r\n//------------------------------------------------------------------------------\r\n"
                                      };
            builder.Append(string.Concat(textArray1));
            builder.Append("using System;\r\n");
            builder.Append("using System.Collections.Generic;\r\n");
            builder.Append("using System.Diagnostics.CodeAnalysis;\r\n");
            builder.Append("using System.Linq;\r\n");
            builder.Append("using Newtonsoft.Json;\r\n\r\n");
            builder.Append("using Centric.PIV.Burgerzaken.RaadplegenPL.ResourceLayer.Brp.Exceptions;\r\n");
            builder.Append(
                "namespace Centric.PIV.Burgerzaken.RaadplegenPL.ResourceLayer.Brp.DomainModel.LogischOntwerp.LandelijkeTabellen\r\n");
            builder.Append("{\r\n");
            foreach (Tabel tabel in this.Tabellen)
            {
                builder.Append(tabel.WriteTabel());
            }

            builder.Append("}\r\n");
            return builder.ToString();
        }

        public string WriteLTElementen()
        {
            IList<string> list = new List<string>();
            StringBuilder builder = new StringBuilder();
            string[] textArray1 = new string[]
                                      {
                                          "//------------------------------------------------------------------------------\r\n// <auto-generated>\r\n//\x00a0\x00a0\x00a0 This code was generated from a template: ",
                                          Versie.Naam, " ", Versie.Nummer, " ", Versie.Datum,
                                          "\r\n//\r\n//\x00a0\x00a0\x00a0 Manual changes to this file may cause unexpected behavior in your application.\r\n//\x00a0\x00a0\x00a0 Manual changes to this file will be overwritten if the code is regenerated.\r\n// </auto-generated>\r\n//------------------------------------------------------------------------------\r\n"
                                      };
            builder.Append(string.Concat(textArray1));
            builder.Append("using System;\r\n");
            builder.Append("using System.Diagnostics.CodeAnalysis;\r\n");
            builder.Append("using Newtonsoft.Json;\r\n\r\n");
            builder.Append(
                "namespace Centric.PIV.Burgerzaken.RaadplegenPL.ResourceLayer.Brp.DomainModel.LogischOntwerp.LandelijkeTabellen\r\n");
            builder.Append("{\r\n");
            foreach (Tabel tabel in this.Tabellen)
            {
                foreach (Tabel.Element element in tabel.ElementOpsomming)
                {
                    if (!list.Contains(element.Nummer))
                    {
                        builder.Append(element.WriteElement() + "\r\n");
                        list.Add(element.Nummer);
                    }
                }
            }

            builder.Append("}\r\n");
            string str = builder.ToString();
            return str.Replace(str.Substring(str.LastIndexOf("}\r\n\r\n}\r\n")), "}\r\n}\r\n");
        }

        public string WriteLTRegels()
        {
            StringBuilder builder = new StringBuilder();
            string[] textArray1 = new string[]
                                      {
                                          "//------------------------------------------------------------------------------\r\n// <auto-generated>\r\n//\x00a0\x00a0\x00a0 This code was generated from a template: ",
                                          Versie.Naam, " ", Versie.Nummer, " ", Versie.Datum,
                                          "\r\n//\r\n//\x00a0\x00a0\x00a0 Manual changes to this file may cause unexpected behavior in your application.\r\n//\x00a0\x00a0\x00a0 Manual changes to this file will be overwritten if the code is regenerated.\r\n// </auto-generated>\r\n//------------------------------------------------------------------------------\r\n"
                                      };
            builder.Append(string.Concat(textArray1));
            builder.Append("using System;\r\n");
            builder.Append("using System.Diagnostics.CodeAnalysis;\r\n");
            builder.Append("using Newtonsoft.Json;\r\n\r\n");
            builder.Append(
                "namespace Centric.PIV.Burgerzaken.RaadplegenPL.ResourceLayer.Brp.DomainModel.LogischOntwerp.LandelijkeTabellen\r\n");
            builder.Append("{\r\n" + this._Tabellen + "}\r\n");
            return builder.ToString();
        }

        // Properties
        public string File { get; private set; }

        public IList<Categorie> Categorieen { get; private set; }

        public IList<Groep> Groepen { get; private set; }

        public IList<Element> Elementen { get; private set; }

        public IList<Tabel> Tabellen { get; private set; }

        private Versie versie { get; set; }

        public IList<int> Pages
        {
            get
            {
                List<int> list1 = new List<int>();
                list1.Add(0x75);
                list1.Add(0x76);
                list1.Add(0x77);
                list1.Add(120);
                list1.Add(0x79);
                list1.Add(0x7a);
                list1.Add(0x7b);
                list1.Add(0x7c);
                list1.Add(0x7d);
                list1.Add(0x7e);
                list1.Add(0x7f);
                list1.Add(0x80);
                list1.Add(0x81);
                list1.Add(130);
                list1.Add(0x83);
                list1.Add(0x84);
                list1.Add(0x85);
                list1.Add(0x88);
                list1.Add(0x89);
                list1.Add(0x8a);
                list1.Add(0x8b);
                list1.Add(140);
                list1.Add(0x8d);
                list1.Add(0x8e);
                list1.Add(0x8f);
                list1.Add(0x90);
                list1.Add(0x91);
                list1.Add(0x92);
                list1.Add(0x93);
                list1.Add(0x94);
                list1.Add(0x95);
                list1.Add(150);
                list1.Add(0x97);
                list1.Add(0x98);
                list1.Add(0x99);
                list1.Add(0x9a);
                list1.Add(0x9b);
                list1.Add(0x9c);
                list1.Add(0x9d);
                list1.Add(0x9e);
                list1.Add(0x9f);
                list1.Add(160);
                list1.Add(0xa1);
                list1.Add(0xa2);
                list1.Add(0xa3);
                list1.Add(0xa4);
                list1.Add(0xa5);
                list1.Add(0xa6);
                list1.Add(0xa7);
                list1.Add(0xa8);
                list1.Add(0xa9);
                list1.Add(170);
                list1.Add(0xab);
                list1.Add(0xac);
                list1.Add(0xad);
                list1.Add(0xae);
                list1.Add(0xaf);
                list1.Add(0xb0);
                list1.Add(0xb1);
                list1.Add(0xb2);
                list1.Add(0xb3);
                list1.Add(180);
                list1.Add(0xb5);
                list1.Add(0xb6);
                list1.Add(0xb7);
                list1.Add(0xb8);
                list1.Add(0xb9);
                list1.Add(0xba);
                list1.Add(0xbb);
                list1.Add(0xbf);
                list1.Add(0xc0);
                list1.Add(0xc1);
                list1.Add(0xc2);
                list1.Add(0xc3);
                list1.Add(0xc4);
                list1.Add(0xc5);
                list1.Add(0xc6);
                list1.Add(0xc7);
                list1.Add(200);
                list1.Add(0xc9);
                list1.Add(0xca);
                list1.Add(0xcb);
                list1.Add(0xcc);
                list1.Add(0xcd);
                list1.Add(0xce);
                list1.Add(0xcf);
                list1.Add(0xd0);
                list1.Add(0xd1);
                list1.Add(210);
                list1.Add(0xd3);
                list1.Add(0xd4);
                list1.Add(0xd5);
                list1.Add(0xd6);
                list1.Add(0xd7);
                list1.Add(0xd8);
                list1.Add(0xd9);
                list1.Add(0xda);
                list1.Add(0xdb);
                list1.Add(220);
                list1.Add(0xdd);
                list1.Add(0xde);
                list1.Add(0xdf);
                list1.Add(0xe0);
                list1.Add(0xe1);
                list1.Add(0xe2);
                list1.Add(0xe3);
                list1.Add(0xe4);
                list1.Add(0xe5);
                list1.Add(230);
                list1.Add(0xe7);
                list1.Add(0xe8);
                list1.Add(0xe9);
                list1.Add(0xea);
                list1.Add(0xeb);
                list1.Add(0xec);
                list1.Add(0xed);
                list1.Add(0xee);
                list1.Add(0xef);
                list1.Add(240);
                list1.Add(0xf1);
                list1.Add(0xf2);
                list1.Add(0xf3);
                list1.Add(0xf4);
                list1.Add(0xf5);
                list1.Add(0xf6);
                list1.Add(0xf7);
                list1.Add(0xf8);
                list1.Add(0xf9);
                list1.Add(250);
                list1.Add(0xfb);
                list1.Add(0xfc);
                list1.Add(0xfd);
                list1.Add(0xfe);
                list1.Add(0xff);
                list1.Add(0x100);
                list1.Add(0x101);
                list1.Add(0x102);
                list1.Add(0x103);
                list1.Add(260);
                list1.Add(0x105);
                list1.Add(0x106);
                list1.Add(0x107);
                list1.Add(0x108);
                list1.Add(0x109);
                list1.Add(0x10a);
                list1.Add(0x10b);
                list1.Add(0x10c);
                list1.Add(0x10d);
                list1.Add(270);
                list1.Add(0x10f);
                list1.Add(0x110);
                list1.Add(0x111);
                list1.Add(0x112);
                list1.Add(0x113);
                list1.Add(0x114);
                list1.Add(0x115);
                list1.Add(0x116);
                list1.Add(0x117);
                list1.Add(280);
                list1.Add(0x119);
                list1.Add(0x11a);
                list1.Add(0x11b);
                list1.Add(0x11c);
                list1.Add(0x11d);
                list1.Add(0x11e);
                list1.Add(0x11f);
                list1.Add(0x120);
                list1.Add(0x121);
                list1.Add(290);
                list1.Add(0x123);
                list1.Add(0x124);
                list1.Add(0x125);
                list1.Add(0x126);
                list1.Add(0x127);
                list1.Add(0x128);
                list1.Add(0x129);
                list1.Add(0x12b);
                list1.Add(300);
                list1.Add(0x12d);
                list1.Add(0x131);
                list1.Add(0x132);
                list1.Add(0x133);
                list1.Add(0x134);
                list1.Add(0x135);
                list1.Add(310);
                list1.Add(0x137);
                list1.Add(0x138);
                list1.Add(0x13a);
                list1.Add(0x13b);
                return list1;
            }
        }

        private string _Categorieen
        {
            get
            {
                string str = string.Empty;
                foreach (Categorie categorie in this.Categorieen)
                {
                    str = str + categorie.Write();
                }

                foreach (Categorie categorie in this.Categorieen.Where(c => c.IsMeerdereKerenActueel))
                {
                    str += categorie.WriteMeerdereKerenActueel();
                }

                return str;
            }
        }

        
        
        private string _CategorieenHist
        {
            get
            {
                string str = string.Empty;
                /*
                Func<Categorie, bool> predicate = <> c.<> 9__33_0;
                if (<> c.<> 9__33_0 == null)
                {
                    Func<Categorie, bool> local1 = <> c.<> 9__33_0;
                    predicate =  <> c.<> 9__33_0 = c => c.HeeftHistorie;
                }
                */
                //foreach (Categorie categorie in this.Categorieen.Where<Categorie>(predicate))
                foreach (Categorie categorie in this.Categorieen.Where(c => c.HeeftHistorie))
                {
                    str = str + categorie.WriteHeeftHist();
                }

                return str;
            }
        }

        private string _CategorieenZonderHist
        {
            get
            {
                string str = string.Empty;
                /*
                Func<Categorie, bool> predicate = <> c.<> 9__35_0;
                if (<> c.<> 9__35_0 == null)
                {
                    Func<Categorie, bool> local1 = <> c.<> 9__35_0;
                    predicate =  <> c.<> 9__35_0 = c => !c.HeeftHistorie;
                }
                */
                //foreach (Categorie categorie in this.Categorieen.Where<Categorie>(predicate))
                foreach (Categorie categorie in this.Categorieen.Where(c => !c.HeeftHistorie))
                {
                    str = str + categorie.WriteZonderHist();
                }

                return str;
            }
        }

        private string _HistCategorieen
        {
            get
            {
                string str = string.Empty;
                /*
                Func<Categorie, bool> predicate = <> c.<> 9__37_0;
                if (<> c.<> 9__37_0 == null)
                {
                    Func<Categorie, bool> local1 = <> c.<> 9__37_0;
                    predicate =  <> c.<> 9__37_0 = c => c.HeeftHistorie;
                }
                */
                //foreach (Categorie categorie in this.Categorieen.Where<Categorie>(predicate))
                foreach (Categorie categorie in this.Categorieen.Where(c => c.HeeftHistorie))
                {
                    str = str + categorie.WriteHistCategorieen();
                }

                return str;
            }
        }

        private string _Groepen
        {
            get
            {
                string str = string.Empty;
                foreach (Groep groep in this.Groepen)
                {
                    str = str + groep.Write();
                }

                return str;
            }
        }

        private string _Tabellen
        {
            get
            {
                string str = string.Empty;
                foreach (Tabel tabel in this.Tabellen)
                {
                    str = str + tabel.Write();
                }

                return str;
            }
        }

        private string _Elementen
        {
            get
            {
                string str = string.Empty;
                foreach (Element element in this.Elementen)
                {
                    str = str + element.Write();
                }

                return str;
            }
        }


        //    // Nested Types
        //    [Serializable, CompilerGenerated]
        //    private sealed class <>c
        //    {
        //        // Fields
        //        public static readonly LogischOntwerpReader.<>c<>9 = new LogischOntwerpReader.<>c();
        //    public static Func<Categorie, bool> <>9__33_0;
        //        public static Func<Categorie, bool> <>9__35_0;
        //        public static Func<Categorie, bool> <>9__37_0;

        //        // Methods
        //        internal bool <get__CategorieenHist>b__33_0(Categorie c) =>
        //            c.HeeftHistorie;

        //    internal bool <get__CategorieenZonderHist>b__35_0(Categorie c) =>
        //        !c.HeeftHistorie;

        //    internal bool <get__HistCategorieen>b__37_0(Categorie c) =>
        //        c.HeeftHistorie;
        //}

        public string OutputDir = "../../LogischOntwerp";


    }
}





