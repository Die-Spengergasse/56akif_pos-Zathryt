using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB_1.Domain
{
    public class Pruefung
    {
        public DateTime Datum { get; set; }
        public string Fach { get; set; } = string.Empty;
        [BsonId]
        public int Id { get; set; }
        public int Note {
            get => _note; 
            set 
            {
                if(value >=1 || value<=5)
                {
                    _note = value;
                }
                else { _note = -1; }
            }}
        private int _note;
        public Lehrer Pruefer { get; set; } = new();
        public Schueler Kandidat { get; set; } = new();
    }
}
