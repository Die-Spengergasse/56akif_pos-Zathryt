using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Model
{
    /// <summary>
    /// * Date (?)
    /// * Lesson (int?)
    /// * Created
    /// * Guid
    /// * Grade (Note 1-5)
    /// (4P)
    /// </summary>
    public class Exam : EntityBase
    {
        // TODO: Implementation
        public DateTime? Date { get; set; }
        public int? Lesson { get; set; }
        public DateTime Created { get; set; }
        public Guid Guid { get; set; } = default!;
        public int Grade { get => _grade; set { if (value <= 5 && value >= 1) _grade = value; } }
        private int _grade = -1;
        public Subject SubjectNavigation { get; set; } = default!;

        protected Exam()
        {}
        public Exam(Guid guid,DateTime? date, int? lesson, int grade,Subject subjectNavigation, DateTime created)
        {
            Guid = guid;
            Date = date;
            Grade = grade;
            Lesson = lesson;
            SubjectNavigation = subjectNavigation;
            Created = created;
        }
    }
}
