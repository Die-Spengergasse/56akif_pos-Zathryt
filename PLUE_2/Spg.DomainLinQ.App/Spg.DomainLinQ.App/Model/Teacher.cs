using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Model
{
    /// <summary>
    /// * FirstName
    /// * LastName
    /// * EMail
    /// * Address
    /// * Gender
    /// * Guid
    /// (4P)
    /// </summary>
    public class Teacher : EntityBase
    {
        // TODO: Implementation
        public string Firstname { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Address Address { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
        public Guid Guid { get; set; } = default!;

        private List<Subject> _subjects = new();
        public virtual IReadOnlyList<Subject> Subjects => _subjects;

        protected Teacher()
        {}
        public Teacher(string firstname, string lastName, string email,Gender gender,Guid guid,Address address)
        {
            Firstname = firstname;
            LastName = lastName;
            Email = email;
            Gender = gender;
            Guid = guid;
            Address = address;
        }

        public void AddSubject(Subject subject)
        {
            _subjects.Add(subject);
        }
    }
}
