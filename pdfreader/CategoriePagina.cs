namespace pdfreader
{
    /// <summary>
    /// Stelt een pagina uit het GBA-gegevenswoordenboek voor
    /// De pagina heeft een vaste opmaak
    /// </summary>
    public class CategoriePagina : Pagina
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
        private int categorienummer => Pagina.IndexOf("Categorienummer") + "Categorienummer".Length + 1;

        /// <summary>
        /// 
        /// </summary>
        private int categorienaam => Pagina.IndexOf("Categorienaam") + "Categorienaam".Length + 1;

        /// <summary>
        /// 
        /// </summary>
        private int toelichting => Pagina.IndexOf("Toelichting") + "Toelichting".Length + 1;

        /// <summary>
        /// 
        /// </summary>
        private int groepsopsomming => Pagina.IndexOf("Groepsopsomming") + "Groepsopsomming".Length + 1;

        /// <summary>
        /// 
        /// </summary>
        private int voorwaarden => Pagina.IndexOf("Voorwaarden");

        /// <summary>
        /// 
        /// </summary>
        private int aantalmalenactueel => Pagina.IndexOf("Aantal malen actueel");

        /// <summary>
        /// constructor
        /// </summary>
        public CategoriePagina(string txt)
        {
            Pagina = txt;
        }

        public Categorie[] Read()
        {
            var _nummer = Pagina.Substring(categorienummer, categorienaam - categorienummer);
            var _naam = Pagina.Substring(categorienaam, toelichting - categorienaam);
            var _toelichting = Pagina.Substring(toelichting, aantalmalenactueel - toelichting);
            var _groepen = Pagina.Substring(groepsopsomming, voorwaarden - groepsopsomming);

            var _aantalmalenactueel = Pagina.Substring(aantalmalenactueel + "Aantal malen actueel".Length, groepsopsomming - aantalmalenactueel);
            _aantalmalenactueel = _aantalmalenactueel.Substring(0, _aantalmalenactueel.IndexOf('\n')).Trim();
            Categorie c = new Categorie(_nummer, _naam, _toelichting, _groepen, _aantalmalenactueel);

            return new Categorie[] { c };
        }
    }
}
