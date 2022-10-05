

namespace ExProperties
{
    public class Lehrer
    {
        public string Vorname { get; set; } = "";
        public string? Zuname { get; set; }
        public decimal? Bruttogehalt
        {
            get => _bruttogehalt; 
            set { if(_bruttogehalt == null)
                    _bruttogehalt = value;}
        }
        decimal? _bruttogehalt = null;

        public string Kuerzel { get => Zuname?.Substring(0,3).ToUpper()?? ""; }

        public decimal Nettogehalt { get => (Bruttogehalt * 0.8M) ?? 0M; }    
        


    }
}
