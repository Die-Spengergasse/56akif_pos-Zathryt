using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Collections;
using System.Reflection.Emit;
using System.Xml.Schema;

class Klasse 
    {
        // TODO: Erstelle ein Property Schuelers, welches alle Schüler der Klasse in einer
        //       Liste speichert.
        public List<Schueler> Schuelers = new List<Schueler>();
        public string Name { get; set; }
        public string KV { get; set; }
        /// <summary>
        /// Fügt den Schüler zur Liste hinzu und setzt das Property KlasseNavigation
        /// des Schülers korrekt auf die aktuelle Instanz.
        /// </summary>
        /// <param name="s"></param>
        public void AddSchueler(Schueler s)
        {
            // HIER DEN CODE EINFÜGEN
            if(Schuelers.Contains(s) || s.KlasseNavigation != null) return;
            Schuelers.Add(s);
            s.KlasseNavigation = this;
        }

    
    }
    class Schueler : Person
    {
    // TODO: Erstelle ein Proeprty KlasseNavigation vom Typ Klasse, welches auf
    //       die Klasse des Schülers zeigt.
    // Füge dann über das Proeprty die Zeile
    // [JsonIgnore]
    // ein, damit der JSON Serializer das Objekt ausgeben kann.
        [JsonIgnore]
        public Klasse KlasseNavigation { get; set; } = new();
        public int Id { get; set; }
        public string Zuname { get; set; }
        public string Vorname { get; set; }
        /// <summary>
        /// Ändert die Klassenzugehörigkeit, indem der Schüler
        /// aus der alten Klasse, die in KlasseNavigation gespeichert ist, entfernt wird.
        /// Danach wird der Schüler in die neue Klasse mit der korrekten Navigation eingefügt.
        /// </summary>
        /// <param name="k"></param>
        public void ChangeKlasse(Klasse k)
        {
        // HIER DEN CODE EINFÜGEN
        KlasseNavigation.Schuelers.Remove(this);
        k.AddSchueler(this);
        
        }

        
    }
class Person : IComparable<Person>
    {
    public int PersonID { get; set; }

    public int CompareTo(Person? other)
    {
        return this.PersonID.CompareTo(other.PersonID);
    }
}
    


class Program
{
    public static IEnumerable<Schueler> GetPupil()
    {
        yield return new Schueler() { Id = 1001, Vorname = "VN1", Zuname = "ZN1", PersonID = 6 };
        yield return new Schueler() { Id = 1002, Vorname = "VN2", Zuname = "ZN2", PersonID = 5 };
        yield return new Schueler() { Id = 1003, Vorname = "VN3", Zuname = "ZN3", PersonID = 4 };
        yield return new Schueler() { Id = 1011, Vorname = "VN4", Zuname = "ZN4", PersonID = 3 };
        yield return new Schueler() { Id = 1012, Vorname = "VN5", Zuname = "ZN5", PersonID = 2 };
        yield return new Schueler() { Id = 1013, Vorname = "VN6", Zuname = "ZN6", PersonID = 1 };
    }
    static void Main(string[] args)
    {
        Dictionary<string, Klasse> klassen = new Dictionary<string, Klasse>();
        klassen.Add("3AHIF", new Klasse() { Name = "3AHIF", KV = "KV1" });
        klassen.Add("3BHIF", new Klasse() { Name = "3BHIF", KV = "KV2" });
        klassen.Add("3CHIF", new Klasse() { Name = "3CHIF", KV = "KV3" });
        klassen["3AHIF"].Schuelers.Add(new Schueler() { Id = 1022, Vorname = "Bernd", Zuname = "Bernd", PersonID = 7 });
        var schuelerse = GetPupil();
        foreach (Klasse k in klassen.Values)
        {
            foreach (var p in schuelerse.Distinct())
            {
                k.AddSchueler(p);   
            }
        }

        Schueler s = klassen["3AHIF"].Schuelers[0];
        Console.WriteLine($"s sitzt in der Klasse {s.KlasseNavigation.Name} mit dem KV {s.KlasseNavigation.KV}.");
        Console.WriteLine("3AHIF vor ChangeKlasse:");
        Console.WriteLine(JsonConvert.SerializeObject(klassen["3AHIF"].Schuelers));
        s.ChangeKlasse(klassen["3BHIF"]);
        Console.WriteLine("3AHIF nach ChangeKlasse:");
        Console.WriteLine(JsonConvert.SerializeObject(klassen["3AHIF"].Schuelers));
        Console.WriteLine("3BHIF nach ChangeKlasse:");
        Console.WriteLine(JsonConvert.SerializeObject(klassen["3BHIF"].Schuelers));
        Console.WriteLine($"s sitzt in der Klasse {s.KlasseNavigation.Name} mit dem KV {s.KlasseNavigation.KV}.");
        orderBy(klassen["3BHIF"]);
    }
    public static void orderBy(Klasse k)
    {
        var ordered = k.Schuelers.OrderBy(s => s.Id);
        foreach (Schueler s in ordered)
        {
            Console.WriteLine(s.Id);
        }
        
    }
}

