using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Zathura.Domain.Model
{
    public class Skillset
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Class Owner { get; set; } = default!;
    }
}
