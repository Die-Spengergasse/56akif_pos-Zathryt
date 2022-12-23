using Bogus;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB_1.Domain;
using System.Linq;

var client = new MongoClient("mongodb://localhost:27017");
var database = client.GetDatabase("Stundenplan");

database.DropCollection(nameof(Lehrer));
database.DropCollection(nameof(Klasse));
database.DropCollection(nameof(Schueler));
database.DropCollection(nameof(Pruefung));


Randomizer.Seed = new Random(1337);
var lehrer = new Faker<Lehrer>().Rules((f, l) =>
{
    l.Vorname = f.Name.FirstName();
    l.Zuname = f.Name.LastName();
    l.Id = l.Zuname.Substring(0, 3).ToUpper();
    l.Email = $"{l.Zuname}@spengergasse.at".OrDefault(f, 0.2f);
    l.Lehrbefaehigung = f.Random.Bool();
    l.Gehalt = f.Finance.Amount(1650, 3000);
})
    .Generate(300)
    .GroupBy(l => l.Id)
    .Select(l => l.First())
    .Take(100)
    .ToList();
database.GetCollection<Lehrer>(nameof(Lehrer)).InsertMany(lehrer);

var schueler = new Faker<Schueler>().Rules((f, s) =>
{
    s.Id = f.UniqueIndex;
    s.Gebdat = f.Date.BetweenDateOnly(new DateOnly(1950,01,01), new DateOnly(2000,01,01));
    s.Vorname = f.Name.FirstName();
    s.Zuname = f.Name.LastName();
})
    .Generate(30)
    .Take(10)
    .ToList();
database.GetCollection<Schueler>(nameof(Schueler)).InsertMany(schueler);

var abteilungen = new string[] { "KIF", "AIF", "CIF", "BIF" };
var klassen = new Faker<Klasse>().Rules((f, a) =>
{
    a.Id = f.Random.Int(1, 6) + f.Random.String2(1, "ABCD") + f.Random.ListItem(abteilungen);
    a.Kv = f.Random.ListItem(lehrer.Where(l => l.Lehrbefaehigung is true).ToList());

})
    .Generate(30)
    .GroupBy(k => k.Id)
    .Select(k => k.First())
    .Take(10)
    .ToList();
database.GetCollection<Klasse>(nameof(Klasse)).InsertMany(klassen);

var fach = new string[] { "Mathe", "Deutsch", "Englisch", "Datenbanken", "Programmieren" };
var pruefung = new Faker<Pruefung>().Rules( (f,p) => 
{
    p.Id = f.UniqueIndex;
    p.Datum = f.Date.Between(new DateTime(2022,01,01),new DateTime(2022,12,01));
    p.Fach = f.Random.ListItem(fach);
    p.Pruefer = f.Random.ListItem(lehrer.Where(l=>l.Lehrbefaehigung is true).ToList());
    p.Note = f.Random.Int(1, 5);
    p.Kandidat = f.Random.ListItem(schueler);
})
    .Generate(30)
    .Take(10)
    .ToList();
database.GetCollection<Pruefung>(nameof(Pruefung)).InsertMany(pruefung);


