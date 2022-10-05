
namespace ExProperties
{
    public class Rechteck
    {
        public int Laenge{
            get => _laenge;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Ungültige Länge");
                else
                    _laenge = value;
                    CalculateFlaeche();
            }
        }
        int _laenge;

        public int Breite{
            get => _breite;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Ungültige Länge");
                else
                    _breite = value;
                    CalculateFlaeche ();
            }
        }
        int _breite;
        public int Flaeche { get => _flaeche;}
        int _flaeche;

        private void CalculateFlaeche()
        {
            _flaeche = _breite * _laenge;
        }
    }
}
