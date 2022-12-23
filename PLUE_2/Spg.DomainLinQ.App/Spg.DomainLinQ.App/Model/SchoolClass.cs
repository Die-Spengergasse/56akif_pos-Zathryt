using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Model
{
    /// <summary>
    /// * Name
    /// * Department [Die ersten 3 Zeichen von Name]
    /// * Guid
    /// (4P)
    /// </summary>
    public class SchoolClass : EntityBase
    {
        // TODO: Implementation
        public string Name { get; set; } = string.Empty;
        public string Department => Name.Substring(0, 2); 
        public Guid Guid { get; private set; }
        public Teacher Kv { get; set; } = default!;
        private List<Student> _students = new();
        public virtual IReadOnlyList<Student> Students => _students;
        private List<Subject> _subjects = new();
        public virtual IReadOnlyList<Subject> Subjects => _subjects;

        protected SchoolClass()
        { }
        public SchoolClass
            (
            string _name,
            Teacher teacher,
            Guid _guid
            )
        {
            Name = _name;
            Kv= teacher;
            Guid = _guid;
        }
    }
}
