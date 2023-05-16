namespace pdfreader
{

    namespace pdfreader
    {
        /// <summary>
        /// Stelt een pagina uit het GBA-gegevenswoordenboek voor
        /// De pagina heeft een vaste opmaak
        /// </summary>
        public class TabelPagina : Pagina
        {


            /// <summary>
            /// 
            /// </summary>
            private string Pagina
            {
                get;
            }

            /// <summary>
            /// Marker. 
            /// </summary>
            private int tabelnummer => Pagina.IndexOf("Tabelnummer") + "Tabelnummer".Length + 1;

            /// <summary>
            /// 
            /// </summary>
            private int tabelnaam => Pagina.IndexOf("Naam") + "Naam".Length + 1;

            /// <summary>
            /// 
            /// </summary>
            private int toelichting => Pagina.IndexOf("Toelichting") + "Toelichting".Length + 1;

            /// <summary>
            /// 
            /// </summary>
            private int tabelregelelementen => Pagina.IndexOf("Tabelregelelementen") + "Tabelregelelementen".Length + 1;

            private int gebruiktInElement => Pagina.IndexOf("Gebruikt in element");




            /// <summary>
            /// constructor
            /// </summary>
            public TabelPagina(string txt)
            {
                Pagina = txt;
            }

            public Tabel Read()
            {
                var _nummer = Pagina.Substring(tabelnummer, tabelnaam - tabelnummer);
                var _naam = Pagina.Substring(tabelnaam, toelichting - tabelnaam);
                var _toelichting = Pagina.Substring(toelichting, tabelregelelementen - toelichting);

                var _elementen = Pagina.Substring(tabelregelelementen, gebruiktInElement - tabelregelelementen);


                return new Tabel(_nummer, _naam, _toelichting, _elementen);
            }
        }
    }



    /// <summary>
    /// Stelt een pagina uit het GBA-gegevenswoordenboek voor
    /// De pagina heeft een vaste opmaak
    /// </summary>
    public class GroepPagina : Pagina
    {


        /// <summary>
        /// 
        /// </summary>
        private string Pagina
        {
            get;
        }

        /// <summary>
        /// Marker. 
        /// </summary>
        private int groepnummer => Pagina.IndexOf("Groepnummer") + "Groepnummer".Length + 1;

        /// <summary>
        /// 
        /// </summary>
        private int groepnaam => Pagina.IndexOf("Groepnaam") + "Groepnaam".Length + 1;

        /// <summary>
        /// 
        /// </summary>
        private int toelichting => Pagina.IndexOf("Toelichting") + "Toelichting".Length + 1;

        /// <summary>
        /// 
        /// </summary>
        private int elementopsomming => Pagina.IndexOf("Elementopsomming") + "Elementopsomming".Length + 1;

        /// <summary>
        /// 
        /// </summary>
        private int voorwaarden => Pagina.IndexOf("Voorwaarden") == -1 ? Pagina.IndexOf("Gebruik") : Pagina.IndexOf("Voorwaarden");

        /// <summary>
        /// aanpassen!
        /// </summary>
        private int soort
        {
            get
            {
                int algemene = Pagina.IndexOf("Soort Algemene");
                int administratieve = Pagina.IndexOf("Soort Administratieve");
                int technische = Pagina.IndexOf("Soort Technische");

                return algemene + administratieve + technische + 2;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private int gebruik => Pagina.IndexOf("Gebruik");

        /// <summary>
        /// constructor
        /// </summary>
        public GroepPagina(string txt)
        {
            Pagina = txt;
        }

        public Groep[] Read()
        {
            var _nummer = Pagina.Substring(groepnummer, groepnaam - groepnummer);
            var _naam = Pagina.Substring(groepnaam, toelichting - groepnaam);
            var _toelichting = Pagina.Substring(toelichting, soort - toelichting);

            var _elementen = Pagina.Substring(elementopsomming, voorwaarden - elementopsomming);


            return new Groep[] { new Groep(_nummer, _naam, _toelichting, _elementen) };
        }
    }
}
