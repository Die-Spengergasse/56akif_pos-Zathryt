using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB_1.Domain
{
    public class Schueler
    {
        public DateOnly Gebdat { get; set; }
        [BsonId]
        public int Id { get; set; }
        public string Vorname { get; set; } = string.Empty;
        public string Zuname { get; set; } = string.Empty;
    }
}
