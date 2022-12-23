using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_1.Domain
{
    public class Klasse
    {
        [BsonId]
        public string Id { get; set; } = string.Empty;
        public Lehrer Kv { get; set; } = new();
        public string Abteilung => Id.Substring(2, 3);
        public List<Schueler> Schueler { get; set; } = new();
    }
}
