using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_1.Domain
{
    public class Lehrer
    {
        [BsonId]
        public string Id { get; set; } = string.Empty;
        public string Vorname { get; set; } = string.Empty;
        public string Zuname { get; set; } = string.Empty;
        public string? Email { get; set; }
        public decimal Gehalt { get; set; }
        public bool Lehrbefaehigung { get; set; }
    }
}
