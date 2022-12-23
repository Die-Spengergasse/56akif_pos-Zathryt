using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace LinqUebung1
{
    /// <summary>
    /// Speichert eine Prüfung eines Schülers.
    /// </summary>
    public class Pruefung
    {
        public string Fach { get; set; }
        public string Pruefer { get; set; }
        public int Note { get; set; }
        public DateTime Datum { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Schueler Schueler { get; set; }
    }
}