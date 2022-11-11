using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testvorbereitung
{
    class Rechteck
    {
        public int Laenge
        {
            get
            {
                return _laenge;
            }
            set
            {
                if (value < 0) throw new ArgumentException("Ungültige Länge");
                else _laenge = value;
            }
        }
        private int _laenge;

        public int Breite
        {
            get
            {
                return _breite;
            }
            set
            {
                if (value < 0) throw new ArgumentException("Ungültige Länge");
                else _breite = value;
            }
        }
        private int _breite;

        public int Flaeche { get { return Laenge * Breite; } }
    }
}
