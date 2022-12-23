using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Spg.Zathura.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace Spg.Zathura.Infrastructure
{
    //1. Diese Klasse muss von DBContext ableiten
    public class ZathuraContext : DbContext
    {
        //2. Die Tabellen der DB als Properties auflisten 
        public DbSet<User> Users => Set<User>();
        public DbSet<Items> Items => Set<Items>();
        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Skills> Skills => Set<Skills>();
        public DbSet<Class> Classes => Set<Class>();
        public DbSet<Skillset> Skillsets => Set<Skillset>();
        public DbSet<Items_Slot> ItemSlots => Set<Items_Slot>();

        //3. Constructor
        public ZathuraContext()
        { }

        public ZathuraContext(DbContextOptions options)
            : base(options)
        { }

        //4. Konfiguration vor DB Erstellung
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Aktiviert das Loggen von beispielsweise SQL statements bei Datenbank Erstellung
            //optionsBuilder.UseLoggerFactory(new LoggerFactory());
            //Needs ConnectionString
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source = Zathura.db");
            }
        }
        //5. Optionen während DB Erstellung
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ToTable ändert Tabellennamen. Default = Name der Klasse: Character -> Characters
            //modelBuilder.Entity<Items>().ToTable("Sneed"); 
            //modelBuilder.Entity<Items>().HasKey(p => p.Name);
            //modelBuilder.Entity<Items>().Property(p => p.Name).IsRequired();
            //modelBuilder.Entity<User>().Property(p => p.First_Name);
            //modelBuilder.Entity<Character>().Property(p => p.Name);
            modelBuilder.Entity<Items_Slot>().HasKey(x => x.SlotID);
            modelBuilder.Entity<Items_Slot>().Property(x => x.SlotID).IsRequired();
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Id).IsRequired();
            modelBuilder.Entity<Class>().HasKey(x => x.Id);
            modelBuilder.Entity<Class>().Property(x => x.Id).IsRequired();
            modelBuilder.Entity<Character>().HasKey(x => x.Id);
            modelBuilder.Entity<Character>().Property(x => x.Id).IsRequired();
            //modelBuilder.Entity<Character>().OwnsOne(x => x.Owner);
            //modelBuilder.Entity<Character>().OwnsOne(x => x.Class);
            //modelBuilder.Entity<Class>().Property(p => p.Name);
            //.HasMany bei n:m beziehung (Ist meistens eine Liste in der Klasse) (Überflüssig da OR Mapper das schon macht ;))

            //Value Object
            //modelBuilder.Entity<Items>().OwnsOne(i => i.Name);
        }
        public void Seed()
        {
            Randomizer.Seed = new Random(1337);
            
            List<User> users = new Faker<User>().CustomInstantiator(f =>
                new User(
                    f.Random.Int(),
                    f.Name.FirstName(),
                    f.Name.LastName(),
                    f.Internet.Email(),
                    f.Date.Between(DateTime.Now.AddYears(-60), DateTime.Now.AddYears(-16)),
                    f.Date.Between(DateTime.Now.AddYears(-50), DateTime.Now.AddDays(-2)),
                    f.Random.Enum<Gender>()
                )) 
                    .Generate(30)
                    .ToList();
                    Users.AddRange(users);
                    SaveChanges();

            List<Character> characters = new Faker<Character>().CustomInstantiator(f =>
            new Character(
                    f.Random.Int(),
                    f.Name.FirstName(Bogus.DataSets.Name.Gender.Male),
                    f.Random.Number(1, 60)
            ))
             .Rules((f,c) =>
             {
                 //c.Owner = f.Random.ListItem(users);
                 c.Owner = new Faker<User>().CustomInstantiator(f => new User
                     (
                      f.Random.Int(),
                    f.Name.FirstName(),
                    f.Name.LastName(),
                    f.Internet.Email(),
                    f.Date.Between(DateTime.Now.AddYears(-60), DateTime.Now.AddYears(-16)),
                    f.Date.Between(DateTime.Now.AddYears(-50), DateTime.Now.AddDays(-2)),
                    f.Random.Enum<Gender>()
                     ));
                 c.Class = new Faker<Class>().CustomInstantiator(f => new Class
                     (
                        f.Random.Int(),
                        f.Name.JobTitle(),
                        f.Hacker.Adjective()
                     ));
             })
            .Generate(30)
            .ToList();
            Characters.AddRange(characters);
            SaveChanges();
        }
    }   
}
