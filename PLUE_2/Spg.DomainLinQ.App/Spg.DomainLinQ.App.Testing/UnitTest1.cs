using Microsoft.EntityFrameworkCore;
using Spg.DomainLinQ.App.Infrastructure;
using Spg.DomainLinQ.App.Model;

namespace Spg.DomainLinQ.App.Testing
{
    public class UnitTest1
    {
        private School2000Context GenerateDb()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite("Data Source=./../../../School2000.db");

            School2000Context db = new School2000Context(optionsBuilder.Options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            return db;
        }



        [Fact]
        public void SeedDb()
        {
            School2000Context db = GenerateDb();
            db.Seed();
            Assert.True(true);
        }

     //  [Fact]
     //  public void Student_Add_OneEntity_SuccessTest()
     //  {
     //      //AAA
     //      //1. Arrange
     //      School2000Context db = GenerateDb();
     //
     //      Student newStudent = new(
     //          1,12,"test1","test2","test@testmail.com",Gender.FEMALE,new SchoolClass("test",new Teacher("test","test2","test@test.com",Gender.FEMALE,12,new Address())));
     //
     //      //2. Act
     //      db.Students.Add(newStudent);
     //      db.SaveChanges();
     //
     //      //3. Assert
     //      //int actual = db.Students.Count();
     //      //Assert.Equal(1, actual);
     //      Assert.True(db.Students.Contains(newStudent));
     //  }
    }
}