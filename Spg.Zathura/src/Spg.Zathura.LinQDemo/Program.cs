
using Microsoft.EntityFrameworkCore;
using Spg.Zathura.Domain.Model;
using Spg.Zathura.Infrastructure;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
optionsBuilder.UseSqlite("Data Source=Zathura.db");

ZathuraContext db = new(optionsBuilder.Options);
db.Database.EnsureDeleted();
db.Database.EnsureCreated();
db.Seed();

//Alle Character deren Vorname mit M beginnt
List<Character> result01 = db.Characters.Where(x => x.Name.StartsWith("A")).ToList();
db.Characters.ToList().ForEach(x => Console.WriteLine($"Name: {x.Name} Level: {x.Level} Owner: {x.Owner.First_Name} Class: {x.Class} Inventory: {x.Inventory}" ));

Console.Read();

