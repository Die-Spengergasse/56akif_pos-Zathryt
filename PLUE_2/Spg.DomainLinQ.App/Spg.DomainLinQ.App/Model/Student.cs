using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Model
{
    /// <summary>
    /// * RegistrationNumber
    /// * FirstName
    /// * LastName
    /// * EMail
    /// * Address
    /// * PhoneNumber
    /// * AccountName = [Die ersten 5 Stellen des LastName + RegistrationNumber]
    /// * Gender
    /// * Guid
    /// (4P)s
    /// </summary>
    public class Student : EntityBase
    {
        // TODO: Implementation
        public int RegistrationNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Address Address { get; set; } = default!; 
        public PhoneNumber PhoneNumber { get; set; } = default!;
        public string AccountName => LastName[..4] + RegistrationNumber;
        public Gender Gender { get; set; } = default!;
        public Guid Guid { get; set; } = default!;
        public SchoolClass SchoolClass { get; set; } = default!;

        private List<Subject> _subjects = new();
        public virtual IReadOnlyList<Subject> Subjects => _subjects;

        protected Student()
        {}
        public Student(int registrationNumber, Guid guid,string firstName, string lastName, string email,Gender gender,SchoolClass schoolClass,Address address,PhoneNumber phoneNumber)
        {
            RegistrationNumber = registrationNumber;
            Guid = guid;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
            SchoolClass= schoolClass;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public void AddSubjects(List<Subject> subjects)
        {
            _subjects.AddRange(subjects);
        }
    }
}
