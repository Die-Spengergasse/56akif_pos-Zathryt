using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonDemo
{
    class Stundenplan
    {
        public List<Lehrer> Lehrer{ get; set; }
        public List<Gegenstaende> Gegenstaendes { get; set; }
        public List<Zeiten> Zeitens { get; set; }   
    }

    // TODO: Schreiben die benötigten Modelklassen für den Stundenplan.
    class Lehrer
    {
        public string Id { get; set; } = string.Empty;
        public string Zuname { get; set; } = string.Empty;
        public string Vorname { get; set; } = string.Empty;
    }
    class Gegenstaende
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
    class Zeiten
    {
        public string Wochentag { get; set; } = string.Empty;
        public int Stunde { get; set; }
    }

    class Program
    {
        static async Task Main()
        {
            // TODO: Erzeugen Sie eine Instanz von Stundenplan mit Testdaten.
            Stundenplan stdplan = new Stundenplan
            {
                Lehrer = new List<Lehrer>
                {
                    new Lehrer{Id = "MA",Zuname = "Mann",Vorname = "Manfred"},
                    new Lehrer{Id = "MA",Zuname = "Mann",Vorname = "Manfred"}
                },
                Gegenstaendes = new List<Gegenstaende> 
                {
                    new Gegenstaende {},
                    new Gegenstaende {}
                },
                Zeitens= new List<Zeiten> 
                {
                   
                }
            };

            string content = JsonSerializer.Serialize(stdplan, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(content);
            await File.WriteAllTextAsync("stdplan.json", content);
        }
    }
}