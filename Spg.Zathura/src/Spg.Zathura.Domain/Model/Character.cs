using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Zathura.Domain.Model
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public User Owner { get; set; } = new User();
        public Class Class { get; set; } = new Class();
        public List<Items> Inventory { get; set; } = new List<Items>();
    }
}
