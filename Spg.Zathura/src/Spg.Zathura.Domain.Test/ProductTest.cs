using Microsoft.EntityFrameworkCore;
using Spg.Zathura.Domain.Model;
using Spg.Zathura.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Zathura.Domain.Test
{
    public class ProductTest
    {
        private ZathuraContext GenerateDb()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite("Data Source=Zathura.db");

            ZathuraContext db = new ZathuraContext(optionsBuilder.Options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            return db;
        }

        [Fact]
        public void Items_Add_OneEntity_SuccessTest()
        {
            //AAA
            //1. Arrange
            ZathuraContext db = GenerateDb();

            Character newChar = new(1, "Peter", 1);
            
            //2. Act
            db.Characters.Add(newChar);
            db.SaveChanges();

            //3. Assert
            //int actual = db.Characters.Count();
            //Assert.Equal(1, actual);
            Assert.True(db.Characters.Contains(newChar));
        }

        [Fact]
        public void SeedDb()
        {
            ZathuraContext db = GenerateDb();
            db.Seed();
            Assert.True(db.Characters.Any(x => x.Id > 1));
        }
    }
}