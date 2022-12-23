using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Zathura.Domain.Model
{
    public class Character
    {
        public int Id { get; private set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; private set; }
        public User Owner { get; set; } = default!;
        public Class Class { get; set; } = default!;

        private List<Items> _inventory = new();
        public virtual IReadOnlyList<Items> Inventory { get => _inventory; }
        public Items_Slot CharacterSlots { get; set; } = new();

        protected Character()
        { }
        public Character(
            int _id,
            string _name,
            int _level
            
        )
        {
            Id = _id;
            Name = _name;
            Level = _level;
            

        }
    }
}
