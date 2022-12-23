using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Zathura.Domain.Model
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Skillset> Skillsets { get; set; } = new();
        protected Class() { }
        public Class(
            int id,
            string name,
            string description
            )
        {
            Id = id;
            Name = name;    
            Description = description;
        }
    }
}
