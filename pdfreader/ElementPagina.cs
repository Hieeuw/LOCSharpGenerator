namespace pdfreader
{
    /// <summary>
    /// Stelt een pagina uit het GBA-gegevenswoordenboek voor
    /// De pagina heeft een vaste opmaak
    /// </summary>
    public class ElementPagina : Pagina
    {


        /// <summary>
        /// 
        /// </summary>
        private string Pagina
        {
            get;
        }

        public int? LandelijkeTabel;

        /// <summary>
        /// Marker. 
        /// </summary>
        private int elementnummer => Pagina.IndexOf("Elementnummer") + "Elementnummer".Length + 1;

        /// <summary>
        /// 
        /// </summary>
        private int elementnaam => Pagina.IndexOf("Elementnaam") + "Elementnaam".Length + 1;

        /// <summary>
        /// 
        /// </summary>
        private int toelichting => Pagina.IndexOf("Toelichting") + "Toelichting".Length + 1;


        /// <summary>
        /// 
        /// </summary>
        private int lengte => Pagina.IndexOf("Lengte") + "Lengte".Length + 1;


        /// <summary>
        /// 
        /// </summary>
        private int type => Pagina.LastIndexOf("Type") + "Type".Length + 1;


        /// <summary>
        /// 
        /// </summary>
        private int standaardwaarde => Pagina.IndexOf("Standaardwaarde");

        /// <summary>
        /// 
        /// </summary>
        private int mogelijkewaarden => Pagina.IndexOf("Mogelijke waarden");

        /// <summary>
        /// 
        /// </summary>
        private int voorwaarden => Pagina.IndexOf("Voorwaarden");

        /// <summary>
        /// constructor
        /// </summary>
        public ElementPagina(string txt)
        {
            Pagina = txt;
        }

        public Element Read()
        {

            var _nummer = Pagina.Substring(elementnummer, elementnaam - elementnummer);
            var _naam = Pagina.Substring(elementnaam, toelichting - elementnaam);
            var _toelichting = Pagina.Substring(toelichting, lengte - toelichting);
            var _landelijkeTabel = _toelichting.IndexOf(" Tabel ") == -1 ?
                null : _toelichting.Substring(_toelichting.IndexOf(" Tabel ") + 7);
            
            if (_landelijkeTabel != null)
                _landelijkeTabel = _landelijkeTabel.Substring(0, _landelijkeTabel.IndexOf(','));

            var _type = Pagina.Substring(type, standaardwaarde - type);
            var _lengte = Pagina.Substring(lengte, type - lengte);


            var _mogelijkewaarden = mogelijkewaarden > -1 ? Pagina.Substring(mogelijkewaarden + "Mogelijke waarden ".Length, voorwaarden - mogelijkewaarden-18) : null;


            return new Element(_nummer, _naam, _toelichting, _lengte, _type, _landelijkeTabel, _mogelijkewaarden);
        }
    }
}
