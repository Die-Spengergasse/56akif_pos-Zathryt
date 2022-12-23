using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Zathura.Domain.Model
{
    public class Skills
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Stats { get; set; }
        public int Skill_Level { get; set; }
        public Skillset Belongs_To { get; set; } = new();
    }
}
