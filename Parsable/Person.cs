using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsable
{
    public class Person : IParsable<Person>
    {
     

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }


        protected Person()
        {  }

        public Person(string firstName, string lastName, DateTime birthdate)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
        }

        public static Person Parse(string s, IFormatProvider? provider)
        {
            if (s is null)
            {
                throw new ArgumentNullException("Input war NULL!");
            }
            string[] result = s.Split(new char[] {',',';','\t'});
            if (result.Length != 3) throw new ArgumentException("Input muss bestehen aus FirstName, LastName, BirthDate!");
            DateTime birthdate;
            if (!DateTime.TryParse(result[2], out birthdate))throw new FormatException("Geburtsdatum hat falsches Format!");
            return new Person(result[0], result[1], birthdate);
        }

        public static bool TryParse([NotNullWhen(true)] string? s,
            IFormatProvider? provider,
            [MaybeNullWhen(false)] out Person result)
        {
            result = new Person();
            if (s is null)
            {
                return false;
            }
            try
            {
                result = Parse(s, provider);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
