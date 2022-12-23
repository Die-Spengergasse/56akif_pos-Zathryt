using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Model
{
    /// <summary>
    /// * Description
    /// (4P)
    /// </summary>
    public class Subject : EntityBase
    {
        // TODO: Implementation
        public string Description { get; set; } = string.Empty;
        public SchoolClass SchoolClass { get; set; } = default!;

        private List<Student> _students = new();
        public virtual IReadOnlyList<Student> Students => _students;
        public Teacher Teacher { get; set; } = default!;
        private List<Exam> _exams = new();
        public virtual IReadOnlyList<Exam> Exams => _exams;

        protected Subject() { }
        public Subject(
            string _description,
            SchoolClass schoolClass
            ) 
        {
            Description = _description;
            SchoolClass = schoolClass;
        }
    }
}
