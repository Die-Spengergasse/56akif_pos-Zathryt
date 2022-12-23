// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Pipes;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

/*
namespace JsonDemo
{
    // TODO: Schreiben Sie Ihre Modelklassen, die das Dokument stundenplan.json abbilden können.
    class Klasse
    {
        public string Id { get; set; } = string.Empty;
        public Lehrer Kv { get; set; } = new();
        public List<Lehrer> Lehrer { get; set; } = new();

    }
    class Lehrer
    {
        public string Id { get; set; } = string.Empty;
        public string Zuname { get; set; } = string.Empty;
        public string Vorname { get; set; } = string.Empty;
    
        public List<Gegenstaende> Gegenstaende { get; set; } = new();
     

    }
    class Gegenstaende 
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<Zeiten> Zeiten { get; set; } =new();
       

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
            // Wichtig: Bei Copy to Output Directory muss im Solution Explorer bei stundenplan.json
            //          die Option Copy Always gesetzt werden-
            using var filestream = new FileStream("stundenplan.json", FileMode.Open, FileAccess.Read);

            // Liest das Dokument in die Variable stdplan ein. Da es ein Array ist, wird hier auch
            // ein Array erstellt.
            Klasse[]? stdplan = await JsonSerializer.DeserializeAsync<Klasse[]>(filestream);
            Console.WriteLine($"Es wurden {stdplan?.Length} Klassen geladen.");

            // TODO: Geben Sie alle Lehrer (ID, Vorname, Zuname) der Schule aus.
            // TODO: Geben Sie alle Gegenstände (ID, Name) der Schule aus.
      
            stdplan?
                .SelectMany(k=>k.Lehrer)
                .DistinctBy(l=>l.Id).ToList()
                .ForEach(l=> Console.WriteLine($"{l.Id} {l.Vorname} {l.Zuname}"));

            stdplan?
                .SelectMany(k => k.Lehrer)
                .SelectMany(l => l.Gegenstaende)
                .DistinctBy(g => g.Id).ToList()
                .ForEach(g => Console.WriteLine($"{g.Id} {g.Name}"));

        }
    }
}
*/