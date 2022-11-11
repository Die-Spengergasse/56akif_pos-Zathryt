using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testvorbereitung
{
    class Lehrer
    {
        public string? Zuname { get; set; }
        public string Vorname {get; set; } = string.Empty;

        public decimal? Bruttogehalt
        {
            get
            {
                return _bruttogehalt;
            }
            set
            {
                if (_bruttogehalt == null) _bruttogehalt = value;
            }
        }
        decimal? _bruttogehalt = null;

        public string Kuerzel 
        {
            get => Zuname?[..3].ToUpper()?? String.Empty;
        } 

        public decimal Nettogehalt
        { get
            {
                return (Bruttogehalt * 0.8M) ?? 0;
            }
        }
    }
    
}
